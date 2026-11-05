<!-- 261105Cl: docs/drafts/261105-cloud — 既存マニュアルとコードの突き合わせ結果 (監査)。docs/src には未統合。 -->
# 第5章 状態方程式 (Equation of states) 監査

> 本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象: `docs/src/ja/5-equation-of-states.md`（以下 ja）, `docs/src/en/5-equation-of-states.md`（以下 en）
照合コード: `PDIndexer/FormEOS.cs`, `PDIndexer/FormEOS.Designer.cs`, `PDIndexer/FormEOS.resx`, `PDIndexer/FormEOS.ja.resx`, `Crystallography/EOS.cs`, `Crystallography/Mathematics/Spline.cs`, `PDIndexer/FormMain.cs`（SetFormEOS）, `PDIndexer/FormSequentialAnalysis.cs`, `Crystallography.Controls/Crystal/EOSControl.cs`

前提:
- `FormEOS.ja.resx` には `.Text` / `HeaderText` / `FooterText` の上書きが**ひとつもない**（ToolTip だけ）。日本語 UI でもグループ名・出典ラベル・ヘッダはすべて英語のまま表示される（例: `Gold`, `Jamieson (82)`, `Temperature`, `T0`）。ウィンドウタイトルは `$this.Text = 'Equation of States'`（FormEOS.resx）。
- en マニュアルは ja と同じ構成・同じ記述で、下表の食い違いはすべて en にも同じように当てはまる（ja/en 間で内容の差は見つからなかった）。
- マニュアル末尾の P–V–T 数表（Au/Pt Jamieson, Au Tsuchiya, Au/Pt Yokoo, NaCl Brown, NaCl Skelton, Re Zha, Ar Ross, Pb Strässle）は、スクリプトで全セルを照合した。コード（`EOS.cs` の各 `double[][]` 表と `FormEOS.cs` の `PbVinet` / `PbA0`）と**全セル一致**（ja/en とも）。Skelton でコメントアウトされている行（0.014, 0.018, …）がマニュアルに載っていないことも確認済み。

---

## 1. 食い違い（マニュアル記述 vs コード）

| # | マニュアル箇所 (file:見出し/行) | マニュアルの記述 | コードの実際 (file:method/line) | 深刻度 |
|---|---|---|---|---|
| 1 | ja:36 / en:36「対応している標準物質」表 | `hBN`（六方晶窒化ホウ素）を選択できる | `checkBoxHBN`（Text=`hBN`）は Designer.cs:1380-1387 で生成されているが、`flowLayoutPanel2.Controls.Add` の対象（Designer.cs 内 checkBoxGold〜checkBoxPb の 10 個）に入っていないため画面に出ない。hBN の groupBox も計算メソッドもない（FormEOS.cs CalculatePressure:62-86, checkBoxGold_CheckedChanged:473-485）。 | 高 |
| 2 | ja:60 / en:60「金（Gold）」 | Au の出典は `Yokoo (09)`、`Matsui (09)`、`Holmes (89)`、`Jamieson (82)`、`Fratanduono (21)` など | Au のラベルは `Jamieson (82)`, `Anderson (89)`, `Sim (02)`, `Tsuchiya (03)`, `Yokoo (09)`, `Fratanduono (21)`（FormEOS.resx label49/22/15/69/19/27, FormEOS.cs Gold():89-116）。`Matsui (09)` と `Holmes (89)` は Pt の出典（label9/label8, Pt():120-148）。 | 高 |
| 3 | ja:66 / en:66「NaCl（B1 構造）」 | `Brown (99)`、`Sakai+`、`Matsui (12)` など | B1 は `Brown (99)`, `Matsui (12)`, `Skelton (84)` の 3 つ（resx label3/label4/label31, NaClB1():228-246）。`Sakai+` は B2（`Sakai+(11) BM`/`Sakai+(11) Vinet`）。Skelton が抜けている。 | 高 |
| 4 | ja:75 / en:75 note「そのほかの物質」 | NaCl (B2) に `Sakai (02)` | B2 のラベルは `Sata (02) (Pt)`, `Sata (02) (Mg)`, `Ueda+(08)`, `Sakai+(11) BM`, `Sakai+(11) Vinet`（resx label6/7/10/11/12）。「Sakai (02)」というものは存在しない。 | 中 |
| 5 | 同上 | コランダムに `Sata (02)` ほか | Al2O3 は `Dubrovinsky (98)` の 1 つだけ（resx label5, Corundum():250-264）。 | 高 |
| 6 | 同上 | Ar に `Dubrovinsky (98)`、`Ross et al. (86)`、`Jephcoat (98)` ほか | Ar は `Ross et al. (86)` と `Jephcoat (98)` の 2 つだけ（resx label14/label17, Ar():152-168）。 | 高 |
| 7 | 同上 | Pt「`Fratanduono (21)`、`Holmes (89)` ほか」、Pb「`Strässle+(14)` ほか」 | Pb は `Strässle+(14)` の 1 つだけで「ほか」はない（resx label32）。Pt は「ほか」で正しい（5 種）。 | 低 |
| 8 | ja:49-50 / en:49-50 tip「温度を考慮した状態方程式」 | 「`Sakai+(11)` の Vinet/BM など、Mie-Grüneisen(-Debye) モデルを用いた式」 | `NaClB2_SakaiBM` / `NaClB2_SakaiVinet`（EOS.cs:434-444）は温度引数がない等温式（BM3 47.00/4.10、Vinet 40.40/5.04、V0=37.73）。MGD を使っているのは Au Sim02, MgO Jackson/Dewaele/Aizawa, NaCl-B1 Matsui12, Pt Matsui09, Mo Huang16（と Tange09・Jephcoat98 の変形）。 | 高 |
| 9 | ja:47 / en:47「入力パラメータ」`T0` 行と tip | `T0` は基準温度で、`Temperature` とあわせて熱圧力の補正に使う | `numericBoxTemperature0` を読むのは `Pt_Matsui`（FormEOS.cs:126,134）と `Pb()`（FormEOS.cs:431-434）だけ。ほかの式の基準温度はコード内に固定されている: Sim/Jackson/Dewaele/Aizawa/Huang/Matsui12=300（FormEOS.cs:99,178-182,301; EOS.cs:479）、Tange=300（EOS.cs:347,366）、Anderson/Holmes/Ueda=300（EOS.cs:417,457,490）、Dubrovinsky T0=300（EOS.cs:532）、Zhao `T0 = 300`（FormEOS.cs:313）、Jephcoat T0=4 K（EOS.cs:1210）。ToolTip（resx `numericBoxTemperature0.ToolTip`）にも "used by the Pt (Matsui) and Pb models" とある。 | 中 |
| 10 | ja:45 / en:45「入力パラメータ」`a0`/`V0` 行、ja:14 手順 3 | `a0`/`V0` を入力して計算に使う | 入力しても使われない欄がある: Ar の `a0`（`numericBoxArA0`）は Ross/Jephcoat のどちらにも渡されない（FormEOS.cs:154-160。Jephcoat の V0=22.557/100 は EOS.cs:1208 に固定）。NaCl B2 の `a0`（`numericalTextBoxNaClB2A0`）は ReadOnly（Designer.cs:862）で、値は計算されるが使われない（Sata は V0=27.17、Ueda は 24.76 cm³/mol、Sakai は 37.73 Å³ がいずれも固定: EOS.cs:423,450,437,443）。Re の `V0` は Zha だけが使い、Anz/Sakai/Dub は固定 V0（29.467/29.47/29.46）を使う（FormEOS.cs:274-280）。ToolTip には同じ説明がある。 | 中 |
| 11 | ja:12 / en:12 手順 1 | 上部のチェックボックスで物質を選ぶ | FormEOS のチェックボックスを操作すると groupBox の表示は切り替わる（checkBoxGold_CheckedChanged:473-485）。ただし `FormMain.SetFormEOS()`（FormMain.cs:2795-2844）が、結晶リスト 1〜10 行目（予約結晶）のチェック状態でチェックボックスを毎回上書きする（`formEOS.checkBoxGold.Checked = dataSet.DataTableCrystal.GetItemChecked(1)` など）。そのため実質的な選択はメイン画面結晶リストのチェックで決まる（Version.cs:198 ver3.811「MainForm側でチェックした結晶のみ表示」）。 | 中 |
| 12 | ja:14 / en:14 手順 3 | `a`/`V` を直接入力して計算できる | 入力は可能。ただし SetFormEOS が呼ばれるたびに、チェックされている予約結晶の格子定数 `A*10`（Å）または体積 `Volume*1000`（Å³）で上書きされる（FormMain.cs:2804-2840）。`a0`/`V0`/`T`/`T0` は結晶リストから来ず、レジストリに保存・復元される（FormMain.cs:1195-1206）。 | 低 |
| 13 | ja:169 / en:169 Pt Matsui09 | 電子熱圧 Pel は「温度の 3 次多項式（基準 300 K で約 0.04 GPa）」 | `Pel = -1.01162E-11 T³ + 1.89796E-07 T² + 6.73266E-05 T - 3.70065E-02`（EOS.cs:522）。コメント（EOS.cs:520）は「PelT (the difference from the value at 300 K of 0.04 GPa) = 0.21, 1.60, 3.78 GPa at 1000, 3000, 5000 K」。多項式は T=300 で ≈0.000 GPa、1000 K で 0.21 GPa になる。つまり 300 K 値（0.04 GPa）からの差分を近似したもので、300 K での値は約 0。また Pel は T0 欄に依存しない（Eth0 だけが T0 欄を使う）。 | 中 |
| 14 | ja:210 / en:210 NaCl-B1 Skelton84、ja:463 表見出し | スプライン補間の温度範囲 T=0–298 K | 実行時に使われるのは焼き込み済みの `SplineNaClB1Skelton`（EOS.cs:1027-1039）で、要素は 10 本（T=40,60,…,298）しかない。0 K 列は含まれない（`Table_NaClB1_Skelton` は 11 列だがこのメソッドからは参照されない。EOS.cs:1041-1046 は lazy 初期化なし）。各スプラインの節点値は表の同じ T の列と一致することを確認済み。40 K 未満は温度方向スプラインの外挿（線形）になる。 | 中 |
| 15 | ja:112 / en:112 等温圧縮項 | BM3/Vinet のほか「BM4、AP2、Keane も選択できる」 | `IsothermalPressure` 列挙は `BM3, BM4, Vinet, Vinet3, AP2, Keane`（EOS.cs:11-14）。3 次 Vinet（`Vinet3rd`, EOS.cs:302-309）が抜けている（ver4.392 で追加、Version.cs:82）。なお本章 FormEOS 自体はこれを選ぶ UI を持たず、選択肢は Crystal 情報の EOS タブ（EOSControl.cs:108-116）にある。 | 低 |
| 16 | ja:142,254 / en 同 | 「2 段の 3 次スプライン」補間。空欄は補間に使用しない | 説明は正しいが、`Spline.GetSpline` の端点条件は両端で 3 次・2 次係数を 0 にするもの（Spline.cs:303-307、自然スプライン相当）。範囲外は**線形外挿**になる（GetValue:151-163）。表の範囲外（例: Au Yokoo の x=0 で 2500 K 以上は空欄）や温度範囲外でも警告なしに外挿値が出ることが書かれていない。 | 低 |
| 17 | ja:4 / en:4 冒頭 | ツールバーの `Equation of States`（状態方程式）アイコン | ツールバーボタンの表示文字列は EN `Equation of\n State (E)`、JA `状態\n方程式 (E)`（FormMain.resx:3397 / FormMain.ja.resx:412）。`Equation of States` はウィンドウタイトル（FormEOS.resx `$this.Text`）。 | 低 |
| 18 | ja:56〜 / en「物質ごとの出典」小見出し・各表 | 出典名を `Anz` / `Sakai` / `Dub` と記載 | 実際の UI ラベルは `Anz (##)`, `Sakai. (##)`, `Dub. (##)`（年が "##" のまま; resx label24/25/26）。ToolTip ではそれぞれ Anzellini / Sakai / Dubrovinsky とされている。 | 低 |

---

## 2. マニュアル未記載の機能・設定

| # | 機能/コントロール (UI 英/日ラベル) | 実装箇所 | 概要 (既定値・単位を含む) |
|---|---|---|---|
| 1 | 各入力欄の既定値 | FormEOS.Designer.cs（Value 設定行） | Au `a`/`a0` = 4.07825 Å (553,567)、Pt 3.9231 Å (293,307)、NaCl-B1 5.639 Å (411,425)、NaCl-B2 `a` 2.93 Å (850)、MgO 4.2112 Å (709,728)、Al2O3 `V`/`V0` 255.89472 Å³ (907,926)、Ar `a` 4.0786 Å (995)、Re `V`/`V0` 29.42795 Å³ (1118,1137)、Mo 31.14 Å³ (1196,1215)、Pb 4.95059 Å (1253,1272)、`Temperature` 300 K (1407)、`T0` 300 K (326)。Ar `a0` と NaCl-B2 `a0` には Value の設定行がない。 |
| 2 | 結晶リストとの対応（固定インデックス） | FormMain.cs SetFormEOS:2795-2844 | 結晶リストの 1=Au, 2=Pt, 3=NaCl B1, 4=NaCl B2, 5=MgO, 6=Al2O3, 7=Ar, 8=Re, 9=Mo, 10=Pb。Au/Pt/NaCl/MgO/Ar/Pb は `A*10`（nm→Å）を `f5` 書式で、Al2O3/Re/Mo は `Volume*1000`（nm³→Å³）を渡す。ピンク行は `Reserved` 結晶（`cellStyle2.BackColor = Color.LightPink`, FormMain.cs:922,3757-3759）。 |
| 3 | 表示中の物質だけを計算 | FormEOS.cs CalculatePressure(onlyVisible=true):62-86 | 計算されるのは groupBox が Visible のものだけ。`Mo`/`Pb` の groupBox は resx で `Visible=False` が初期値（チェック時に表示）。 |
| 4 | 逐次解析との連携 | FormSequentialAnalysis.cs:94-118, 229-236 | 選択結晶が予約結晶 1〜10 のときは、FormEOS の該当メソッド（Gold() など）が返す全出典の圧力を `Pressure` タブに列として出力し、EOS ウィンドウを自動で開く（`toolStripButtonEquationOfState.Checked = true`）。それ以外の結晶では `crystal.EOSCondition.GetPressure(Volume*1000)` を使う。 |
| 5 | マクロ API | Macro.cs:472-480 | `PDI.Crystal.CellVolume`（Å³）、`PDI.Crystal.Pressure(volume=0)` は結晶個別の EOS（EOSCondition）から計算した値で、FormEOS の固定出典は使わない。 |
| 6 | キーボードショートカット | FormMain.cs:4775 / Version.cs:400 | `Ctrl + Shift + E` で Equation of State ウィンドウを開閉する。 |
| 7 | 設定の保存 | FormMain.cs:1061-1063, 1195-1206 | ウィンドウ位置と `Ar_a0, Al2O3_v0, Au_a0, MgO_a0, NaCl_a0, Pt_a0, Mo_v0, Re_v0, Pb_a0, Temperature0, Temperature` をレジストリに保存・復元する。 |
| 8 | F1 ヘルプ | FormEOS.cs:38 | `HelpPage = "5-equation-of-states"`。F1 キーで本章のオンラインマニュアルを開く。 |
| 9 | Pb: T0 での a0 スケーリング | FormEOS.cs Pb():433-436 | `a0(T) = (a0入力 / a0表(T0)) × a0表(T)`。入力した `a0` を `T0` における値とみなして内蔵 a0(T) 表を比例補正する。B, B' は T で線形補間（MathNet `Interpolate.Linear`）。式は Vinet `P = 3B(1-x)/x² exp[1.5(B'-1)(1-x)]`、x = a/a0(T)（FormEOS.cs:441）。マニュアルには「線形補間」とだけあり、T0 を使ったこのスケーリングが書かれていない。 |
| 10 | Ar Jephcoat の固定 V0 | EOS.cs Ar_Jephcoat:1197-1220 | V0 = 22.557 cm³/mol 固定、Z=4。モル体積 V = a³·6.0221367/Z（a は nm, 単位 100 cm³/mol）。 |
| 11 | NaCl B2 Ueda08 の固定 V0 | EOS.cs NaClB2_Ueda:447-460 | V0 = 24.76 cm³/mol（= 24.76/6.0221367×10 ≈ 41.115 Å³/cell）固定。マニュアルの表は K0/K0' だけで V0 の記載がない。 |
| 12 | MGD 系の Z（式量数/胞） | FormEOS.cs:99,178-182,301; EOS.cs:479 | Sim02 Z=4,n=1；MgO 3 種 Z=4,n=2；Matsui12 Z=4,n=2；Huang16 Z=2,n=1；Tange Z=4,n=2（EOS.cs:339,365）；Pt Matsui Z=4（EOS.cs:507）。マニュアル記号表（ja:85-98）には Z がない（V→Vm 換算に必要）。 |
| 13 | 誤差伝播はない | FormEOS.cs 全体, FormMain.cs SetFormEOS | FormEOS に渡るのは格子定数・体積の値だけで、誤差（`A_err`, `Volume_err`）は渡らず、圧力の誤差も計算・表示されない。逐次解析は `V_err` を出力するが（FormSequentialAnalysis.cs:220）、圧力列は値だけ。 |
| 14 | ToolTip（ja/en） | FormEOS.resx / FormEOS.ja.resx `*.ToolTip` | 全入力欄・結果欄に ToolTip がある（使われない a0 の注記を含む）。 |
| 15 | 3 次 Vinet（Crystal EOS タブ側） | EOS.cs Vinet3rd:302-309, GetPressure:136 | `P = 3K0 (1-y)/y² exp[η(1-y) + β(1-y)² + ψ(1-y)³]`、y=(V/V0)^{1/3}。パラメータは `Vinet3rd_Ita/Beta/Psi`。 |

---

## 3. 実装上の疑問点

1. **hBN チェックボックスが残っている**（Designer.cs:156, 1380-1387, 1618）。フォームのコンテナに追加されておらず、計算処理もない。未完成の機能が残っているように見える。マニュアルはこれを「対応物質」として記載している（§1-#1）。
2. **`EOS.GetPressure` の T_dependence_BM 分岐に `Vinet3` の case がない**（EOS.cs:157-165）。ThermalPressure=T_dependence_BM と Vinet3 を組み合わせると `_ => 0` に落ち、圧力が 0 になる。MieGruneisen 分岐（EOS.cs:136）には case がある。
3. **Debye 積分 `integ` の分点がずれている**（EOS.cs:315-328）。`for i=1..num` で `z = (i + 0.5) * x / num` としているため、区間 [Δ, x+Δ]（Δ=x/100000）の中点和になっている（正しい中点則なら i=0..num-1 で (i+0.5)、または i=1..num で (i-0.5)）。相対誤差は ~1e-5 程度で実用上は無視できるが、系統的なずれではある。
4. **`MieGruneisen`（9 引数版）の XML コメントは v0/v を "nm^3" としている**（EOS.cs:178-179）が、`/100` で GPa にする換算は Å³ を前提にしている（V[Å³]×6.0221367/Z → ×1e-7 m³/mol なので γE/V×1e7 Pa = ×1e-2 GPa）。実際に FormEOS は Å³ を渡しており（FormEOS.cs:91-92 の v=a³, a[Å]）、EOSControl も `Volume*1000`（Å³）を渡す（EOSControl.cs:134）ので計算は正しい。コメントだけが誤り。
5. **`GetPressure` の MGD で Q=0 のとき** `(Gamma0 - gamma)/Q` が NaN になり、`double.IsNaN(deltaPth) ? Pst` によって熱圧項が警告なしに捨てられる（EOS.cs:143,149）。
6. **基準温度の扱いが式ごとにばらばら**（§1-#9）。Pt Matsui では Eth0 だけが T0 欄を使い、Pel は 300 K 基準のまま（EOS.cs:518,522）。T0≠300 にすると不整合になる。
7. **Skelton の焼き込みスプラインに 0 K 列が入っていない**（§1-#14）。表データ（`Table_NaClB1_Skelton`）を変えてもスプラインには反映されない。ほかの材料は「null なら InitializeSpline」の lazy 化に移行済み（EOS.cs:618-621 など）だが、Skelton と Ross（`SplineRossAr`, EOS.cs:1188-1195）は焼き込みのまま。ほかの焼き込みスプライン（Au/Pt Jamieson, Brown, Tsuchiya, Zha, Au/Pt Yokoo）は、節点値が表と一致することをスクリプトで確認した（最大偏差 <1e-6）。
8. **ToolTip の物理的な誤り**: `numericBoxTemperature.ToolTip`（en: "raising T adds thermal pressure and lowers the computed P"、ja: 「温度を上げると熱圧力が加わり算出圧力 P は下がります」）。同じ V で T を上げると熱圧項 ΔPth>0 が加わるので、コード上 P は上がる（例: EOS.cs:149 `deltaPth + Pst`）。
9. **未使用のコード**: `MgO_Jamieson` + `MgOJamieson` 表（EOS.cs:696-767）、`NaClB1_Sata`（EOS.cs:426-431）、`InverseThirdBirchMurnaghan`（EOS.cs:269-291）、Yokoo 型の `MieGruneisen`（11 引数版, EOS.cs:211-227）は、リポジトリ内のどこからも呼ばれていない。
10. `Corundum_Dubrovinsky` と `GetPressure`（T_dependence）は `1/T` を含むので、T=0 で発散する（EOS.cs:539,155）。入力チェックはない。
11. Pb の B, B' 表は 0–300 K、a0 表は 0–310 K しかない。範囲外の T をそのまま MathNet の線形補間に渡している（FormEOS.cs:424-439）。範囲外の扱いは §4 を参照。

---

## 4. 要確認事項

1. hBN をマニュアルから削除するか、実装予定があるか（§1-#1, §3-1）。
2. Pt Matsui09 の Pel の意味（300 K 値からの差分か）を、マニュアルでどう表現するか。著者に確認したい（§1-#13）。
3. Skelton84 で 0 K 列を使わないのは意図的か（§1-#14）。
4. Ar `a0` / NaCl-B2 `a0` の初期値（Designer に Value がない）が 0 になるのか。レジストリ復元前の表示値は未確認。
5. MathNet `Interpolate.Linear` が範囲外で外挿するのか、端の値で止めるのか（Pb の T>300 K / T>310 K）。ライブラリの挙動はリポジトリ内では確認できない。
6. 逐次解析で予約結晶がメイン画面でチェックされていないと、SetFormEOS が FormEOS の `a`/`V` を更新しない（FormMain.cs:2804 以降は `if (… = GetItemChecked(n))` の中でだけ代入している）。そのため古い値で圧力が出力される可能性がある。逐次解析の対象結晶は常にチェック済みなのかを確認したい。
7. Sata02（NaCl B2）の V0=27.17 Å³ と、Sakai11 の V0=37.73 Å³ / Ueda08 の V0≈41.11 Å³ の物理的な意味の違い（基準状態が違うのか）。コードにはコメントがない。マニュアルで「V0」とまとめて書いてよいか。
8. Re の出典ラベル `Anz (##)` などの年が未記入。マニュアルに年を書くには原典の確認が必要。

---

## 5. 補足: 下書き用素材

### 5.1 実装どおりの式（確認済み）
- BM3: `1.5 K0 (x^{7/3} − x^{5/3}) [1 − 0.75(4 − K')(x^{2/3} − 1)]`、x=V0/V（EOS.cs:260-261）。マニュアル式と同じ。
- BM4: a=x^{1/3} として `1.5 K0 a^5 (a²−1) [1 + 0.75(K'−4)(a²−1) + (9K0K'' + 9K'² − 63K' + 143)/24 · (a²−1)²]`（EOS.cs:263-267）。NaCl Matsui12 は f=(x^{2/3}−1)/2 を使った同じ式の別表記 `3fK0(1+2f)^{5/2}(1 + 1.5(K'−4)f + (9K0K''+9K'²−63K'+143)/6·f²)`（EOS.cs:463-481）。
- Vinet: y = x^{−1/3}、`3K0 (1−y)/y² exp[1.5(K'−1)(1−y)]`（EOS.cs:296-300）。マニュアル式と同じ。
- AP2: y=(V/V0)^{1/3}, `pFG = 2336.965 (Ze/V0)^{5/3}`（Ze=胞内総電子数, V0 は Å³）, `C0 = −ln(3K0/pFG)`, `C2 = 1.5(K'−3) − C0`, `P = 3K0 (1−y)/y^5 exp[C0(1−y)] [1 + C2 y(1−y)]`（EOS.cs:236-244）。
- Keane: x=V0/V, `P = K0 [ (K'/K∞²)(x^{K∞} − 1) − (K'/K∞ − 1) ln x ]`（EOS.cs:229-234）。
- MGD（GetPressure / MieGruneisen）: `Vm = V[Å³]·6.0221367/Z`（単位 10⁻⁷ m³/mol）、`γ = γ0 (Vm/Vm0)^q`、`θ = θ0 exp[(γ0−γ)/q]`、`Eth = 9 R n T (T/θ)³ ∫0^{θ/T} t³/(e^t−1) dt`（R=8.31451 または `UniversalConstants.R`）、`ΔPth = γ/Vm (Eth − Eth0)/100` [GPa]（EOS.cs:140-149, 182-196）。Debye 積分は 100000 分割の矩形和（§3-3）。
- T-dependence: `KT0 = K0 + KperT (T−T0)`、`V0(T) = V0 exp[A·1e−5 (T−T0) + B·1e−9/2 (T²−T0²) − C (1/T − 1/T0)]` を等温式に入れる（EOS.cs:151-166）。マニュアル ja:130 と同じ。
- Tange09: `γ = γ0[1 + a((V/V0)^b − 1)]`、`θ = θ0 (V/V0)^{−(1−a)γ0} exp[−(γ−γ0)/b]`。E は θ/T の 6 次多項式近似で、`ΔE = 9 n R (T·e(θ/T) − 300·e(θ/300))`、`Pth = γ/(V/V0)/Vm0 · ΔE · 1e−9`（R=8.3145, Vm0 = 6.0221/Z·V0·1e−7）（EOS.cs:330-379）。
- 2 段スプライン: 各温度列で x 方向の自然 3 次スプライン（範囲外は線形）→ 目的 x での各温度の P を、T 方向で再びスプライン補間（EOS.cs:1250-1257, Spline.cs:263-338）。x の定義は、Au/Pt Jamieson・Tsuchiya・Brown が `1 − a³/a0³`（nm 単位の a を渡す）、Yokoo・Zha が `1 − V/V0`、Skelton が `1 − a/a0`。Ross は Vm[cm³/mol] = 6.022e23/1e21 · a[nm]³ /4 の 1 段スプライン（EOS.cs:1191-1195、表ヘッダ T=273 K, EOS.cs:1168）。

### 5.2 「物質ごとの出典」節の差し替え案（UI ラベル準拠, EN/JA 共通表示）
- Gold: `Jamieson (82)`, `Anderson (89)`, `Sim (02)`, `Tsuchiya (03)`, `Yokoo (09)`, `Fratanduono (21)`
- Platinum: `Jamieson (82)`, `Holmes (89)`, `Matsui (09)`, `Yokoo (09)`, `Fratanduono (21)`
- NaCl (B1): `Brown (99)`, `Matsui (12)`, `Skelton (84)`
- NaCl (B2): `Sata (02) (Pt)`, `Sata (02) (Mg)`, `Ueda+(08)`, `Sakai+(11) BM`, `Sakai+(11) Vinet`
- Periclase: `Jackson (98)`, `Dewaele (00)`, `Aizawa (06)`, `Tange (09) Vinet`, `Tange (09) BM`
- Corundum: `Dubrovinsky (98)`
- Ar: `Ross et al. (86)`, `Jephcoat (98)`
- Re: `Zha et al. (04)`, `Anz (##)`, `Sakai. (##)`, `Dub. (##)`
- Mo: `Huang+(16)MGD`, `Zhao+(00)`
- Pb: `Strässle+(14)`

### 5.3 「入力パラメータ」節の補足案
- `Temperature`（K, 既定 300）: 全物質で共通に使う。
- `T0`（K, 既定 300）: 使うのは Pt `Matsui (09)` と Pb `Strässle+(14)` だけ。ほかの式は基準温度が固定（300 K。Jephcoat は 4 K）。
- 計算に使われない欄: Ar `a0`、NaCl (B2) `a0`（読み取り専用）、Re `V0`（`Zha et al. (04)` 以外では不使用）。
