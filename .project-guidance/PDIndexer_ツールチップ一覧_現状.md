# PDIndexer ツールチップ一覧（現状）

- 作成 / 最終更新: 2026-05-31 (260531Cl)
- **resx が正本**。本ファイル末尾の一覧は `c:\tmp\pdi_extract_tooltips_md.py` で `*.resx` / `*.ja.resx` から再生成できる（変更後はこれで更新）。
- 表示時は **55 カラムで折返し**（resx に CRLF 埋込）されるが、一覧では内容把握のため**改行を畳んで**表示する。
- 監査・方針の詳細は [PDIndexer_ツールチップ監査_全体統合.md](PDIndexer_ツールチップ監査_全体統合.md)、WinForms ToolTip の一般仕様・罠は [ツールチップ編集方針(共通).md](ツールチップ編集方針(共通).md)（4 ソフト共通）を参照。

---

## PDIndexer 固有の ToolTip メモ

PDIndexer 固有の配線・適用状況・据え置き（FormMain の `.ToolTip1` 表示キー、`menuStrip.ShowItemToolTips=true`、動的 111 元素箱の共有 tip、ja.resx 新設フォーム、死蔵フォームの扱い、適用スクリプト等）は **[PDIndexer_ツールチップ監査_全体統合.md](PDIndexer_ツールチップ監査_全体統合.md)**（「ツールチップ表示方式（PDIndexer 固有メモ）」「適用ログ」）に集約。WinForms `ToolTip` の一般仕様・罠は **[ツールチップ編集方針(共通).md](ツールチップ編集方針(共通).md)** を参照。本ファイルは現状の文案一覧（下記）に徹する。

## 現状ツールチップ一覧（resx 由来・改行畳み）

<!-- 自動生成: pdi_extract_tooltips_md.py / forms=13 EN=322 JA=322 -->

### EDXControl  （DataConverter/EDXControl.resx / EN 4 ・ JA 4）

| コントロール | EN | JA |
|---|---|---|
| `checkBox1` | Enable this EDX detector; its label shows the detector number. | この EDX 検出器を使用します。ラベルは検出器番号を示します。 |
| `numericBoxEGC0` | Constant term a0 (eV offset) of the energy calibration E = a0 + a1*n + a2*n^2 (n = channel number). | エネルギー較正式 E = a0 + a1·n + a2·n²（n: チャンネル 番号）の定数項 a0（eV、オフセット）を設定します。 |
| `numericBoxEGC1` | Linear gain term a1 (eV per channel) of the energy calibration. | エネルギー較正式の 1 次（ゲイン）項 a1（eV/チャンネル）を設定します。 |
| `numericBoxEGC2` | Quadratic (nonlinearity) term a2 (eV per channel^2) of the energy calibration. | エネルギー較正式の 2 次（非線形）項 a2（eV/チャンネル²）を設定します。 |

### FormDataConverter  （DataConverter/FormDataConverter.resx / EN 6 ・ JA 6）

| コントロール | EN | JA |
|---|---|---|
| `buttonCancel` | Cancel the conversion. | 変換をキャンセルします。 |
| `buttonOK` | Apply the settings and convert the data. | 設定を適用してデータを変換します。 |
| `checkBoxLowEnergyCutoff` | Enable cutting off the low-energy side of the EDX spectrum below the threshold at right. | EDX スペクトルの低エネルギー側を右の閾値以下で切り捨てます。 |
| `horizontalAxisUserControl` | Set the data's horizontal-axis type and the associated source parameters (wavelength/energy, 2theta, TOF length/angle, etc.). | データの横軸種別と関連パラメータ（波長/ エネルギー・2θ・TOF 距離/角度など）を設定します。 |
| `numericBoxLowEnergyCutoff` | Energy threshold (eV) below which the EDX spectrum is discarded; enabled by the checkbox at left. | この値（eV）未満の EDX スペクトルを切り 捨てます。左のチェックで有効化します。 |
| `numericalTextBox1` | Exposure (measurement) time per data step, in seconds. Values <= 0 are treated as 1. | データ 1 ステップあたりの露出（測定）時間を 秒単位で設定します。0 以下は 1 として扱われます。 |

### FormAboutMe  （FormAboutMe.resx / EN 2 ・ JA 2）

| コントロール | EN | JA |
|---|---|---|
| `linkLabelHomePage` | Click to open the project homepage in your browser. | クリックするとプロジェクトの ホームページをブラウザで開きます。 |
| `linkLabelMail` | Click to open your e-mail client addressed to the author. | クリックすると表示中のアドレス宛にメールソフトを開きます。 |

### FormAtomicPositionFinder  （FormAtomicPositionFinder.resx / EN 31 ・ JA 31）

| コントロール | EN | JA |
|---|---|---|
| `buttonAddPeak` | Add the entered d-spacing and intensity as a new row in the diffraction peak table. | 入力した d 値と強度を回折ピーク表に 1 行追加します。 |
| `buttonReindexPeaks` | Recompute the hkl (Miller) indices for all peaks from the current cell and space group. | 現在の格子定数と空間群で全ピークの hkl 指数（ミラー指数）を再計算します。 |
| `buttonResume` | Resume the search using the current candidate list as the starting population, rather than clearing it. | 現在の候補一覧を初期集団として探索を 再開します（候補をクリアしません）。 |
| `buttonStart` | Start a new structure search from scratch (clears previous candidates). While running it shows 'Stop!' and stops the search when clicked. | 構造探索を新規に開始します（既存候補をクリア）。 実行中は 'Stop!' 表示になり、押すと探索を中断します。 |
| `buttonTest` | (Debug) Import peaks from clipboard tab-separated text (column 0 = d, column 4 = intensity), replacing the peak table. | （デバッグ用）クリップボードのタブ区切り テキスト（0 列目=d, 4 列目=強度）を読み 込み、回折ピーク表を置き換えます。 |
| `comboBoxCrystalSystem` | Crystal system (triclinic to cubic). Selecting one constrains the editable cell parameters and lists the matching space groups. | 結晶系（triclinic〜cubic）を選択します。 選んだ結晶系に応じて編集できる格子定数が 制限され、空間群候補一覧が更新されます。 |
| `dataGridView2` | Found structure candidates sorted by R-factor. Residual = R; Info lists space group, Wyckoff sites and fractional coordinates. Click a row to send it to the Crystal form and copy it to the clipboard. | 探索で得られた結晶構造候補（R 因子の昇順）です。 Residual は R、Info は空間群・各原子のワイコフ位置と 分率座標を表します。行をクリックすると Crystal フォームへ送られ、クリップボードにもコピーされます。 |
| `dataGridViewDiffractionPeaks` | Observed diffraction peaks. Use the Check column to include a peak in the search and the Delete button to remove a row; the Index column shows the assigned hkl. | 観測回折ピーク一覧です。Check 列で探索に使う ピークを選び、Delete 列で行を削除します。Index 列には割り当てられた hkl が表示されます。 |
| `graphControl1` | Plot of the R-factor convergence during the search. | 探索中の R 因子の収束を表示するグラフです。 |
| `listBoxSpaceGroupCandidate` | Candidate space groups (number.sub: Hermann-Mauguin symbol). Select one or more; each selected group is searched. Multi-select supported. | 探索対象とする空間群候補（番号.副番号: Hermann-Mauguin 記号）を選びます。複数選択で き、選んだ各空間群について構造探索を行います。 |
| `numericBoxA` | Unit-cell edge length a (Å). For high-symmetry systems b and c are auto-linked to a. | 単位格子の a 軸長（Å）です。対称性の 高い結晶系では b・c が a に連動します。 |
| `numericBoxAlpha` | Unit-cell angle alpha (degrees). Auto-fixed (e.g. to 90) according to the crystal system. | 格子角 α（度）です。結晶系に応じ て 90° などに自動固定されます。 |
| `numericBoxB` | Unit-cell edge length b (Å). Becomes read-only and equal to a for tetragonal, trigonal, hexagonal and cubic systems. | 単位格子の b 軸長（Å）です。正方・三方・ 六方・立方晶系では a と等しく固定されます。 |
| `numericBoxBeta` | Unit-cell angle beta (degrees). Auto-fixed to 90 for orthorhombic and higher-symmetry systems. | 格子角 β（度）です。斜方晶系以上で は 90° に自動固定されます。 |
| `numericBoxC` | Unit-cell edge length c (Å). Becomes read-only and equal to a for the cubic system. | 単位格子の c 軸長（Å）です。 立方晶系では a と等しく固定されます。 |
| `numericBoxGamma` | Unit-cell angle gamma (degrees). Auto-fixed to 120 for trigonal/hexagonal, 90 for other high-symmetry systems. | 格子角 γ（度）です。三方・六方晶系では 120°、そ の他の高対称晶系では 90° に自動固定されます。 |
| `numericUpDownAngleThreshold` | Angle threshold in degrees (0-2). Reflections closer than this in 2theta are combined into one peak. | 角度しきい値（度、0〜2）です。これより 2θ が 近い反射どうしを 1 本のピークに併合します。 |
| `numericUpDownEnergyThreshold` | Energy threshold in electron-volts (0-10) for combining peaks (effective only in energy-threshold mode). | ピーク併合に用いるエネルギーしきい値（eV、0〜10）で す（エネルギーしきい値モードでのみ有効）。 |
| `numericUpDownHybridization` | Probability (%) of the genetic-algorithm crossover that hybridizes two existing candidates. Auto-normalized with the other two to 100%. | 既存の候補 2 つを掛け合わせる遺伝的アルゴリズム （交叉）を行う確率（%、既定 2）です。他の 2 つ と合わせて 100% に自動調整されます。 |
| `numericUpDownIonRadiusThreshold` | Allowance (%) on the sum of ionic radii used to reject atomic positions that overlap. Lower values reject more crowded arrangements. | 原子の重なり判定に用いるイオン半径和の 許容係数（%、既定 70）です。値が小さい ほど近接した配置を強く棄却します。 |
| `numericUpDownRandomization` | Probability (%) of generating a brand-new random atomic arrangement each Monte-Carlo step. The three probabilities are auto-normalized to total 100%. | 各モンテカルロ試行で原子配置を新規にランダム 生成する確率（%、既定 95）です。3 つの確率は 合計 100% になるよう自動調整されます。 |
| `numericUpDownShaking` | Probability (%) of 'shaking', i.e. slightly perturbing the atomic positions of an existing candidate. Auto-normalized to total 100%. | 既存候補の原子座標をわずかに揺らす（shaking）確率（%、 既定 3）です。合計 100% になるよう自動調整されます。 |
| `numericUpDownThreadTotal` | Number of parallel worker threads for the search (1-16). Higher values use more CPU cores. | 探索に使う並列スレッド数（1〜16、既定 2）です。 値を大きくすると多くの CPU コアを使います。 |
| `numericUpDownZ` | Number of formula units per unit cell, Z (minimum 1). Multiplies the formula to give the total atom count per unit cell. | 単位格子あたりの式単位数 Z（最小 1）です。 組成式に掛けて単位格子内の全原子数を決めます。 |
| `numericalTextBoxDspacing` | d-spacing (Å) of a peak to add to the table via the Add Peak button. | 表に追加するピークの面間隔 d（Å）を入力します。 Add Peak ボタンで回折ピーク表に追加されます。 |
| `numericalTextBoxIntensity` | Relative diffraction intensity (rel %) of the peak to add. Intensities are normalized to the strongest peak for the R-factor. | 追加するピークの相対回折強度（rel %）を入力しま す。R 因子計算時には最強ピークで規格化されます。 |
| `radioButtonAngleThreshold` | Merge reflections whose diffraction angles differ by less than the angle threshold below. | 回折角の差が下のしきい値より小さい反射を 1 本のピークとして併合するモードを選びます。 |
| `radioButtonEnergyThreshold` | Merge reflections by an energy threshold instead of an angle threshold (note: the energy branch may be inactive in the current code). | 角度の代わりにエネルギーしきい値で反射を 併合するモードを選びます（現コードでは エネルギー分岐が無効の可能性あり）。 |
| `textBoxFormula` | Read-only: total atomic composition in the unit cell (formula times Z). Updates automatically when the formula or Z changes. | 単位格子内の全原子組成を表示します（組成式 × Z、読み 取り専用）。組成式や Z の変更で自動更新されます。 |
| `textBoxInputFormula` | Chemical formula (empirical/reduced, e.g. 'Ti O2'). Parsed to fill per-element atom counts and the formula-unit count Z. | 化学式（最簡組成式、例: Ti O2）を入力します。解析され て各元素の原子数欄と式単位数 Z が自動計算されます。 |
| `waveLengthControl1` | X-ray wave source and wavelength used to convert d-spacings to angles and to compute diffraction intensities. | 波源（X線など）と波長を設定します。面間隔から 回折角への変換と回折強度の計算に使われます。 |

### FormCellFinder  （FormCellFinder.resx / EN 24 ・ JA 24）

| コントロール | EN | JA |
|---|---|---|
| `button1` | Resume the search keeping the current candidates instead of clearing them (shares the Find handler). | Find と同じ処理で探索を再開します （候補をクリアせず継続します）。 |
| `buttonAddPeak` | Add the entered d-spacing and reliability as a new row in the peak list. | 入力した d 値と信頼度を一覧に新しい行として追加します。 |
| `buttonFind` | Start the auto-indexing search; click again (the label changes to 'Stop!') to cancel it. | 自動指数付け探索を開始します。実行中はラベル が 'Stop!' に変わり、再クリックで中止します。 |
| `comboBoxCrystalSystem` | Crystal system to search. Sets the number of free lattice parameters (triclinic=6 ... cubic=1); fewer unknowns means a faster, more constrained search. | 探索する晶系を選びます。格子定数の 未知数（triclinic=6〜cubic=1）が決まり、対称性が 高いほど高速かつ拘束の強い探索になります。 |
| `comboBoxReliability` | Reliability of the peak being added (High/Medium/Low); weights the least-squares fit (High=1, Medium=0.5, Low=0.1). | 追加するピークの信頼度（High/Medium/Low） です。最小二乗の重み付け（High=1, Medium=0.5, Low=0.1）に反映します。 |
| `comboBoxX` | Lattice parameter (a/b/c/alpha/beta/gamma) plotted on the distribution map's X-axis. | 分布図の X 軸に表示する格子定数（a/b/c/α/β/γ）を選びます。 |
| `comboBoxY` | Lattice parameter (a/b/c/alpha/beta/gamma) plotted on the distribution map's Y-axis. | 分布図の Y 軸に表示する格子定数（a/b/c/α/β/γ）を選びます。 |
| `dataGridView1` | Editable list of observed peaks: tick 'Use for Calc. ', set reliability and d_obs; Delete removes a row. Indexed h k l, d_calc and diff appear after a search. | 観測ピークの編集用一覧です。「Use for Calc.」の チェック・信頼度・d_obs を編集し、Delete で行を削除し ます。探索後は h k l・d_calc・diff が表示されます。 |
| `dataGridViewResult` | Candidate cells (best 300) sorted by R; click a row to apply its hkl indexing to the peak list and highlight it on the map. SigmadQ and R are figures of merit (smaller is better). | 候補セル一覧（R の小さい順に最良 300 件）です。行を クリックすると入力表に hkl を反映し、分布図で強調し ます。ΣdQ・R は評価指標（小さいほど良）です。 |
| `distributionGraphControl1` | Scatter map of candidate cells in the chosen X-Y parameter space, colored by R (figure of merit). | 選択した X–Y パラメータ空間での候補セルの 散布図です。R（評価指標）で色付けします。 |
| `numericUpDownMaxA` | Upper bound of axis length a (Å) for the search. | 探索する軸長 a の上限（Å）です。 |
| `numericUpDownMaxAlpha` | Upper bound of interaxial angle alpha (degrees, max 180). | 探索する軸間角 α の上限（度、上限 180）です。 |
| `numericUpDownMaxB` | Upper bound of axis length b (Å) for the search. | 探索する軸長 b の上限（Å）です。 |
| `numericUpDownMaxBeta` | Upper bound of interaxial angle beta (degrees, max 180). | 探索する軸間角 β の上限（度、上限 180）です。 |
| `numericUpDownMaxC` | Upper bound of axis length c (Å) for the search. | 探索する軸長 c の上限（Å）です。 |
| `numericUpDownMaxGamma` | Upper bound of interaxial angle gamma (degrees, max 180). | 探索する軸間角 γ の上限（度、上限 180）です。 |
| `numericUpDownMinA` | Lower bound of axis length a (Å) for the search. Candidates with a outside this range are rejected. | 探索する軸長 a の下限（Å）です。 範囲外の候補セルは棄却します。 |
| `numericUpDownMinAlpha` | Lower bound of interaxial angle alpha (degrees) for the search. | 探索する軸間角 α の下限（度）です。 |
| `numericUpDownMinB` | Lower bound of axis length b (Å) for the search. | 探索する軸長 b の下限（Å）です。 |
| `numericUpDownMinBeta` | Lower bound of interaxial angle beta (degrees) for the search. | 探索する軸間角 β の下限（度）です。 |
| `numericUpDownMinC` | Lower bound of axis length c (Å) for the search. | 探索する軸長 c の下限（Å）です。 |
| `numericUpDownMinGamma` | Lower bound of interaxial angle gamma (degrees) for the search. | 探索する軸間角 γ の下限（度）です。 |
| `numericalTextBox1` | Observed d-spacing (Å) of the peak to add to the list below. | 一覧に追加するピークの観測 d 値（面間隔、Å）を入力します。 |
| `waveLengthControl1` | Radiation source and wavelength used to convert observed d-spacings (default Cu Kalpha1, 0.15418 nm). | 観測 d 値の換算に用いる波源と波長を 設定します（既定 Cu Kα1、0.15418 nm）。 |

### FormCrystal  （FormCrystal.resx / EN 2 ・ JA 2）

| コントロール | EN | JA |
|---|---|---|
| `checkBoxCalculateIntensity` | Check if you want to calculate intensity ratios of  diffraction peaks based on crystal structures | 回折強度比を計算したい場合にチェックします。 |
| `checkBoxVariableRatioOfIntensity` | Check if you want to change diffraction peak height by mouse drag. (relative intensity ratio is always reserved) | マウスドラッグで回折ピークの高さ を変えたい場合にチェックします。 |

### FormEOS  （FormEOS.resx / EN 66 ・ JA 66）

| コントロール | EN | JA |
|---|---|---|
| `checkBoxAr` | Show or hide the solid argon (Ar) panel. | 固体アルゴン（Ar）のパネル表示／非表示を切り替えます。 |
| `checkBoxCorundum` | Show or hide the Al2O3 (corundum) panel. | Al2O3（コランダム）のパネル表示／非表示を切り替えます。 |
| `checkBoxGold` | Show or hide the gold (Au) pressure-standard panel. | 金（Au）圧力標準のパネル表示／非表示を切り替えます。 |
| `checkBoxMo` | Show or hide the molybdenum (Mo) panel. | モリブデン（Mo）のパネル表示／非表示を切り替えます。 |
| `checkBoxNaClB1` | Show or hide the NaCl B1 (rock-salt phase) panel. | NaCl B1（岩塩型相）のパネル表示／非表示を切り替えます。 |
| `checkBoxNaClB2` | Show or hide the NaCl B2 (CsCl-type high-pressure phase) panel. | NaCl B2（CsCl型高圧相）のパネル表示／非表示を切り替えます。 |
| `checkBoxPb` | Show or hide the lead (Pb) panel. | 鉛（Pb）のパネル表示／非表示を切り替えます。 |
| `checkBoxPericlase` | Show or hide the MgO (periclase) panel. | MgO（ペリクレース）のパネル表示／非表示を切り替えます。 |
| `checkBoxPlatinum` | Show or hide the platinum (Pt) pressure-standard panel. | 白金（Pt）圧力標準のパネル表示／非表示を切り替えます。 |
| `checkBoxRe` | Show or hide the rhenium (Re) panel. | レニウム（Re）のパネル表示／非表示を切り替えます。 |
| `numericBoxArA0` | Reference lattice parameter a0 (Å) of Ar (reference display only; the Ross/Jephcoat models do not use it). | Ar の基準格子定数 a0（Å）です（参照表示用。 Ross/Jephcoat の計算には使われません）。 |
| `numericBoxAuFratanduono` | Computed pressure P (GPa) for gold from Fratanduono (2021), Vinet. Read-only result. | 金の圧力 P（GPa）を Fratanduono(2021) （Vinet）で計算して表示します（表示専用）。 |
| `numericBoxAuYokoo` | Computed pressure P (GPa) for gold from Yokoo (2009). Read-only result. | 金の圧力 P（GPa）を Yokoo(2009) の 状態方程式で計算して表示します（表示専用）。 |
| `numericBoxColundumV0` | Zero-pressure reference unit-cell volume V0 (Å³) of Al2O3 (default 255.89472). | Al2O3 の常圧基準格子体積 V0（Å³）です（既定 255.89472）。 |
| `numericBoxCorundumDubrovinsky` | Computed pressure P (GPa) for Al2O3 (corundum) from Dubrovinsky (1998). Read-only result. | Al2O3 の圧力 P（GPa）を Dubrovinsky(1998) で計算して表示します（表示専用）。 |
| `numericBoxGoldA0` | Zero-pressure reference lattice parameter a0 (Å) of Au (default 4.07825); P depends on the V/V0 ratio. | 金（Au）の常圧基準格子定数 a0（Å）です（既定 4.07825）。圧力は V/V0 比から計算されます。 |
| `numericBoxMgOA0` | Zero-pressure reference lattice parameter a0 (Å) of MgO (default 4.2112). | MgO の常圧基準格子定数 a0（Å）です（既定 4.2112）。 |
| `numericBoxMgOTangeBM` | Computed pressure P (GPa) for MgO from Tange (2009), Birch-Murnaghan. Read-only result. | MgO の圧力 P（GPa）を Tange(2009)（Birch-Murnaghan） で計算して表示します（表示専用）。 |
| `numericBoxMgOTangeVinet` | Computed pressure P (GPa) for MgO from Tange (2009), Vinet. Read-only result. | MgO の圧力 P（GPa）を Tange(2009)（Vinet） で計算して表示します（表示専用）。 |
| `numericBoxMoHuang` | Computed pressure P (GPa) for molybdenum from Huang (2016), BM3 + Mie-Grüneisen-Debye. Read-only result. | モリブデンの圧力 P（GPa）を Huang(2016)（BM3＋ Mie-Grüneisen-Debye）で計算して表示します（表示専用）。 |
| `numericBoxMoV` | Measured unit-cell volume V (Å³) of molybdenum (Mo) (default 31.14). | モリブデン（Mo）の測定格子体積 V（Å³）です（既定 31.14）。 |
| `numericBoxMoV0` | Zero-pressure reference volume V0 (Å³) of Mo (default 31.14); used by the Huang (MGD) and Zhao models. | モリブデン（Mo）の常圧基準格子体積 V0（Å³）です （既定 31.14）。Huang（MGD）・Zhao 式で使われます。 |
| `numericBoxMoZhao` | Computed pressure P (GPa) for molybdenum from Zhao (2000), BM4 + thermal-pressure correction. Read-only result. | モリブデンの圧力 P（GPa）を Zhao(2000)（BM4＋ 熱圧力補正）で計算して表示します（表示専用）。 |
| `numericBoxNaClB1A0` | Zero-pressure reference lattice parameter a0 (Å) of the NaCl B1 phase (default 5.639). | NaCl B1 相の常圧基準格子定数 a0（Å）です（既定 5.639）。 |
| `numericBoxNaClB1Matsui` | Computed pressure P (GPa) for NaCl B1 from Matsui (2012). Read-only result. | NaCl B1 相の圧力 P（GPa）を Matsui(2012) で計算して表示します（表示専用）。 |
| `numericBoxNaClB1Skelton` | Computed pressure P (GPa) for NaCl B1 from Skelton (1984). Read-only result. | NaCl B1 相の圧力 P（GPa）を Skelton(1984) で計算して表示します（表示専用）。 |
| `numericBoxPbA` | Measured lattice parameter a (Å) of lead (Pb); the Strassle model uses a/a0(T) in a Vinet form. | 鉛（Pb）標準の測定格子定数 a（Å）です。Strässle 式は a/a0(T) を Vinet 形式で使い圧力を算出します。 |
| `numericBoxPbA0` | Zero-pressure reference lattice parameter a0 (Å) of Pb (default 4.95059); scales the internal a0(T) table to your sample at T0. | 鉛（Pb）の常圧基準格子定数 a0（Å）で す（既定 4.95059）。内部の a0(T) 表を T0 で試料に合わせて補正します。 |
| `numericBoxPbStrassle` | Computed pressure P (GPa) for lead from Strassle (2014), Vinet form with B(T), B'(T), a0(T) from a built-in table. Read-only result. | 鉛の圧力 P（GPa）を Strässle(2014)（B(T)・ B'(T)・a0(T) を内蔵表から補間する Vinet 形式）で計算して表示します（表示専用）。 |
| `numericBoxPtA0` | Zero-pressure reference lattice parameter a0 (Å) of Pt (default 3.9231). | 白金（Pt）の常圧基準格子定数 a0（Å）です（既定 3.9231）。 |
| `numericBoxPtFratanduono` | Computed pressure P (GPa) for platinum from Fratanduono (2021), Vinet. Read-only result. | 白金の圧力 P（GPa）を Fratanduono(2021) （Vinet）で計算して表示します（表示専用）。 |
| `numericBoxPtYokoo` | Computed pressure P (GPa) for platinum from Yokoo (2009). Read-only result. | 白金の圧力 P（GPa）を Yokoo(2009) の 状態方程式で計算して表示します（表示専用）。 |
| `numericBoxReAnz` | Computed pressure P (GPa) for rhenium from Anzellini, Vinet with fixed K0/K0'. Read-only result. | レニウムの圧力 P（GPa）を Anzellini（固定 K0/K0' の Vinet）で計算して表示します（表示専用）。 |
| `numericBoxReDub` | Computed pressure P (GPa) for rhenium from Dubrovinsky, 4th-order Birch-Murnaghan. Read-only result. | レニウムの圧力 P（GPa）を Dubrovinsky（4次 Birch-Murnaghan）で計算して表示します（表示専用）。 |
| `numericBoxReSakai` | Computed pressure P (GPa) for rhenium from Sakai, Vinet with fixed K0/K0'. Read-only result. | レニウムの圧力 P（GPa）を Sakai（固定 K0/K0' の Vinet）で計算して表示します（表示専用）。 |
| `numericBoxReV` | Measured unit-cell volume V (Å³) of rhenium (Re). | レニウム（Re）の測定格子体積 V（Å³）です。 |
| `numericBoxTemperature` | Sample temperature T (K) at which the cell was measured. Shared by all standards; raising T adds thermal pressure and lowers the computed P. | 測定時の試料温度 T（K）です。全標準物質で共通に使われ、 温度を上げると熱圧力が加わり算出圧力 P は下がります。 |
| `numericBoxTemperature0` | Reference temperature T0 (K) of the a0/V0 reference values; used by the Pt (Matsui) and Pb models. Usually 300 K. Distinct from the measurement temperature T. | 参照値（a0/V0）の基準温度 T0（K）です。 Pt（Matsui）と Pb で参照格子を温度 T に補正する際に 使われます。通常 300 K。測定温度 T とは別です。 |
| `numericalTextBoxArA` | Measured lattice parameter a (Å) of solid argon (Ar). The Ar models use a directly (no a0). | 固体アルゴン（Ar）の測定格子定数 a（Å）です。Ar の各式は a0 を使わず a から直接 P を計算します。 |
| `numericalTextBoxArJephcoat` | Computed pressure P (GPa) for solid Ar from Jephcoat (1998), temperature-dependent. Read-only result. | 固体 Ar の圧力 P（GPa）を Jephcoat(1998)（温 度依存）で計算して表示します（表示専用）。 |
| `numericalTextBoxArRoss` | Computed pressure P (GPa) for solid Ar from Ross (1986). Read-only result. | 固体 Ar の圧力 P（GPa）を Ross(1986) で計算して表示します（表示専用）。 |
| `numericalTextBoxColundumV` | Measured unit-cell volume V (Å³) of Al2O3 (corundum). This standard takes the volume directly, not a. | Al2O3（コランダム）の測定格子体積 V（Å³）です。こ の標準は格子定数 a ではなく体積を直接入力します。 |
| `numericalTextBoxGoldA` | Measured lattice parameter a (Å) of the gold (Au) marker; V = a³ is fed to all Au equations of state to compute P. | 金（Au）標準の測定格子定数 a（Å）です。V = a³ と して各 Au 状態方程式に渡り圧力 P を算出します。 |
| `numericalTextBoxGoldAnderson` | Computed pressure P (GPa) for gold from Anderson (1989). Read-only result. | 金の圧力 P（GPa）を Anderson(1989) の 状態方程式で計算して表示します（表示専用）。 |
| `numericalTextBoxGoldJamieson` | Computed pressure P (GPa) for gold from Jamieson (1982). Read-only result. | 金の圧力 P（GPa）を Jamieson(1982) の 状態方程式で計算して表示します（表示専用）。 |
| `numericalTextBoxGoldSim` | Computed pressure P (GPa) for gold from Sim (2002), BM3 + Mie-Grüneisen. Read-only result. | 金の圧力 P（GPa）を Sim(2002)（BM3＋ Mie-Grüneisen）で計算して表示します（表示専用）。 |
| `numericalTextBoxGoldTsuchiya` | Computed pressure P (GPa) for gold from Tsuchiya (2003). Read-only result. | 金の圧力 P（GPa）を Tsuchiya(2003) の 状態方程式で計算して表示します（表示専用）。 |
| `numericalTextBoxMgOA` | Measured lattice parameter a (Å) of the MgO (periclase) marker (default 4.2112); V = a³ for the MgO equation of state. | MgO（ペリクレース）標準の測定格子定数 a（Å）です（既定 4.2112）。V = a³ として MgO 状態方程式に使われます。 |
| `numericalTextBoxMgOAizawa` | Computed pressure P (GPa) for MgO from Aizawa (2006), BM3 + Mie-Grüneisen. Read-only result. | MgO の圧力 P（GPa）を Aizawa(2006)（BM3＋ Mie-Grüneisen）で計算して表示します（表示専用）。 |
| `numericalTextBoxMgODewaele` | Computed pressure P (GPa) for MgO from Dewaele (2000), BM3 + Mie-Grüneisen. Read-only result. | MgO の圧力 P（GPa）を Dewaele(2000)（BM3＋ Mie-Grüneisen）で計算して表示します（表示専用）。 |
| `numericalTextBoxMgOJacson` | Computed pressure P (GPa) for MgO from Jackson (1998), BM3 + Mie-Grüneisen. Read-only result. | MgO の圧力 P（GPa）を Jackson(1998)（BM3＋ Mie-Grüneisen）で計算して表示します（表示専用）。 |
| `numericalTextBoxNaClB1A` | Measured lattice parameter a (Å) of the B1 (rock-salt) phase of NaCl. | NaCl の B1（岩塩型）相の測定格子定数 a（Å）です。 |
| `numericalTextBoxNaClB1Brown` | Computed pressure P (GPa) for NaCl B1 from Brown (1999). Read-only result. | NaCl B1 相の圧力 P（GPa）を Brown(1999) で計算して表示します（表示専用）。 |
| `numericalTextBoxNaClB2A` | Measured lattice parameter a (Å) of the B2 (CsCl-type) high-pressure phase of NaCl (a separate phase from B1). | NaCl の高圧 B2（CsCl型）相の測定格子定数 a（Å）です（B1 相とは別相）。 |
| `numericalTextBoxNaClB2A0` | Reference lattice parameter a0 (Å) for NaCl B2 (read-only reference; the B2 models compute P directly from a). | NaCl B2 の基準格子定数 a0（Å）です（読み取り専用の 参照値。B2 各式は a から直接 P を計算します）。 |
| `numericalTextBoxNaClB2SakaiBM` | Computed pressure P (GPa) for NaCl B2 from Sakai (2011), Birch-Murnaghan. Read-only result. | NaCl B2 相の圧力 P（GPa）を Sakai(2011) （Birch-Murnaghan）で計算して表示します（表示専用）。 |
| `numericalTextBoxNaClB2SakaiVinet` | Computed pressure P (GPa) for NaCl B2 from Sakai (2011), Vinet. Read-only result. | NaCl B2 相の圧力 P（GPa）を Sakai(2011) （Vinet）で計算して表示します（表示専用）。 |
| `numericalTextBoxNaClB2SataMgO` | Computed pressure P (GPa) for NaCl B2 from Sata (2002), cross-calibrated to the MgO scale. Read-only result. | NaCl B2 相の圧力 P（GPa）を Sata(2002)（MgO 基準で較正）で計算して表示します（表示専用）。 |
| `numericalTextBoxNaClB2SataPt` | Computed pressure P (GPa) for NaCl B2 from Sata (2002), cross-calibrated to the Pt scale. Read-only result. | NaCl B2 相の圧力 P（GPa）を Sata(2002)（Pt 基準で較正）で計算して表示します（表示専用）。 |
| `numericalTextBoxNaClB2Ueda` | Computed pressure P (GPa) for NaCl B2 from Ueda (2008). Read-only result. | NaCl B2 相の圧力 P（GPa）を Ueda(2008) で計算して表示します（表示専用）。 |
| `numericalTextBoxPtA` | Measured lattice parameter a (Å) of the platinum (Pt) marker; V = a³ for the Pt equation of state. | 白金（Pt）標準の測定格子定数 a（Å）です。 V = a³ として Pt 状態方程式に使われます。 |
| `numericalTextBoxPtHolmes` | Computed pressure P (GPa) for platinum from Holmes (1989). Read-only result. | 白金の圧力 P（GPa）を Holmes(1989) の 状態方程式で計算して表示します（表示専用）。 |
| `numericalTextBoxPtJamieson` | Computed pressure P (GPa) for platinum from Jamieson (1982). Read-only result. | 白金の圧力 P（GPa）を Jamieson(1982) の 状態方程式で計算して表示します（表示専用）。 |
| `numericalTextBoxPtMatsui` | Computed pressure P (GPa) for platinum from Matsui (2009); uses the reference temperature T0. Read-only result. | 白金の圧力 P（GPa）を Matsui(2009) で計算して 表示します（基準温度 T0 を使用、表示専用）。 |
| `numericalTextBoxReZha` | Computed pressure P (GPa) for rhenium from Zha (2004); uses the reference volume V0. Read-only result. | レニウムの圧力 P（GPa）を Zha(2004) で計算して 表示します（基準体積 V0 を使用、表示専用）。 |
| `numerictBoxReV0` | Zero-pressure reference volume V0 (Å³) of Re (default 29.42795); used by the Zha model (the others use a built-in V0). | レニウム（Re）の常圧基準格子体積 V0（Å³）です（既定 29.42795）。Zha 式で使用され、他は内蔵 V0 を使います。 |

### FormFitting  （FormFitting.resx / EN 11 ・ JA 11）

| コントロール | EN | JA |
|---|---|---|
| `buttonApplyFWHMToAll` | Apply the initial FWHM value above to all peaks as their starting peak width. | 上の初期半値全幅（FWHM）を全ピーク の初期ピーク幅として適用します。 |
| `buttonApplyFunctionToAll` | Apply the peak shape function selected above to all peaks of this crystal. | 上で選択したピーク形状関数を、こ の結晶の全ピークに適用します。 |
| `buttonApplyRangeToAll` | Apply the search range (fitting window half-width) above to all peaks. | 上の探索範囲（フィッティング窓の 半幅）を全ピークに適用します。 |
| `buttonClearPeaks` | Clear all manually added peaks of the selected crystal (Flexible mode only). | 選択中の結晶（フレキシブルモード時のみ 表示）に手動追加した全ピークを削除します。 |
| `buttonConfirm` | Apply the optimized cell constants as those of the selected crystal. | 精密化した格子定数を、選択中の 結晶の格子定数として適用します。 |
| `buttonCopyCellConstantsToClipboard` | Copy the optimized cell constants to the clipboard. You can paste them directly into Excel. | 精密化した格子定数をクリップボードにコピー します。Excel に直接貼り付けられます。 |
| `buttonCopyTableToClipboard` | Copy the table data below to the clipboard. You can paste it directly into Excel. | 下のテーブルのデータをクリップボードにコピー します。Excel に直接貼り付けられます。 |
| `buttonRemovePeaks` | Subtract the fitted peak profiles of the selected crystal from the current profile and create a new profile (named below). Simple-search peaks are excluded. | 選択中の結晶のフィットしたピーク形状を現在の プロファイルから差し引き、新しいプロファイル（下で 命名）を作成します。Simple 探索のピークは除外されます。 |
| `buttonSaveTableAsCSV` | Save the table data below as a CSV file. | 下のテーブルのデータを CSV 形式で保存します。 |
| `numericBoxEffectiveDigit` | Number of significant digits shown in the peak table (1-16). Display only; does not affect fitting. | ピーク一覧テーブルの表示有効桁数（1〜16）を設定しま す。表示のみで、フィッティング結果には影響しません。 |
| `numericBoxEffectiveDigit` | Number of significant digits shown in the peak table (1-16). Display only; does not affect fitting. | ピーク一覧テーブルの表示有効桁数（1〜16）を設定しま す。表示のみで、フィッティング結果には影響しません。 |

### FormMain  （FormMain.resx / EN 73 ・ JA 73）

| コントロール | EN | JA |
|---|---|---|
| `BitmapToolStripMenuItem *(menu/bar)*` | Copy the viewer to the clipboard as a bitmap. | 表示内容をビットマップとしてクリップボードへコピーします。 |
| `aboutMeToolStripMenuItem *(menu/bar)*` | Show version and author information. | バージョン情報・作者情報を表示します。 |
| `asCSVcommaSeperatedFileToolStripMenuItem *(menu/bar)*` | Export the profile(s) as a comma-separated (CSV) file. | プロファイルをカンマ区切り（CSV）ファイルへ書き出します。 |
| `asGSASFileToolStripMenuItem *(menu/bar)*` | Export the profile(s) as a GSAS (Rietveld) data file. | プロファイルを GSAS（リートベルト解析）形式で書き出します。 |
| `asTSVtabSeparatedValuesFileToolStripMenuItem *(menu/bar)*` | Export the profile(s) as a tab-separated (TSV) file. | プロファイルをタブ区切り（TSV）ファイルへ書き出します。 |
| `automaticallySaveTheCrystalListToolStripMenuItem *(menu/bar)*` | When checked, automatically save the crystal list on exit and reload it on startup. | チェックすると、終了時に結晶リストを 自動保存し、次回起動時に読み込みます。 |
| `checkBoxAll` | Check or uncheck all profiles at once (show / hide all). | 全プロファイルのチェックを一括でオン / オフします（全表示 / 全非表示）。 |
| `checkBoxChangeColor` | In Multi-Profile mode, assign a random color to each newly added profile. | マルチプロファイル表示時に、新しく追加する プロファイルへ自動的に色を割り当てます。 |
| `checkBoxChangeHorizontalAppearance` | When loading a profile, automatically switch the horizontal-axis settings (radiation source, wavelength, axis mode) to match the loaded file. | プロファイル読み込み時に、横軸の 設定（線源・波長・軸モード）をその ファイルに合わせて自動的に切り替えます。 |
| `checkBoxCrystalParameter` | Open the Crystal Parameter window for detailed settings of the selected crystal. | 選択中の結晶の詳細設定ウィンドウを開きます。 |
| `checkBoxErrorBar` | Show error bars on data points when the profile contains error values. | プロファイルが誤差値を持つ場合に、 各データ点へエラーバーを表示します。 |
| `checkBoxProfileParameter` | Open the Profile Parameter window for detailed settings of the selected profile. | 選択中プロファイルの詳細設定ウィンドウを開きます。 |
| `checkBoxShowScaleLine` | Show grid (scale) lines on the profile viewer. | プロファイル表示領域に目盛り（グリッド）線を表示します。 |
| `clearRegistryToolStripMenuItem *(menu/bar)*` | When checked, clear all saved settings from the registry on exit (restart to reset). | チェックすると、終了時にレジストリの保存設定を すべて消去します（再起動で初期化）。 |
| `closeToolStripMenuItem *(menu/bar)*` | Close PDIndexer. | PDIndexer を終了します。 |
| `colorControlBack` | Background color of the profile viewer. | プロファイル描画領域の背景色を設定します。 |
| `colorControlBack` | Background color of the profile viewer. | プロファイル描画領域の背景色を設定します。 |
| `colorControlScaleLine` | Color of the scale / grid lines. | 目盛り線・グリッド線の色を設定します。 |
| `colorControlScaleLine` | Color of the scale / grid lines. | 目盛り線・グリッド線の色を設定します。 |
| `colorControlScaleText` | Color of the scale (axis tick) labels. | 軸目盛りの数値文字の色を設定します。 |
| `colorControlScaleText` | Color of the scale (axis tick) labels. | 軸目盛りの数値文字の色を設定します。 |
| `copyAsMetafileToolStripMenuItem *(menu/bar)*` | Copy the viewer to the clipboard as a metafile (vector). | 表示内容をメタファイル（ベクター）と してクリップボードへコピーします。 |
| `dataGridViewCrystals` | Crystal list. Diffraction peaks of the checked crystals are visible on the main profile viewer. Right double clicks eneble/unable blinking mode. Detailed crystal information can be checked by "Crystal Parameter". | Crystal のリストを表示します。 チェックされた結晶の回折線が表示されます。 結晶の詳しい情報は下の「Crystal Parameter」で設定します。 |
| `dataGridViewProfiles` | Profile list. Checked profiles are visible on the main profile viewer. To display multiple profiles, check "Multiple Profiles" radio button in "Appearance & Single/Multi Profiles" | プロファイルのリストを表示します。 チェックされたプロファイルのみが表示されます。 複数のプロファイルを読み込むにはメニューの｢Multi Profile」モードをONにします。 プロファイルの詳しい情報は下の「Profile Parameter」で設定します。 |
| `editorToolStripMenuItem *(menu/bar)*` | Open the macro editor window. | マクロエディタウィンドウを開きます。 |
| `englishToolStripMenuItem *(menu/bar)*` | Switch the UI language to English (requires restart). | UI 言語を英語に切り替えます（再起動が必要）。 |
| `groupBox4` | Choose the vertical (intensity) axis display mode. | 縦軸（強度軸）の表示モードを選びます。 |
| `helpwebToolStripMenuItem *(menu/bar)*` | Open the PDIndexer manual (PDF). | PDIndexer のマニュアル（PDF）を開きます。 |
| `hintToolStripMenuItem *(menu/bar)*` | Show usage hints. | 使い方のヒントを表示します。 |
| `japaneseToolStripMenuItem *(menu/bar)*` | Switch the UI language to Japanese (requires restart). | UI 言語を日本語に切り替えます（再起動が必要）。 |
| `label2` | Color of the scale / grid lines. | 目盛り線・グリッド線の色を設定します。 |
| `label4` | Background color of the profile viewer. | プロファイル描画領域の背景色を設定します。 |
| `label5` | Color of the scale (axis tick) labels. | 軸目盛りの数値文字の色を設定します。 |
| `numericBoxLowerX` | Lower bound of the displayed horizontal-axis range. Set the axis limit via the right-click menu. | 横軸の表示範囲の下限値です。右 クリックメニューで軸の限界値を設定できます。 |
| `numericBoxLowerX` | Lower bound of the displayed horizontal-axis range. Set the axis limit via the right-click menu. | 横軸の表示範囲の下限値です。右 クリックメニューで軸の限界値を設定できます。 |
| `numericBoxLowerY` | Lower bound of the displayed intensity (vertical) axis. | 縦軸（強度）の表示範囲の下限値です。 |
| `numericBoxLowerY` | Lower bound of the displayed intensity (vertical) axis. | 縦軸（強度）の表示範囲の下限値です。 |
| `numericBoxUpperX` | Upper bound of the displayed horizontal-axis range (2theta / d / energy, etc.). Set the axis limit via the right-click menu. | 横軸（2θ／d／エネルギー等）の表示範囲の上限値で す。右クリックメニューで軸の限界値を設定できます。 |
| `numericBoxUpperX` | Upper bound of the displayed horizontal-axis range (2theta / d / energy, etc.). Set the axis limit via the right-click menu. | 横軸（2θ／d／エネルギー等）の表示範囲の上限値で す。右クリックメニューで軸の限界値を設定できます。 |
| `numericBoxUpperY` | Upper bound of the displayed intensity (vertical) axis. | 縦軸（強度）の表示範囲の上限値です。 |
| `numericBoxUpperY` | Upper bound of the displayed intensity (vertical) axis. | 縦軸（強度）の表示範囲の上限値です。 |
| `pictureBoxMain` | Main profile viewer Left button drag: move a diffraction peak position of a checked  & selected crystal Right button click: Shrink Right button drag: Zoom Middle button drag: Translation | プロファイルを表示します 左ドラッグ: 回折線移動 右クリック: 縮小 右ドラッグ: 拡大 中ドラッグ: 平行移動 |
| `printToolStripMenuItem *(menu/bar)*` | Print the profile viewer. | プロファイル表示を印刷します。 |
| `programUpdatesToolStripMenuItem *(menu/bar)*` | Check for a newer version online and download/install it. | オンラインで最新版を確認し、 ダウンロード／インストールします。 |
| `radioButtonCountsPerStep` | Show counts normalized per step (CPS = counts / step width). | 1 ステップあたりのカウント（CPS = カウント / ステップ幅）に正規化して表示します。 |
| `radioButtonLinearity` | Plot intensity on a linear vertical scale. | 強度を縦軸リニア（線形）スケールで表示します。 |
| `radioButtonLogarithm` | Plot intensity on a logarithmic vertical scale (emphasizes weak peaks). | 強度を縦軸対数スケールで表示します （微弱なピークが見やすくなります）。 |
| `radioButtonRawCounts` | Show raw integrated counts (no division by step width). | 各点の生のカウント値（ステップ幅で割らない）を表示します。 |
| `readAndAddToolStripMenuItem *(menu/bar)*` | Load crystals from an XML file and add them to the current list. | 結晶データ（XML）を読み込み、現在のリストへ追加します。 |
| `readCrystalDataToolStripMenuItem *(menu/bar)*` | Load crystals from an XML file as a new list. | 結晶データ（XML）を新規リストとして読み込みます。 |
| `readPatternProfileToolStripMenuItem *(menu/bar)*` | Open and read diffraction profile file(s) as a new list. | 回折プロファイルファイルを新規リストとして読み込みます。 |
| `resetInitialCrystalDataToolStripMenuItem *(menu/bar)*` | Revert the crystal list to the initial (default) state. | 結晶リストを初期（既定）状態に戻します。 |
| `saveCrystalDataToolStripMenuItem *(menu/bar)*` | Save the current crystal list to a file. | 現在の結晶リストをファイルに保存します。 |
| `savePatternProfileToolStripMenuItem *(menu/bar)*` | Save all loaded profiles to a .pdi2 file. | 読み込み済みの全プロファイルを .pdi2 形式で保存します。 |
| `setDirectoryToTheWatchToolStripMenuItem *(menu/bar)*` | Choose the folder to watch for new profile files. | 監視対象とするフォルダを選択します。 |
| `toolStripButtonAtomicPositonFinder *(menu/bar)*` | Toggle the Atomic Position Finder window to search atomic positions from diffraction intensities. | 原子位置探索ウィンドウを開閉し、 回折強度から原子座標を探索します。 |
| `toolStripButtonCellFinder *(menu/bar)*` | Toggle the Cell Finder window to search lattice constants from peak positions. | セルファインダーウィンドウを開閉し、 ピーク位置から格子定数を探索します。 |
| `toolStripButtonCrystalParameter *(menu/bar)*` | Toggle the Crystal Parameter window. | 結晶の詳細設定ウィンドウを開閉します。 |
| `toolStripButtonEquationOfState *(menu/bar)*` | Toggle the Equation of State window to estimate pressure from the cell volume of a standard material. | 状態方程式ウィンドウを開閉し、標準物質の 格子体積から圧力を算出します。 |
| `toolStripButtonFittingParameter *(menu/bar)*` | Toggle the Peak Fitting window to fit diffraction peaks (position, FWHM, intensity). | ピークフィッティングウィンドウを開閉し、回折ピーク （位置・半値全幅・強度）をフィットします。 |
| `toolStripButtonLPO *(menu/bar)*` | Toggle the LPO (lattice-preferred orientation) Analysis window. | LPO（格子選択配向）解析ウィンドウを開閉します。 |
| `toolStripButtonProfileParameter *(menu/bar)*` | Toggle the Profile Parameter window. | プロファイルの詳細設定ウィンドウを開閉します。 |
| `toolStripButtonSequentialAnalysis *(menu/bar)*` | Toggle the Sequential Analysis window for batch processing of a file series. | 連続解析ウィンドウを開閉し、複数ファイルを一括処理します。 |
| `toolStripMenuItemExportCIF *(menu/bar)*` | Export the selected crystal as a CIF file. | 選択中の結晶を CIF 形式で保存します。 |
| `toolStripMenuItemExportExcelFile *(menu/bar)*` | Export the selected profile(s) to a text or GSAS file. | 選択中のプロファイルをテキストまた は GSAS ファイルへ書き出します。 |
| `toolStripMenuItemImport *(menu/bar)*` | Import a crystal structure from a CIF or AMC file. | CIF／AMC ファイルから結晶構造を取り込みます。 |
| `toolStripMenuItemPageSetup *(menu/bar)*` | Open the page setup dialog for printing. | 印刷のページ設定ダイアログを開きます。 |
| `toolStripMenuItemPrintPreview *(menu/bar)*` | Show a print preview of the profile viewer. | プロファイル表示の印刷プレビューを表示します。 |
| `toolStripMenuItemSaveMetafile *(menu/bar)*` | Save the viewer as an EMF metafile. | 表示内容を EMF メタファイルとして保存します。 |
| `toolStripTextBoxDirectoryToWatch *(menu/bar)*` | Path of the folder being watched (editable). | 監視対象フォルダのパスです（直接入力できます）。 |
| `toolTipToolStripMenuItem *(menu/bar)*` | Enable or disable the tooltips on the main window. | このウィンドウ（メイン画面）の ツールチップ表示を有効／無効にします。 |
| `watchReadANewProfileToolStripMenuItem *(menu/bar)*` | Watch a folder and automatically read newly created .pdi profile files. | 指定フォルダを監視し、新しく作成された .pdi プロファイルを自動的に読み込みます。 |
| `watchReadClipboardToolStripMenuItem *(menu/bar)*` | Watch the clipboard and auto-read profiles/crystals copied from other apps (e.g. IPAnalyzer). | クリップボードを監視し、他アプリ（IPAnalyzer 等）から コピーされたプロファイル／結晶を自動で取り込みます。 |

### FormPrintOption  （FormPrintOption.resx / EN 9 ・ JA 9）

| コントロール | EN | JA |
|---|---|---|
| `button1` | Apply these print options. | これらの印刷オプションを適用します。 |
| `button2` | Cancel without changing the print options. | 印刷オプションを変更せずにキャンセルします。 |
| `checkBoxPrintDiffractionPeak` | Include the marked diffraction peaks (index lines) in the printout. | 回折ピーク（指数線）を印刷に含めます。 |
| `checkBoxPrintProfile` | Include the diffraction profile curve in the printout. | 回折プロファイル曲線を印刷に含めます。 |
| `checkBoxPrintProfileName` | Print the profile name label; its position is set by the buttons below. | プロファイル名を印刷します。 表示位置は下のボタンで指定します。 |
| `radioButtonLowerLeft` | Place the profile name in the lower-left corner. | プロファイル名を左下に配置します。 |
| `radioButtonLowerRight` | Place the profile name in the lower-right corner. | プロファイル名を右下に配置します。 |
| `radioButtonUpperLeft` | Place the profile name in the upper-left corner. | プロファイル名を左上に配置します。 |
| `radioButtonUpperRight` | Place the profile name in the upper-right corner (default). | プロファイル名を右上に配置します（既定）。 |

### FormProfileSetting  （FormProfileSetting.resx / EN 65 ・ JA 65）

| コントロール | EN | JA |
|---|---|---|
| `button1` | Delete ALL loaded profiles (asks for confirmation). | 読み込み済みのすべてのプロファイルを削除します（確認あり）。 |
| `buttonApplyAllProfiles` | Apply the current processing settings to ALL profiles (background settings excluded). | 現在の各処理設定を、バックグラウンド設定を 除いてすべてのプロファイルに適用します。 |
| `buttonBackgroundAutoDetectBG` | Automatically place the specified number of background points along the profile. | 指定した点数でバックグラウンド点を プロファイル上に自動配置します。 |
| `buttonCalculate` | Perform the selected operation and add the result as a new profile. | 選択した演算を実行し、結果を新しい プロファイルとして一覧に追加します。 |
| `buttonChangeSourceXAxis` | Apply the edited horizontal-axis source settings (and exposure time) to the selected profile. | 編集した横軸の線源設定（と露光時間）を 選択中プロファイルに反映します。 |
| `buttonDeleteAllMask` | Delete all masking ranges of this profile. | このプロファイルのマスク範囲をすべて削除します。 |
| `buttonDeleteMask` | Delete the masking range selected in the list. | 一覧で選択中のマスク範囲を 1 件削除します。 |
| `buttonDeleteProfile` | Delete the currently selected profile. | 選択中のプロファイルを削除します。 |
| `buttonLower` | Move the selected profile down one position in the list. | 選択中プロファイルを一覧で 1 つ下へ移動します。 |
| `buttonTwoThetaCalibration` | Open/close the calibration window to determine the 2theta offset from an internal standard. | 内部標準を用いて 2θ オフセットを求める 校正ウィンドウの表示/非表示を切り替えます。 |
| `buttonTwoThetaOffsetReset` | Reset all three 2theta offset coefficients (c0, c1, c2) to zero. | 2θオフセットの 3 係数（c0, c1, c2）をすべて 0 に戻します。 |
| `buttonUpper` | Move the selected profile up one position in the list. | 選択中プロファイルを一覧で 1 つ上へ移動します。 |
| `checkBoxBackgroundSubtraction` | Step 6: Subtract a background curve from the profile. | 手順6: プロファイルからバックグラウンド曲線を差し引きます。 |
| `checkBoxBandPassFilter` | Step 4: Apply an FFT bandpass filter to suppress unwanted frequency components. | 手順4: FFT によるバンドパスフィルタ で不要な周波数成分を抑制します。 |
| `checkBoxHighPassFilter` | Enable a high-pass filter: remove low-frequency (long-period) components below the threshold. | ハイパスフィルタを有効にし、しきい値より 低い周波数（長周期）成分を除去します。 |
| `checkBoxLowPassFilter` | Enable a low-pass filter: remove high-frequency (short-period noise) components above the threshold. | ローパスフィルタを有効にし、しきい値より高い 周波数（短周期ノイズ）成分を除去します。 |
| `checkBoxMaskingMode` | Step 2: Mask selected x-ranges and replace them by polynomial interpolation (e.g. to remove artifacts). | 手順2: 指定した範囲をマスクし、多項式補間で 置き換えます（アーティファクト除去など）。 |
| `checkBoxNormarizeIntensity` | Step 7: Normalize the intensity within a chosen x-range to a target value. | 手順7: 指定した範囲内の強度を目標値に規格化します。 |
| `checkBoxRemoveKalpha2` | Step 5: Strip the Kalpha2 contribution from the profile (only when the source is an X-ray Kalpha1 line). | 手順5: プロファイルから Kα2 成分を除去し ます（線源がX線 Kα1 の場合のみ）。 |
| `checkBoxShiftHorizontalAxis` | Shift the entire profile along the horizontal axis by a fixed amount. | プロファイル全体を横軸方向に一定量だけ平行移動します。 |
| `checkBoxShowBackgroundProfile` | Show/hide the background curve on the graph (background subtraction must be on). | バックグラウンド曲線をグラフに表示/非表示し ます（BG 差し引きが有効なときのみ）。 |
| `checkBoxShowMaskedRange` | Enable setting/showing masking ranges directly on the graph with the mouse. | グラフ上でマウス操作によりマスク範囲を 設定・表示するモードを有効にします。 |
| `checkBoxSmoothing` | Step 3: Smooth the profile using a Savitzky-Golay filter. | 手順3: Savitzky-Golay フィルタでプロファイルを平滑化します。 |
| `checkBoxTwoThetaOffset` | Step 1: Apply a 2theta-angle offset Delta(2theta) = c0 + c1*tan(theta) + c2*tan^2(theta) (angle-dispersive data only). | 手順1: 角度分散測定の回折角に Δ(2θ)=c0+c1·tan(θ)+c2·tan²(θ) のオフセット補正を適用します。 |
| `colorControlLineColor` | Set the line (plot) color of the selected profile. | 選択中プロファイルの線（プロット）の色を設定します。 |
| `comboBoxBackgroundReferrence` | Select which loaded profile is used as the reference background. | 参照バックグラウンドとして差し引くプロファイルを選択します。 |
| `dataGridViewProfile` | List of loaded profiles. Select a row to edit it below; the checkbox toggles its plot and the swatch shows its line color. | 読み込み済みプロファイルの一覧です。行を 選ぶと下の各設定で編集でき、チェックで 表示/非表示、色見本で線色を示します。 |
| `label20` | Number of data points taken from each side of the masked range to fit the interpolation. | マスク範囲の左右それぞれから補間に 使うデータ点数を設定します。 |
| `label21` | Number of data points taken from each side of the masked range to fit the interpolation. | マスク範囲の左右それぞれから補間に 使うデータ点数を設定します。 |
| `listBoxMaskRanges` | List of masking ranges (start-end on the horizontal axis). Select one to highlight it; drop a .mas file to load ranges. | 設定済みマスク範囲（横軸の開始〜終了）の 一覧です。選択で強調表示し、.mas ファイルをドロップして読み込めます。 |
| `listBoxTwoProfiles1` | Select the first (primary) profile for the operation; allows multiple selection in Average mode. | 演算の第 1（主）プロファイルを選択しま す。平均モードでは複数選択できます。 |
| `listBoxTwoProfiles2` | Select the second profile for two-profile operations. | 2 プロファイル演算における第 2 プロファイルを選択します。 |
| `numericBoxTwhoThetaOffsetCoeff0` | Constant term c0 of the 2theta offset Delta(2theta) = c0 + c1*tan(theta) + c2*tan^2(theta), in degrees. | 2θオフセット式 Δ(2θ)=c0+c1·tan(θ)+c2·tan²(θ) の定数項 c0（度）を設定します。 |
| `numericBoxTwhoThetaOffsetCoeff1` | Coefficient c1 of the tan(theta) term in the 2theta offset, in degrees. | 2θオフセット式の tan(θ) 項の係数 c1（度）を設定します。 |
| `numericBoxTwhoThetaOffsetCoeff2` | Coefficient c2 of the tan^2(theta) term in the 2theta offset, in degrees. | 2θオフセット式の tan²(θ) 項の係数 c2（度）を設定します。 |
| `numericUpDownBackgroundReferrenceScale` | Scale factor multiplied to the reference background before subtraction. | 参照バックグラウンドに掛ける倍率を設定します。 |
| `numericUpDownBgPointsNumber` | Number of background points (3-50) used for auto-detection / B-spline fitting. | 自動検出・B-スプライン用のバックグラウンド 点の数（3〜50）を設定します。 |
| `numericUpDownHighPass` | High-pass cutoff frequency (in 1/[horizontal-axis unit]); components below it are removed. Range adapts to the data. | ハイパスのしきい値（横軸単位の逆数＝周波数） を設定します。これより低周波の成分を除去しま す（範囲はデータに応じて自動）。 |
| `numericUpDownInterpolationOrder` | Polynomial order used to interpolate across masked ranges (0-5). Higher = more flexible curve. | マスク範囲を補間する多項式の次数（0〜5）を 設定します。大きいほど曲線が柔軟になります。 |
| `numericUpDownInterpolationPoints` | Number of data points taken from EACH side of the masked range to fit the interpolation (used with the polynomial order). Larger = wider fitting window. | マスク範囲の左右それぞれから補間に使うデータ 点数を設定します。多項式次数と組み合わせ、 点数を増やすほど広い範囲を参照します。 |
| `numericUpDownLineWidth` | Set the plot line width of the selected profile, in points (pt). | 選択中プロファイルのプロット線の太さを pt 単位で設定します。 |
| `numericUpDownLowPass` | Low-pass cutoff frequency (in 1/[horizontal-axis unit]); components above it are removed. Range adapts to the data. | ローパスのしきい値（横軸単位の逆数＝周波数） を設定します。これより高周波の成分を除去しま す（範囲はデータに応じて自動）。 |
| `numericUpDownNormarizeIntensity` | Target intensity value (1-100000) the range's average/maximum is scaled to. | 範囲の平均/最大強度を合わせる 目標強度値（1〜100000）を設定します。 |
| `numericUpDownNormarizeRangeHigh` | Upper bound (horizontal-axis units) of the range used to compute the normalization. | 規格化の基準とする横軸範囲の上端（横軸単位）を設定します。 |
| `numericUpDownNormarizeRangeLow` | Lower bound (horizontal-axis units) of the range used to compute the normalization. | 規格化の基準とする横軸範囲の下端（横軸単位）を設定します。 |
| `numericUpDownShiftHorizontalAxis` | Amount to shift the profile along the horizontal axis (in horizontal-axis units). | 横軸方向の平行移動量（横軸単位）を設定します。 |
| `numericUpDownSmoothingSavitzkyAndGolayM` | Savitzky-Golay window half-width (points on each side). Larger = stronger smoothing. | Savitzky-Golay 平滑化の窓幅（片側の点数）を 設定します。大きいほど強く平滑化します。 |
| `numericUpDownSmoothingSavitzkyAndGolayN` | Savitzky-Golay polynomial order (0-5). Higher preserves peaks but smooths less. | Savitzky-Golay 平滑化の多項式次数（0〜5）を設定します。 大きいほどピーク形状を保ちますが平滑化は弱まります。 |
| `numericalTextBoxExposureTime` | Exposure time in seconds, used to convert intensity to counts-per-second (CPS) on the vertical axis. | 縦軸を CPS（毎秒カウント）表示に換算す る際に使う露光時間（秒）を設定します。 |
| `numericalTextBoxTargetValue` | Constant value combined with the profile in 'Profile and value' mode. | 「Profile and value」モードでプロファイル に演算する定数値を設定します。 |
| `radioButtonAddition` | Select addition (+) as the operation. | 演算として加算（＋）を選びます。 |
| `radioButtonAverage` | Operator mode: average multiple selected profiles (with error propagation). | 演算モード: 選択した複数プロファイル の平均を計算します（誤差も伝播）。 |
| `radioButtonBackgroundReferrence` | Use another profile as the reference background to subtract. | 別のプロファイルを参照バックグラウンド として差し引くモードにします。 |
| `radioButtonBagkgroundBSpline` | Define the background as a B-spline curve through manually/auto-placed points. | バックグラウンドを、手動または自動で配置した 点を通る B-スプライン曲線として定義します。 |
| `radioButtonDivision` | Select division as the operation (the button shows no symbol; this is the divide operator). | 演算として除算（÷）を選びます （ボタンに記号は表示されません）。 |
| `radioButtonMutiplication` | Select multiplication as the operation (the button shows no symbol; this is the multiply operator). | 演算として乗算（×）を選びます （ボタンに記号は表示されません）。 |
| `radioButtonNormarizeAverage` | Normalize so that the AVERAGE intensity in the range equals the target value. | 範囲内の平均強度が目標値になるように規格化します。 |
| `radioButtonNormarizeMaximum` | Normalize so that the MAXIMUM intensity in the range equals the target value. | 範囲内の最大強度が目標値になるように規格化します。 |
| `radioButtonProfileAndValue` | Operator mode: combine one profile with a constant value (add or multiply). | 演算モード: 1 つのプロファイルと 定数値を演算します（加算・乗算）。 |
| `radioButtonSubtraction` | Select subtraction (-) as the operation. | 演算として減算（－）を選びます。 |
| `radioButtonTwoProfiles` | Operator mode: perform +, -, * or / between two selected profiles. | 演算モード: 選択した 2 つのプロファイル 間で ＋・－・×・÷ を行います。 |
| `textBoxComment` | Free-text comment stored with the selected profile; does not affect processing. | 選択中プロファイルに付ける任意のコメント を設定します。処理には影響しません。 |
| `textBoxOutputFilename` | Name given to the newly created result profile (trailing number auto-increments after each calculation). | 演算結果として生成するプロファイルの名前を設定し ます（計算ごとに末尾の連番が自動で増えます）。 |
| `textBoxProfileName` | Display name of the selected profile (shown in lists and legends). | 選択中プロファイルの表示名を設定し ます。一覧や凡例に表示されます。 |
| `xAxisUserControl` | Edit the source horizontal-axis settings (axis type 2theta/d/energy/TOF, radiation source, wavelength, takeoff angle). Apply with 'Change'. | 線源の横軸設定（横軸種別 2θ/d/エネルギー /TOF、線源、波長、取り出し角）を編集しま す。「Change」で確定します。 |

### FormSequentialAnalysis  （FormSequentialAnalysis.resx / EN 26 ・ JA 26）

| コントロール | EN | JA |
|---|---|---|
| `buttonCopy` | Copy the active tab's table to the clipboard (tab-separated). | 表示中タブの表をタブ区切りでクリップボードにコピーします。 |
| `buttonExecute` | Run the sequential analysis: fit every loaded profile in turn and tabulate 2theta, d-spacing, FWHM, intensity, cell constants and pressure. Requires the Fitting window open with peaks checked. | 連続解析を実行します。読み込んだ全プロファイルを 順にフィットし、2θ・d 値・FWHM・強度・格子定数・ 圧力を表に出力します。Fitting フォームでピークを チェックしておく必要があります。 |
| `buttonSave` | Save the active tab's table to a CSV file. | 表示中タブの表を CSV ファイルに保存します。 |
| `buttonSetDirectory` | Choose the folder where auto-saved CSV files are written. | 自動保存する CSV の出力先フォルダを選択します。 |
| `checkBoxAutoSaveCell` | Automatically save the lattice-constant results (with errors) to '*_cell.csv'. | 解析後に格子定数（誤差付き）結果を '*_cell.csv' として自動保存します。 |
| `checkBoxAutoSaveD` | Automatically save the d-spacing results to '*_d.csv' after analysis. | 解析後に d 値結果を '*_d.csv' として自動保存します。 |
| `checkBoxAutoSaveFWHM` | Automatically save the FWHM (full width at half maximum) results to '*_fwhm.csv'. | 解析後に FWHM（半値全幅）結果を '*_fwhm.csv' として自動保存します。 |
| `checkBoxAutoSaveInt` | Automatically save the integrated-intensity results to '*_intensity.csv'. | 解析後に積分強度結果を '*_intensity.csv' として自動保存します。 |
| `checkBoxAutoSavePressure` | Automatically save the pressure results to '*_pressure.csv'. | 解析後に圧力結果を '*_pressure.csv' として自動保存します。 |
| `checkBoxAutoSaveSingh` | Automatically save the Singh's-equation parameters to '*_Singh.csv'. | 解析後に Singh の式のパラメータを '*_Singh.csv' として自動保存します。 |
| `checkBoxAutoSaveTwoTheta` | Automatically save the 2theta results to '*_2theta.csv' in the chosen directory after analysis. | 解析後に 2θ 結果を指定ディレクトリへ '*_2theta.csv' として自動保存します。 |
| `checkBoxLoop` | When starting from a number, also process the skipped earlier profiles (0 ... start-1) after reaching the end, wrapping around. | 開始番号を指定した場合に、末尾まで処理した後に飛ば した先頭側（0〜開始番号-1）も続けて処理します。 |
| `checkBoxStartNumber` | Start the analysis from the profile number set at right instead of the first one (the first profile is number 0). | 解析を先頭ではなく右で指定した番号の プロファイルから開始します（先頭は 0 番）。 |
| `checkBoxToleranceFactor` | Reject a fit (output NaN) when the refined cell volume changes from the initial value by more than the tolerance factor at right. | フィット後の体積が初期値から右の許容係数を超えて 変化した場合、その結果を NaN として棄却します。 |
| `graphControl1` | Plot of the fitted Singh's-equation d-spacing vs. azimuth Psi (0-360 degrees). | フィットした Singh の式の d 値–方位角 Ψ（0〜360°）曲線を表示します。 |
| `numericBoxStartNumber` | Profile index to start from (integer, minimum 1); enabled only when 'start from number' is checked. | 解析を開始するプロファイル番号（整数、最小 1）で す。左のチェックが ON のときだけ入力できます。 |
| `numericBoxToleranceFactor` | Allowed cell-volume change as a percentage (0-100%); fits exceeding it are discarded. | 許容する体積変化の割合（%、0〜100）です。 これを超えたフィット結果は破棄します。 |
| `tabControl` | Switch between result categories (2theta / d / FWHM / intensity / cell / pressure / Singh); Copy and Save act on the currently selected tab. | 結果の種類（2θ／d 値／FWHM／強度／格 子定数／圧力／Singh）を切り替えます。 コピー／保存は表示中タブが対象です。 |
| `textBox2theta` | Per-profile peak positions 2theta (degrees), one row per profile. | プロファイルごとのピーク位置 2θ（°）を 1 行ずつ表示します。 |
| `textBoxCellConstants` | Per-profile refined cell volume and lattice constants a-gamma with their errors (Angstrom, degrees). | プロファイルごとの精密化した体積・格子定数 a〜γ とその誤差（Å, °）を表示します。 |
| `textBoxDirectory` | Shows the destination folder for auto-saved files; set it with the 'Set' button. | 自動保存先フォルダのパスを表示します （読み取り専用、「設定」で変更します）。 |
| `textBoxDspacing` | Per-profile d-spacings (Angstrom). | プロファイルごとの面間隔 d 値（Å）を表示します。 |
| `textBoxFWHM` | Per-profile peak FWHM (full width at half maximum, degrees). | プロファイルごとのピーク FWHM（半値全幅、°）を表示します。 |
| `textBoxIntensity` | Per-profile integrated peak intensities. | プロファイルごとのピークの積分強度を表示します。 |
| `textBoxPressure` | Per-profile pressure (GPa) derived from the equation of state of the selected standard material. | 選択した標準物質の状態方程式から求めた 各プロファイルの圧力（GPa）を表示します。 |
| `textBoxSingh` | Singh's-equation parameters (d0, Psi_max, t/6*G_hkl) refined from the stress-analysis profiles. | 応力解析プロファイルから精密化した Singh の 式パラメータ（d0, Ψmax, t/6·Ghkl）を表示します。 |

### FormTwoThetaCalibration  （FormTwoThetaCalibration.resx / EN 3 ・ JA 3）

| コントロール | EN | JA |
|---|---|---|
| `buttonCalibrate` | Iteratively fit the observed vs. calculated 2theta of the standard and update the 2theta offset coefficients. (Requires the Fitting window to be open.) | 標準物質の観測 2θ と計算 2θ の差を反復 フィッティングし、2θ オフセット係数を更新します （フィッティング窓を開いている必要があります）。 |
| `buttonRevert` | Restore the 2theta offset coefficients to the values before the last calibration. | 2θ オフセット係数を直前の較正前の値に戻します。 |
| `numericUpDownOrder` | Number of terms (1-3) in the shift function Delta(2theta) = a1 + a2*tan(theta) + a3*tan^2(theta). 1 = zero-offset only; higher orders fit angle-dependent shift. | シフト関数 Δ(2θ)=a1+a2·tanθ+a3·tan²θ の 項数（1〜3）を指定します。1 はゼロ点オフセット のみ、値を上げると角度依存のずれも補正します。 |

