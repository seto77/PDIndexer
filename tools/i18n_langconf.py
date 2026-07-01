#!/usr/bin/env python3
# 260625Cl 追加: ReciPro の i18n ツールから各言語の glossary / rules / langinfo を抽出し、
#   言語別 config JSON を書き出す。翻訳 Workflow の agent がこれを Read して用語/書式規則を得る。
#   手転記を避け ReciPro 資産(IUCr/Termonline 準拠 glossary)をそのまま流用するのが目的。
#
# 使い方: python tools/i18n_langconf.py [--recipro-tools <dir>] [--out <dir>]
# 出力:   <out>/<lang>.json = {"lang","name","locale","charset","glossary","rules"}  (de + 8言語)

import argparse, json, os, sys

try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

CULTURE_RULES_TMPL = (
    "FORMATTING RULES (must follow exactly):\n"
    "- Output proper {name} text using {charset}. Never ASCII-substitute or transliterate.\n"
    "- Match EN's leading/trailing whitespace and trailing colon byte-for-byte (UI alignment). Do not add/remove spaces.\n"
    "- Preserve embedded newlines (\\n): same number of lines as EN.\n"
    "- Keep \"&&\" literally (WinForms ampersand escape).\n"
    "- Do NOT translate pure symbols/units/variables: LaTeX (\\alpha), math (2theta/2theta, sigma, q, t, Z, A), units (nm, nm^2, um, Angstrom, %, kV), spectral notation. Return unchanged.\n"
    "- Keep crystallographic abbreviations terse to fit narrow columns/buttons.\n"
    "- These are short UI labels/headers/buttons/tab titles: concise standard UI wording, not full sentences."
)


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--recipro-tools", default=r"C:\Users\seto\source\repos\ReciPro\tools")
    ap.add_argument("--out", default=r"C:\tmp\pdi_i18n\lang")
    args = ap.parse_args()
    os.makedirs(args.out, exist_ok=True)

    # --- de: i18n_gen_workflow.py から GLOSSARY + RULES を抽出 (slice + exec) ---
    de_src = open(os.path.join(args.recipro_tools, "i18n_gen_workflow.py"), encoding="utf-8").read()
    a, b = de_src.index("GLOSSARY = "), de_src.index("\nSCHEMA = {")
    ns_de = {}
    exec(de_src[a:b], ns_de)
    de_conf = {"lang": "de", "name": "German", "locale": "de-DE",
               "charset": "umlauts/eszett (a-umlaut o-umlaut u-umlaut eszett)",
               "glossary": ns_de["GLOSSARY"], "rules": ns_de["RULES"]}
    json.dump(de_conf, open(os.path.join(args.out, "de.json"), "w", encoding="utf-8"), ensure_ascii=False, indent=1)

    # --- 8言語: i18n_gen_culture_workflow.py から LANGINFO + GLOSSARIES を抽出 ---
    cw_src = open(os.path.join(args.recipro_tools, "i18n_gen_culture_workflow.py"), encoding="utf-8").read()
    a, b = cw_src.index("LANGINFO = {"), cw_src.index("\nname, locale, charset =")
    ns = {}
    exec(cw_src[a:b], ns)
    LANGINFO, GLOSSARIES = ns["LANGINFO"], ns["GLOSSARIES"]
    for lang, (name, locale, charset) in LANGINFO.items():
        rules = CULTURE_RULES_TMPL.format(name=name, charset=charset)
        conf = {"lang": lang, "name": name, "locale": locale, "charset": charset,
                "glossary": GLOSSARIES[lang], "rules": rules}
        json.dump(conf, open(os.path.join(args.out, f"{lang}.json"), "w", encoding="utf-8"),
                  ensure_ascii=False, indent=1)

    print("wrote lang configs ->", args.out)
    for fn in sorted(os.listdir(args.out)):
        print("  " + fn)


if __name__ == "__main__":
    main()
