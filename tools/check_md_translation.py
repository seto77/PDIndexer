#!/usr/bin/env python3
# 260627Cl 追加: Pages マニュアル多言語化 (Phase 4) の翻訳検証ハーネス。ReciPro 版 (tools/check_md_translation.py) を移植。
#   英語の原文 (docs/src/en/<slug>.md) と訳文 (docs/src/<lang>/<slug>.md) を突き合わせ、
#   「prose だけ訳し、コード・数式・リンク・画像パス・アンカー・frontmatter は凍結」が守れているかを機械チェックする。
#   方針の正本は .project-guidance/PDIndexer_Pages編集方針.md と ReciPro 側 ReciPro_Pages多言語化計画.md §4.2。
#
#   mkdocs build --strict はアンカー切れ (既定 info) を捕まえないため、このスクリプトが一次防衛線。
#   使い方:
#     python tools/check_md_translation.py --lang de                 # de 全訳ページを en と照合
#     python tools/check_md_translation.py --lang de --page index.md # 1 ページだけ
#     python tools/check_md_translation.py --src docs/src/en/index.md --dst docs/src/de/index.md
#   いずれかのゲートで不一致があれば非ゼロ終了 (CI 化可能)。
import argparse
import re
import sys
from collections import Counter
from pathlib import Path

# Windows コンソール (cp932) でも日本語の診断文を化けさせない
try:
    sys.stdout.reconfigure(encoding="utf-8")
    sys.stderr.reconfigure(encoding="utf-8")
except Exception:
    pass

REPO = Path(__file__).resolve().parent.parent
SRC_ROOT = REPO / "docs" / "src"

# --- 凍結要素の抽出関数群 -----------------------------------------------------
# いずれも「順序を問わない集合」または「個数」で比較する。訳すと順序は変わり得るが、
# コード片・数式・リンク先・画像パスの「集合」と「総数」は不変であるべき、という考え。

FENCE_RE = re.compile(r"^(\s*)(```|~~~)", re.MULTILINE)          # コードフェンス開始/終了行 (個数用)
FENCE_BLOCK_RE = re.compile(r"```.*?```|~~~.*?~~~", re.DOTALL)    # フェンスブロック全体 (除去用)
INLINE_CODE_RE = re.compile(r"`[^`\n]+`")                          # インラインコード `...`
# 数式 (arithmatex generic 前提): $$...$$ ブロック / $...$ inline / \[...\] / \(...\)。
#   個数だけでなく「中身」を凍結対象として multiset 比較する (訳で文を組み替えても LaTeX は不変であるべき)。
MATH_BLOCK_RE = re.compile(r"\$\$(.+?)\$\$", re.DOTALL)
MATH_BRACKET_RE = re.compile(r"\\\[(.+?)\\\]", re.DOTALL)
MATH_INLINE_DOLLAR_RE = re.compile(r"(?<![\$\\])\$(?!\$)(.+?)(?<!\\)\$(?!\$)")
MATH_INLINE_PAREN_RE = re.compile(r"\\\((.+?)\\\)", re.DOTALL)
# 画像 ![alt](path)  ※ alt は訳してよいので path だけ取る
IMAGE_RE = re.compile(r"!\[[^\]]*\]\(([^)\s]+)(?:\s+[^)]*)?\)")
# 通常リンク [text](target)  ※ ! が直前に無いもの。text は訳す、target は凍結
LINK_RE = re.compile(r"(?<!!)\[[^\]]*\]\(([^)\s]+)(?:\s+\"[^\"]*\")?\)")
# 自動リンク <https://...>
AUTOLINK_RE = re.compile(r"<((?:https?|mailto):[^>\s]+)>")
# 明示アンカー {#id ...} / {: #id } / { #id } (attr_list は空白・コロンを許容)
ANCHOR_RE = re.compile(r"\{:?\s*#([A-Za-z0-9_\-:.]+)")
# 見出し行 (構造の本数)
HEADING_RE = re.compile(r"^#{1,6}\s", re.MULTILINE)
# cap-<culture>-auto/manual のカルチャトークン (画像 retarget の健全性確認用)
CAP_RE = re.compile(r"cap-([a-zA-Z-]+)-(auto|manual)")


def split_frontmatter(text):
    """先頭 YAML frontmatter (--- ... ---) を (keys_set, body) に分解。無ければ (set(), text)。"""
    if text.startswith("---\n") or text.startswith("---\r\n"):
        m = re.search(r"^---\r?\n(.*?)\r?\n---\r?\n", text, re.DOTALL)
        if m:
            keys = set(re.findall(r"^([A-Za-z0-9_\-]+)\s*:", m.group(1), re.MULTILINE))
            return keys, text[m.end():]
    return set(), text


def normalize_cap(paths):
    """画像パスの cap-<culture>-auto を cap-<X>-auto に潰す。
    言語間で cap dir は意図的に変わる (cap-en-auto→cap-de-auto) ので、retarget 後も
    '構造は同じ' を判定できるようにするための正規化。"""
    return {CAP_RE.sub(r"cap-X-\2", p) for p in paths}


def extract_math(body):
    """数式を種類別に取り出し、中身 (空白正規化) の multiset を返す。順に $$..$$ → \\[..\\] → $..$ → \\(..\\)。
    先に抽出したものは本文から除去し、後段が境界を二重に拾わないようにする。"""
    def norm(s):
        return re.sub(r"\s+", " ", s.strip())
    blocks = [norm(x) for x in MATH_BLOCK_RE.findall(body)]
    body = MATH_BLOCK_RE.sub(" ", body)
    brackets = [norm(x) for x in MATH_BRACKET_RE.findall(body)]
    body = MATH_BRACKET_RE.sub(" ", body)
    inlines = [norm(x) for x in MATH_INLINE_DOLLAR_RE.findall(body)]
    body = MATH_INLINE_DOLLAR_RE.sub(" ", body)
    parens = [norm(x) for x in MATH_INLINE_PAREN_RE.findall(body)]
    return Counter(blocks + brackets + inlines + parens)


def analyze(text):
    keys, body = split_frontmatter(text)
    # 数式・リンク・画像はコード (フェンス/インライン) の外側だけを見る。
    # コード内の $ や [..](..) を数式・リンクと誤認しないため (例: マクロ頁の `$` プレースホルダ)。
    nocode = INLINE_CODE_RE.sub(" ", FENCE_BLOCK_RE.sub(" ", body))
    return {
        "frontmatter_keys": keys,
        "fence_count": len(FENCE_RE.findall(body)),
        "inline_code_count": len(INLINE_CODE_RE.findall(body)),
        "math": extract_math(nocode),
        "images": [m for m in IMAGE_RE.findall(nocode)],
        "links": set(LINK_RE.findall(nocode)),
        "autolinks": set(AUTOLINK_RE.findall(body)),
        "anchors": set(ANCHOR_RE.findall(body)),
        "heading_count": len(HEADING_RE.findall(body)),
        "cap_cultures": {c for c, _ in CAP_RE.findall(body)},
    }


def check_pair(src_path, dst_path, lang):
    src = src_path.read_text(encoding="utf-8")
    dst = dst_path.read_text(encoding="utf-8")
    a, b = analyze(src), analyze(dst)
    fails = []

    def eq(name, label):
        if a[name] != b[name]:
            fails.append(f"{label}: en={a[name]!r} != {lang}={b[name]!r}")

    eq("frontmatter_keys", "frontmatter キー")
    eq("fence_count", "コードフェンス数")
    eq("heading_count", "見出し本数")
    eq("anchors", "明示アンカー {#...} 集合")

    # 数式: 中身 (LaTeX) の multiset 一致。訳で文が組み替わっても数式は凍結なので不変であるべき。
    if a["math"] != b["math"]:
        only_en = a["math"] - b["math"]
        only_x = b["math"] - a["math"]
        if only_en:
            fails.append(f"数式 (en のみ, {sum(only_en.values())} 件): {list(only_en)[:5]}")
        if only_x:
            fails.append(f"数式 ({lang} のみ, {sum(only_x.values())} 件): {list(only_x)[:5]}")

    # 画像パス: cap カルチャを正規化した集合 (+ 多重度) で比較
    if normalize_cap(set(a["images"])) != normalize_cap(set(b["images"])):
        fails.append(f"画像パス集合 (cap 正規化後): en={sorted(normalize_cap(set(a['images'])))} != "
                     f"{lang}={sorted(normalize_cap(set(b['images'])))}")
    if len(a["images"]) != len(b["images"]):
        fails.append(f"画像参照の総数: en={len(a['images'])} != {lang}={len(b['images'])}")

    # リンク先・自動リンク: 完全一致 (訳してはいけない)
    if a["links"] != b["links"]:
        only_en = a["links"] - b["links"]
        only_x = b["links"] - a["links"]
        fails.append(f"リンク先集合: en のみ={sorted(only_en)} / {lang} のみ={sorted(only_x)}")
    if a["autolinks"] != b["autolinks"]:
        fails.append(f"自動リンク集合: en={sorted(a['autolinks'])} != {lang}={sorted(b['autolinks'])}")

    # cap カルチャの混入: 訳ページ側の cap トークンは lang か、原文と同じ共有 (en にしか無いなら漏れ) を確認
    # en が参照する cap カルチャ = {en} 等。訳側は {lang} へ retarget 済みか、原文に cap が無ければ {} であるべき。
    stray = b["cap_cultures"] - {lang}
    if stray:
        # en 原文が cap を一切持たない (= 共有 references のみ) ページで cap が湧くのは異常
        if not a["cap_cultures"]:
            fails.append(f"cap-<culture> 混入: {lang} ページに {sorted(stray)} が出現 (原文は cap 不使用)")
        else:
            fails.append(f"cap-<culture> retarget 漏れ: {lang} に {sorted(stray)} 残存 (期待は cap-{lang}-*)")

    return fails


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--lang", help="対象言語ディレクトリ (例 de)")
    ap.add_argument("--page", help="単一ページの slug (例 index.md / appendix/algorithms.md)")
    ap.add_argument("--src", help="原文 md パス (個別指定)")
    ap.add_argument("--dst", help="訳文 md パス (個別指定)")
    args = ap.parse_args()

    pairs = []
    if args.src and args.dst:
        pairs.append((Path(args.src), Path(args.dst)))
    elif args.lang:
        lang_root = SRC_ROOT / args.lang
        if args.page:
            pairs.append((SRC_ROOT / "en" / args.page, lang_root / args.page))
        else:
            for dst in sorted(lang_root.rglob("*.md")):
                rel = dst.relative_to(lang_root)
                pairs.append((SRC_ROOT / "en" / rel, dst))
    else:
        ap.error("--lang か --src/--dst を指定してください")

    lang = args.lang or "dst"
    total_fail = 0
    checked = 0
    for src, dst in pairs:
        if not dst.exists():
            continue
        if not src.exists():
            print(f"[SKIP] 原文なし: {src}")
            continue
        checked += 1
        fails = check_pair(src, dst, lang)
        rel = dst.relative_to(SRC_ROOT) if SRC_ROOT in dst.parents else dst
        if fails:
            total_fail += 1
            print(f"[FAIL] {rel}")
            for f in fails:
                print(f"        - {f}")
        else:
            print(f"[ OK ] {rel}")

    print(f"\n{checked} ページ照合, {total_fail} ページ NG")
    sys.exit(1 if total_fail else 0)


if __name__ == "__main__":
    main()
