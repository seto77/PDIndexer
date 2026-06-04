<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# 状態方程式

メイン画面のツールバーで `Equation of States`（状態方程式）アイコンをクリックすると、下のようなウィンドウが開きます。これは標準物質の状態方程式（EOS, Equation of State）から圧力を計算するためのツールです。

![状態方程式ウィンドウ全体](../assets/cap-ja-auto/FormEOS.png)

高圧実験では、試料と一緒に圧力の基準となる標準物質（圧力マーカー）を入れて測定し、その標準物質の格子定数（体積）と既知の状態方程式から圧力を逆算します。本ツールはその計算を行います。

## 使い方

1. ウィンドウ上部のチェックボックスから、圧力を求めたい標準物質を選択します。
2. 選択した物質ごとに、ウィンドウ下部にその計算結果（圧力）が表示されます。
3. 格子定数（`a`、`a0` または体積 `V`、`V0`）を直接入力して計算できます。
4. メイン画面で回折線をマウスでドラッグして動かすと、その値が即座に状態方程式の計算結果に反映されます。

!!! note "結晶リストとの対応"
    標準物質は、結晶リストの中でピンク色の行として表示されている結晶に対応します。標準で約 10 種類の物質（金 Au、白金 Pt、NaCl-B1、NaCl-B2、ペリクレース MgO、コランダム Al2O3、アルゴン Ar、レニウム Re、モリブデン Mo、鉛 Pb など）が用意されています。

## 対応している標準物質

ウィンドウ上部のチェックボックスで選択できる標準物質は次の通りです。物質ごとに複数の研究者による状態方程式（出典）が用意されており、選択したものすべての結果が個別に表示されます。

| 標準物質 | 内容 |
| --- | --- |
| `Au (Gold)` | 金 |
| `Pt (Platinum)` | 白金 |
| `NaCl (B1)` | 塩化ナトリウム（B1 構造、岩塩型） |
| `NaCl (B2)` | 塩化ナトリウム（B2 構造、CsCl 型） |
| `MgO (Periclase)` | 酸化マグネシウム（ペリクレース） |
| `Al2O3 (Corundum)` | 酸化アルミニウム（コランダム） |
| `Ar` | アルゴン |
| `Re` | レニウム |
| `Mo` | モリブデン |
| `Pb` | 鉛 |
| `hBN` | 六方晶窒化ホウ素 |

## 入力パラメータ

各物質の `groupBox` では、次の値を入力・参照します。

| 項目 | 説明 |
| --- | --- |
| `a` / `V` | 測定された格子定数、または体積。メイン画面で回折線を動かすと自動的に更新されます。 |
| `a0` / `V0` | 常圧（基準状態）での格子定数、または体積。 |
| `Temperature` | 試料の温度。熱圧力を含む状態方程式（高温 EOS）で使用します。 |
| `T0` | 基準温度。`Temperature` とあわせて熱圧力の補正に使います。 |

!!! tip "温度を考慮した状態方程式"
    一部の出典は熱圧力（thermal pressure）を含む高温状態方程式に対応しています。`Temperature` と `T0` を実験条件に合わせて入力することで、温度補正を加えた圧力が得られます。`Sakai+(11)` の Vinet/BM など、Mie-Grüneisen(-Debye) モデルを用いた式がこれにあたります。

## 物質ごとの出典（参考文献）

各物質の `groupBox` には、複数の出典による状態方程式が並んでおり、それぞれの式で計算した圧力が同時に表示されます。研究や測定条件に応じて、信頼できる出典を選んで比較できます。以下に代表的な物質の出典例を示します。

### 金（Gold）

![金の状態方程式の出典一覧](../assets/cap-ja-auto/FormEOS.tableLayoutPanel1.flowLayoutPanel1.groupBoxGold.png)

金（`Au (Gold)`）では、`Yokoo (09)`、`Matsui (09)`、`Holmes (89)`、`Jamieson (82)`、`Fratanduono (21)` などの状態方程式が利用できます。

### NaCl（B1 構造）

![NaCl-B1 の状態方程式の出典一覧](../assets/cap-ja-auto/FormEOS.tableLayoutPanel1.flowLayoutPanel1.groupBoxNaClB1.png)

`NaCl (B1)` では、`Brown (99)`、`Sakai+`、`Matsui (12)` などの状態方程式が利用できます。

### ペリクレース（Periclase, MgO）

![ペリクレース MgO の状態方程式の出典一覧](../assets/cap-ja-auto/FormEOS.tableLayoutPanel1.flowLayoutPanel1.groupBoxPericlase.png)

`MgO (Periclase)` では、`Tange (09) BM`、`Tange (09) Vinet`、`Aizawa (06)`、`Dewaele (00)`、`Jackson (98)` などの状態方程式が利用できます。

!!! note "そのほかの物質"
    白金（`Pt (Platinum)`：`Fratanduono (21)`、`Holmes (89)` ほか）、`NaCl (B2)`（`Sakai (02)`、`Ueda+(08)` ほか）、コランダム（`Al2O3 (Corundum)`：`Sata (02)` ほか）、`Ar`（`Dubrovinsky (98)`、`Ross et al. (86)`、`Jephcoat (98)` ほか）、`Re`（`Zha et al. (04)` ほか）、`Mo`（`Zhao+(00)`、`Huang+(16) MGD` ほか）、`Pb`（`Strässle+(14)` ほか）も同様に、複数の出典から選択できます。

## 状態方程式の理論

物質の圧力・体積・温度の関係を表す式が状態方程式 \( P = P(V, T) \) であり、測定した体積 \( V \) から圧力 \( P \) を求めるのが本ツールの役割です。圧力は、基準温度での **等温圧縮項** \( P_\text{st}(V) \) と、基準温度との差による **熱圧力項** \( \Delta P_\text{th} \) の和として計算します。

$$P(V, T) = P_\text{st}(V) + \Delta P_\text{th}(V, T)$$

以下の一般式は、本フォームが各標準物質の圧力を計算する際の共通の枠組みです。各出典は、この枠組みに公表されたパラメータを当てはめるか、出典固有の式を用います（出典ごとの具体的な式・パラメータは下の [出典別の計算式](#per-source) を参照）。なお、結晶ごとに EOS を設定する Crystal Information の状態方程式タブについては [回折線・結晶情報](3-crystal-parameter.md) を参照してください。

### 記号

| 記号 | 意味 |
| --- | --- |
| \( V_0,\ V \) | 基準状態・測定状態の単位胞体積 |
| \( K_0 \) | 基準温度・基準体積での等温体積弾性率 |
| \( K_0' \) | \( K_0 \) の圧力微分 |
| \( K_0'' \) | \( K_0 \) の圧力二階微分（BM4 で使用） |
| \( T_0,\ T \) | 基準温度・測定温度 |
| \( \gamma_0 \) | 基準体積での Grüneisen 定数 |
| \( \theta_0 \) | 基準体積での Debye 温度 |
| \( q \) | Grüneisen 定数の体積依存性 |
| \( n \) | 化学式単位あたりの原子数 |
| \( R \) | 気体定数 |

### 等温圧縮項 \( P_\text{st}(V) \)

体積比を \( x = V_0/V \) とします。

**3 次 Birch-Murnaghan 式（BM3, 既定）**

$$P_\text{st} = \tfrac{3}{2}K_0\left(x^{7/3} - x^{5/3}\right)\left[1 + \tfrac{3}{4}(K_0' - 4)\left(x^{2/3} - 1\right)\right]$$

**Vinet 式**: \( y = (V/V_0)^{1/3} \) として

$$P_\text{st} = 3K_0\,\frac{1-y}{y^2}\,\exp\!\left[\tfrac{3}{2}(K_0' - 1)(1 - y)\right]$$

このほか、4 次 Birch-Murnaghan 式（**BM4**, \( K_0'' \) を含む高次項を追加）、**AP2**、**Keane** 式も選択できます。

### 熱圧力項 \( \Delta P_\text{th}(V, T) \)

**Mie-Grüneisen-Debye モデル（既定）**: モル体積を \( V_m \)（基準は \( V_{m0} \)）として、Grüneisen 定数と Debye 温度を

$$\gamma = \gamma_0\left(\frac{V_m}{V_{m0}}\right)^{q},\qquad \theta = \theta_0\exp\!\left[\frac{\gamma_0 - \gamma}{q}\right]$$

とし、熱圧力は

$$\Delta P_\text{th} = \frac{\gamma}{V_m}\Bigl[E_\text{th}(T,\theta) - E_\text{th}(T_0,\theta)\Bigr]$$

で与えられます。ここで \( E_\text{th} \) は Debye の内部エネルギー

$$E_\text{th}(T,\theta) = 9nRT\left(\frac{T}{\theta}\right)^3\int_0^{\theta/T}\frac{t^3}{e^t - 1}\,dt$$

です。

**T-dependence K0&V0 モデル**: 体積弾性率と基準体積を温度の関数とし、\( K_{T0} = K_0 + (\partial K/\partial T)(T - T_0) \)、熱膨張率 \( \alpha(T) = A\times10^{-5} + B\times10^{-9}\,T + C/T^2 \) の積分から温度補正した基準体積 \( V_0(T) \) を求め、上の等温式に代入します。

各物質ごとの具体的なパラメータ値や出典の背景は、作者による解説ページにもまとめられています。

- [状態方程式（EOS）の解説](https://yseto.net/misc/misc-4/misc-4-1)

## 出典別の計算式 {#per-source}

各標準物質では、出典ごとに次の 3 通りのいずれかで圧力を計算します。

1. **一般式＋公表パラメータ**: 上記の BM3 / BM4 / Vinet（等温項）に Mie-Grüneisen-Debye（熱圧力）を組み合わせ、出典の公表値を当てはめる。
2. **出典固有の閉形式**: その出典に固有の式を用いる（該当箇所に式を示します）。
3. **公表 P-V-T 表の補間**: 解析式ではなく、出典が公表した圧力・体積・温度の数表を 2 段の 3 次スプライン（圧縮率方向 → 温度方向）で補間する。

以下、物質ごとに FormEOS が表示する出典と計算式を示します（パラメータは実装にハードコードされた公表値。K0 は GPa、温度は K、体積比は V/V0）。BM3/BM4/Vinet/Mie-Grüneisen-Debye の式形は前節を参照してください。

### 金 Au

| 出典 | モデル | 主なパラメータ |
| --- | --- | --- |
| Jamieson82 | P-V-T 表のスプライン補間 | 圧縮率 x=1−V/V0、T=200–1500 K |
| Anderson89 | BM3 + 線形熱項 | K0=166.65, K0'=5.4823, ∂K/∂T=−0.0115 |
| Sim02 | BM3 + Mie-Grüneisen-Debye | K0=167, K0'=5.0；θ0=170, γ0=2.97, q=1.0, n=1 |
| Tsuchiya03 | P-V-T 表のスプライン補間 | T=300–2500 K |
| Yokoo09 | P-V-T 表のスプライン補間 | T=0–3000 K |
| Fratanduono21 | Vinet（等温） | K0=170.09, K0'=5.880 |

Anderson89 の熱項: $\Delta P_\text{th} = \left[0.00714 + (\partial K/\partial T)\ln(V_0/V)\right](T-300)$。

### 白金 Pt

| 出典 | モデル | 主なパラメータ |
| --- | --- | --- |
| Jamieson82 | P-V-T 表のスプライン補間 | T=200–1500 K |
| Holmes89 | Vinet（等温項）+ 線形熱項 | K0=266, K0'=5.81, αT=0.261 |
| Matsui09 | Vinet + Mie-Grüneisen-Debye + 電子熱圧 Pel | K0=273, K0'=5.20；θ0=230, γ0=2.70, q=1.10 |
| Yokoo09 | P-V-T 表のスプライン補間 | T=0–3000 K |
| Fratanduono21 | Vinet（等温） | K0=259.7, K0'=5.839 |

Holmes89 の熱項: $\Delta P_\text{th} = \alpha_T K_0 (T-300)/10000$。Matsui09 の電子熱圧 $P_\text{el}$ は温度の 3 次多項式（基準 300 K で約 0.04 GPa）。

### アルゴン Ar

| 出典 | モデル | 主なパラメータ |
| --- | --- | --- |
| Ross86 | P-V 表のスプライン補間（273 K 等温） | モル体積 [cm³/mol] を内挿 |
| Jephcoat98 | BM3 + Mie-Grüneisen-Debye | K0=3.03, K0'=7.24；θ0=93.3, γ0=0.5, T0=4 K |

Jephcoat98 は γ を体積に線形依存させます: $\gamma = \gamma_0 + \gamma_1 (V/V_0)$（γ1=2.20、θ は θ0 固定）。

### 酸化マグネシウム MgO

| 出典 | モデル | 主なパラメータ |
| --- | --- | --- |
| Jackson98 | BM3 + Mie-Grüneisen-Debye | K0=162.5, K0'=4.13；θ0=673, γ0=1.41, q=1.3, n=2 |
| Dewaele00 | BM3 + Mie-Grüneisen-Debye | K0=161, K0'=3.94；θ0=800, γ0=1.45, q=0.8, n=2 |
| Aizawa06 | BM3 + Mie-Grüneisen-Debye | K0=160, K0'=4.15；θ0=773, γ0=1.41, q=0.7, n=2 |
| Tange09 Vinet | Vinet + Tange 熱項 | K0=160.63, K0'=4.367；θ0=761, γ0=1.442, a=0.138, b=5.4 |
| Tange09 BM | BM3 + Tange 熱項 | K0=160.64, K0'=4.221；θ0=761, γ0=1.431, a=0.29, b=3.5 |

Tange 熱項は γ の体積依存を $\gamma=\gamma_0\left[1+a\left((V/V_0)^{b}-1\right)\right]$ とし、Debye 内部エネルギーを θ/T の多項式で近似します。

### 塩化ナトリウム NaCl（B2 構造）

| 出典 | モデル | 主なパラメータ |
| --- | --- | --- |
| Sata02（Pt 基準） | Decker/Sata 型閉形式 | Pr=31.14, Kr=143.5, V0=27.17 Å³ |
| Sata02（MgO 基準） | Decker/Sata 型閉形式 | Pr=32.15, Kr=141.0, V0=27.17 Å³ |
| Ueda08 | Vinet + 線形熱項 | K0=28.45, K0'=5.16；熱項 0.00468(T−300) |
| Sakai11 BM | BM3（等温） | K0=47.00, K0'=4.10, V0=37.73 Å³ |
| Sakai11 Vinet | Vinet（等温） | K0=40.40, K0'=5.04, V0=37.73 Å³ |

Sata 型: $P = P_r (V/V_0)^{-2/3}\exp\!\left[-(3K_r/P_r-2)\left((V/V_0)^{1/3}-1\right)\right]$。

### 塩化ナトリウム NaCl（B1 構造）

| 出典 | モデル | 主なパラメータ |
| --- | --- | --- |
| Brown99 | P-V-T 表のスプライン補間 | T=300–1200 K |
| Matsui12 | BM4 + Mie-Grüneisen-Debye | K0=23.7, K0'=5.14, K0''=−0.392；θ0=279, γ0=1.56, q=0.96, n=2 |
| Skelton84 | P-V-T 表のスプライン補間（線歪 1−a/a0） | T=0–298 K |

### コランダム Al2O3

| 出典 | モデル | 主なパラメータ |
| --- | --- | --- |
| Dubrovinsky98 | BM3（K0・V0 を温度補正） | K0=258, K0'=4.88, ∂K/∂T=−0.020；熱膨張 a=2.6e−5, b=1.81e−9, c=−0.67 |

$K_T=258+(\partial K/\partial T)(T-300)$ と、熱膨張で補正した $V_0(T)=V_0\exp\!\left[a(T-T_0)+\tfrac{b}{2}(T^2-T_0^2)-c(1/T-1/T_0)\right]$ を用いて BM3 を評価します。

### レニウム Re

| 出典 | モデル | 主なパラメータ |
| --- | --- | --- |
| Zha04 | P-V-T 表のスプライン補間 | x=1−V/V0=0–0.20、T=300–3000 K |
| Anz | Vinet（等温） | K0=352.6, K0'=4.56, V0=29.467 Å³ |
| Sakai | Vinet（等温） | K0=358, K0'=4.8, V0=29.47 Å³ |
| Dub | BM4（等温） | K0=342, K0'=6.15, K0''=−0.029, V0=29.46 Å³ |

### モリブデン Mo

| 出典 | モデル | 主なパラメータ |
| --- | --- | --- |
| Huang16 | BM3 + Mie-Grüneisen-Debye | K0=255, K0'=4.25；θ0=470, γ0=2.01, q=0.6, n=1, z=2 |
| Zhao00 | BM4 + 熱膨張補正（T-dependence） | K0=268, K0'=3.81, K0''=−0.0141, ∂K/∂T=−0.0213；熱膨張 A=1.31e−5, B=11.2e−9 |

Zhao00 は $K_{T0}=K_0+(\partial K/\partial T)(T-T_0)$ と熱膨張で補正した $V_0(T)$ を用いて BM4 を評価します。

### 鉛 Pb

| 出典 | モデル | 主なパラメータ |
| --- | --- | --- |
| Strassle14 | Vinet（K0・K0'・a0 を温度補間） | B(T), B'(T), a0(T) を実測表から線形補間（B/B' は 0–300 K、a0 は 0–310 K） |

## 関連ページ

- 結晶の登録やリスト表示については [プロファイル情報](4-profile-parameter.md) などの関連ページを参照してください。
