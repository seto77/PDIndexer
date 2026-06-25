#!/usr/bin/env python3
# 260625Cl 追加: 翻訳 Workflow の結果 JSON から、各フォームの culture resx を生成する (gen_de_resx.py 経由)。
#   多言語化 Phase 1 の取り込み。i18n_process_culture.py (ReciPro) と同じ思想。
#
# 使い方:
#   python tools/i18n_apply.py <lang> <outdir> [--index <harvest/_index.json>]
#   <outdir> = 翻訳 Workflow の各 verify agent が書いたユニット別 JSON のディレクトリ。
#             各ファイル = {"unit","form","translations":{key:value}}  (_ で始まるファイルは無視)
#   <_index.json> = i18n_harvest.py が出力した forms->neutral path のインデックス

import argparse, glob, json, os, subprocess, sys, xml.etree.ElementTree as ET

try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

_THIS = os.path.dirname(os.path.abspath(__file__))
GEN = os.path.join(_THIS, "gen_de_resx.py")


def neutral_vals(path):
    root = ET.parse(path).getroot()
    return {d.get("name"): (d.find("value").text if d.find("value") is not None else "") for d in root.findall("data")}


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("lang")
    ap.add_argument("outdir")
    ap.add_argument("--index", default=r"C:\tmp\pdi_i18n\harvest\_index.json")
    args = ap.parse_args()

    index = json.load(open(args.index, encoding="utf-8"))
    form2neutral = {f["form"]: f["neutral"] for f in index["forms"]}

    # ユニット別 JSON を読み、フォーム単位に translations をマージする。
    merged = {}
    unit_files = [p for p in glob.glob(os.path.join(args.outdir, "*.json"))
                  if not os.path.basename(p).startswith("_")]
    for p in sorted(unit_files):
        try:
            e = json.load(open(p, encoding="utf-8"))
        except Exception as ex:
            print(f"  WARN unreadable unit file {os.path.basename(p)}: {ex}"); continue
        form = e.get("form") or os.path.basename(p).split("__")[0]
        merged.setdefault(form, {}).update(e.get("translations") or {})
    print(f"read {len(unit_files)} unit files -> {len(merged)} forms")

    tmp = os.path.join(os.environ.get("TEMP", "."), "pdi_i18n_apply")
    os.makedirs(tmp, exist_ok=True)
    total_forms = total_entries = 0
    for form, trans in merged.items():
        if form not in form2neutral:
            print(f"  WARN unknown form: {form}"); continue
        neutral = form2neutral[form]
        nv = neutral_vals(neutral)
        fixed = {}
        for k, v in trans.items():
            if v is None or v == "":
                continue
            en = nv.get(k, "")
            # WinForms の && は literal "&" → en にあるのに訳に無ければ補修
            if "&&" in en and "&&" not in v:
                v = v.replace("&", "&&") if "&" in v else v
            fixed[k] = v
        jp = os.path.join(tmp, f"{args.lang}_{form}.json")
        json.dump(fixed, open(jp, "w", encoding="utf-8"), ensure_ascii=False)
        out = neutral[:-len(".resx")] + f".{args.lang}.resx"
        r = subprocess.run([sys.executable, GEN, neutral, jp, out, "--lang", args.lang],
                           capture_output=True, text=True, encoding="utf-8")
        sys.stdout.write(f"[{form}] " + (r.stdout or "").strip() + "\n")
        if r.returncode != 0:
            sys.stdout.write(f"  ERROR gen_de_resx: {(r.stderr or '').strip()}\n")
        total_forms += 1
        total_entries += len(fixed)
    print(f"=== {args.lang}: {total_forms} forms, {total_entries} entries written ===")


if __name__ == "__main__":
    main()
