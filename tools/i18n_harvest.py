#!/usr/bin/env python3
# 260625Cl 追加: PDIndexer の neutral(en) resx から「翻訳対象文字列」を抽出し、フォーム単位の JSON を出力する。
#   多言語化 Phase 1 の入力生成。check_resx_textonly.py の ALLOWLIST と同じ規則で翻訳対象キーを選ぶ。
#   cross-reference 言語(--ref, 既定 ja)の既訳も併記する (de パイロット=ja参照 / 8言語展開=de参照)。
#
# 使い方:
#   python tools/i18n_harvest.py [--ref ja|de] [--out <dir>] [--app <PDIndexerAppDir>]
# 出力:
#   <out>/<Form>.json   = {"form": "<Form>", "neutral": "<path>", "ref": "ja", "items": {key: {"en":..., "ref":...}}}
#   <out>/_index.json   = {"ref": "ja", "forms": [{"form","neutral","count","file"}, ...]}

import argparse, glob, json, os, re, sys, xml.etree.ElementTree as ET

try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

_THIS = os.path.dirname(os.path.abspath(__file__))
_REPO_ROOT = os.path.dirname(_THIS)

# check_resx_textonly.py の KEEP 規則と一致させること。
KEEP_EXACT = {"Text", "HeaderText", "FooterText", "AccessibleName", "AccessibleDescription"}
KEEP_SUFFIXED_RE = re.compile(r"^(?:Items|ToolTip|ToolTipText)\d*$")
_CULTURE_RE = re.compile(r"\.[a-z]{2}(-[A-Za-z]+)?\.resx$")


def prop_of(name):
    return name.rsplit(".", 1)[-1] if "." in name else name


def is_translatable(name):
    if not name or name.startswith(">>"):
        return False
    p = prop_of(name)
    return p in KEEP_EXACT or KEEP_SUFFIXED_RE.match(p) is not None


def parse_vals(path):
    if not os.path.exists(path):
        return {}
    root = ET.parse(path).getroot()
    out = {}
    for d in root.findall("data"):
        nm = d.get("name")
        v = d.find("value")
        out[nm] = v.text if (v is not None and v.text is not None) else ""
    return out


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--refs", default="ja", help="cross-reference 言語 (カンマ区切り。例 ja または ja,de)")
    ap.add_argument("--out", default=r"C:\tmp\pdi_i18n\harvest")
    ap.add_argument("--app", default=os.path.join(_REPO_ROOT, "PDIndexer"))
    args = ap.parse_args()

    refs = [r.strip() for r in args.refs.split(",") if r.strip()]
    os.makedirs(args.out, exist_ok=True)
    forms = []
    for path in sorted(glob.glob(os.path.join(args.app, "**", "*.resx"), recursive=True)):
        base = os.path.basename(path)
        if _CULTURE_RE.search(base) or base == "Resources.resx":
            continue
        form = base[:-len(".resx")]
        nv = parse_vals(path)
        refvals = {r: parse_vals(path[:-len(".resx")] + f".{r}.resx") for r in refs}
        items = {}
        for k, v in nv.items():
            if not is_translatable(k):
                continue
            if v is None or v == "":  # en 原文が空なら翻訳不要
                continue
            it = {"en": v}
            for r in refs:                       # 既訳がある参照言語のみ併記 (空はキー自体省略)
                rv = refvals[r].get(k, "")
                if rv:
                    it[r] = rv
            items[k] = it
        if not items:
            continue
        rec = {"form": form, "neutral": path, "refs": refs, "items": items}
        outfile = os.path.join(args.out, form + ".json")
        json.dump(rec, open(outfile, "w", encoding="utf-8"), ensure_ascii=False, indent=1)
        forms.append({"form": form, "neutral": path, "count": len(items), "file": outfile})

    index = {"refs": refs, "forms": forms}
    json.dump(index, open(os.path.join(args.out, "_index.json"), "w", encoding="utf-8"), ensure_ascii=False, indent=1)
    total = sum(f["count"] for f in forms)
    print(f"harvested {len(forms)} forms, {total} translatable strings (refs={','.join(refs)}) -> {args.out}")
    for f in forms:
        print(f"  {f['form']:<32} {f['count']}")


if __name__ == "__main__":
    main()
