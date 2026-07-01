#!/usr/bin/env python3
# 260617Cl 追加 (ReciPro tools より PDIndexer へ移植 260625Cl): 多言語化 Phase 1/3 用 —
#   neutral resx と {key: 訳文} JSON から text-only な culture resx を生成する。
#   方針: 新言語 culture resx は text-only (Size/Location/Font を持たない=neutral フォールバック)。
#   .Text/.HeaderText 等の翻訳済み文字列だけを書き出し、utf-8-bom + crlf (.editorconfig) を保証する。
#   検証: 出力後 tools/check_resx_textonly.py が PASS することを前提 (禁止プロパティを書かない)。
#
# 使い方:  python tools/gen_de_resx.py <neutral.resx> <translations.json> <out.de.resx> [--lang de]
#   translations.json = { "<control>.Text": "<訳>", ... }  (neutral に存在する key のみ。値が空/None はスキップ)
#   neutral.resx に無い key、または neutral 値と同一の訳は警告して書かない (取りこぼし/未翻訳の検出)。
import sys, json, xml.etree.ElementTree as ET
from xml.sax.saxutils import escape

# Windows コンソール (cp932) で警告に Å/Cyrillic 等の非 cp932 文字があると print が
#   UnicodeEncodeError でクラッシュする。UTF-8 出力に固定する。
try:
    sys.stdout.reconfigure(encoding="utf-8")
except Exception:
    pass

HEADER = '''<?xml version="1.0" encoding="utf-8"?>
<root>
  <!-- {comment} -->
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
'''

def main():
    if len(sys.argv) < 4:
        print("usage: gen_de_resx.py <neutral.resx> <translations.json> <out.resx> [--lang de]"); sys.exit(2)
    neutral, jpath, out = sys.argv[1], sys.argv[2], sys.argv[3]
    lang = "de"
    if "--lang" in sys.argv: lang = sys.argv[sys.argv.index("--lang")+1]
    nroot = ET.parse(neutral).getroot()
    ndata = {d.get("name"): (d.find("value").text if d.find("value") is not None else "") for d in nroot.findall("data")}
    trans = json.load(open(jpath, encoding="utf-8"))
    body, written, warn = [], 0, []
    for k, v in trans.items():
        if v is None or v == "":
            continue
        if k not in ndata:
            warn.append(f"  WARN key not in neutral: {k}"); continue
        if v == ndata[k]:
            warn.append(f"  WARN identical to neutral (untranslated?): {k} = {v!r}"); continue
        body.append(f'  <data name="{escape(k)}" xml:space="preserve">\n    <value>{escape(v)}</value>\n  </data>')
        written += 1
    comment = (f"260625Cl: 多言語化 Phase1/3 ({lang}) text-only リソース。"
               f"レイアウト(Size/Location/Font)は neutral へフォールバック。"
               f"結晶学/回折用語は IUCr Online Dictionary 準拠。")
    text = HEADER.format(comment=comment) + "\n".join(body) + "\n</root>\n"
    text = text.replace("\r\n", "\n").replace("\n", "\r\n")
    open(out, "wb").write(b"\xef\xbb\xbf" + text.encode("utf-8"))
    print(f"wrote {written} entries -> {out}")
    for w in warn: print(w)

if __name__ == "__main__":
    main()
