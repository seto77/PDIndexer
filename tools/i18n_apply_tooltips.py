#!/usr/bin/env python3
# 260625Cl 追加: Phase 2 F2 — ボタン状態を多言語化したことでツールチップ本文に残った literal 'Stop!'
#   (訳ボタン "Stopp!"/"停止!" 等との不一致) を解消するため、リワードした 2 ツールチップの全言語訳を
#   neutral + 各 culture resx の該当 <data> へ書き戻す。formatting/encoding(UTF-8+BOM) と改行様式は保持し、
#   対象 <data name="...ToolTip"> の <value> のみ置換する。
#
# 入力: C:\tmp\pdi_i18n\code\_Tooltips.json      (id/en)
#       C:\tmp\pdi_i18n\code_out\_Tooltips.json  ({"translations":{id:{ja,de,...}}})
# 使い方: python tools/i18n_apply_tooltips.py
import json, os, re, sys

try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

_THIS = os.path.dirname(os.path.abspath(__file__))
APP = os.path.join(os.path.dirname(_THIS), "PDIndexer")
SRC = r"C:\tmp\pdi_i18n\code\_Tooltips.json"
TR = r"C:\tmp\pdi_i18n\code_out\_Tooltips.json"
LANGS = ["ja", "de", "fr", "es", "pt", "it", "ru", "zh-Hans", "zh-Hant", "ko"]

# id → (Designer basename, resx data key)
MAP = {
    "tipFind":  ("FormCellFinder",           "buttonFind.ToolTip"),
    "tipStart": ("FormAtomicPositionFinder",  "buttonStart.ToolTip"),
}


def xml_escape(s):
    return s.replace("&", "&amp;").replace("<", "&lt;").replace(">", "&gt;")


def resx_path(form, lang):
    # neutral(en) は <Form>.resx、それ以外は <Form>.<lang>.resx (DataConverter 等のサブフォルダも探索)
    import glob
    name = f"{form}.resx" if lang == "en" else f"{form}.{lang}.resx"
    hits = glob.glob(os.path.join(APP, "**", name), recursive=True)
    return hits[0] if hits else None


def update_value(path, key, new_text):
    raw = open(path, "rb").read()
    bom = raw.startswith(b"\xef\xbb\xbf")
    text = raw.decode("utf-8-sig")
    nl = "\r\n" if "\r\n" in text else "\n"          # ファイルの改行様式に合わせる
    val = xml_escape(new_text).replace("\n", nl)
    pat = re.compile(r'(<data name="' + re.escape(key) + r'"[^>]*>\s*<value>)(.*?)(</value>)', re.DOTALL)
    new, n = pat.subn(lambda m: m.group(1) + val + m.group(3), text)
    if n != 1:
        return f"  SKIP {os.path.basename(path)} [{key}]: matched {n} (expected 1)"
    out = new.encode("utf-8")
    open(path, "wb").write((b"\xef\xbb\xbf" if bom else b"") + (out[3:] if out.startswith(b"\xef\xbb\xbf") else out))
    return f"  ok   {os.path.basename(path)} [{key}]"


def main():
    src = {it["ctrl"]: it["en"] for it in json.load(open(SRC, encoding="utf-8"))["items"]}
    tr = json.load(open(TR, encoding="utf-8")).get("translations", {})
    updated = 0
    for tid, (form, key) in MAP.items():
        # neutral (en)
        for lang in ["en"] + LANGS:
            val = src[tid] if lang == "en" else tr.get(tid, {}).get(lang, "")
            if not val:
                print(f"  WARN no text for {tid}[{lang}]"); continue
            p = resx_path(form, lang)
            if not p:
                print(f"  WARN resx not found: {form} {lang}"); continue
            msg = update_value(p, key, val)
            print(msg)
            if msg.lstrip().startswith("ok"):
                updated += 1
    print(f"updated {updated} resx values")


if __name__ == "__main__":
    main()
