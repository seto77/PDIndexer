#!/usr/bin/env python3
# 260618Cl 追加 (ReciPro tools より PDIndexer へ移植 260625Cl): neutral resx の Font サイズを 5 段階ティアへスナップ。
#   check_resx_textonly.py が import する依存 (tier_of/fmt_pt/UI_BODY_FAMILIES)。
#   UiFont (Crystallography.Controls/UiFont.cs) と一致させること。
#
# 使い方:
#   python tools/snap_neutral_font_tiers.py                # --check: 変更プレビュー (既定)
#   python tools/snap_neutral_font_tiers.py --root <dir>   # 走査ルート指定
#   python tools/snap_neutral_font_tiers.py --fix          # 実際に書き換える

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
_REPO_ROOT = os.path.dirname(_THIS)
DEFAULT_ROOTS = [
    os.path.join(_REPO_ROOT, "PDIndexer"),
    os.path.join(_REPO_ROOT, "Crystallography.Controls"),
]

# UiFont.cs と一致させること。ティア代表 pt。
TIERS = [("SS", 7.0), ("S", 8.25), ("M", 9.0), ("L", 9.75), ("LL", 13.0)]

# UiFont.IsUiBodyFont と一致させること (SupportedCultures.All の FontFamily)。
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
    s = f"{pt:.2f}".rstrip("0").rstrip(".")
    return s


_CULTURE_RE = re.compile(r"\.[a-z]{2}(-[A-Za-z]+)?\.resx$")

_FONT_RE = re.compile(
    r'(<data name="([^"]*)\.Font"[^>]*>\s*<value[^>]*>)([^,<]+),\s*([0-9.]+)pt',
    re.DOTALL,
)


def process_text(text: str):
    changes = []

    def repl(m):
        name, family, pt = m.group(2), m.group(3), float(m.group(4))
        if family.strip() not in UI_BODY_FAMILIES:
            return m.group(0)
        tier_name, tier_pt = tier_of(pt)
        if abs(tier_pt - pt) < 0.001:
            return m.group(0)
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
    ap.add_argument("--root", action="append", help="走査ルート (複数可)。")
    ap.add_argument("--fix", action="store_true", help="実際に書き換える (既定は --check=プレビューのみ)")
    args = ap.parse_args()
    roots = args.root or DEFAULT_ROOTS

    total_changes = 0
    files_touched = 0
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
        return 1
    return 0


if __name__ == "__main__":
    sys.exit(main())
