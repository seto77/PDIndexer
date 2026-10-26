#!/usr/bin/env python3
# 260617Cl 追加 / 260618Cl 全面改訂: 多言語化方針 Phase 0 の "resx text-only" ガード。
#
# 目的: 新言語 (de/fr/es/pt/zh-Hans 等) の culture resx を「文字列だけ」に保つ。
#       VS デザイナは Localizable=true のとき、Language ドロップダウンを (Default) 以外にして
#       編集/保存すると Size/Location/Font 等のレイアウトを culture resx へ焼き込む。これを
#       「言語ごとにレイアウトを焼き直す保守地獄」への退行とみなし、検出/自動除去する。
#       新言語はすべて neutral(base) レイアウトへフォールバックさせる方針。
#
# 260618Cl 改訂点:
#   (1) 判定を denylist(禁止プロパティ列挙) から ALLOWLIST(文字列プロパティだけ残す) へ格上げ。
#       デザイナが将来吐く新種プロパティ(Visible/RightToLeft 等)も取りこぼさず text-only に収束する。
#   (2) --fix を追加。違反 <data>/<metadata> ブロックを除去して書き戻す (utf-8-bom + crlf 保証)。
#       消した項目は必ずログ出力する (Image/Icon など想定外のものを黙って落とさないため)。
#   使い分け: CI=検出して exit 1 (大声で叫ぶ診断価値を残す) / pre-commit・手動=--fix で自動修復。
#       ビルド時サイレント strip はしない (壊れたワークフローが見えなくなる + 作業ツリー churn)。
#
# 対象: 既定で ReciPro リポと共有ライブラリ Crystallography.Controls の *.{lang}.resx。
#       260618Cl: ReciPro 本体・Controls とも ja.resx を text-only 化したので ja も既定スコープへ
#       格上げ (DEFAULT_NEW_LANGS に ja)。--include-ja は後方互換の no-op として残す。
#       neutral(.resx, 言語サフィックス無し) は対象外 = レイアウトの正本なので触らない。
#
# 260618Cl ja 例外: 作者要望で ja だけは Font を残す (日本語ネイティブがデザイナ=実行時を一致させたい)。
#   ただし Size/Location 等のレイアウトは他言語同様に除去し、残す Font の値は UiFont.Resolve(ja) 相当へ
#   正規化する = 本文フォント family→Yu Gothic UI・size→5 段階ティアへ離散化 (役割フォント/Style は不変)。
#   他言語 (de/fr/es/pt/zh-Hans …) は従来どおり完全 text-only (Font も除去)。
#
# 使い方:
#   python tools/check_resx_textonly.py                 # 既定言語を検査 (違反あれば exit 1)
#   python tools/check_resx_textonly.py --lang de        # 独語のみ
#   python tools/check_resx_textonly.py --fix            # 違反ブロック除去 + ja Font 正規化を書き戻す
#   python tools/check_resx_textonly.py --include-ja --fix  # (後方互換) ja も対象に含める
# 終了コード: 0=違反なし or --fix成功 / 1=違反あり(検出モード) or 修復不能なエラー

import argparse
import codecs
import glob
import os
import re
import sys
import xml.etree.ElementTree as ET

# Windows コンソール (cp932) でも日本語メッセージが文字化けしないよう UTF-8 出力に固定。
try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

_THIS = os.path.dirname(os.path.abspath(__file__))
_RECIPRO_ROOT = os.path.dirname(_THIS)
# 260726Cl: 走査ルートは ReciPro リポだけでよい。Crystallography.Controls は submodule として
#   ReciPro/Crystallography.Controls に居るので、再帰 glob が既に拾っている。
#   旧コードは更に ../Crystallography.Controls/Crystallography.Controls (junction 時代の名残の別クローン) も
#   対象にしていたが、submodule 移行後は HEAD が別物の無関係な作業ツリーであり、
#   pre-commit フックの --fix がそこを黙って書き換えてしまう (コミットにも入らない) ため外す。
# 旧: os.path.normpath(os.path.join(_RECIPRO_ROOT, "..", "Crystallography.Controls", "Crystallography.Controls"))
DEFAULT_ROOTS = [_RECIPRO_ROOT]

# 260618Cl 全面改訂: 検査対象言語を中央 allow-list (Crystallography/SupportedCultures.cs) から自動導出する。
#   従来は de/fr/es/pt/zh-Hans/ja をハードコードしており、後から SupportedCultures へ追加した
#   it/ru/zh-Hant/ko の culture resx を CI が検査せず取りこぼしていた (多言語化 §11.4 step1)。
#   SupportedCultures.All を唯一の真実とし、このスクリプトを手で更新しなくても言語追加へ追従する。
#   ja も対象 (ReciPro 本体・Controls とも ja.resx を text-only 化済。--include-ja は後方互換の no-op)。
#   en は neutral(culture resx 無し)なので除外。パース失敗時のみ _FALLBACK_LANGS。
# 旧: DEFAULT_NEW_LANGS = ["de", "fr", "es", "pt", "zh-Hans", "ja"]
# 260726Cl: SupportedCultures.cs は Localization/ 配下へ移動済み (L10n.cs→Localization/ 改名時)。
#   旧パスのままだったため「中央 allow-list から自動導出」が常に失敗し、静かに _FALLBACK_LANGS で
#   動いていた (今の 10 言語と一致するので実害は出ていなかったが、12 言語目を足しても検査対象に
#   入らない)。両方を探して最初に見つかったものを使う。
_SUPPORTED_CULTURES_CANDIDATES = [
    os.path.join(_RECIPRO_ROOT, "Crystallography", "Localization", "SupportedCultures.cs"),
    os.path.join(_RECIPRO_ROOT, "Crystallography", "SupportedCultures.cs"),  # 旧配置
]
_SUPPORTED_CULTURES_CS = next((p for p in _SUPPORTED_CULTURES_CANDIDATES if os.path.isfile(p)),
                              _SUPPORTED_CULTURES_CANDIDATES[0])
_FALLBACK_LANGS = ["ja", "de", "fr", "es", "pt", "it", "ru", "zh-Hans", "zh-Hant", "ko"]


def _load_supported_cultures():
    """SupportedCultures.cs の `new("xx", …)` から culture 名を抽出 (en 除外)。失敗時は _FALLBACK_LANGS。"""
    try:
        text = open(_SUPPORTED_CULTURES_CS, encoding="utf-8-sig").read()
        names = [n for n in re.findall(r'new\(\s*"([^"]+)"', text) if n.lower() != "en"]
        return names or _FALLBACK_LANGS
    except Exception:
        return _FALLBACK_LANGS


DEFAULT_NEW_LANGS = _load_supported_cultures()

# 260618Cl 追加: ja.resx のフォント正規化 (作者要望「日本語はデザイナ=実行時を一致させたい」)。
#   ja だけは Font を text-only から例外的に残す。ただし生の pt/family のままでは実行時 UiFont と
#   ズレる (デザイナは生 pt を表示、実行時は family swap + ティア丸め)。そこで残す Font 値を
#   UiFont.Resolve(culture=ja) と同値へ正規化する = 本文フォント family→Yu Gothic UI・size→ティア離散化。
#   役割フォント(Times/Courier/Segoe UI Symbol/Tahoma 等)・Style(Bold/Italic) は不変。
#   → デザイナ(Language=日本語)表示が実行時描画と一致し、かつ runtime 挙動は不変
#     (InitializeComponent が解決済値を適用→UiFont は no-op で同一インスタンス返却)。
# tier_of/fmt_pt/UI_BODY_FAMILIES は snap_neutral_font_tiers.py と共有 (どちらも UiFont.cs と一致させる)。
sys.path.insert(0, _THIS)
from snap_neutral_font_tiers import tier_of, fmt_pt, UI_BODY_FAMILIES  # noqa: E402

JA_FAMILY = "Yu Gothic UI"  # SupportedCultures ja の FontFamily と一致させること

# Font 値 "Family, Npt[, style=...]" を分解する。
_FONT_VALUE_RE = re.compile(r"^\s*([^,]+?)\s*,\s*([0-9.]+)pt(.*)$", re.DOTALL)


def normalize_ja_font_value(value: str) -> str:
    """ja の Font 値を UiFont.Resolve(culture=ja) 相当へ正規化する。
    本文フォントのみ family→Yu Gothic UI・size→ティア離散化。役割フォント/Style は不変。"""
    m = _FONT_VALUE_RE.match(value)
    if not m:
        return value  # pt を持たない想定外の値は触らない
    family, pt, rest = m.group(1).strip(), float(m.group(2)), m.group(3)
    if family not in UI_BODY_FAMILIES:
        return value  # 役割フォントは言語軸・サイズ軸とも不変 (実行時も無変更)
    new_pt = tier_of(pt)[1]
    return f"{JA_FAMILY}, {fmt_pt(new_pt)}pt{rest}"


# data ブロック内 <value>...</value> の中身だけ差し替えるための正規表現。
_VALUE_BODY_RE = re.compile(r"(<value[^>]*>)(.*?)(</value>)", re.DOTALL)


def normalize_ja_font_block(block: str) -> str:
    """ja の .Font <data> ブロックの <value> 本文を正規化して返す。"""
    return _VALUE_BODY_RE.sub(
        lambda v: v.group(1) + normalize_ja_font_value(v.group(2)) + v.group(3), block, count=1
    )

# ── ALLOWLIST: culture resx に残してよい「ローカライズ対象の文字列」プロパティ ───────────────
# これ以外の <data> と、すべての <metadata> ボディ要素 (>>階層メタ/トレイ部品等) は除去する。
# <resheader>/<assembly>/<xsd:schema>/<root> は構造なので常に保持 (除去対象は data/metadata のみ)。
KEEP_EXACT = {
    "Text",
    "HeaderText", "FooterText",          # DataGridView 列 / 自作 MiniTable 等の見出し・脚注
    "AccessibleName", "AccessibleDescription",
}
# 260618Cl 改訂: 末尾に連番が付き得るローカライズ文字列プロパティをまとめて許可する。
#   - Items, Items1, Items2 …  : ComboBox/ListBox の項目 (1コントロールに複数値)。
#   - ToolTip, ToolTip1, …     : NumericBox/ColorControl は [Localizable] string ToolTip を持つが、
#     配置先フォームの ToolTip 拡張子 ("ToolTip on toolTip1") と名前衝突するため、resx 上は
#     "ToolTip1" と番号付きで直列化される (NumericBox.cs:156 のコメント参照)。旧 allowlist は
#     素の "ToolTip" しか持たず、この "ToolTip1" を取りこぼして日本語ツールチップを削除していた。
# 旧: KEEP_ITEMS_RE = re.compile(r"Items\d*$")  (Items のみ。ToolTip1 を保護できなかった)
KEEP_SUFFIXED_RE = re.compile(r"^(?:Items|ToolTip|ToolTipText)\d*$")


def prop_of(name: str) -> str:
    return name.rsplit(".", 1)[-1] if "." in name else name


def keep_data(name: str, ja_font: bool = False) -> bool:
    """この <data name=...> を残すなら True。
    ja_font=True (ja.resx) のときだけ .Font も残す (値は別途 normalize_ja_font_* で正規化する)。"""
    if not name or name.startswith(">>"):  # >> はデザイナ階層メタ → 残さない
        return False
    p = prop_of(name)
    if ja_font and p == "Font":  # 260618Cl: ja のみ Font ($this.Font 含む) を保持
        return True
    return p in KEEP_EXACT or KEEP_SUFFIXED_RE.match(p) is not None  # 260618Cl: ToolTip\d* も保護


# ── 検出モード (ET でパースして違反を列挙) ─────────────────────────────────────────────
def scan_resx(path: str, ja_font: bool = False):
    """除去対象 (name, prop, kind) を列挙する。
    ja_font=True のときは、保持される .Font が正規化済 (Yu Gothic UI + ティア値) でなければ違反とする。"""
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
            if cur != normalize_ja_font_value(cur):  # off-tier / 非 Yu Gothic は要修復
                bad.append((name, prop_of(name), "font-not-normalized"))
    for meta in root.findall("metadata"):  # metadata ボディは常に非ローカライズ
        name = meta.get("name", "")
        if name:
            bad.append((name, prop_of(name), "metadata"))
    return bad


# ── 修復モード (生テキストからブロック除去。BOM/CRLF と他要素の書式を厳密保持) ───────────────
# data|metadata ブロックを行頭インデント込み・末尾改行込みで掴む。値内の改行も含めて非貪欲に閉じタグまで。
# 埋め込み XSD スキーマは <xsd:element ...> なので <(data|metadata)\b では一致しない (誤除去しない)。
_BLOCK_RE = re.compile(
    r"[ \t]*<(data|metadata)\b[^>]*(?:/>|>.*?</\1>)[ \t]*\r?\n",
    re.DOTALL,
)
_NAME_RE = re.compile(r'\bname="([^"]*)"')


def fix_text(text: str, ja_font: bool = False):
    """(new_text, removed, normalized) を返す。removed=除去した(name,prop)、normalized=ja で値を
    正規化した Font の name。ja_font=True のときは .Font を残し UiFont.Resolve(ja) 相当へ正規化する。"""
    removed = []
    normalized = []

    def repl(m):
        block = m.group(0)
        nm = _NAME_RE.search(block)
        name = nm.group(1) if nm else ""
        tag = m.group(1)
        if tag == "data" and keep_data(name, ja_font):
            if ja_font and prop_of(name) == "Font":
                new_block = normalize_ja_font_block(block)  # family→Yu Gothic UI・size→ティア離散化
                if new_block != block:
                    normalized.append(name)
                return new_block
            return block  # ローカライズ文字列は保持
        removed.append((name, prop_of(name)))
        return ""  # data(非許可) / metadata は丸ごと除去

    new_text = _BLOCK_RE.sub(repl, text)
    return new_text, removed, normalized


# ── 260726Cl 追加: neutral resx の「デザイナ言語」焼き付き対策 ──────────────────────────────
# 背景: VS デザイナで Language ドロップダウンを (Default) 以外にして保存すると、
#   (a) 選んだ言語が neutral resx へ `$this.Language` metadata として保存され、
#   (b) 次にそのフォームをデザイナで開くと自動的にその言語で開くため、以後の編集が全部
#       culture resx へ流れて neutral が更新されなくなる (レイアウト正本の凍結)、
#   (c) さらに VS は一部プロパティを neutral から culture 側へ「移動」させる
#       (実例: FormEBSD の colorControl* の HeaderFont/FooterFont 4 件が neutral から消え ja へ移った)。
#   作者は VS で GUI を編集するので (a) は必ず起きうる前提。よって「起きない運用」を求めず、
#   コミットのたびに (a) を自動で剥がして再発を断ち、(c) は検出して知らせる。
# neutral は本来このスクリプトの対象外 (レイアウトの正本なので触らない) だが、
#   `$this.Language` だけは「レイアウトではなくデザイナの状態」なので例外的に除去してよい。
NEUTRAL_DROP_METADATA = {"$this.Language"}


def fix_neutral_text(text: str):
    """neutral resx から NEUTRAL_DROP_METADATA の metadata ブロックを除去して (new_text, removed) を返す。"""
    removed = []

    def repl(m):
        if m.group(1) != "metadata":
            return m.group(0)
        nm = _NAME_RE.search(m.group(0))
        name = nm.group(1) if nm else ""
        if name in NEUTRAL_DROP_METADATA:
            removed.append(name)
            return ""
        return m.group(0)

    return _BLOCK_RE.sub(repl, text), removed


def ja_orphan_fonts(neutral_path: str):
    """neutral には無いのに ja.resx にだけ在り、しかも値が「ja 以外の本文フォント」になっている
    Font 系エントリ (.Font/.HeaderFont/.FooterFont) の (name, value) を返す。

    デザイナを Language=ja で保存すると、neutral 側にあった値が落ちて ja へ「移動」することがある
    (実例: FormEBSD の colorControl* が neutral から消え、Segoe UI のまま ja へ移った)。
    ja だけに Font があること自体は方針どおり正常 (ja は Font を保持する言語) なので、それだけでは警告しない。
    値の family が UI 本文フォントかつ Yu Gothic UI でない = ja として正規化されていない = neutral の値が
    紛れ込んだ、という組み合わせだけを拾う。役割フォント (Times/Courier/Symbol 等) は言語不変なので対象外。
    自動復元はしない (正しい neutral 値を機械的には決められない) が、必ず知らせる。"""
    ja_path = neutral_path[:-len(".resx")] + ".ja.resx"
    if not os.path.isfile(ja_path):
        return []
    try:
        def font_entries(p):
            return {d.get("name", ""): (d.findtext("value") or "")
                    for d in ET.parse(p).getroot().findall("data")
                    if prop_of(d.get("name", "")).endswith("Font")}
        neutral_names = set(font_entries(neutral_path))
        out = []
        for name, value in sorted(font_entries(ja_path).items()):
            if name in neutral_names:
                continue
            m = _FONT_VALUE_RE.match(value)
            family = m.group(1).strip() if m else ""
            if family in UI_BODY_FAMILIES and family != JA_FAMILY:
                out.append((name, value))
        return out
    except ET.ParseError:
        return []


def fix_neutral_file(path: str):
    """戻り値: (removed list, error or None)。変更が無ければ書き換えない。"""
    raw = open(path, "rb").read()
    text = raw.decode("utf-8-sig")
    new_text, removed = fix_neutral_text(text)
    if not removed:
        return [], None
    try:
        ET.fromstring(new_text)
    except ET.ParseError as e:
        return removed, f"結果が不正 XML になるため書込中止: {e}"
    new_text = new_text.replace("\r\n", "\n").replace("\n", "\r\n")
    open(path, "wb").write(codecs.BOM_UTF8 + new_text.encode("utf-8"))
    return removed, None


def collect_neutral(roots, langs):
    """culture サフィックスを持たない *.resx (= neutral) を集める。"""
    suffixes = tuple(f".{l}.resx" for l in langs)
    out = []
    for root in roots:
        for p in glob.glob(os.path.join(root, "**", "*.resx"), recursive=True):
            if not p.endswith(suffixes):
                out.append(os.path.normpath(p))
    return sorted(set(out))


def fix_file(path: str, ja_font: bool = False):
    """戻り値: (removed list, normalized list, error or None)。変更が無ければ書き換えない。"""
    raw = open(path, "rb").read()
    text = raw.decode("utf-8-sig")  # BOM があれば落とす
    new_text, removed, normalized = fix_text(text, ja_font)
    if not removed and not normalized and new_text == text:
        return [], [], None
    # 書き戻し前に well-formed か検証 (壊れる変換なら書かない)
    try:
        ET.fromstring(new_text)
    except ET.ParseError as e:
        return removed, normalized, f"結果が不正 XML になるため書込中止: {e}"
    # gen_de_resx.py と同じイディオム: CRLF 正規化 + utf-8 BOM。
    new_text = new_text.replace("\r\n", "\n").replace("\n", "\r\n")
    open(path, "wb").write(codecs.BOM_UTF8 + new_text.encode("utf-8"))
    return removed, normalized, None


def main() -> int:
    ap = argparse.ArgumentParser(description="新言語 culture resx を text-only に保つ (検出 / --fix 修復)。")
    ap.add_argument("--lang", action="append", help="言語コード (複数可)。既定: " + ",".join(DEFAULT_NEW_LANGS))
    ap.add_argument("--root", action="append", help="走査ルート (複数可)。既定: ReciPro + Crystallography.Controls")
    ap.add_argument("--include-ja", action="store_true", help="ja も対象に含める (既定は除外)")
    ap.add_argument("--fix", action="store_true", help="違反ブロックを除去して書き戻す (utf-8-bom + crlf)")
    args = ap.parse_args()

    langs = args.lang or list(DEFAULT_NEW_LANGS)
    if args.include_ja and "ja" not in langs:
        langs.append("ja")
    roots = [r for r in (args.root or DEFAULT_ROOTS) if os.path.isdir(r)]

    # (path, ja_font) のリスト。ja は Font を保持+正規化、他言語は text-only。
    pairs = {}
    for root in roots:
        for lang in langs:
            for p in glob.glob(os.path.join(root, "**", f"*.{lang}.resx"), recursive=True):
                pairs[os.path.normpath(p)] = (lang == "ja")
    files = sorted(pairs)

    langs_disp = ",".join(langs)

    # 260726Cl 追加: neutral resx のデザイナ言語焼き付き ($this.Language) と、
    #   neutral から ja へ移動した疑いのある .Font を、culture resx の処理と同じ実行で扱う。
    neutral_files = collect_neutral(roots, langs)
    neutral_hits, orphan_hits = [], []
    for path in neutral_files:
        rel = os.path.relpath(path)
        if args.fix:
            removed, err = fix_neutral_file(path)
            if err:
                print(f"ERROR {rel}: {err}")
            elif removed:
                neutral_hits.append(rel)
                print(f"FIXED {rel}  (デザイナ言語の焼き付きを除去: {', '.join(removed)})")
        else:
            try:
                names = [m.get("name", "") for m in ET.parse(path).getroot().findall("metadata")]
            except ET.ParseError:
                names = []
            hit = [n for n in names if n in NEUTRAL_DROP_METADATA]
            if hit:
                neutral_hits.append(rel)
                print(f"FAIL {rel}\n    designer-language baked in: {', '.join(hit)}")
        orphans = ja_orphan_fonts(path)
        if orphans:
            orphan_hits.append(rel)
            print(f"WARN {rel}: neutral から ja.resx へ移動した疑いの Font "
                  f"(ja なのに Yu Gothic UI でない = neutral の値。自動復元しないので手で戻すこと)")
            for n, v in orphans:
                print(f"    ja-only font: {n} = {v}")

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
        print(f"neutral resx {len(neutral_files)} 件を検査; "
              f"{len(neutral_hits)} 件のデザイナ言語焼き付きを除去, {len(orphan_hits)} 件に ja 専用 Font の警告.")
        if orphan_hits:
            print("  ↑ 警告は自動修復されない。neutral から消えた .Font を手で戻すこと "
                  "(そのままだと英語 UI が明示フォントを失い、日本語だけ neutral のフォントに固定される)。")
        return 1 if errors else 0

    # 検出モード (CI)
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

    total_violations += len(neutral_hits)  # 260726Cl: neutral のデザイナ言語焼き付きも CI で落とす
    print(f"\nscanned {len(files)} culture resx ({langs_disp}) + {len(neutral_files)} neutral resx; "
          f"{total_violations} violation(s), {len(orphan_hits)} ja-only-font warning(s).")
    if total_violations:
        print("culture resx は文字列 (.Text/.ToolTip/.HeaderText/.Items 等) のみにすること "
              "(レイアウトは neutral へフォールバック)。ja のみ .Font を保持できるが値は "
              "Yu Gothic UI + 5 段階ティアへ正規化必須。`--fix` で自動修復できる。"
              "VS デザイナで Language=(Default) 以外で保存すると焼き込みが再混入する。")
        return 1
    print("OK: culture resx は規約どおり (他言語=text-only / ja=text+正規化 Font)。")
    return 0


if __name__ == "__main__":
    sys.exit(main())
