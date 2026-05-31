// 260531Ch: Retarget the Material language selector to the matching page in the other language.
(function () {
  "use strict";

  var enRoot = "";
  var jaRoot = "";
  var rootsReady = false;

  function ensureRoots() {
    if (rootsReady) return true;
    document.querySelectorAll("a.md-select__link[hreflang]").forEach(function (a) {
      var lang = a.getAttribute("hreflang");
      if (lang === "en" && !enRoot) enRoot = a.getAttribute("href");
      else if (lang === "ja" && !jaRoot) jaRoot = a.getAttribute("href");
    });
    rootsReady = !!(enRoot && jaRoot);
    return rootsReady;
  }

  function targetFor(lang) {
    if (!ensureRoots()) return null;

    var enPrefix = enRoot + "en/";
    var path = window.location.pathname;
    var slug;

    if (path === enRoot || path === jaRoot) slug = "";
    else if (path.indexOf(jaRoot) === 0) slug = path.slice(jaRoot.length);
    else if (path.indexOf(enPrefix) === 0) slug = path.slice(enPrefix.length);
    else return null;

    if (lang === "en") return slug === "" ? enRoot : enPrefix + slug;
    return slug === "" ? jaRoot : jaRoot + slug;
  }

  function retarget() {
    var en = targetFor("en");
    var ja = targetFor("ja");
    document.querySelectorAll("a.md-select__link[hreflang]").forEach(function (a) {
      var lang = a.getAttribute("hreflang");
      if (lang === "en" && en) a.setAttribute("href", en);
      else if (lang === "ja" && ja) a.setAttribute("href", ja);
    });
  }

  document.addEventListener("click", function (ev) {
    var link = ev.target && ev.target.closest && ev.target.closest("a.md-select__link[hreflang]");
    if (!link) return;
    var lang = link.getAttribute("hreflang");
    if (lang !== "en" && lang !== "ja") return;
    var target = targetFor(lang);
    if (!target) return;
    ev.preventDefault();
    window.location.href = target;
  });

  if (typeof window.document$ !== "undefined" && window.document$.subscribe) {
    window.document$.subscribe(retarget);
  } else if (document.readyState !== "loading") {
    retarget();
  } else {
    document.addEventListener("DOMContentLoaded", retarget);
  }
})();
