#!/usr/bin/env python3
# 260618Cl (ReciPro tools より PDIndexer へ移植 260625Cl): 多言語化の "resx text-only" ガード。
#
# 目的: 新言語 (de/fr/es/pt/it/ru/zh-Hans/zh-Hant/ko) の culture resx を「文字列だけ」に保つ。
#       VS デザイナは Localizable=true のとき Language を (Default) 以外で保存すると Size/Location/Font を
#       culture resx へ焼き込む。これを退行とみなし検出/自動除去する。新言語は neutral レイアウトへフォールバック。
#
#   判定は ALLOWLIST (文字列プロパティだけ残す)。--fix で違反 <data>/<metadata> を除去 (utf-8-bom + crlf 保証)。
#   使い分け: CI=検出して exit 1 / pre-commit・手動=--fix で自動修復。
#
# 使い方:
#   python tools/check_resx_textonly.py                 # 既定言語を検査 (違反あれば exit 1)
#   python tools/check_resx_textonly.py --lang de        # 独語のみ
#   python tools/check_resx_textonly.py --root <dir>     # 走査ルート指定 (PDIndexer 自前フォームだけ見るなら PDIndexer\PDIndexer)
#   python tools/check_resx_textonly.py --fix            # 違反ブロック除去 + ja Font 正規化を書き戻す
# 終了コード: 0=違反なし or --fix成功 / 1=違反あり(検出モード) or 修復不能なエラー

import argparse
import codecs
import glob
import os
import re
import sys
import xml.etree.ElementTree as ET

try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

_THIS = os.path.dirname(os.path.abspath(__file__))
_REPO_ROOT = os.path.dirname(_THIS)
DEFAULT_ROOTS = [
    os.path.join(_REPO_ROOT, "PDIndexer"),            # PDIndexer 自前フォーム
    os.path.join(_REPO_ROOT, "Crystallography.Controls"),  # 共有 lib (submodule)。通常は別リポで検証済
]

# 検査対象言語を中央 allow-list (Crystallography/.../SupportedCultures.cs) から自動導出。
# 260625Cl: L10n→Localization リネーム後はフォルダ再編で Localization\ 配下にあるので両パスを試す。
_SC_CANDIDATES = [
    os.path.join(_REPO_ROOT, "Crystallography", "Localization", "SupportedCultures.cs"),
    os.path.join(_REPO_ROOT, "Crystallography", "SupportedCultures.cs"),
]
_FALLBACK_LANGS = ["ja", "de", "fr", "es", "pt", "it", "ru", "zh-Hans", "zh-Hant", "ko"]


def _load_supported_cultures():
    """SupportedCultures.cs の `new("xx", …)` から culture 名を抽出 (en 除外)。失敗時は _FALLBACK_LANGS。"""
    for cs in _SC_CANDIDATES:
        try:
            text = open(cs, encoding="utf-8-sig").read()
            names = [n for n in re.findall(r'new\(\s*"([^"]+)"', text) if n.lower() != "en"]
            if names:
                return names
        except Exception:
            continue
    return _FALLBACK_LANGS


DEFAULT_NEW_LANGS = _load_supported_cultures()

# ja.resx の Font 正規化 (ja だけ Font を text-only から例外的に残す → UiFont.Resolve(ja) 相当へ正規化)。
sys.path.insert(0, _THIS)
from snap_neutral_font_tiers import tier_of, fmt_pt, UI_BODY_FAMILIES  # noqa: E402

JA_FAMILY = "Yu Gothic UI"

_FONT_VALUE_RE = re.compile(r"^\s*([^,]+?)\s*,\s*([0-9.]+)pt(.*)$", re.DOTALL)


def normalize_ja_font_value(value: str) -> str:
    m = _FONT_VALUE_RE.match(value)
    if not m:
        return value
    family, pt, rest = m.group(1).strip(), float(m.group(2)), m.group(3)
    if family not in UI_BODY_FAMILIES:
        return value
    new_pt = tier_of(pt)[1]
    return f"{JA_FAMILY}, {fmt_pt(new_pt)}pt{rest}"


_VALUE_BODY_RE = re.compile(r"(<value[^>]*>)(.*?)(</value>)", re.DOTALL)


def normalize_ja_font_block(block: str) -> str:
    return _VALUE_BODY_RE.sub(
        lambda v: v.group(1) + normalize_ja_font_value(v.group(2)) + v.group(3), block, count=1
    )

# ── ALLOWLIST: culture resx に残してよい「ローカライズ対象の文字列」プロパティ ───────────────
KEEP_EXACT = {
    "Text",
    "HeaderText", "FooterText",
    "AccessibleName", "AccessibleDescription",
}
KEEP_SUFFIXED_RE = re.compile(r"^(?:Items|ToolTip|ToolTipText)\d*$")


def prop_of(name: str) -> str:
    return name.rsplit(".", 1)[-1] if "." in name else name


def keep_data(name: str, ja_font: bool = False) -> bool:
    if not name or name.startswith(">>"):
        return False
    p = prop_of(name)
    if ja_font and p == "Font":
        return True
    return p in KEEP_EXACT or KEEP_SUFFIXED_RE.match(p) is not None


def scan_resx(path: str, ja_font: bool = False):
    try:
        root = ET.parse(path).getroot()
    except ET.ParseError as e:
        return [("<parse-error>", str(e), "error")]
    bad = []
    for data in root.findall("data"):
        name = data.get("name", "")
        if not name:
            continue
        if not keep_data(name, ja_font):
            bad.append((name, prop_of(name), "data"))
        elif ja_font and prop_of(name) == "Font":
            cur = (data.findtext("value") or "")
            if cur != normalize_ja_font_value(cur):
                bad.append((name, prop_of(name), "font-not-normalized"))
    for meta in root.findall("metadata"):
        name = meta.get("name", "")
        if name:
            bad.append((name, prop_of(name), "metadata"))
    return bad


_BLOCK_RE = re.compile(
    r"[ \t]*<(data|metadata)\b[^>]*(?:/>|>.*?</\1>)[ \t]*\r?\n",
    re.DOTALL,
)
_NAME_RE = re.compile(r'\bname="([^"]*)"')


def fix_text(text: str, ja_font: bool = False):
    removed = []
    normalized = []

    def repl(m):
        block = m.group(0)
        nm = _NAME_RE.search(block)
        name = nm.group(1) if nm else ""
        tag = m.group(1)
        if tag == "data" and keep_data(name, ja_font):
            if ja_font and prop_of(name) == "Font":
                new_block = normalize_ja_font_block(block)
                if new_block != block:
                    normalized.append(name)
                return new_block
            return block
        removed.append((name, prop_of(name)))
        return ""

    new_text = _BLOCK_RE.sub(repl, text)
    return new_text, removed, normalized


def fix_file(path: str, ja_font: bool = False):
    raw = open(path, "rb").read()
    text = raw.decode("utf-8-sig")
    new_text, removed, normalized = fix_text(text, ja_font)
    if not removed and not normalized and new_text == text:
        return [], [], None
    try:
        ET.fromstring(new_text)
    except ET.ParseError as e:
        return removed, normalized, f"結果が不正 XML になるため書込中止: {e}"
    new_text = new_text.replace("\r\n", "\n").replace("\n", "\r\n")
    open(path, "wb").write(codecs.BOM_UTF8 + new_text.encode("utf-8"))
    return removed, normalized, None


def main() -> int:
    ap = argparse.ArgumentParser(description="新言語 culture resx を text-only に保つ (検出 / --fix 修復)。")
    ap.add_argument("--lang", action="append", help="言語コード (複数可)。既定: " + ",".join(DEFAULT_NEW_LANGS))
    ap.add_argument("--root", action="append", help="走査ルート (複数可)。既定: PDIndexer + Crystallography.Controls")
    ap.add_argument("--include-ja", action="store_true", help="ja も対象に含める")
    ap.add_argument("--fix", action="store_true", help="違反ブロックを除去して書き戻す (utf-8-bom + crlf)")
    args = ap.parse_args()

    langs = args.lang or list(DEFAULT_NEW_LANGS)
    if args.include_ja and "ja" not in langs:
        langs.append("ja")
    roots = [r for r in (args.root or DEFAULT_ROOTS) if os.path.isdir(r)]

    pairs = {}
    for root in roots:
        for lang in langs:
            for p in glob.glob(os.path.join(root, "**", f"*.{lang}.resx"), recursive=True):
                pairs[os.path.normpath(p)] = (lang == "ja")
    files = sorted(pairs)

    langs_disp = ",".join(langs)

    if args.fix:
        total_removed = 0
        total_normalized = 0
        errors = 0
        for path in files:
            removed, normalized, err = fix_file(path, pairs[path])
            rel = os.path.relpath(path)
            if err:
                print(f"ERROR {rel}: {err}")
                errors += 1
                continue
            if removed or normalized:
                total_removed += len(removed)
                total_normalized += len(normalized)
                print(f"FIXED {rel}  ({len(removed)} 項目除去, {len(normalized)} Font 正規化)")
                for name, prop in removed:
                    print(f"    removed: {name}  (.{prop})")
                for name in normalized:
                    print(f"    normalized font: {name}")
        print(f"\nfixed {len(files)} culture resx ({langs_disp}); "
              f"{total_removed} 項目除去, {total_normalized} Font 正規化, {errors} エラー.")
        return 1 if errors else 0

    total_violations = 0
    for path in files:
        bad = scan_resx(path, pairs[path])
        if bad:
            total_violations += len(bad)
            rel = os.path.relpath(path)
            print(f"FAIL {rel}")
            for name, prop, kind in bad:
                label = "font-not-normalized" if kind == "font-not-normalized" else "non-text entry"
                print(f"    {label}: {name}  (.{prop})")

    print(f"\nscanned {len(files)} culture resx ({langs_disp}); {total_violations} violation(s).")
    if total_violations:
        print("culture resx は文字列 (.Text/.ToolTip/.HeaderText/.Items 等) のみにすること "
              "(レイアウトは neutral へフォールバック)。`--fix` で自動修復できる。")
        return 1
    print("OK: culture resx は規約どおり (他言語=text-only / ja=text+正規化 Font)。")
    return 0


if __name__ == "__main__":
    sys.exit(main())
