<!-- 261105Cl: docs/drafts/261105-cloud — コードから起こした計算手法の下書き。docs/src には未統合 (mkdocs ビルド対象外)。 -->
# 計算手法（実装準拠）

> 本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

本稿は PDIndexer の数値処理を **現行コードの実装どおりに** 記述したものです。既存の [アルゴリズム解説](../../../src/ja/appendix/algorithms.md)（旧 `PDIndexerAlgorithm.pdf` の移植）と式が異なる箇所は、両方を示して「要確認」に挙げています。参照したコードは PDIndexer 本体 (`PDIndexer/`) と共通ライブラリのサブモジュール `Crystallography/`（コミット `c28490a`）です。

1. [内部単位と横軸の換算](#1-axis)
2. [プロファイル処理の流れ](#2-pipeline)
3. [ピークプロファイル関数](#3-profile-functions)
4. [ピークフィッティング（Marquardt 法）](#4-peak-fitting)
5. [格子定数の最小二乗精密化](#5-lattice-refinement)
6. [既存「アルゴリズム解説」との差分](#6-diff)
7. [実装上の疑問点（本稿に関わるもの）](#7-issues)
8. [要確認事項](#8-tbc)

---

## 1. 内部単位と横軸の換算 {#1-axis}

### 1.1 内部表現

- 横軸の換算はすべて **d 値（単位 nm）を経由** します。`HorizontalAxisConverter.ConvertToD()` が任意の横軸 → d [nm]、`ConvertFromD()` が d [nm] → 任意の横軸を担当します（`Crystallography/Profile.cs`, `HorizontalAxisConverter`）。
- 波長 `HorizontalAxisProperty.WaveLength` も **nm** で保持されます（`TwoThetaInDegreeToD()` 等が `d = λ / (2 sin θ)` を同一単位で計算するため）。
- 横軸の種類は `enum HorizontalAxis { Angle, d, WaveNumber, Length, EnergyXray, EnergyElectron, EnergyNeutron, NeutronTOF, None }`（`Profile.cs`）。角度単位は `enum AngleUnitEnum { Degree, Radian, CentiDegree, MilliRadian }`（`Crystallography/Enums.cs`、CentiDegree / MilliRadian は ver4.457 で追加）。

### 1.2 換算式（実装どおり）

| 横軸 | → d [nm] | 実装 |
| --- | --- | --- |
| 2θ（度） | $d=\lambda/\{2\sin(2\theta\cdot\pi/360)\}$ | `TwoThetaInDegreeToD` |
| 2θ（ラジアン） | $d=\lambda/\{2\sin(2\theta/2)\}$ | `TwoThetaInRadianToD` |
| 2θ（センチ度 c°） | 入力を 1/100 して度として扱う | `TwoThetaInCentiDegreeToD` |
| 2θ（ミリラジアン） | 入力を 1/1000 してラジアンとして扱う | `TwoThetaInMilliRadianToD` |
| d（Å / nm） | Å は ×0.1 | `ConvertToD` |
| 波数 | $d=2\pi/q$（$q$ は nm⁻¹。Å⁻¹ 入力は ×10 してから） | `WaveNumberToD` |
| X 線エネルギー | $d=\lambda(E)/\{2\sin(2\theta_\mathrm{EDX}/2)\}$ | `XrayEnergyToD` |
| 中性子 TOF | $d=\lambda(v)/\{2\sin(2\theta_\mathrm{TOF}/2)\}$, $v=L/t$ | `NeutronTofToD` |

エネルギー分散（EDX）のときの $2\theta_\mathrm{EDX}$ は `HorizontalAxisProperty.EnergyTakeoffAngle`（コメント上は「取り出し角 (2Θ)」、ラジアン）で、**散乱角 2θ そのもの** を与えます（`DToXrayEnergy(d, takeoffAngle)` が `2d·sin(takeoffAngle/2)` を波長とするため）。エネルギーの単位は内部 eV で、keV / MeV は ×10³ / ×10⁶ して換算します。

波長とエネルギー・速度の関係（`Crystallography/UniversalConstants.cs`, `UniversalConstants.Convert`）:

- X 線: $E\,[\mathrm{eV}] = \dfrac{6.62606896}{1.60217733}\times 2.99792458\times 100 \Big/ \lambda\,[\mathrm{nm}]$、すなわち $E\lambda = 1239.8412\ \mathrm{eV\,nm}$（$=12.398412\ \mathrm{keV\,Å}$）。`WavelengthToXrayEnergy` / `EnergyToXrayWaveLength`。
- 中性子: $\lambda\,[\mathrm{nm}] = h/(m_n v)\times 10^{3}$（$v$ は m/μs、$h=6.62606896\times10^{-34}$, $m_n=1.674927351\times10^{-27}$ kg）。`NeutronVelocityToWavelength`。TOF は μs（ns 入力は 1/1000）、飛行距離 $L$ は m。
- 中性子エネルギー: $E=h^2/(2m_n\lambda^2)$（`WaveLengthToNeutronEnergy`）。
- 電子線: 相対論補正込みの $\lambda = h/\sqrt{2m_0eV(1+eV/2m_0c^2)}$ を 2 次方程式として解く（`WaveLengthToElectronEnergy`、keV）。`DToElectronEnergy` はさらに ×1000 して eV にしている。

---

## 2. プロファイル処理の流れ {#2-pipeline}

実装は `Crystallography/Profile.cs` の `class DiffractionProfile2`。UI（`FormProfileSetting.SetCurrentProfile`）が設定を書き込み、`SetConvertedProfile(HorizontalAxisProperty)` から次の順に連鎖実行されます。各段は前段の結果を入力にします。

| 順 | 処理 | 実装 | 生成物 |
| --- | --- | --- | --- |
| 1 | 横軸変換（Src→Dst）、CPS 化 $Y/t_\mathrm{exp}$（`IsCPS` かつ `ExposureTime>0`）、対数表示時 $\log_{10}Y$ | `ConvertSrcToDest` | |
| 2 | 横軸シフト $X\leftarrow X+\Delta$（`IsShiftX`） | `SetConvertedProfile` | |
| 3 | 2θ オフセット $X\leftarrow X+c_0+c_1t+c_2t^2$、$t=\tan(X\pi/360)$（横軸が角度のとき。X を 2θ [度] とみなす） | 同上 | `ConvertedProfile` |
| 4 | マスク範囲の削除と多項式補間 | `SetMaskingProfile` | `InterpolatedProfile` |
| 5 | Savitzky–Golay 平滑化 → FFT バンドパス | `SetSmoothingProfile` | `SmoothedProfile` |
| 6 | Kα2 除去 | `SetKalpha2RemovedProfile` | `Kalpha2RemovedProfile` |
| 7 | 強度の正規化 → バックグラウンド減算 | `SetBackGroundProfile`（内部で `Normarize()` を先に呼ぶ） | `Profile` |

既存マニュアル（4 章）は「1〜7 の番号順」とし、正規化（7）をバックグラウンド（6）の後に置いていますが、実装は **正規化が先** です。B-Spline 背景は正規化前の `ConvertedProfile` から作られるため、正規化を有効にすると背景曲線と強度のスケールが合わなくなります（4 章監査の疑問点）。誤差 `Err` は X の変換と正規化の倍率だけを受け、平滑化・バンドパス・Kα2・背景では変わりません。

### 2.1 マスクと補間（`SetMaskingProfile`, `Profile.GetValues`）

各マスク範囲の開区間 $(x_\mathrm{min},x_\mathrm{max})$ の点を削除し、範囲の両側から交互に計 $2N_p$ 点（片側 $N_p$ 点）を取り、X を $[0,1]$ 付近に線形スケールした上で次数 $n$ の多項式を最小二乗で当てはめ、削除した X で評価して戻します（同一範囲内は同じ多項式）。プロファイル側の既定は $n=2$, $N_p=20$（`InterpolationOrder`, `InterpolationPoints`）。

### 2.2 Savitzky–Golay 平滑化（`Crystallography/Smoothing.cs`）

UI の `Point No.` $M$ は **窓の総点数**（±M ではない）、`Order` $N$ は多項式次数。$M<2$ または $N\le0$ なら処理なし、$M<N+1$ なら $N\leftarrow M-1$。

- 等間隔データ（`SavitzkyGolaySimple`）: $A_{ji}=(j-\lfloor M/2\rfloor)^i$ として $(A^\top A)^{-1}A^\top$ の第 0 行を係数にした畳み込み。端の $\lfloor M/2\rfloor$ 点は元の値。
- 非等間隔（`SavitzkyGolayAccuracy`）: 各点の近傍 $M$ 点に $N$ 次多項式を当てはめてその点で評価。

既定値 $M=3, N=3$ では $N\to2$ となり、3 点 2 次の補間は元データを再現するので **既定設定では平滑化は実質的に効きません**。

### 2.3 FFT バンドパス（`SetSmoothingProfile`）

$\Delta x=x_1-x_0$（等間隔を仮定）、点数 $L$、bin $i$ の周波数 $i/(L\Delta x)$ [1/横軸単位]。`Cut low-freq. under` $f_H$ は $\ell=f_HL\Delta x$ として $i<\ell/2$ を 0、$\ell/2\le i<\ell$ を線形に減衰（DC は保持）。`Cut high-freq. over` $f_L$ は $\ell=f_LL\Delta x$ として $i>2\ell$ を 0、$\ell<i\le2\ell$ を線形減衰。負周波数側を複素共役で埋めて逆 FFT し、各点の **絶対値** を強度とします（$i=0$ は元値）。

### 2.4 Kα2 除去（`SetKalpha2RemovedProfile`）

条件: 有効化かつ Src の線源が X 線、元素番号が 0 でなく、線が Kα1。

$\lambda_1,\lambda_2$ = `AtomStatic.CharacteristicXrayWavelength(Z, Ka1/Ka2)`。各点 $i$ で

$$ d_i=\frac{\lambda_2}{2\sin(X_i\pi/360)},\qquad 2\theta'_i=2\arcsin\frac{\lambda_1}{2d_i} $$

（$X_i$ を 2θ [度] とみなす）を求め、**X の小さい側から順にその場で**

$$ y_i\leftarrow y_i-0.5\,y(2\theta'_i) $$

を行います（$y(2\theta'_i)$ は更新途中のプロファイルを 2 点線形補間、$2\theta'_i<X_0$ のときは $y(2\theta'_i)$ の代わりに $\frac23y_0$）。強度比 $I(\mathrm{K\alpha_2})/I(\mathrm{K\alpha_1})=0.5$ は固定で UI からは変えられません。横軸が 2θ [度] 以外のときのチェックはありません（要確認 T-8）。

### 2.5 強度の正規化（`Normarize`）

範囲 $x_\mathrm{s}<X<x_\mathrm{e}$（既定 0〜180）の平均（`Average`）または最大値（`Maximum`）が目標値（既定 1000）になる倍率を全点の Y と Err に掛けます。

### 2.6 バックグラウンド

- **B-Spline curve**: 名称に反して B スプラインではなく、制御点を通る 3 次補間スプライン（`Crystallography/Mathematics/Spline.cs` `GetSpline`）。両端の外側は 1 次関数（端点で 2 階微分 0 = 自然スプライン）、$(4n+4)$ 元の連立方程式を直接解く。既存の付録「3 次スプライン関数の導出」の定式化と同じです。制御点 3 点未満なら背景 0。
- 制御点 `BgPoints` は Src 座標・Src 強度で保持し、表示時に軸変換します（`ConvertDestToSrc`）。
- **Refference**（UI 表記のまま）: 他プロファイルの最終 `Profile` を近傍 2 点の平均で読み、`Scale` 倍して差し引く。
- **背景点の自動検出**（`getBgPointsAuto`、入力は `SmoothedProfile`）:
  1. 1 階・2 階差分を作り、2 階差分を標準偏差で規格化した $y''_k/\sigma$ を得る（各段で SG(3,3) を通すが実質恒等）。
  2. 間隔 $r=\lfloor N_{p1}/(3N_\mathrm{bg})\rfloor$ 以上離れた位置で、30 点窓の $\sum|y''/\sigma|$ が最小かつ 2 未満の窓を探し、その中央（$i+15$）を採用。これを $N_\mathrm{bg}$ 点（既定 15、UI 3〜50）に達するか候補が尽きるまで繰り返す。
  3. 採用点ごとに、近傍 11 点（$k-5\ldots k+5$）の平均強度を背景点とする（和を常に 11 で割る）。3 点未満しか見つからなければ変更しない。

### 2.7 2θ オフセットの較正（`FormTwoThetaCalibration.buttonCalibrate_Click`）

Fitting ウィンドウ表示中のみ有効。フィット済みの反射について $\tan(X_\mathrm{calc}-X_\mathrm{obs})$（度の差をそのままラジアンとして tan に入れる）を $\tan^j\theta_\mathrm{calc}$（$j<$ 次数、次数 ≤ 3 かつ ≤ 反射数）で最小二乗展開し、係数を 0.9 倍して $c_j$ に加算、これを 8 回反復します（要確認 T-9）。

---

## 3. ピークプロファイル関数 {#3-profile-functions}

実装は `Crystallography/PeakSearch.cs` の `class PeakFunction`。関数の種類は `enum PeakFunctionForm { Simple, PseudoVoigt, Peason, SplitPseudoVoigt, SplitPearson }`（綴り `Peason` はコードのまま）です。以下 $u=(x-X)/H_k$、$X$ はピーク中心、$H_k$ は FWHM（いずれも現在の横軸単位）。

### 3.1 強度パラメータ `Int` の意味（重要）

| 関数 | `Int` の意味 | 積分強度 `GetIntegral()` |
| --- | --- | --- |
| Pseudo-Voigt | **積分強度**（関数は面積 1 に規格化） | `Int` |
| Pearson VII | **ピーク高さ** | $\dfrac{\sqrt\pi\,\Gamma(m-\frac12)}{2\sqrt{2^{1/m}-1}\,\Gamma(m)}H_k\,\mathrm{Int}$ |
| Split Pseudo-Voigt | **ピーク高さ** | 3.3 節 |
| Split Pearson VII | **ピーク高さ** | 3.4 節（実装に疑問あり） |

既存マニュアル（アルゴリズム解説）は「いずれの関数も積分値が 1 に規格化してあります」としていますが、実装で面積規格化されているのは対称 Pseudo-Voigt のみです。フィッティング結果表の `Intensity` 列はどの関数でも `GetIntegral()` を横軸ステップ $\Delta x=x_1-x_0$ で割った値です（`FormFitting.Fitting()`: `p.observedIntensity = p.peakFunction.GetIntegral() / (Pt[1].X - Pt[0].X)`）。

### 3.2 Pseudo-Voigt（`PseudoVoigt`）

$$
f(x)=\mathrm{Int}\cdot\frac{2}{H_k}\left[\frac{\eta}{\pi}\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\frac{\ln 2}{\pi}}\,e^{-4\ln 2\,u^2}\right]
$$

- $\eta$ はローレンツ成分の **面積分率**（両成分とも面積 1、FWHM 共通 $H_k$）。
- パラメータ順（ヤコビアンの列順）: `Int, eta, Hk, X`（`differentialPseudoVoigt`）。
- 既存マニュアルの式 $\frac{2}{H_k\pi}\left(\eta\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln2}\cdot2^{-4u^2}\right)$ と数学的に同値です（$2^{-4u^2}=e^{-4\ln2\,u^2}$、$\sqrt{\pi\ln2}/\pi=\sqrt{\ln2/\pi}$）。

### 3.3 Split Pseudo-Voigt（`SplitPseudoVoigt`）

$Z_1=1+e^{-A}$（低角側, $x<X$）、$Z_2=1+e^{A}$（高角側, $x\ge X$）とし、$S=\sqrt{\pi\ln2}$ として

$$
f(x)=\mathrm{Int}\cdot\frac{\eta_L\,\dfrac{1}{1+Z_1^2u^2}+(1-\eta_L)\,S\,2^{-Z_1^2u^2}}{\eta_L+(1-\eta_L)S}\quad(x<X),
\qquad
f(x)=\mathrm{Int}\cdot\frac{\eta_H\,\dfrac{1}{1+Z_2^2u^2}+(1-\eta_H)\,S\,2^{-Z_2^2u^2}}{\eta_H+(1-\eta_H)S}\quad(x\ge X)
$$

（`RenewParamSplitPseudoVoigt` の `a3=(etaL-1)S`, `a5=1/(etaL-a3)` 等を展開したもの）

- $f(X)=\mathrm{Int}$（高さ規格化）。
- 低角側の半値半幅は $H_k/Z_1$、高角側は $H_k/Z_2$ で、和は $H_k\{1/(1+e^{-A})+1/(1+e^{A})\}=H_k$。すなわち **$H_k$ は全体の FWHM**、$A$ は左右の配分を決める非対称パラメータ（$A>0$ で低角側が広い）。
- 各側で $\eta$ は面積分率として働く（ローレンツ・ガウスの高さ比 $S$ を掛けているため）。
- 積分強度（`GetIntegral`）: $\displaystyle \frac{\pi}{2}H_k\,\mathrm{Int}\left[\frac{1}{(1+e^{-A})\{\eta_L+S(1-\eta_L)\}}+\frac{1}{(1+e^{A})\{\eta_H+S(1-\eta_H)\}}\right]$。数値積分と一致することを確認済み（相対差 < 10⁻⁴）。
- パラメータ順: `Int, Hk, A, etaL, etaH, X`。
- 既存マニュアルの式は (i) ローレンツ項の分母が $1+(1+e^{-A})(x/H_k)^2$（$Z_1$ が 2 乗でない）、(ii) ガウス項の指数が $-4(1+e^{-A})(x/H_k)^2$、(iii) 面積規格化の前因子、の 3 点で実装と異なります（要確認 T-3）。

### 3.4 Pearson VII（`PeasonIV` / `SplitPearsonIV`）

メソッド名は `PeasonIV` ですが、関数形は Pearson **VII** です。

対称形（パラメータ順 `Int, Hk, m, X`）:

$$ f(x)=\mathrm{Int}\left[1+4\left(2^{1/m}-1\right)u^2\right]^{-m} $$

Split 形（パラメータ順 `Int, Hk, A, Rl, Rh, X`）:

$$ f(x)=\mathrm{Int}\left[1+\left(2^{1/R_l}-1\right)Z_1^2u^2\right]^{-R_l}\ (x<X),\qquad f(x)=\mathrm{Int}\left[1+\left(2^{1/R_h}-1\right)Z_2^2u^2\right]^{-R_h}\ (x\ge X) $$

$Z_1, Z_2$ は 3.3 節と同じ。関数形（$x$ 依存部）は既存マニュアルと一致し、違いは規格化（実装は高さ = `Int`）のみです。

Split Pearson VII の `GetIntegral()` は

$$ \frac{\sqrt\pi\,H_k\,\mathrm{Int}}{2(1+A)}\left[\frac{\Gamma(R_h-\frac12)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}+A\,\frac{\Gamma(R_l-\frac12)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}\right] $$

と実装されていますが、上の関数を解析的に積分すると $A$ の位置に $e^{A}$ が入ります（既存マニュアルの規格化因子とも整合）。

$$ \int f\,dx=\frac{\sqrt\pi\,H_k\,\mathrm{Int}}{2(1+e^{A})}\left[\frac{\Gamma(R_h-\frac12)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}+e^{A}\frac{\Gamma(R_l-\frac12)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}\right] $$

→ [7. 実装上の疑問点 I-2](#7-issues)。

### 3.5 Simple

`PeakFunctionForm.Simple` はプロファイル関数を当てはめず、計算位置 $X_\mathrm{calc}\pm$ `SerchRange` の範囲で **強度最大の測定点の x** をピーク位置とします（`FittingPeak.FitPeakAsSimple`）。このとき `X Err` には横軸ステップ $x_1-x_0$ が入ります（`FormFitting.Fitting()`）。

---

## 4. ピークフィッティング（Marquardt 法） {#4-peak-fitting}

### 4.1 呼び出し単位（`FormFitting.Fitting()`）

1. チェックされた結晶の、`IsFittingChecked` な各反射について、計算位置 $X_\mathrm{calc}$ = `ConvertFromD(d, 現在の横軸)` を求め、`PeakFunction{ X=X_calc, range=SerchRange·F, Hk=FWHM·F, Option=SerchOption }` を作る。$F$ は `SerchRangeFactor`（4.4 節）。
2. **`Pattern decomposition`（ピーク分離）オフ**: 各反射を独立に 1 ピーク＋1 次バックグラウンドでフィット（`FittingPeak.FitPeakThread`、`Parallel.ForEach`）。
3. **ピーク分離オン**: 全対象ピークを X でソートし、隣接ピークの探索窓 $[X_i-r_i, X_i+r_i]$ が重なるものを同一グループに束ね、グループごとに複数ピーク＋共通 1 次バックグラウンドを同時にフィット（`FitMultiPeaksThread`、`Parallel.For`）。
4. 成功したピークについて $X_\mathrm{obs}$ → `dObs = ConvertToD(XObs)`、重み `Weight`（5.3 節）を設定し、`FittingDiffraction()`（格子定数精密化）を呼ぶ。

### 4.2 目的関数とデータ範囲（`FittingPeak.FitMultiPeaksThread`）

- 対象データ: $\min_i(X_i-r_i)\le x\le\max_i(X_i+r_i)$ の測定点（$i$ はグループの先頭と末尾のピーク）。**強度は内部で 1/1000 倍** して扱い、最後に `Int`, `B1`, `B2` を 1000 倍して戻します。
- モデル: $F(x)=\sum_j f_j(x)+B_1+B_2\,(x-x_c)$、$x_c$ はデータ範囲の中点。結果の `B1` は各ピーク中心での背景値 $B_1+B_2(X_j-x_c)$ に直して格納されます。
- 最小化するのは **無重み** の残差二乗和 $R=\sum_i\{Y_i-F(x_i)\}^2$（重み $w_i=1$。計数統計による重みは入っていません）。
- `SearchPeakTop` が真のピークは、開始前に窓内の最大点へ $X$ を移動（`FormFitting` からは既定 false のまま）。

### 4.3 Levenberg–Marquardt の実装詳細

$\alpha_{jk}=\sum_i\partial_jF\,\partial_kF$、対角のみ $(1+\lambda)$ 倍、$\beta_j=\sum_i r_i\,\partial_jF$、$\Delta\mathbf a=\alpha^{-1}\beta$（MathNet `TryInverse`）。偏微分は 3 章の解析式（`GetDifferentialValue`）、背景は $\partial F/\partial B_1=1$, $\partial F/\partial B_2=x-x_c$。

| 項目 | 実装値 |
| --- | --- |
| $\lambda$ 初期値 | 10 |
| 改善時 ($R_\mathrm{new}\le R$) | 採用し $\lambda\times0.5$ |
| 悪化時・制約違反時 | 棄却し $\lambda\times4$ |
| 終了条件 | $\lambda\ge10^9$、反復 500 回、または反復 50 回超かつ相対改善 $(R-R_\mathrm{new})/R<10^{-10}$ |
| 制約（違反でステップ棄却） | $H_k<0$；Pearson $m\notin(0.5,10)$；Split PV $\eta_{L,H}\notin[0,1]$, $A\notin[-2,2]$；Split Pearson $R_{l,h}\notin(0.5,10)$, $A\notin[-2,2]$ |
| 制約（クリップ） | Pseudo-Voigt の $\eta$ は $[0,1]$ に切り詰め |
| 複数ピーク時の X 拘束 | 初期位置から $\pm r/8$ を超えて動いたらその X だけ前回値に戻す |

既存マニュアルの「$\lambda$ を 0.1〜0.5 倍 / 2〜10 倍」は一般論で、実装は 0.5 倍 / 4 倍の固定です。

### 4.4 初期値と多重スタート

- `SerchRangeFactor` $F$（`FormFitting.ChangeHorizontalAxis()`）: 現在の横軸での $|x(d{=}1.00\,\mathrm{nm})-x(d{=}1.06\,\mathrm{nm})|\times8$ を $x\cdot10^n$（$x$ は整数に丸め）に丸めた値。`Plane.SerchRange` と `Plane.FWHM`（既定 0.10）は $F$ で割った無次元量として保存され、UI の `Search Range` / `Initial FWHM` には $F$ 倍して表示されます。
- 初期値（`Initial` = 0〜10 の 11 通り、係数 $c=(c_0,c_1,c_2)$）:
  $H_k=c_0\cdot$`Hk`（`Hk`≤0 なら $c_0\cdot0.5\,r$）、$\eta=\eta_L=\eta_H=0.5c_1$、$m=R_l=R_h=2c_1$、$A=0$、$B_1=\min Y$、$B_2=0$、
  $\mathrm{Int}_j = c_2\,(\textstyle\sum Y-n\min Y)\,\Delta x\;\hat I_j / \mathrm{GetIntegral}(\mathrm{Int}{=}1)$。$\hat I_j$ は各ピーク位置に最も近い点の（$Y-\min Y$）を総和 1 に規格化したもの（`Statistics.Normarize`）。
  $c$ の組: (1,1,1), (1,1,2), (1,1,0.5), (0.5,1,1), (0.5,1,2), (0.5,1,0.5), (2,1,1), (2,1,0.5), (2,1,2), (1,1.5,1), (1,0.5,1)。
- 各初期値で収束後、相対残差 $\rho=\frac1n\sum_i\{(F_i-Y_i)/F_i\}^2$ を評価し、$\sqrt\rho<0.25$ なら打ち切り。11 通りすべてで満たさない場合、最良の $\rho$ が $\sqrt\rho>0.90$ なら失敗（X, Int, Hk に NaN）、そうでなければ最良の初期値で再計算して採用。
- 表の `R` 列はこの $\rho$（最良値）です（`DataSet.cs`: `r.R = p.peakFunction.Residual`）。

### 4.5 ピーク位置の誤差 `X Err`

`prms[i].Xerr = 1 / Math.Sqrt(Alpha[k,k])`（$k$ は X の列、`Alpha` は最終ヤコビアンから作った $J^\top J$、$\lambda$ なし）。

$$ \sigma_X^{(\mathrm{code})}=\big[(J^\top J)_{XX}\big]^{-1/2} $$

通常の推定誤差 $\sigma_X=\sqrt{s^2\,[(J^\top J)^{-1}]_{XX}}$, $s^2=R/(n-p)$ とは (i) 逆行列の対角ではなく行列の対角を使う、(ii) 残差分散 $s^2$ を掛けない、(iii) 強度を 1/1000 にした $J$ を使う、の 3 点で異なり、統計的な標準誤差としては解釈できません。この値は格子定数精密化の重みには使われていません（5.3 節）。→ I-3。

---

## 5. 格子定数の最小二乗精密化 {#5-lattice-refinement}

実装は `PDIndexer/FormFitting.cs` `FittingDiffraction()`（三斜晶のみ `Crystallography/Crystal/CrystalGeometry.cs` `GetErrorTriclinic()`）。

### 5.1 観測方程式

対象は `IsFittingChecked` かつ（`Simple` または `observedIntensity > 0`）の反射。観測量は $Y_i=1/d_{\mathrm{obs},i}^2$（d は **nm**）、線形モデル $Y=QC$ の $Q$ の列は晶系ごとに次のとおり（`Symmetry.CrystalSystemStr` で分岐）。

| 晶系 | $Q$ の列 | $C$ から格子定数 |
| --- | --- | --- |
| cubic | $h^2+k^2+l^2$ | $a=C_0^{-1/2}$ |
| tetragonal | $h^2+k^2,\ l^2$ | $a=C_0^{-1/2}, c=C_1^{-1/2}$ |
| hexagonal / trigonal | $\frac43(h^2+hk+k^2),\ l^2$ | $a=C_0^{-1/2}, c=C_1^{-1/2}$, $\gamma=120^\circ$ |
| orthorhombic | $h^2, k^2, l^2$ | $a,b,c=C_{0,1,2}^{-1/2}$ |
| monoclinic（unique axis a/b/c） | $h^2,k^2,l^2$ と $kl$ / $lh$ / $hk$ | 例 (b): $\beta=\arccos\{-C_3/(2\sqrt{C_0C_2})\}$, $a=C_0^{-1/2}/\sin\beta$, $b=C_1^{-1/2}$, $c=C_2^{-1/2}/\sin\beta$ |
| triclinic | $h^2,k^2,l^2,kl,lh,hk$ | `GetErrorTriclinic`: $V^*=\frac12\sqrt{4ABC-AU^2-BV^2-CW^2+UVW}$ 等 |

（三方晶は六方晶と同じ式。菱面体設定の空間群も `CrystalSystemStr = "trigonal"` なので同じ式が適用されます → I-5。）

解は $C=(Q^\top WQ)^{-1}Q^\top WY$（MathNet `TryInverse`）。解けない場合（`a == 0`）は、元の格子を等方的に拡大縮小する係数 $k=\sum w_i d_i d_{\mathrm{obs},i}/\sum w_i d_i^2$ を求めて $a,b,c$ に掛けます（角度は据え置き、2020/10/16 追加のフォールバック）。

### 5.2 誤差評価

既存マニュアルと同じく、重みは比率としてのみ与え、残差からスケールを決めます。

$$ s^2=\frac{\sum_i w_i\delta_i^2}{N-P},\qquad \operatorname{Var}(C)=\operatorname{diag}\left[(Q^\top W'Q)^{-1}\right],\quad W'=W/s^2 $$

（コード: `W[i,i] = Weight·(N-P)/sum`）。$N-P\le0$ のときは誤差を計算せず、表示値は −1 のままです。$a=C^{-1/2}$ への伝播は $\sigma_a^2=\frac14C^{-3}\sigma_C^2$（cubic〜orthorhombic で共通）。

体積の誤差 `V_err` の式は、実装では次のとおりです（I-4 で疑問点として挙げています）。

| 晶系 | 実装 | 1 次の誤差伝播（参考） |
| --- | --- | --- |
| cubic | $\sqrt3\,a\,\sigma_a$ | $3a^2\sigma_a$ |
| tetragonal | $\sqrt{2ac\,\sigma_a^2+a^2\sigma_c^2}$ | $\sqrt{(2ac\,\sigma_a)^2+(a^2\sigma_c)^2}$ |
| hexagonal / trigonal | 上式 $\times\sqrt3/2$ | 上式 $\times\sqrt3/2$ |
| orthorhombic | $\sqrt{bc\,\sigma_a^2+ca\,\sigma_b^2+ab\,\sigma_c^2}$ | $\sqrt{(bc\sigma_a)^2+(ca\sigma_b)^2+(ab\sigma_c)^2}$ |
| triclinic | $\sigma_{V^*}\,V^3/2$ 相当（`v_err = sqrt(ValVstar2)·v³/2`） | — |

### 5.3 重み

`FormFitting.Fitting()` で設定:

- 横軸が角度で単位が Degree: $w=1/\sin^2(2\theta_\mathrm{obs}\cdot\pi/360)=1/\sin^2\theta$
- 横軸が角度でそれ以外の単位: $w=1/\sin^2(x_\mathrm{obs}/2)$（ラジアンとみなす。CentiDegree / MilliRadian もこの分岐に入る → I-6）
- 角度以外（d, エネルギー, TOF, 波数）: $w=1$

既存マニュアルは $\partial(1/d^2)/\partial\theta=4\sin2\theta/\lambda^2$ から $w=1/\sin^2(2\theta)$ を導いていますが、実装は $1/\sin^2\theta$ です（要確認 T-1）。

---

## 6. 既存「アルゴリズム解説」との差分 {#6-diff}

| # | 項目 | 既存マニュアル | 実装 |
| --- | --- | --- | --- |
| D-1 | 規格化 | 全関数を積分 1 に規格化 | 面積規格化は Pseudo-Voigt のみ。他は `Int` = ピーク高さ |
| D-2 | Split PV の関数形 | $1+(1+e^{-A})(x/H)^2$、$2^{-4(1+e^{-A})(x/H)^2}$ | $1+(1+e^{-A})^2u^2$、$2^{-(1+e^{-A})^2u^2}$（低角側） |
| D-3 | Marquardt の λ 更新 | 0.1〜0.5 倍 / 2〜10 倍 | 0.5 倍 / 4 倍、初期 10、上限 $10^9$ |
| D-4 | 重み $w_i$ | $1/\sin^2(2\theta)$ | $1/\sin^2\theta$（角度軸）、1（その他） |
| D-5 | 背景 | $B_1+B_2(\theta-\Theta)$（ピーク中心基準） | 内部はデータ範囲中点基準 $B_1+B_2(x-x_c)$。出力時にピーク中心基準へ換算 |
| D-6 | PV の $\partial F/\partial H_k$ | $-\frac{2I}{\pi}\big(\eta\frac{H^2-4b^2}{(H^2+4b^2)^2}+(1-\eta)\frac{\sqrt{\pi\ln2}}{H^2}e^{\cdots}\big)$ | ガウス項は $\propto(H^2-8\ln2\,b^2)/H^4$。ただし実装には別の疑問あり（I-1） |
| D-7 | 重み付き残差 $w_i$ | Marquardt の $\alpha,\beta$ に $w_i$ を含む | $w_i=1$（無重み） |
| D-8 | Pearson VII の偏微分 | $\partial F/\partial\Theta$ の式に $1/H_k^2$ | 実装（`differectialPeasonIV`）は数値微分と一致を確認。既存式の $\partial/\partial\Theta$ は $u$ と $(\theta-\Theta)$ の次数が実装と異なる（要確認 T-4） |

---

## 7. 実装上の疑問点（本稿に関わるもの） {#7-issues}

コードは修正していません。検算スクリプトは [`../check/`](../check/)（`deriv.py`: 解析微分と中心差分の比較、`integ.py`: `GetIntegral` と数値積分の比較、`lm.py`: LM の再現試験。numpy が必要）。

- **I-1（中）Pseudo-Voigt の $\partial f/\partial H_k$ のガウス項が π 倍大きい。** `PeakFunction.differentialPseudoVoigt` の `d[2]` で、ローレンツ項は `/PI` を含むがガウス項 `_eta*(tmp2-2*tmp3*Ln2)/(tmp2*tmp2)*tmp5` に `1/π` がない。中心差分との比はピーク中心から離れた点で 3.142。単一ピークの模擬データ（PV, η=0.3）で LM を再現した試験では、収束値は正しいヤコビアンの場合と 5 桁一致し、反復回数が 51→57 に増えただけでした。影響は主に収束速度と考えられますが、ピーク分離など条件の悪い問題では未検証です。
- **I-2（中）Split Pearson VII の `GetIntegral()` が $e^{A}$ ではなく $A$ を使っている。** $A=0.3, R_l=1.5, R_h=2.5$ で数値積分 25.03 に対し 24.17、$A=0$ でも 24.84 に対し 23.59（$R_l\neq R_h$ のとき $A=0$ で左半分が消える）。`Intensity` 列と初期 `Int` の見積もりに影響。
- **I-3（中）`X Err` が標準誤差ではない。** 4.5 節参照。
- **I-4（高）体積誤差 `V_err` の式で、偏微分係数が 2 乗されていない（次元が合わない）。** cubic は $\sqrt3\,a\sigma_a$（Å²）で、1 次伝播 $3a^2\sigma_a$ に対し $\sqrt3a$ 倍（NaCl, $a=5.64$ Å なら約 1/9.8）小さい。tetragonal / hexagonal / orthorhombic / monoclinic も同型。なお EOS 窓（`FormMain.SetFormEOS`）へは格子定数・体積のみが渡され誤差は伝播しないため（5 章監査）、圧力値そのものには影響しない。表示される体積誤差と、それを手で使う場合に影響する。
- **I-5（中）菱面体設定の三方晶が六方晶の観測方程式で精密化される。** `StrArray.csv` の `R3Rho` 等も `CrystalSystemStr = "trigonal"` で、`FittingDiffraction` は `case "trigonal"` で $\frac43(h^2+hk+k^2)$, $l^2$ を使う。菱面体指数のままでは誤った格子定数になる。
- **I-6（中）CentiDegree / MilliRadian 軸での重み。** `TwoThetaUnit == Degree` 以外はラジアンとして $1/\sin^2(x/2)$ を計算するため、c° や mrad の数値がそのまま角度扱いになる（ver4.457 で単位追加後の取りこぼしと推測）。
- **I-7（中）単斜晶の $\sigma_b,\sigma_c$ の演算子優先順位。** `1 / Math.Sin(alfa) * Math.Sin(alfa) / C^3` は $1/C^3$ と評価され（意図は $1/(\sin^2\alpha\,C^3)$ と推測）、さらに $\frac14$ が抜けている。unique axis a の分岐で確認。
- **I-8（低）Simple モードの探索窓に `SerchRangeFactor` が掛かっていない。** `FitPeakAsSimple(p.XCalc, p.SerchRange, ...)` は $F$ を掛けない生の `SerchRange` を使う（他の関数は `range = SerchRange·F`）。Cu Kα（λ=0.15406 nm, 2θ 度）なら $F=4$ なので、表示値の 1/4 の窓になる。
- **I-9（低）コメントと実装の不一致。** 「平均2乗残差が5%以下だったら終了」→ 閾値は $\sqrt\rho<0.25$。「1.00 nm ~ 1.05 nm を基準」→ 実装は 1.06 nm。

---

## 8. 要確認事項 {#8-tbc}

- **T-1** 格子精密化の重みは $1/\sin^2\theta$（実装）と $1/\sin^2 2\theta$（既存マニュアル）のどちらが意図か。
- **T-2** Pseudo-Voigt 以外で `Int` を高さにしているのは意図どおりか（マニュアルの「積分 1 に規格化」を直すべきか）。
- **T-3** Split Pseudo-Voigt の既存マニュアル式（Toraya 1990 改）を実装式に置き換えてよいか。
- **T-4** 既存マニュアルの Pearson VII 偏微分（「$R$ と $m$ の双方で表記（同一量）」）を実装の式に置き換えてよいか。
- **T-5** 強度の 1/1000 スケーリングは数値安定化のためだけか（`Int`, `B` 以外に影響しないか）。
- **T-6** フィッティングの残差を無重み（$w_i=1$）とするのは意図どおりか（計数統計の $1/Y_i$ 重みを入れない理由）。
- **T-7** ピーク分離のグルーピングは隣接ピークの窓の重なりのみで決まり、結晶をまたいでも束ねる。`in each crystal` / `between crystals` の選択（`radioButtonEachCrystal`）は `Fitting()` から参照されておらず（変更時に再計算を呼ぶだけ）、効果がない。意図した仕様の確認を。
- **T-8** Kα2 除去・2θ オフセットは横軸を 2θ [度] と仮定している（`X/360·π`）。ラジアン・c°・mrad 表示や EDX 軸で有効化されたときの扱いは意図どおりか。
- **T-9** 2θ 較正で度の差 $X_\mathrm{calc}-X_\mathrm{obs}$ をそのまま `tan` に入れている（ラジアン換算なし）。小角近似では $\tan\delta\approx\delta$ なので結果は度単位の係数になるが、意図の確認を。
