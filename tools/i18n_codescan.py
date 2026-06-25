#!/usr/bin/env python3
# 260625Cl 追加: Phase 2 — Localizable=false フォーム/UC の Designer.cs に直書きされた可視文字列
#   (`ctrl.Text = "..."` / `ctrl.HeaderText = "..."` / `this.Text = "..."`) を抽出する。
#   CodeLocalizer(中央レジストリ)で実行時に多言語化する対象を harvest する。記号/単位/プレースホルダ
#   タイトル等の非翻訳文字列は allowlist 規則で除外する。
#
# 使い方: python tools/i18n_codescan.py <Form1> <Form2> ...   (Designer.cs の basename, 拡張子なし)
#   省略時は既定の Localizable=false 3 フォーム。
# 出力:  C:\tmp\pdi_i18n\code\<Form>.json = {"type":"PDIndexer.<Form>","items":[{"ctrl","prop","en"}, ...]}
#        C:\tmp\pdi_i18n\code\_index.json

import glob, json, os, re, sys

try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

_THIS = os.path.dirname(os.path.abspath(__file__))
APP = os.path.join(os.path.dirname(_THIS), "PDIndexer")
OUT = r"C:\tmp\pdi_i18n\code"

DEFAULT_FORMS = ["FormExportGSAS", "FormLimitChanger", "FormLPO"]

# 260625Cl 追加: 実行時にコード側がラベルを書き換える「動的ボタン」は中央レジストリから除外する
#   (CodeLocalizer が初期値を焼き直すと、コード側の Loc() トグル(Find!/Stop! 等)を上書きしてしまうため)。
#   これらは各フォームの inline Loc() で多言語化する。詳細は .project-guidance/PDIndexer_多言語化方針.md Phase 2a。
DYNAMIC_EXCLUDE = {
    "FormCellFinder": {"buttonFind"},                       # Find! ⇄ Stop! をコード側でトグル
    "FormAtomicPositionFinder": {"buttonStart", "buttonResume"},  # Start ⇄ Stop! / Resume を操作状態グループでコード側管理
    "FormTwoThetaCalibration": {"buttonCalibrate", "labelEquation"},  # Calibrate ⇄ Now calibrating… / Shift function 式は実行時に組立 (PdiText)
}

# `<ctrl>.Text = "<literal>";` / `.HeaderText`。this.Text も拾う(ctrl="this")。
_ASSIGN = re.compile(r'(?:this\.)?(\w+)\.(Text|HeaderText)\s*=\s*"((?:[^"\\]|\\.)*)"\s*;')

# 260625Cl 追加: MenuStrip/StatusStrip/ToolStrip の Designer 既定 Text (= コントロール名そのもの。例 "menuStrip1") は
#   画面に出ない非可視文字列なので翻訳対象から除外する。
_CONTAINER_DEFAULT = re.compile(r'(?:menu|status|tool|context)Strip\d*$')


def designer_path(form):
    hits = glob.glob(os.path.join(APP, "**", form + ".Designer.cs"), recursive=True)
    return hits[0] if hits else None


def is_translatable(text, form):
    if not text or text.isspace():
        return False
    t = text.encode("utf-8").decode("unicode_escape") if "\\" in text else text
    if t == form:                      # プレースホルダタイトル ("FormLPO" 等) は除外
        return False
    if _CONTAINER_DEFAULT.fullmatch(t):  # 260625Cl: MenuStrip/StatusStrip 等の既定 Text (= コントロール名) は非可視のため除外
        return False
    if not re.search(r"[A-Za-zÀ-ɏ]{2,}", t):  # 2文字以上の語が無い (記号/単位/単文字) は除外
        return False
    return True


def main():
    forms = sys.argv[1:] or DEFAULT_FORMS
    os.makedirs(OUT, exist_ok=True)
    index = []
    for form in forms:
        path = designer_path(form)
        if not path:
            print(f"  WARN Designer not found: {form}"); continue
        src = open(path, encoding="utf-8-sig").read()
        exclude = DYNAMIC_EXCLUDE.get(form, set())  # 260625Cl: 動的ボタンは inline Loc() 側で扱うので registry から除外
        seen = set()
        items = []
        for m in _ASSIGN.finditer(src):
            ctrl, prop, lit = m.group(1), m.group(2), m.group(3)
            # `this.Text` は m.group(1) が直前トークン (Text の前) を拾えないので個別処理
            key = (ctrl, prop)
            if key in seen:
                continue
            if ctrl in exclude:        # 260625Cl: 動的ボタン (Find!/Stop!/Start/Resume) を除外
                continue
            if not is_translatable(lit, form):
                continue
            seen.add(key)
            items.append({"ctrl": ctrl, "prop": prop, "en": lit})
        # this.Text (フォームタイトル) を別途拾う
        for m in re.finditer(r'this\.Text\s*=\s*"((?:[^"\\]|\\.)*)"\s*;', src):
            lit = m.group(1)
            if ("this", "Text") in seen or not is_translatable(lit, form):
                continue
            seen.add(("this", "Text"))
            items.append({"ctrl": "this", "prop": "Text", "en": lit})
        rec = {"type": f"PDIndexer.{form}", "form": form, "designer": path, "items": items}
        json.dump(rec, open(os.path.join(OUT, form + ".json"), "w", encoding="utf-8"), ensure_ascii=False, indent=1)
        index.append({"form": form, "type": rec["type"], "count": len(items)})
        print(f"  {form:<24} {len(items)} translatable")
    json.dump({"forms": index}, open(os.path.join(OUT, "_index.json"), "w", encoding="utf-8"), ensure_ascii=False, indent=1)
    print(f"scanned {len(index)} forms -> {OUT}")


if __name__ == "__main__":
    main()
