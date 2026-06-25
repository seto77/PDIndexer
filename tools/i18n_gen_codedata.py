#!/usr/bin/env python3
# 260625Cl 追加: Phase 2 — code harvest(i18n_codescan.py の en) + 翻訳結果(全10非英語言語) から
#   PDIndexer 固有の中央レジストリ `PDIndexerLocalizationData.cs` を生成する。
#   CodeLocalizer が FullName キー("PDIndexer.<Form>")で引き、Localizable=false フォームの直書きラベルを
#   実行時に差し替える。共有 LocalizationData(ReciPro/共有UC) には混ぜない(app-local provider 経由)。
#
# 使い方: python tools/i18n_gen_codedata.py
#   入力: C:\tmp\pdi_i18n\code\<Form>.json     (en/ctrl/prop/type)
#         C:\tmp\pdi_i18n\code_out\<Form>.json  ({"translations":{ctrl:{ja,de,fr,es,pt,it,ru,zh-Hans,zh-Hant,ko}}})
#   出力: PDIndexer\PDIndexerLocalizationData.cs

import glob, json, os, sys

try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

_THIS = os.path.dirname(os.path.abspath(__file__))
APP = os.path.join(os.path.dirname(_THIS), "PDIndexer")
CODE = r"C:\tmp\pdi_i18n\code"
OUTDIR = r"C:\tmp\pdi_i18n\code_out"
LANGS = ["ja", "de", "fr", "es", "pt", "it", "ru", "zh-Hans", "zh-Hant", "ko"]


def cs_str(s):
    if s is None:
        s = ""
    return '"' + s.replace("\\", "\\\\").replace('"', '\\"').replace("\r", "\\r").replace("\n", "\\n") + '"'


def main():
    forms = []
    for harv in sorted(glob.glob(os.path.join(CODE, "*.json"))):
        if os.path.basename(harv).startswith("_"):
            continue
        h = json.load(open(harv, encoding="utf-8"))
        form, typ = h["form"], h["type"]
        outp = os.path.join(OUTDIR, form + ".json")
        if not os.path.exists(outp):
            print(f"  WARN no translation output for {form}"); continue
        tr = json.load(open(outp, encoding="utf-8")).get("translations", {})
        entries = []
        for it in h["items"]:
            ctrl, prop, en = it["ctrl"], it["prop"], it["en"]
            t = tr.get(ctrl, {})
            vals = [cs_str(en)] + [cs_str(t.get(l, "")) for l in LANGS]
            entries.append(f'            new({cs_str(ctrl)}, {cs_str(prop)}, {", ".join(vals)}),')
        forms.append((typ, entries))

    lines = [
        "namespace PDIndexer;",
        "",
        "// 260625Cl 自動生成 (tools/i18n_gen_codedata.py 由来)。手で編集しない。",
        "// 多言語化 Phase 2: Localizable=false フォームの Designer 直書き可視ラベルの 11 言語訳テーブル。",
        "// 起動時に Register() を呼ぶと、共有 Crystallography.Localization の中央レジストリへ app-local provider",
        "// として merge される。CodeLocalizer が FullName キー(\"PDIndexer.<Form>\")で引いて実行時に差し替える。",
        "internal static class PDIndexerLocalizationData",
        "{",
        "    /// <summary>フォーム生成前に1回呼ぶこと (Program.Main 冒頭)。</summary>",
        "    public static void Register() => Crystallography.Localization.AddProvider(Populate);",
        "",
        "    private static void Populate(System.Collections.Generic.Dictionary<string, Crystallography.Localization.Entry[]> reg)",
        "    {",
    ]
    for typ, entries in forms:
        lines.append(f'        reg[{cs_str(typ)}] = new Crystallography.Localization.Entry[]')
        lines.append("        {")
        lines.extend(entries)
        lines.append("        };")
    lines.append("    }")
    lines.append("}")
    text = "\r\n".join(lines) + "\r\n"
    out = os.path.join(APP, "PDIndexerLocalizationData.cs")
    open(out, "wb").write(b"\xef\xbb\xbf" + text.encode("utf-8"))
    print(f"wrote {out}: {len(forms)} forms, {sum(len(e) for _, e in forms)} entries")


if __name__ == "__main__":
    main()
