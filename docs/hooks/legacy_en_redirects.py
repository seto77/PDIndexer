# 260625Cl: 旧英語マニュアル URL (/PDIndexer/en/<slug>/) を、static-i18n 移行後の
# 新ルート URL (/PDIndexer/<slug>/) へ逃がす post-build フック (ReciPro 版を PDIndexer 向けに移植)。
#
# 背景: 多言語化で mkdocs-static-i18n を導入し、default locale (en) をサイトルートへ出すようにした。
#   これにより英語ページの公開 URL が /PDIndexer/en/<slug>/ → /PDIndexer/<slug>/ へ移動する。
#   旧 /en/ URL は約3週間公開済みで、アプリ F1 ヘルプ・README・ブックマーク・検索エンジン索引が指している。
#
# なぜ mkdocs-redirects でなくフックか (ReciPro 実測で確定, 2026-06-22):
#   mkdocs-redirects の redirect target URL 算出は static-i18n の「再ホーム前」の名前空間に固定されており、
#   value `en/foo.md` は死 URL /en/foo/ に解決される (KEY==VALUE では url=./ の自己参照ループになる)。
#   → 英語の /en/→ルート 互換は mkdocs-redirects では張れない。PDIndexer は JA リネーム履歴が無いので
#     redirects プラグインは空 (将来用)。本フックの責務は「過去の英語 URL 互換の静的 meta-refresh stub 生成」だけ。

from pathlib import Path
import html
import os

import mkdocs.plugins

# 旧英語リネーム履歴: /PDIndexer/en/<旧slug>/ → /PDIndexer/<新slug>/。
# PDIndexer のマニュアルは 2026-05-31 に現行 slug で新規作成され、以後リネームしていないため空。
# (将来ページをリネームして旧 /en/ URL を救済する必要が出たら、ここに {旧slug: 新slug} を足す。)
LEGACY_EN_RENAMES = {}

# サイトルート直下で、言語ディレクトリや生成物として扱う (= 英語ルートページではない) トップ階層。
# mkdocs.yml の i18n.languages の locale 名と一致させること (新言語追加時はここにも足す)。
_RESERVED_TOP = {
    "en", "ja", "de", "fr", "es", "pt", "it", "ru",
    "zh-Hans", "zh-Hant", "ko",
    "assets", "search",
}

_STUB = (
    "<!doctype html>\n"
    '<html lang="en"><head><meta charset="utf-8">\n'
    '<meta http-equiv="refresh" content="0; url={url}">\n'
    '<link rel="canonical" href="{url}">\n'
    "<script>location.replace({url_js}+location.search+location.hash)</script>\n"
    '<title>Redirecting…</title></head><body>\n'
    '<a href="{url}">This page has moved. Redirecting…</a>\n'
    "</body></html>\n"
)


@mkdocs.plugins.event_priority(-100)  # 他プラグイン (mkdocs-redirects 等) の on_post_build の後に走らせる
def on_post_build(config):
    site = Path(config.site_dir).resolve()
    en_dir = site / "en"

    def write_redirect(source_slug, target_slug):
        dest_dir = (en_dir / source_slug) if source_slug else en_dir
        target_dir = (site / target_slug) if target_slug else site
        target_index = target_dir / "index.html"
        if not target_index.exists():
            raise RuntimeError(f"legacy_en_redirects: target missing for /en/{source_slug}/ -> /{target_slug}/")

        dest_index = dest_dir / "index.html"
        rel = os.path.relpath(target_dir, dest_dir).replace("\\", "/")
        if rel == ".":
            # 自己参照 (無限リロード) を絶対に作らない。foo.md→foo/index.md 罠の一般化。
            raise RuntimeError(f"legacy_en_redirects: self-loop for /en/{source_slug}/")
        url = (rel.rstrip("/") + "/") if rel != ".." else "../"
        dest_dir.mkdir(parents=True, exist_ok=True)
        dest_index.write_text(
            _STUB.format(url=html.escape(url), url_js=repr(url)), encoding="utf-8"
        )

    # (1) 現行の全英語ルートページ: /en/<slug>/ → /<slug>/ (将来追加ページも自動で互換 alias を持つ)。
    written = 0
    for index in sorted(site.rglob("index.html")):
        rel = index.relative_to(site)
        if rel.parts[0] in _RESERVED_TOP:
            continue
        slug = "" if rel.parts == ("index.html",) else "/".join(rel.parts[:-1])
        write_redirect(slug, slug)
        written += 1

    # (2) 旧英語リネーム履歴: /en/<旧slug>/ → /<新slug>/。
    for old_slug, new_slug in LEGACY_EN_RENAMES.items():
        write_redirect(old_slug, new_slug)

    mkdocs.plugins.log.info(
        "legacy_en_redirects: wrote %d current + %d legacy /en/ redirect stubs",
        written, len(LEGACY_EN_RENAMES),
    )
