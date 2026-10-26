#!/usr/bin/env python3
# 260618Cl: ja.resx の Font を neutral から同期する (B案 = ja は「デザイナ=実行時」一致のため Font を持つ)。
#
# 方針(作者決定): ja の .Font = 「neutral の .Font を family だけ Yu Gothic UI へ差し替えたもの」
#   (size は neutral がティア正規化済みなので不変、役割フォント=Times/Courier/Symbol/Tahoma 等は不変)。
#   = UiFont.Resolve(font, culture=ja, Win) を neutral 各フォントに適用した値。これにより:
#     ・ja .Font キー == neutral .Font キー(完全ミラー)→ neutral にあって ja に無い穴が無い
#       (穴があるとそのコントロールは ja デザイナで Segoe にフォールバック → 実行時 Yu Gothic とズレる)。
#     ・$this.Font も含むので ambient 継承コントロールも Yu Gothic で一致。
#     ・値が Yu Gothic+ティア(Resolve の不動点)なので、デザイナ表示 == 実行時描画(UiFont は no-op)。
#   テキスト(.Text/.ToolTip*/.Items*/.HeaderText…)は作業ツリーの ja をそのまま土台にして 1 文字も変えない。
#
# フック安全: 土台は「作業ツリーの ja.resx から Font/レイアウト/メタを除いた text-only」(HEAD ではなく
#   作業ツリー基準 = コミット予定の内容・編集途中の翻訳を尊重)。Font だけ neutral から(再)生成して注入する。
#   → コミットの度に走らせれば「neutral にあって ja に無い Font」を埋め、designer==runtime を恒常的に保証。
#
# 変更検出は <data> の意味的集合 (name→value) で行う(並び順/空白差では書き換えない=churn 最小・idempotent)。
#
# 使い方:
#   python tools/restore_ja_fonts.py            # --check: 未同期を列挙 (あれば exit 1, CI 用)
#   python tools/restore_ja_fonts.py --fix      # 同期して書き戻す (utf-8 BOM + CRLF)

import argparse
import codecs
import os
import subprocess
import sys
import xml.etree.ElementTree as ET

sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
import check_resx_textonly as crt  # noqa: E402

try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

_THIS = os.path.dirname(os.path.abspath(__file__))
_REPO = os.path.dirname(_THIS)

FONT_TYPE = "System.Drawing.Font, System.Drawing"


def git(*args) -> str:
    return subprocess.run(["git", "-C", _REPO, *args], check=True,
                          stdout=subprocess.PIPE).stdout.decode("utf-8-sig")


def list_ja_resx():
    out = git("ls-files", "*.ja.resx")
    return [p for p in out.replace("\r\n", "\n").split("\n") if p]


def neutral_path_of(ja_gitpath: str) -> str:
    return ja_gitpath[: -len(".ja.resx")] + ".resx"


def font_entries(text: str):
    """text 内の .Font <data> を [(name, value)] で返す (順序保持)。"""
    out = []
    for d in ET.fromstring(text).findall("data"):
        name = d.get("name", "")
        if name.endswith(".Font"):
            out.append((name, d.findtext("value") or ""))
    return out


def data_map(text: str, want_font=None):
    """<data> を {name: value} で返す。want_font=None: 全部 / True: .Font のみ / False: .Font 以外。"""
    out = {}
    for d in ET.fromstring(text).findall("data"):
        name = d.get("name", "")
        if not name:
            continue
        is_font = name.endswith(".Font")
        if want_font is None or is_font == want_font:
            out[name] = d.findtext("value") or ""
    return out


def build_font_block(name: str, value: str) -> str:
    # resx の Font data ブロック。type 属性が無いと文字列扱いになり Font 復元に失敗するので必須。
    return (f'  <data name="{name}" type="{FONT_TYPE}">\r\n'
            f"    <value>{value}</value>\r\n"
            f"  </data>\r\n")


def make_ja_text(text_base: str, neutral_fonts) -> str:
    """text_base (text-only ja) の </root> 直前に、neutral 由来の正規化 Font ブロックを挿入する。"""
    blocks = "".join(build_font_block(name, crt.normalize_ja_font_value(val))
                     for name, val in neutral_fonts)
    idx = text_base.rfind("</root>")
    if idx < 0:
        raise ValueError("</root> が見つからない")
    return text_base[:idx] + blocks + text_base[idx:]


def sync_one(gitpath: str):
    """戻り値: (new_text, changed, n_fonts, error)。changed=意味的に現行と差があるか。"""
    disk = os.path.join(_REPO, gitpath)
    ja_text = open(disk, "rb").read().decode("utf-8-sig")

    # 土台 = 作業ツリー ja から Font/レイアウト/メタを除いた text-only。
    text_base, _, _ = crt.fix_text(ja_text, ja_font=False)

    npath = os.path.join(_REPO, neutral_path_of(gitpath))
    neutral_fonts = []
    if os.path.exists(npath):
        neutral_fonts = font_entries(open(npath, "rb").read().decode("utf-8-sig"))

    new_text = make_ja_text(text_base, neutral_fonts)

    try:
        ET.fromstring(new_text)
    except ET.ParseError as e:
        return None, False, 0, f"生成結果が不正 XML: {e}"

    # 安全: テキスト(Font 以外)が作業ツリーと一致すること(テキスト退行ゼロ)。
    if data_map(new_text, want_font=False) != data_map(ja_text, want_font=False):
        return None, False, 0, "テキスト退行検出 (Font 以外が作業ツリーと不一致)"

    changed = data_map(new_text) != data_map(ja_text)  # 並び順でなく意味集合で判定
    return new_text, changed, len(neutral_fonts), None


def main() -> int:
    ap = argparse.ArgumentParser(description="ja.resx の Font を neutral から同期する (designer==runtime 保証)。")
    ap.add_argument("--fix", action="store_true", help="同期して書き戻す (既定は --check)")
    args = ap.parse_args()

    files = list_ja_resx()
    changed_files = errors = total_font = 0

    for gitpath in files:
        new_text, changed, nfonts, err = sync_one(gitpath)
        rel = os.path.relpath(os.path.join(_REPO, gitpath), _REPO)
        if err:
            print(f"FAIL {rel}: {err}")
            errors += 1
            continue
        total_font += nfonts
        if not changed:
            continue
        changed_files += 1
        print(f"{'SYNC ' if args.fix else 'STALE'} {rel}  (Font {nfonts} = neutral ミラー)")
        if args.fix:
            out = new_text.replace("\r\n", "\n").replace("\n", "\r\n")
            open(os.path.join(_REPO, gitpath), "wb").write(codecs.BOM_UTF8 + out.encode("utf-8"))

    verb = "synced" if args.fix else "checked"
    print(f"\n{verb} {len(files)} ja.resx; {changed_files} {'同期' if args.fix else '未同期'}, "
          f"{total_font} Font(累計), {errors} エラー.")
    if errors:
        return 1
    if not args.fix and changed_files:
        print("ja.resx の Font が neutral と未同期 (neutral にあって ja に無い/値違いの Font)。"
              "`python tools/restore_ja_fonts.py --fix` で同期できる。"
              "これが揃わないと該当コントロールはデザイナ(日本語)で Segoe 表示になり実行時とズレる。")
        return 1
    return 0


if __name__ == "__main__":
    sys.exit(main())
