#!/usr/bin/env python3
# 260625Cl 追加: harvest のフォーム別 JSON を「翻訳ユニット」(<=CHUNK キー)へ分割する。
#   大物フォーム(FormMain 381 等)を1エージェントに丸投げするとキー見落としが起きるため、
#   翻訳/検証は小さなユニット単位で並列化する。apply はフォーム単位でマージする。
#
# 使い方: python tools/i18n_units.py [--chunk 50] [--dir <harvest dir>] [--out <units dir>]
# 出力:
#   <out>/<Form>__<i>.json = {"unit":"<Form>__<i>", "form":"<Form>", "chunk":i, "items":{key:{en,ref}}}
#   <out>/_units.json      = {"ref":..., "units":[{"unit","form","chunk","file","count"}, ...]}

import argparse, json, os, sys

try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--chunk", type=int, default=50)
    ap.add_argument("--dir", default=r"C:\tmp\pdi_i18n\harvest")
    ap.add_argument("--out", default=r"C:\tmp\pdi_i18n\units")
    args = ap.parse_args()

    os.makedirs(args.out, exist_ok=True)
    index = json.load(open(os.path.join(args.dir, "_index.json"), encoding="utf-8"))
    refs = index.get("refs", [index.get("ref", "ja")])
    units = []
    for f in index["forms"]:
        rec = json.load(open(f["file"], encoding="utf-8"))
        items = rec["items"]
        keys = list(items.keys())
        nchunks = max(1, (len(keys) + args.chunk - 1) // args.chunk)
        for i in range(nchunks):
            sub = {k: items[k] for k in keys[i * args.chunk:(i + 1) * args.chunk]}
            unit = f"{rec['form']}__{i}"
            outfile = os.path.join(args.out, unit + ".json")
            json.dump({"unit": unit, "form": rec["form"], "chunk": i, "refs": refs, "items": sub},
                      open(outfile, "w", encoding="utf-8"), ensure_ascii=False, indent=1)
            units.append({"unit": unit, "form": rec["form"], "chunk": i, "file": outfile, "count": len(sub)})

    json.dump({"refs": refs, "units": units},
              open(os.path.join(args.out, "_units.json"), "w", encoding="utf-8"), ensure_ascii=False, indent=1)
    print(f"split {len(index['forms'])} forms -> {len(units)} units (chunk={args.chunk}) -> {args.out}")
    for u in units:
        print(f"  {u['unit']:<38} {u['count']}")


if __name__ == "__main__":
    main()
