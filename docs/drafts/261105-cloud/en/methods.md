<!-- 261105Cl: docs/drafts/261105-cloud — methods draft derived from the code. Not yet merged into docs/src (outside the mkdocs build). -->
# Computational methods (as implemented)

> Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

This page describes PDIndexer's numerical processing **exactly as the current code implements it**. Where a formula differs from the existing [Algorithms](../../../src/en/appendix/algorithms.md) appendix (ported from the old `PDIndexerAlgorithm.pdf`), both versions are given and the point is listed under "To be confirmed". Code referenced: the PDIndexer app (`PDIndexer/`) and the shared library submodule `Crystallography/` (commit `c28490a`).

1. [Internal units and axis conversion](#1-axis)
2. [Profile processing pipeline](#2-pipeline)
3. [Peak profile functions](#3-profile-functions)
4. [Peak fitting (Marquardt method)](#4-peak-fitting)
5. [Least-squares refinement of cell constants](#5-lattice-refinement)
6. [Differences from the existing Algorithms page](#6-diff)
7. [Implementation questions (related to this page)](#7-issues)
8. [To be confirmed](#8-tbc)

---

## 1. Internal units and axis conversion {#1-axis}

### 1.1 Internal representation

- Every horizontal-axis conversion goes **through the d-spacing in nm**. `HorizontalAxisConverter.ConvertToD()` maps any axis → d [nm], and `ConvertFromD()` maps d [nm] → any axis (`Crystallography/Profile.cs`, `HorizontalAxisConverter`).
- The wavelength `HorizontalAxisProperty.WaveLength` is also held in **nm** (`TwoThetaInDegreeToD()` etc. compute `d = λ / (2 sin θ)` in a single unit).
- Axis types: `enum HorizontalAxis { Angle, d, WaveNumber, Length, EnergyXray, EnergyElectron, EnergyNeutron, NeutronTOF, None }` (`Profile.cs`). Angle units: `enum AngleUnitEnum { Degree, Radian, CentiDegree, MilliRadian }` (`Crystallography/Enums.cs`; CentiDegree / MilliRadian were added in ver4.457).

### 1.2 Conversion formulas (as implemented)

| Axis | → d [nm] | Implementation |
| --- | --- | --- |
| 2θ (degree) | $d=\lambda/\{2\sin(2\theta\cdot\pi/360)\}$ | `TwoThetaInDegreeToD` |
| 2θ (radian) | $d=\lambda/\{2\sin(2\theta/2)\}$ | `TwoThetaInRadianToD` |
| 2θ (centi-degree, c°) | input ÷ 100, then treated as degrees | `TwoThetaInCentiDegreeToD` |
| 2θ (milli-radian) | input ÷ 1000, then treated as radians | `TwoThetaInMilliRadianToD` |
| d (Å / nm) | Å × 0.1 | `ConvertToD` |
| Wave number | $d=2\pi/q$ ($q$ in nm⁻¹; Å⁻¹ input is ×10 first) | `WaveNumberToD` |
| X-ray energy | $d=\lambda(E)/\{2\sin(2\theta_\mathrm{EDX}/2)\}$ | `XrayEnergyToD` |
| Neutron TOF | $d=\lambda(v)/\{2\sin(2\theta_\mathrm{TOF}/2)\}$, $v=L/t$ | `NeutronTofToD` |

For energy-dispersive (EDX) data, $2\theta_\mathrm{EDX}$ is `HorizontalAxisProperty.EnergyTakeoffAngle` (the code comment calls it the "take-off angle (2Θ)", in radians). It is **the full scattering angle 2θ**, because `DToXrayEnergy(d, takeoffAngle)` uses `2d·sin(takeoffAngle/2)` as the wavelength. Energy is held internally in eV; keV / MeV are converted by ×10³ / ×10⁶.

Wavelength vs energy / velocity (`Crystallography/UniversalConstants.cs`, `UniversalConstants.Convert`):

- X-ray: $E\,[\mathrm{eV}] = \dfrac{6.62606896}{1.60217733}\times 2.99792458\times 100 \Big/ \lambda\,[\mathrm{nm}]$, i.e. $E\lambda = 1239.8412\ \mathrm{eV\,nm}$ ($=12.398412\ \mathrm{keV\,Å}$). `WavelengthToXrayEnergy` / `EnergyToXrayWaveLength`.
- Neutron: $\lambda\,[\mathrm{nm}] = h/(m_n v)\times 10^{3}$ ($v$ in m/μs, $h=6.62606896\times10^{-34}$, $m_n=1.674927351\times10^{-27}$ kg). `NeutronVelocityToWavelength`. TOF in μs (ns input ÷ 1000); flight path $L$ in m.
- Neutron energy: $E=h^2/(2m_n\lambda^2)$ (`WaveLengthToNeutronEnergy`).
- Electron: the relativistic $\lambda = h/\sqrt{2m_0eV(1+eV/2m_0c^2)}$ is solved as a quadratic (`WaveLengthToElectronEnergy`, keV); `DToElectronEnergy` multiplies by 1000 to give eV.

---

## 2. Profile processing pipeline {#2-pipeline}

Implemented in `class DiffractionProfile2` in `Crystallography/Profile.cs`. The UI (`FormProfileSetting.SetCurrentProfile`) writes the settings, and `SetConvertedProfile(HorizontalAxisProperty)` runs the following chain in this order. Each step takes the previous result as input.

| Order | Step | Implementation | Output |
| --- | --- | --- | --- |
| 1 | Axis conversion (Src→Dst); CPS $Y/t_\mathrm{exp}$ (when `IsCPS` and `ExposureTime>0`); $\log_{10}Y$ for log display | `ConvertSrcToDest` | |
| 2 | Axis shift $X\leftarrow X+\Delta$ (`IsShiftX`) | `SetConvertedProfile` | |
| 3 | 2θ offset $X\leftarrow X+c_0+c_1t+c_2t^2$, $t=\tan(X\pi/360)$ (angle axis only; X is taken as 2θ in degrees) | same | `ConvertedProfile` |
| 4 | Remove mask ranges and fill by polynomial interpolation | `SetMaskingProfile` | `InterpolatedProfile` |
| 5 | Savitzky–Golay smoothing → FFT band-pass | `SetSmoothingProfile` | `SmoothedProfile` |
| 6 | Kα2 stripping | `SetKalpha2RemovedProfile` | `Kalpha2RemovedProfile` |
| 7 | Intensity normalisation → background subtraction | `SetBackGroundProfile` (calls `Normarize()` first) | `Profile` |

The existing manual (chapter 4) says steps run "in the order 1–7" and puts normalisation (7) after background (6), but the code **normalises first**. The B-spline background is built from the un-normalised `ConvertedProfile`, so enabling normalisation makes the background curve and the intensities inconsistent in scale (question raised in the chapter 4 audit). The error `Err` is only affected by the X conversion and the normalisation factor; smoothing, band-pass, Kα2 and background leave it unchanged.

### 2.1 Masking and interpolation (`SetMaskingProfile`, `Profile.GetValues`)

Points in the open interval $(x_\mathrm{min},x_\mathrm{max})$ of each mask range are removed. A total of $2N_p$ points ($N_p$ per side) are taken alternately from both sides of the range, X is linearly rescaled to around $[0,1]$, a polynomial of order $n$ is least-squares fitted, and it is evaluated at the removed X values (one polynomial per range). Profile defaults: $n=2$, $N_p=20$ (`InterpolationOrder`, `InterpolationPoints`).

### 2.2 Savitzky–Golay smoothing (`Crystallography/Smoothing.cs`)

The UI `Point No.` $M$ is the **total window size** (not ±M); `Order` $N$ is the polynomial order. Nothing is done if $M<2$ or $N\le0$; if $M<N+1$ then $N\leftarrow M-1$.

- Evenly spaced data (`SavitzkyGolaySimple`): convolution with row 0 of $(A^\top A)^{-1}A^\top$, $A_{ji}=(j-\lfloor M/2\rfloor)^i$. The $\lfloor M/2\rfloor$ points at each end keep their original values.
- Unevenly spaced data (`SavitzkyGolayAccuracy`): an order-$N$ polynomial is fitted to the $M$ nearest points and evaluated at the point.

With the defaults $M=3, N=3$, $N$ becomes 2, and a 3-point quadratic reproduces the data exactly, so **smoothing has effectively no effect at the default settings**.

### 2.3 FFT band-pass (`SetSmoothingProfile`)

$\Delta x=x_1-x_0$ (even spacing assumed), $L$ points, bin $i$ has frequency $i/(L\Delta x)$ [1/axis unit]. `Cut low-freq. under` $f_H$: with $\ell=f_HL\Delta x$, bins $i<\ell/2$ are zeroed and $\ell/2\le i<\ell$ are tapered linearly (DC kept). `Cut high-freq. over` $f_L$: with $\ell=f_LL\Delta x$, bins $i>2\ell$ are zeroed and $\ell<i\le2\ell$ are tapered linearly. The negative-frequency half is filled with complex conjugates, the inverse FFT is taken, and the **absolute value** of each point becomes the intensity (point $i=0$ keeps its original value).

### 2.4 Kα2 stripping (`SetKalpha2RemovedProfile`)

Conditions: enabled, and the Src source is X-ray with a non-zero element number and line Kα1.

$\lambda_1,\lambda_2$ = `AtomStatic.CharacteristicXrayWavelength(Z, Ka1/Ka2)`. For each point $i$:

$$ d_i=\frac{\lambda_2}{2\sin(X_i\pi/360)},\qquad 2\theta'_i=2\arcsin\frac{\lambda_1}{2d_i} $$

($X_i$ is taken as 2θ in degrees), then **in place, from low X upwards**,

$$ y_i\leftarrow y_i-0.5\,y(2\theta'_i) $$

where $y(2\theta'_i)$ is read from the partially updated profile by two-point linear interpolation, and $\frac23y_0$ is used instead when $2\theta'_i<X_0$. The intensity ratio $I(\mathrm{K\alpha_2})/I(\mathrm{K\alpha_1})=0.5$ is fixed and cannot be changed in the UI. There is no check that the axis is 2θ in degrees (to be confirmed, T-8).

### 2.5 Intensity normalisation (`Normarize`)

All Y and Err are multiplied by the factor that makes the mean (`Average`) or maximum (`Maximum`) in $x_\mathrm{s}<X<x_\mathrm{e}$ (default 0–180) equal to the target (default 1000).

### 2.6 Background

- **B-Spline curve**: despite the name, not a B-spline but a cubic interpolating spline through the control points (`GetSpline` in `Crystallography/Mathematics/Spline.cs`). Outside the end points it is linear (zero second derivative at the ends = natural spline); the $(4n+4)$-unknown linear system is solved directly. This is the same formulation as the existing appendix "Derivation of the cubic spline". With fewer than 3 control points the background is 0.
- Control points `BgPoints` are stored in Src coordinates and Src intensity, and converted to the display axis when used (`ConvertDestToSrc`).
- **Refference** (spelling as in the UI): the final `Profile` of another profile is read as the mean of the two nearest points, multiplied by `Scale`, and subtracted.
- **Automatic background-point detection** (`getBgPointsAuto`, input `SmoothedProfile`):
  1. First and second differences are formed, and the second difference is normalised by its standard deviation, $y''_k/\sigma$ (each step passes through SG(3,3), effectively an identity).
  2. At positions at least $r=\lfloor N_{p1}/(3N_\mathrm{bg})\rfloor$ apart from accepted points, find the 30-point window with the smallest $\sum|y''/\sigma|$ that is below 2, and accept its centre ($i+15$). Repeat until $N_\mathrm{bg}$ points (default 15, UI 3–50) are found or no candidate remains.
  3. For each accepted point, the mean intensity of the 11 neighbours ($k-5\ldots k+5$) is the background point (the sum is always divided by 11). If fewer than 3 points are found, nothing changes.

### 2.7 2θ offset calibration (`FormTwoThetaCalibration.buttonCalibrate_Click`)

Enabled only while the Fitting window is shown. For fitted reflections, $\tan(X_\mathrm{calc}-X_\mathrm{obs})$ (the difference in degrees is passed to tan as if it were radians) is least-squares expanded in $\tan^j\theta_\mathrm{calc}$ ($j<$ order; order ≤ 3 and ≤ number of reflections); 0.9 times the coefficients is added to $c_j$, and this is iterated 8 times (to be confirmed, T-9).

---

## 3. Peak profile functions {#3-profile-functions}

Implemented in `class PeakFunction` in `Crystallography/PeakSearch.cs`. Function types: `enum PeakFunctionForm { Simple, PseudoVoigt, Peason, SplitPseudoVoigt, SplitPearson }` (the spelling `Peason` is as in the code). Below, $u=(x-X)/H_k$, where $X$ is the peak centre and $H_k$ is the FWHM (both in current axis units).

### 3.1 Meaning of the intensity parameter `Int` (important)

| Function | Meaning of `Int` | Integrated intensity `GetIntegral()` |
| --- | --- | --- |
| Pseudo-Voigt | **integrated intensity** (function normalised to unit area) | `Int` |
| Pearson VII | **peak height** | $\dfrac{\sqrt\pi\,\Gamma(m-\frac12)}{2\sqrt{2^{1/m}-1}\,\Gamma(m)}H_k\,\mathrm{Int}$ |
| Split Pseudo-Voigt | **peak height** | §3.3 |
| Split Pearson VII | **peak height** | §3.4 (implementation questionable) |

The existing manual (Algorithms) says "All functions are normalised so that their integral is 1". In the code, only the symmetric Pseudo-Voigt is area-normalised. For every function, the `Intensity` column of the fitting table is `GetIntegral()` divided by the axis step $\Delta x=x_1-x_0$ (`FormFitting.Fitting()`: `p.observedIntensity = p.peakFunction.GetIntegral() / (Pt[1].X - Pt[0].X)`).

### 3.2 Pseudo-Voigt (`PseudoVoigt`)

$$
f(x)=\mathrm{Int}\cdot\frac{2}{H_k}\left[\frac{\eta}{\pi}\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\frac{\ln 2}{\pi}}\,e^{-4\ln 2\,u^2}\right]
$$

- $\eta$ is the Lorentzian **area fraction** (both components have unit area and the same FWHM $H_k$).
- Parameter (Jacobian column) order: `Int, eta, Hk, X` (`differentialPseudoVoigt`).
- This is mathematically identical to the existing manual's $\frac{2}{H_k\pi}\left(\eta\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln2}\cdot2^{-4u^2}\right)$ (since $2^{-4u^2}=e^{-4\ln2\,u^2}$ and $\sqrt{\pi\ln2}/\pi=\sqrt{\ln2/\pi}$).

### 3.3 Split Pseudo-Voigt (`SplitPseudoVoigt`)

With $Z_1=1+e^{-A}$ (low-angle side, $x<X$), $Z_2=1+e^{A}$ (high-angle side, $x\ge X$) and $S=\sqrt{\pi\ln2}$:

$$
f(x)=\mathrm{Int}\cdot\frac{\eta_L\,\dfrac{1}{1+Z_1^2u^2}+(1-\eta_L)\,S\,2^{-Z_1^2u^2}}{\eta_L+(1-\eta_L)S}\quad(x<X),
\qquad
f(x)=\mathrm{Int}\cdot\frac{\eta_H\,\dfrac{1}{1+Z_2^2u^2}+(1-\eta_H)\,S\,2^{-Z_2^2u^2}}{\eta_H+(1-\eta_H)S}\quad(x\ge X)
$$

(expanded from `a3=(etaL-1)S`, `a5=1/(etaL-a3)`, etc. in `RenewParamSplitPseudoVoigt`)

- $f(X)=\mathrm{Int}$ (height-normalised).
- The low-angle HWHM is $H_k/Z_1$ and the high-angle HWHM is $H_k/Z_2$; their sum is $H_k\{1/(1+e^{-A})+1/(1+e^{A})\}=H_k$. So **$H_k$ is the total FWHM**, and $A$ is the asymmetry parameter that splits it between the two sides ($A>0$ makes the low-angle side wider).
- On each side, $\eta$ acts as an area fraction (the factor $S$ is the Gaussian/Lorentzian height ratio).
- Integrated intensity (`GetIntegral`): $\displaystyle \frac{\pi}{2}H_k\,\mathrm{Int}\left[\frac{1}{(1+e^{-A})\{\eta_L+S(1-\eta_L)\}}+\frac{1}{(1+e^{A})\{\eta_H+S(1-\eta_H)\}}\right]$. Checked against numerical integration (relative difference < 10⁻⁴).
- Parameter order: `Int, Hk, A, etaL, etaH, X`.
- The existing manual's formula differs from the code in three ways: (i) the Lorentzian denominator is $1+(1+e^{-A})(x/H_k)^2$ ($Z_1$ not squared); (ii) the Gaussian exponent is $-4(1+e^{-A})(x/H_k)^2$; (iii) the prefactor normalises area. (To be confirmed, T-3.)

### 3.4 Pearson VII (`PeasonIV` / `SplitPearsonIV`)

The methods are named `PeasonIV`, but the functional form is Pearson **VII**.

Symmetric (parameter order `Int, Hk, m, X`):

$$ f(x)=\mathrm{Int}\left[1+4\left(2^{1/m}-1\right)u^2\right]^{-m} $$

Split (parameter order `Int, Hk, A, Rl, Rh, X`):

$$ f(x)=\mathrm{Int}\left[1+\left(2^{1/R_l}-1\right)Z_1^2u^2\right]^{-R_l}\ (x<X),\qquad f(x)=\mathrm{Int}\left[1+\left(2^{1/R_h}-1\right)Z_2^2u^2\right]^{-R_h}\ (x\ge X) $$

$Z_1, Z_2$ are as in §3.3. The $x$-dependent part agrees with the existing manual; only the normalisation differs (the code uses height = `Int`).

`GetIntegral()` for Split Pearson VII is implemented as

$$ \frac{\sqrt\pi\,H_k\,\mathrm{Int}}{2(1+A)}\left[\frac{\Gamma(R_h-\frac12)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}+A\,\frac{\Gamma(R_l-\frac12)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}\right] $$

but integrating the function above analytically puts $e^{A}$ where the code has $A$ (consistent with the normalisation factor in the existing manual):

$$ \int f\,dx=\frac{\sqrt\pi\,H_k\,\mathrm{Int}}{2(1+e^{A})}\left[\frac{\Gamma(R_h-\frac12)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}+e^{A}\frac{\Gamma(R_l-\frac12)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}\right] $$

→ [7. Implementation questions, I-2](#7-issues).

### 3.5 Simple

`PeakFunctionForm.Simple` fits no profile function: the peak position is the $x$ of **the measured point with the highest intensity** within $X_\mathrm{calc}\pm$ `SerchRange` (`FittingPeak.FitPeakAsSimple`). `X Err` is then set to the axis step $x_1-x_0$ (`FormFitting.Fitting()`).

---

## 4. Peak fitting (Marquardt method) {#4-peak-fitting}

### 4.1 Fitting units (`FormFitting.Fitting()`)

1. For each reflection with `IsFittingChecked` in the checked crystals, compute the calculated position $X_\mathrm{calc}$ = `ConvertFromD(d, current axis)` and create `PeakFunction{ X=X_calc, range=SerchRange·F, Hk=FWHM·F, Option=SerchOption }`. $F$ is `SerchRangeFactor` (§4.4).
2. **`Pattern decomposition` off**: each reflection is fitted independently with one peak plus a linear background (`FittingPeak.FitPeakThread`, `Parallel.ForEach`).
3. **`Pattern decomposition` on**: all target peaks are sorted by X; peaks whose search windows $[X_i-r_i, X_i+r_i]$ overlap their neighbour's are grouped, and each group is fitted simultaneously with several peaks plus one shared linear background (`FitMultiPeaksThread`, `Parallel.For`).
4. For each successful peak, $X_\mathrm{obs}$ → `dObs = ConvertToD(XObs)` and the weight `Weight` (§5.3) are set, then `FittingDiffraction()` (cell refinement) is called.

### 4.2 Objective function and data range (`FittingPeak.FitMultiPeaksThread`)

- Data used: points with $\min_i(X_i-r_i)\le x\le\max_i(X_i+r_i)$ ($i$ = first and last peak of the group). **Intensities are scaled by 1/1000 internally**; `Int`, `B1` and `B2` are multiplied back by 1000 at the end.
- Model: $F(x)=\sum_j f_j(x)+B_1+B_2\,(x-x_c)$, where $x_c$ is the midpoint of the data range. The stored `B1` is converted to the background at each peak centre, $B_1+B_2(X_j-x_c)$.
- The quantity minimised is the **unweighted** sum of squared residuals $R=\sum_i\{Y_i-F(x_i)\}^2$ (weights $w_i=1$; no counting-statistics weights).
- Peaks with `SearchPeakTop` true are first moved to the maximum point in their window (left at the default false by `FormFitting`).

### 4.3 Levenberg–Marquardt details

$\alpha_{jk}=\sum_i\partial_jF\,\partial_kF$ with only the diagonal multiplied by $(1+\lambda)$, $\beta_j=\sum_i r_i\,\partial_jF$, $\Delta\mathbf a=\alpha^{-1}\beta$ (MathNet `TryInverse`). Partial derivatives are the analytic forms of §3 (`GetDifferentialValue`); background: $\partial F/\partial B_1=1$, $\partial F/\partial B_2=x-x_c$.

| Item | Implemented value |
| --- | --- |
| Initial $\lambda$ | 10 |
| On improvement ($R_\mathrm{new}\le R$) | accept, $\lambda\times0.5$ |
| On worsening or constraint violation | reject, $\lambda\times4$ |
| Termination | $\lambda\ge10^9$, 500 iterations, or more than 50 iterations with relative improvement $(R-R_\mathrm{new})/R<10^{-10}$ |
| Constraints (step rejected) | $H_k<0$; Pearson $m\notin(0.5,10)$; Split PV $\eta_{L,H}\notin[0,1]$, $A\notin[-2,2]$; Split Pearson $R_{l,h}\notin(0.5,10)$, $A\notin[-2,2]$ |
| Constraint (clipped) | Pseudo-Voigt $\eta$ is clipped to $[0,1]$ |
| X restraint (multi-peak) | if X moves more than $\pm r/8$ from its initial position, only that X is reset to its previous value |

The existing manual's "multiply λ by 0.1–0.5 / 2–10" is the general description; the code uses fixed factors of 0.5 / 4.

### 4.4 Initial values and multi-start

- `SerchRangeFactor` $F$ (`FormFitting.ChangeHorizontalAxis()`): $|x(d{=}1.00\,\mathrm{nm})-x(d{=}1.06\,\mathrm{nm})|\times8$ on the current axis, rounded to $x\cdot10^n$ ($x$ rounded to an integer). `Plane.SerchRange` and `Plane.FWHM` (default 0.10) are stored as dimensionless values divided by $F$; the UI `Search Range` / `Initial FWHM` show them multiplied by $F$.
- Initial values (`Initial` = 0–10, 11 sets of coefficients $c=(c_0,c_1,c_2)$):
  $H_k=c_0\cdot$`Hk` ($c_0\cdot0.5\,r$ if `Hk` ≤ 0), $\eta=\eta_L=\eta_H=0.5c_1$, $m=R_l=R_h=2c_1$, $A=0$, $B_1=\min Y$, $B_2=0$,
  $\mathrm{Int}_j = c_2\,(\textstyle\sum Y-n\min Y)\,\Delta x\;\hat I_j / \mathrm{GetIntegral}(\mathrm{Int}{=}1)$, where $\hat I_j$ is ($Y-\min Y$) at the point nearest each peak, normalised to sum 1 (`Statistics.Normarize`).
  Sets of $c$: (1,1,1), (1,1,2), (1,1,0.5), (0.5,1,1), (0.5,1,2), (0.5,1,0.5), (2,1,1), (2,1,0.5), (2,1,2), (1,1.5,1), (1,0.5,1).
- After convergence from each start, the relative residual $\rho=\frac1n\sum_i\{(F_i-Y_i)/F_i\}^2$ is evaluated; the loop stops once $\sqrt\rho<0.25$. If no start satisfies this, the fit fails (X, Int, Hk set to NaN) when the best $\sqrt\rho>0.90$; otherwise the best start is recomputed and adopted.
- The table's `R` column is this $\rho$ (best value) (`DataSet.cs`: `r.R = p.peakFunction.Residual`).

### 4.5 Peak-position error `X Err`

`prms[i].Xerr = 1 / Math.Sqrt(Alpha[k,k])` ($k$ = the X column; `Alpha` = $J^\top J$ from the final Jacobian, without λ).

$$ \sigma_X^{(\mathrm{code})}=\big[(J^\top J)_{XX}\big]^{-1/2} $$

This differs from the usual estimate $\sigma_X=\sqrt{s^2\,[(J^\top J)^{-1}]_{XX}}$, $s^2=R/(n-p)$, in three ways: (i) it uses the diagonal of the matrix, not of its inverse; (ii) it is not multiplied by the residual variance $s^2$; (iii) $J$ is built from intensities scaled by 1/1000. It cannot be read as a statistical standard error. It is not used as a weight in the cell refinement (§5.3). → I-3.

---

## 5. Least-squares refinement of cell constants {#5-lattice-refinement}

Implemented in `FittingDiffraction()` in `PDIndexer/FormFitting.cs` (triclinic only: `GetErrorTriclinic()` in `Crystallography/Crystal/CrystalGeometry.cs`).

### 5.1 Observation equations

Reflections used: `IsFittingChecked` and (`Simple` or `observedIntensity > 0`). Observations $Y_i=1/d_{\mathrm{obs},i}^2$ (d in **nm**); linear model $Y=QC$ with the columns of $Q$ chosen by crystal system (branch on `Symmetry.CrystalSystemStr`):

| Crystal system | Columns of $Q$ | Cell constants from $C$ |
| --- | --- | --- |
| cubic | $h^2+k^2+l^2$ | $a=C_0^{-1/2}$ |
| tetragonal | $h^2+k^2,\ l^2$ | $a=C_0^{-1/2}, c=C_1^{-1/2}$ |
| hexagonal / trigonal | $\frac43(h^2+hk+k^2),\ l^2$ | $a=C_0^{-1/2}, c=C_1^{-1/2}$, $\gamma=120^\circ$ |
| orthorhombic | $h^2, k^2, l^2$ | $a,b,c=C_{0,1,2}^{-1/2}$ |
| monoclinic (unique axis a/b/c) | $h^2,k^2,l^2$ plus $kl$ / $lh$ / $hk$ | e.g. (b): $\beta=\arccos\{-C_3/(2\sqrt{C_0C_2})\}$, $a=C_0^{-1/2}/\sin\beta$, $b=C_1^{-1/2}$, $c=C_2^{-1/2}/\sin\beta$ |
| triclinic | $h^2,k^2,l^2,kl,lh,hk$ | `GetErrorTriclinic`: $V^*=\frac12\sqrt{4ABC-AU^2-BV^2-CW^2+UVW}$ etc. |

(Trigonal uses the hexagonal formula. Space groups in the rhombohedral setting also have `CrystalSystemStr = "trigonal"`, so the same formula is applied → I-5.)

Solution: $C=(Q^\top WQ)^{-1}Q^\top WY$ (MathNet `TryInverse`). If it cannot be solved (`a == 0`), a factor $k=\sum w_i d_i d_{\mathrm{obs},i}/\sum w_i d_i^2$ for isotropic scaling of the original cell is computed and applied to $a,b,c$ (angles unchanged; fallback added 2020/10/16).

### 5.2 Error estimate

As in the existing manual, the weights give only ratios and the scale comes from the residuals:

$$ s^2=\frac{\sum_i w_i\delta_i^2}{N-P},\qquad \operatorname{Var}(C)=\operatorname{diag}\left[(Q^\top W'Q)^{-1}\right],\quad W'=W/s^2 $$

(code: `W[i,i] = Weight·(N-P)/sum`). When $N-P\le0$ no error is computed and the displayed value stays −1. Propagation to $a=C^{-1/2}$ is $\sigma_a^2=\frac14C^{-3}\sigma_C^2$ (common to cubic through orthorhombic).

The volume error `V_err` is implemented as follows (raised as question I-4):

| Crystal system | Implemented | First-order propagation (reference) |
| --- | --- | --- |
| cubic | $\sqrt3\,a\,\sigma_a$ | $3a^2\sigma_a$ |
| tetragonal | $\sqrt{2ac\,\sigma_a^2+a^2\sigma_c^2}$ | $\sqrt{(2ac\,\sigma_a)^2+(a^2\sigma_c)^2}$ |
| hexagonal / trigonal | above $\times\sqrt3/2$ | above $\times\sqrt3/2$ |
| orthorhombic | $\sqrt{bc\,\sigma_a^2+ca\,\sigma_b^2+ab\,\sigma_c^2}$ | $\sqrt{(bc\sigma_a)^2+(ca\sigma_b)^2+(ab\sigma_c)^2}$ |
| triclinic | equivalent to $\sigma_{V^*}\,V^3/2$ (`v_err = sqrt(ValVstar2)·v³/2`) | — |

### 5.3 Weights

Set in `FormFitting.Fitting()`:

- Angle axis in Degree: $w=1/\sin^2(2\theta_\mathrm{obs}\cdot\pi/360)=1/\sin^2\theta$
- Angle axis in any other unit: $w=1/\sin^2(x_\mathrm{obs}/2)$ (treated as radians; CentiDegree / MilliRadian also fall into this branch → I-6)
- Non-angle axes (d, energy, TOF, wave number): $w=1$

The existing manual derives $w=1/\sin^2(2\theta)$ from $\partial(1/d^2)/\partial\theta=4\sin2\theta/\lambda^2$, but the code uses $1/\sin^2\theta$ (to be confirmed, T-1).

---

## 6. Differences from the existing Algorithms page {#6-diff}

| # | Item | Existing manual | Implementation |
| --- | --- | --- | --- |
| D-1 | Normalisation | all functions normalised to unit integral | only Pseudo-Voigt is area-normalised; elsewhere `Int` = peak height |
| D-2 | Split PV form | $1+(1+e^{-A})(x/H)^2$, $2^{-4(1+e^{-A})(x/H)^2}$ | $1+(1+e^{-A})^2u^2$, $2^{-(1+e^{-A})^2u^2}$ (low-angle side) |
| D-3 | Marquardt λ update | ×0.1–0.5 / ×2–10 | ×0.5 / ×4, initial 10, upper limit $10^9$ |
| D-4 | Weight $w_i$ | $1/\sin^2(2\theta)$ | $1/\sin^2\theta$ (angle axis), 1 (other axes) |
| D-5 | Background | $B_1+B_2(\theta-\Theta)$ (relative to peak centre) | internally $B_1+B_2(x-x_c)$ relative to the data-range midpoint; converted to peak-centre reference on output |
| D-6 | PV $\partial F/\partial H_k$ | $-\frac{2I}{\pi}\big(\eta\frac{H^2-4b^2}{(H^2+4b^2)^2}+(1-\eta)\frac{\sqrt{\pi\ln2}}{H^2}e^{\cdots}\big)$ | Gaussian term $\propto(H^2-8\ln2\,b^2)/H^4$; the code has a separate issue (I-1) |
| D-7 | Weighted residual $w_i$ | $w_i$ included in Marquardt $\alpha,\beta$ | $w_i=1$ (unweighted) |
| D-8 | Pearson VII derivatives | $\partial F/\partial\Theta$ formula contains $1/H_k^2$ | the code (`differectialPeasonIV`) agrees with numerical derivatives; the existing $\partial/\partial\Theta$ uses different powers of $u$ and $(\theta-\Theta)$ (to be confirmed, T-4) |

---

## 7. Implementation questions (related to this page) {#7-issues}

The code has not been modified. The check scripts are in [`../check/`](../check/) (`deriv.py`: analytic vs central-difference derivatives; `integ.py`: `GetIntegral` vs numerical integration; `lm.py`: LM reproduction test; requires numpy).

- **I-1 (medium) The Gaussian term of the Pseudo-Voigt $\partial f/\partial H_k$ is π times too large.** In `d[2]` of `PeakFunction.differentialPseudoVoigt`, the Lorentzian term includes `/PI` but the Gaussian term `_eta*(tmp2-2*tmp3*Ln2)/(tmp2*tmp2)*tmp5` lacks `1/π`. Its ratio to a central difference is 3.142 at points away from the peak centre. In a test reproducing the LM loop on a simulated single peak (PV, η=0.3), the converged values agreed with the correct-Jacobian run to five significant figures; only the iteration count rose from 51 to 57. The effect is probably mainly on convergence speed, but ill-conditioned cases such as pattern decomposition were not tested.
- **I-2 (medium) Split Pearson VII `GetIntegral()` uses $A$ instead of $e^{A}$.** With $A=0.3, R_l=1.5, R_h=2.5$: 24.17 vs a numerical integral of 25.03; even with $A=0$: 23.59 vs 24.84 (for $R_l\neq R_h$ the left half drops out at $A=0$). Affects the `Intensity` column and the initial `Int` estimate.
- **I-3 (medium) `X Err` is not a standard error.** See §4.5.
- **I-4 (high) In the volume error `V_err`, the partial-derivative coefficients are not squared (dimensions do not match).** For cubic, $\sqrt3\,a\sigma_a$ (Å²) is $\sqrt3a$ times smaller than first-order propagation $3a^2\sigma_a$ (about 1/9.8 for NaCl, $a=5.64$ Å). Tetragonal / hexagonal / orthorhombic / monoclinic have the same pattern. Because only the cell constants and volume, not their errors, are passed to the EOS window (`FormMain.SetFormEOS`; see the chapter 5 audit), pressures themselves are unaffected. It affects the displayed volume error and any manual use of it.
- **I-5 (medium) Trigonal crystals in the rhombohedral setting are refined with the hexagonal observation equation.** `R3Rho` etc. in `StrArray.csv` also have `CrystalSystemStr = "trigonal"`, and `FittingDiffraction` uses $\frac43(h^2+hk+k^2)$, $l^2$ in `case "trigonal"`. With rhombohedral indices this gives wrong cell constants.
- **I-6 (medium) Weights on CentiDegree / MilliRadian axes.** Every `TwoThetaUnit` other than Degree is treated as radians in $1/\sin^2(x/2)$, so c° and mrad values are used directly as angles (probably missed when the units were added in ver4.457).
- **I-7 (medium) Operator precedence in monoclinic $\sigma_b,\sigma_c$.** `1 / Math.Sin(alfa) * Math.Sin(alfa) / C^3` evaluates to $1/C^3$ (presumably $1/(\sin^2\alpha\,C^3)$ was intended), and the factor $\frac14$ is also missing. Confirmed in the unique-axis-a branch.
- **I-8 (low) The Simple-mode search window ignores `SerchRangeFactor`.** `FitPeakAsSimple(p.XCalc, p.SerchRange, ...)` uses the raw `SerchRange` without $F$ (other functions use `range = SerchRange·F`). For Cu Kα (λ = 0.15406 nm, 2θ in degrees) $F=4$, so the window is 1/4 of the displayed value.
- **I-9 (low) Comments disagree with the code.** "stop when the mean squared residual is below 5%" → the threshold is $\sqrt\rho<0.25$. "based on 1.00 nm–1.05 nm" → the code uses 1.06 nm.

---

## 8. To be confirmed {#8-tbc}

- **T-1** Which cell-refinement weight is intended: $1/\sin^2\theta$ (code) or $1/\sin^2 2\theta$ (existing manual)?
- **T-2** Is it intended that `Int` is the peak height for every function except Pseudo-Voigt (should the manual's "normalised to unit integral" be corrected)?
- **T-3** May the existing Split Pseudo-Voigt formula (modified Toraya 1990) be replaced by the implemented one?
- **T-4** May the existing Pearson VII derivatives ("written with both $R$ and $m$ (the same quantity)") be replaced by the implemented ones?
- **T-5** Is the 1/1000 intensity scaling only for numerical stability (no effect other than on `Int` and `B`)?
- **T-6** Is the unweighted residual ($w_i=1$) intended (why no $1/Y_i$ counting-statistics weight)?
- **T-7** Pattern-decomposition grouping depends only on overlapping windows of neighbouring peaks, and groups peaks across crystals. The `in each crystal` / `between crystals` choice (`radioButtonEachCrystal`) is never read by `Fitting()` (changing it only triggers a refit), so it has no effect. Please confirm the intended behaviour.
- **T-8** Kα2 stripping and the 2θ offset assume the axis is 2θ in degrees (`X/360·π`). Is the behaviour intended when they are enabled with radian, c°, mrad or EDX axes?
- **T-9** The 2θ calibration passes the difference in degrees $X_\mathrm{calc}-X_\mathrm{obs}$ directly to `tan` (no conversion to radians). For small differences $\tan\delta\approx\delta$, so the coefficients come out in degrees, but please confirm the intent.
