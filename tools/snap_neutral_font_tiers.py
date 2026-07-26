#!/usr/bin/env python3
# 260618Cl 追加: neutral(言語サフィックス無し) resx の Font サイズを 5 段階ティアへスナップする。
#
# 背景: UiFont (Crystallography.Controls/UiFont.cs) は実行時に各コントロールの font pt を
#   TierOf(pt) → PtOf(tier) で 5 段階(SS=7/S=8.25/M=9/L=9.75/LL=13)へ離散化して描画する。
#   ところが VS デザイナはソース(resx)の生の pt を表示するため、例えば 10pt を設定しても
#   デザイナ上は 10pt のまま(実行時は L=9.75 に潰れる)で「実際の大きさ」が設計時に見えない。
#   そこで neutral resx の Font pt を「コミット時に」ティア値へ書き換えれば、デザイナ表示が
#   実行時サイズ(英語ティア)に一致する。family は触らず size のみ。
#
# 方針:
#   - 対象は neutral resx のみ (*.{culture}.resx は除外。culture resx は別途 text-only)。
#   - .Font / $this.Font 等「.Font」で終わる data の <value> 内 pt をティアへスナップ。
#   - family と style(=...,style=Bold 等) は保持。既にティア値なら無変更 (idempotent)。
#   - BOM(utf-8) + CRLF を保持 (check_resx_textonly.py / gen_de_resx.py と同じイディオム)。
#   - compile 時でなく commit 時(pre-commit)に走らせる想定 (ビルドでソースを書き換えない)。
#
# 使い方:
#   python tools/snap_neutral_font_tiers.py                # --check: 変更プレビュー (既定)
#   python tools/snap_neutral_font_tiers.py --root ReciPro # 走査ルート指定
#   python tools/snap_neutral_font_tiers.py --fix          # 実際に書き換える
# 終了コード(check): 0=off-tier 無し / 1=off-tier あり (CI 用)。fix: 0=成功。

import argparse
import codecs
import glob
import os
import re
import sys

try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

_THIS = os.path.dirname(os.path.abspath(__file__))
_RECIPRO_ROOT = os.path.dirname(_THIS)
# 260726Cl: Crystallography.Controls は submodule (ReciPro/Crystallography.Controls) なので再帰 glob が拾う。
#   junction 時代の名残だった ../Crystallography.Controls/Crystallography.Controls は HEAD が別物の
#   無関係な作業ツリーで、--fix がそこを黙って書き換えてしまうため外す (check_resx_textonly.py と同じ理由)。
# 旧: os.path.normpath(os.path.join(_RECIPRO_ROOT, "..", "Crystallography.Controls", "Crystallography.Controls"))
DEFAULT_ROOTS = [_RECIPRO_ROOT]

# UiFont.cs と一致させること。ティア代表 pt。
TIERS = [("SS", 7.0), ("S", 8.25), ("M", 9.0), ("L", 9.75), ("LL", 13.0)]

# UiFont.IsUiBodyFont と一致させること (SupportedCultures.All の FontFamily)。
# ★これ以外の family (Segoe UI Symbol/Times New Roman/Courier New/Tahoma 等の役割フォント) は
#   実行時にティア化されないので、ここでもスナップしない (snap すると実行時と不一致=記号縮小等)。
UI_BODY_FAMILIES = {
    "Segoe UI", "Yu Gothic UI", "Microsoft YaHei UI", "Microsoft JhengHei UI", "Malgun Gothic",
}


def tier_of(pt: float):
    # UiFont.TierOf と同じ境界: <7.6 SS / <8.6 S / <9.5 M / <11.6 L / else LL
    if pt < 7.6:
        return TIERS[0]
    if pt < 8.6:
        return TIERS[1]
    if pt < 9.5:
        return TIERS[2]
    if pt < 11.6:
        return TIERS[3]
    return TIERS[4]


def fmt_pt(pt: float) -> str:
    # 9.0→"9", 9.75→"9.75", 8.25→"8.25", 13.0→"13" (resx の表記に合わせ末尾0を落とす)
    s = f"{pt:.2f}".rstrip("0").rstrip(".")
    return s


# culture resx (*.ja.resx / *.de.resx / *.zh-Hans.resx 等) を除外するための判定。
_CULTURE_RE = re.compile(r"\.[a-z]{2}(-[A-Za-z]+)?\.resx$")

# .Font data の <value> 内 "Family, Npt..." の N を捕捉。group: 1=prefix(name含む) 2=family 3=pt
_FONT_RE = re.compile(
    r'(<data name="([^"]*)\.Font"[^>]*>\s*<value[^>]*>)([^,<]+),\s*([0-9.]+)pt',
    re.DOTALL,
)


def process_text(text: str):
    """(new_text, changes[(name, family, old_pt, tier, new_pt)]) を返す。"""
    changes = []

    def repl(m):
        name, family, pt = m.group(2), m.group(3), float(m.group(4))
        if family.strip() not in UI_BODY_FAMILIES:
            return m.group(0)  # 役割フォント (Symbol/Times/Courier/Tahoma 等) はティア化しない
        tier_name, tier_pt = tier_of(pt)
        if abs(tier_pt - pt) < 0.001:
            return m.group(0)  # 既にティア値
        changes.append((name, family.strip(), pt, tier_name, tier_pt))
        return f"{m.group(1)}{family}, {fmt_pt(tier_pt)}pt"

    return _FONT_RE.sub(repl, text), changes


def iter_neutral_resx(roots):
    for root in roots:
        if not os.path.isdir(root):
            continue
        for path in glob.glob(os.path.join(root, "**", "*.resx"), recursive=True):
            if not _CULTURE_RE.search(os.path.basename(path)):
                yield path


def main() -> int:
    ap = argparse.ArgumentParser(description="neutral resx の Font サイズを 5 段階ティアへスナップ。")
    ap.add_argument("--root", action="append", help="走査ルート (複数可)。既定: ReciPro + Crystallography.Controls")
    ap.add_argument("--fix", action="store_true", help="実際に書き換える (既定は --check=プレビューのみ)")
    args = ap.parse_args()
    roots = args.root or DEFAULT_ROOTS

    total_changes = 0
    files_touched = 0
    # ティア別・どの pt が何に化けるかの集計 (ティア表チューニング用)。
    bucket = {}

    for path in sorted(iter_neutral_resx(roots)):
        raw = open(path, "rb").read()
        text = raw.decode("utf-8-sig")
        new_text, changes = process_text(text)
        if not changes:
            continue
        files_touched += 1
        total_changes += len(changes)
        rel = os.path.relpath(path)
        print(f"{'FIX ' if args.fix else 'OFF-TIER '}{rel}  ({len(changes)})")
        for name, family, old_pt, tier, new_pt in changes:
            print(f"    {name}: {fmt_pt(old_pt)}pt -> {tier}={fmt_pt(new_pt)}pt  ({family})")
            bucket[(fmt_pt(old_pt), tier, fmt_pt(new_pt))] = bucket.get((fmt_pt(old_pt), tier, fmt_pt(new_pt)), 0) + 1
        if args.fix:
            out = new_text.replace("\r\n", "\n").replace("\n", "\r\n")
            open(path, "wb").write(codecs.BOM_UTF8 + out.encode("utf-8"))

    print("\n=== 変更サマリ (old pt -> tier=new pt : 件数) ===")
    for (old_pt, tier, new_pt), n in sorted(bucket.items(), key=lambda kv: -kv[1]):
        print(f"  {old_pt}pt -> {tier}={new_pt}pt : {n}")
    verb = "snapped" if args.fix else "off-tier"
    print(f"\n{verb}: {total_changes} font entr(ies) in {files_touched} neutral resx.")
    if not args.fix and total_changes:
        print("--fix で書き換え。ティア表(TIERS)は UiFont.cs と一致させること。")
        return 1
    return 0


if __name__ == "__main__":
    sys.exit(main())
