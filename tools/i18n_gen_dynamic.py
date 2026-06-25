#!/usr/bin/env python3
# 260625Cl 追加: Phase 2a — コード側で実行時に組み立てる「動的 UI 文字列」(ボタン状態 Find!/Stop!、
#   進捗フォーマット、MessageBox、日本語only の英語 canonical 化、起動スプラッシュの永続表示) の
#   11 言語訳を、名前付きアクセサを持つヘルパークラス `PdiText` として生成する。
#   呼び出し側は `PdiText.Find` / `string.Format(PdiText.TryNumber, n)` のように使い、各サイトを簡潔に保つ。
#   静的 Designer ラベルの中央レジストリ (PDIndexerLocalizationData.cs / CodeLocalizer) とは別管理 (codex 合意)。
#
# 使い方: python tools/i18n_gen_dynamic.py
#   入力: C:\tmp\pdi_i18n\code\_Dynamic.json      (id=ctrl / en)
#         C:\tmp\pdi_i18n\code_out\_Dynamic.json  ({"translations":{id:{ja,de,fr,es,pt,it,ru,zh-Hans,zh-Hant,ko}}})
#   出力: PDIndexer\PdiText.cs

import glob, json, os, sys

try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

_THIS = os.path.dirname(os.path.abspath(__file__))
APP = os.path.join(os.path.dirname(_THIS), "PDIndexer")
# 260625Cl: 動的文字列ソースは複数に分割可 (_Dynamic.json=初回22件 / _Dynamic2.json=Phase 2c 追加分 …)。
#   既訳を再翻訳せず追加分だけ別ファイルで翻訳→ここで全 _Dynamic*.json を順に merge して PdiText 化する。
CODE = r"C:\tmp\pdi_i18n\code"
OUT = r"C:\tmp\pdi_i18n\code_out"
# Loc() の引数順 (en は別引数なので除く)。zh-Hans/zh-Hant は C# 引数名 zhHans/zhHant。
LANGS = [("ja", "ja"), ("de", "de"), ("fr", "fr"), ("es", "es"), ("pt", "pt"),
         ("it", "it"), ("ru", "ru"), ("zh-Hans", "zhHans"), ("zh-Hant", "zhHant"), ("ko", "ko")]


def cs_str(s):
    if s is None:
        s = ""
    return '"' + s.replace("\\", "\\\\").replace('"', '\\"').replace("\r", "\\r").replace("\n", "\\n") + '"'


def prop_name(cid):
    return cid[0].upper() + cid[1:]


def main():
    members = []
    total = 0
    for src_path in sorted(glob.glob(os.path.join(CODE, "_Dynamic*.json"))):
        base = os.path.basename(src_path)
        tr_path = os.path.join(OUT, base)
        if not os.path.exists(tr_path):
            print(f"  WARN no translation output for {base}"); continue
        src = json.load(open(src_path, encoding="utf-8"))
        tr = json.load(open(tr_path, encoding="utf-8")).get("translations", {})
        for it in src["items"]:
            cid, en = it["ctrl"], it["en"]
            t = tr.get(cid, {})
            args = [f"en: {cs_str(en)}"]
            for code, argname in LANGS:
                args.append(f"{argname}: {cs_str(t.get(code, ''))}")
            members.append(f"    /// <summary>{prop_name(cid)} ({cid})</summary>")
            members.append(f"    public static string {prop_name(cid)} => Crystallography.Localization.Loc({', '.join(args)});")
            total += 1

    lines = [
        "namespace PDIndexer;",
        "",
        "// 260625Cl 自動生成 (tools/i18n_gen_dynamic.py 由来)。手で編集しない。",
        "// 多言語化 Phase 2a: コード側で実行時に組み立てる動的 UI 文字列の 11 言語訳アクセサ。",
        "// ボタン状態 (Find!/Stop! 等)・進捗フォーマット・MessageBox・日本語only の英語 canonical 化・",
        "// 起動スプラッシュの永続表示。呼び出し側は PdiText.Xxx で参照し、{0}/{1} は string.Format で埋める。",
        "internal static class PdiText",
        "{",
    ]
    lines.extend(members)
    lines.append("}")
    text = "\r\n".join(lines) + "\r\n"
    out = os.path.join(APP, "PdiText.cs")
    open(out, "wb").write(b"\xef\xbb\xbf" + text.encode("utf-8"))
    print(f"wrote {out}: {total} members")


if __name__ == "__main__":
    main()
