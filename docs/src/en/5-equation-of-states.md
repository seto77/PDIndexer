<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Equation of states

Clicking the `Equation of States` icon on the main window toolbar opens the window shown below. This tool calculates pressure from the equation of state (EOS) of a standard material.

![Full Equation of States window](../assets/cap-en-auto/FormEOS.png)

In high-pressure experiments, a standard material (pressure marker) is loaded together with the sample to serve as a pressure reference. The pressure is then derived from the marker's measured lattice constant (volume) and its known equation of state. This tool performs that calculation.

## How to use

1. Use the checkboxes at the top of the window to select the standard material(s) for which you want to determine the pressure.
2. For each selected material, the calculated result (pressure) is displayed in the lower part of the window.
3. You can compute the pressure by entering the lattice constants (`a`, `a0`) or volume (`V`, `V0`) directly.
4. When you drag a diffraction line in the main window, its value is immediately reflected in the EOS calculation.

!!! note "Relationship to the crystal list"
    The standard materials correspond to the crystals shown as pink rows in the crystal list. Roughly 10 materials are provided by default: gold (Au), platinum (Pt), NaCl-B1, NaCl-B2, periclase (MgO), corundum (Al2O3), argon (Ar), rhenium (Re), molybdenum (Mo), lead (Pb), and others.

## Supported standard materials

The standard materials that can be selected with the checkboxes at the top of the window are listed below. Each material provides several equations of state from different researchers (references), and the results for every selected entry are displayed individually.

| Standard material | Description |
| --- | --- |
| `Au (Gold)` | Gold |
| `Pt (Platinum)` | Platinum |
| `NaCl (B1)` | Sodium chloride (B1 structure, rock-salt type) |
| `NaCl (B2)` | Sodium chloride (B2 structure, CsCl type) |
| `MgO (Periclase)` | Magnesium oxide (periclase) |
| `Al2O3 (Corundum)` | Aluminum oxide (corundum) |
| `Ar` | Argon |
| `Re` | Rhenium |
| `Mo` | Molybdenum |
| `Pb` | Lead |
| `hBN` | Hexagonal boron nitride |

## Input parameters

Each material's `groupBox` lets you enter or read the following values.

| Item | Description |
| --- | --- |
| `a` / `V` | Measured lattice constant or volume. Updated automatically when you drag a diffraction line in the main window. |
| `a0` / `V0` | Lattice constant or volume at ambient (reference) conditions. |
| `Temperature` | Sample temperature. Used by equations of state that include thermal pressure (high-temperature EOS). |
| `T0` | Reference temperature. Used together with `Temperature` to apply the thermal-pressure correction. |

!!! tip "Temperature-dependent equations of state"
    Some references support high-temperature equations of state that include thermal pressure. By entering `Temperature` and `T0` to match your experimental conditions, you obtain a pressure that includes the temperature correction. Formulations based on the Mie-Grüneisen(-Debye) model, such as the Vinet/BM forms of `Sakai+(11)`, fall into this category.

## References per material

Each material's `groupBox` lists several equations of state from different references, and the pressure computed by each formula is displayed simultaneously. You can compare them and choose the reference that best suits your study or measurement conditions. Representative examples are shown below.

### Gold

![List of equation-of-state references for gold](../assets/cap-en-auto/FormEOS.tableLayoutPanel1.flowLayoutPanel1.groupBoxGold.png)

For gold (`Au (Gold)`), equations of state such as `Yokoo (09)`, `Matsui (09)`, `Holmes (89)`, `Jamieson (82)`, and `Fratanduono (21)` are available.

### NaCl (B1 structure)

![List of equation-of-state references for NaCl-B1](../assets/cap-en-auto/FormEOS.tableLayoutPanel1.flowLayoutPanel1.groupBoxNaClB1.png)

For `NaCl (B1)`, equations of state such as `Brown (99)`, `Sakai+`, and `Matsui (12)` are available.

### Periclase (MgO)

![List of equation-of-state references for periclase MgO](../assets/cap-en-auto/FormEOS.tableLayoutPanel1.flowLayoutPanel1.groupBoxPericlase.png)

For `MgO (Periclase)`, equations of state such as `Tange (09) BM`, `Tange (09) Vinet`, `Aizawa (06)`, `Dewaele (00)`, and `Jackson (98)` are available.

!!! note "Other materials"
    Platinum (`Pt (Platinum)`: `Fratanduono (21)`, `Holmes (89)`, etc.), `NaCl (B2)` (`Sakai (02)`, `Ueda+(08)`, etc.), corundum (`Al2O3 (Corundum)`: `Sata (02)`, etc.), `Ar` (`Dubrovinsky (98)`, `Ross et al. (86)`, `Jephcoat (98)`, etc.), `Re` (`Zha et al. (04)`, etc.), `Mo` (`Zhao+(00)`, `Huang+(16) MGD`, etc.), and `Pb` (`Strässle+(14)`, etc.) likewise offer a choice of several references.

## Theory of the equations of state

The equation of state \( P = P(V, T) \) expresses the relationship between a substance's pressure, volume, and temperature; this tool's role is to obtain the pressure \( P \) from the measured volume \( V \). The pressure is computed as the sum of an **isothermal compression term** \( P_\text{st}(V) \) at the reference temperature and a **thermal pressure term** \( \Delta P_\text{th} \) due to the temperature difference.

$$P(V, T) = P_\text{st}(V) + \Delta P_\text{th}(V, T)$$

The general formulas below are the common framework this form uses to compute the pressure of each standard material; each source either plugs published parameters into this framework or uses a source-specific equation (see [Formulas by source](#per-source) below for the specifics). For the per-crystal EOS tab of the Crystal Information control, see [Crystal parameter](3-crystal-parameter.md).

### Symbols

| Symbol | Meaning |
| --- | --- |
| \( V_0,\ V \) | unit-cell volume in the reference / measured state |
| \( K_0 \) | isothermal bulk modulus at the reference temperature and volume |
| \( K_0' \) | pressure derivative of \( K_0 \) |
| \( K_0'' \) | second pressure derivative of \( K_0 \) (used in BM4) |
| \( T_0,\ T \) | reference / measured temperature |
| \( \gamma_0 \) | Grüneisen parameter at the reference volume |
| \( \theta_0 \) | Debye temperature at the reference volume |
| \( q \) | volume dependence of the Grüneisen parameter |
| \( n \) | atoms per formula unit |
| \( R \) | gas constant |

### Isothermal compression term \( P_\text{st}(V) \)

Let the compression ratio be \( x = V_0/V \).

**Third-order Birch-Murnaghan (BM3, default)**

$$P_\text{st} = \tfrac{3}{2}K_0\left(x^{7/3} - x^{5/3}\right)\left[1 + \tfrac{3}{4}(K_0' - 4)\left(x^{2/3} - 1\right)\right]$$

**Vinet**: with \( y = (V/V_0)^{1/3} \),

$$P_\text{st} = 3K_0\,\frac{1-y}{y^2}\,\exp\!\left[\tfrac{3}{2}(K_0' - 1)(1 - y)\right]$$

The fourth-order Birch-Murnaghan equation (**BM4**, adding higher-order terms involving \( K_0'' \)), **AP2**, and **Keane** equations are also available.

### Thermal pressure term \( \Delta P_\text{th}(V, T) \)

**Mie-Grüneisen-Debye model (default)**: with the molar volume \( V_m \) (reference \( V_{m0} \)), the Grüneisen parameter and Debye temperature are

$$\gamma = \gamma_0\left(\frac{V_m}{V_{m0}}\right)^{q},\qquad \theta = \theta_0\exp\!\left[\frac{\gamma_0 - \gamma}{q}\right]$$

and the thermal pressure is

$$\Delta P_\text{th} = \frac{\gamma}{V_m}\Bigl[E_\text{th}(T,\theta) - E_\text{th}(T_0,\theta)\Bigr]$$

where \( E_\text{th} \) is the Debye internal energy

$$E_\text{th}(T,\theta) = 9nRT\left(\frac{T}{\theta}\right)^3\int_0^{\theta/T}\frac{t^3}{e^t - 1}\,dt.$$

**T-dependence K0&V0 model**: the bulk modulus and reference volume are treated as functions of temperature, with \( K_{T0} = K_0 + (\partial K/\partial T)(T - T_0) \) and a temperature-corrected reference volume \( V_0(T) \) obtained by integrating the thermal expansivity \( \alpha(T) = A\times10^{-5} + B\times10^{-9}\,T + C/T^2 \); these are then substituted into the isothermal equations above.

The specific parameter values and the background of each material's published EOS are also summarized on the author's explanatory page.

- [Notes on equations of state (EOS)](https://yseto.net/misc/misc-4/misc-4-1)

## Formulas by source {#per-source}

For each standard material, the pressure is computed in one of three ways per source:

1. **General formula + published parameters**: combine the isothermal BM3 / BM4 / Vinet with the Mie-Grüneisen-Debye thermal pressure, plugging in the source's published values.
2. **Source-specific closed form**: a formula specific to that source (given where it applies).
3. **Interpolation of a published P-V-T table**: not an analytic equation, but a two-stage cubic-spline interpolation (along compression, then temperature) of the source's tabulated pressure–volume–temperature data.

The sources FormEOS displays for each material are listed below (parameters are the published values hard-coded in the implementation; K0 in GPa, temperature in K, volume ratio V/V0). For the forms of BM3/BM4/Vinet/Mie-Grüneisen-Debye, see the previous section.

### Gold (Au)

| Source | Model | Main parameters |
| --- | --- | --- |
| Jamieson82 | spline of a P-V-T table | compression x=1−V/V0, T=200–1500 K |
| Anderson89 | BM3 + linear thermal term | K0=166.65, K0'=5.4823, ∂K/∂T=−0.0115 |
| Sim02 | BM3 + Mie-Grüneisen-Debye | K0=167, K0'=5.0; θ0=170, γ0=2.97, q=1.0, n=1 |
| Tsuchiya03 | spline of a P-V-T table | T=300–2500 K |
| Yokoo09 | spline of a P-V-T table | T=0–3000 K |
| Fratanduono21 | Vinet (isothermal) | K0=170.09, K0'=5.880 |

Anderson89 thermal term: $\Delta P_\text{th} = \left[0.00714 + (\partial K/\partial T)\ln(V_0/V)\right](T-300)$.

### Platinum (Pt)

| Source | Model | Main parameters |
| --- | --- | --- |
| Jamieson82 | spline of a P-V-T table | T=200–1500 K |
| Holmes89 | Vinet (isothermal) + linear thermal term | K0=266, K0'=5.81, αT=0.261 |
| Matsui09 | Vinet + Mie-Grüneisen-Debye + electronic term Pel | K0=273, K0'=5.20; θ0=230, γ0=2.70, q=1.10 |
| Yokoo09 | spline of a P-V-T table | T=0–3000 K |
| Fratanduono21 | Vinet (isothermal) | K0=259.7, K0'=5.839 |

Holmes89 thermal term: $\Delta P_\text{th} = \alpha_T K_0 (T-300)/10000$. Matsui09's electronic pressure $P_\text{el}$ is a cubic polynomial in temperature (~0.04 GPa at the 300 K reference).

### Argon (Ar)

| Source | Model | Main parameters |
| --- | --- | --- |
| Ross86 | spline of a P-V table (273 K isotherm) | molar volume [cm³/mol] interpolated |
| Jephcoat98 | BM3 + Mie-Grüneisen-Debye | K0=3.03, K0'=7.24; θ0=93.3, γ0=0.5, T0=4 K |

Jephcoat98 makes γ linear in volume: $\gamma = \gamma_0 + \gamma_1 (V/V_0)$ (γ1=2.20, θ fixed at θ0).

### Magnesium oxide (MgO)

| Source | Model | Main parameters |
| --- | --- | --- |
| Jackson98 | BM3 + Mie-Grüneisen-Debye | K0=162.5, K0'=4.13; θ0=673, γ0=1.41, q=1.3, n=2 |
| Dewaele00 | BM3 + Mie-Grüneisen-Debye | K0=161, K0'=3.94; θ0=800, γ0=1.45, q=0.8, n=2 |
| Aizawa06 | BM3 + Mie-Grüneisen-Debye | K0=160, K0'=4.15; θ0=773, γ0=1.41, q=0.7, n=2 |
| Tange09 Vinet | Vinet + Tange thermal | K0=160.63, K0'=4.367; θ0=761, γ0=1.442, a=0.138, b=5.4 |
| Tange09 BM | BM3 + Tange thermal | K0=160.64, K0'=4.221; θ0=761, γ0=1.431, a=0.29, b=3.5 |

The Tange thermal term uses a volume dependence $\gamma=\gamma_0\left[1+a\left((V/V_0)^{b}-1\right)\right]$ and approximates the Debye internal energy by a polynomial in θ/T.

### Sodium chloride NaCl (B2 structure)

| Source | Model | Main parameters |
| --- | --- | --- |
| Sata02 (Pt scale) | Decker/Sata closed form | Pr=31.14, Kr=143.5, V0=27.17 Å³ |
| Sata02 (MgO scale) | Decker/Sata closed form | Pr=32.15, Kr=141.0, V0=27.17 Å³ |
| Ueda08 | Vinet + linear thermal term | K0=28.45, K0'=5.16; thermal 0.00468(T−300) |
| Sakai11 BM | BM3 (isothermal) | K0=47.00, K0'=4.10, V0=37.73 Å³ |
| Sakai11 Vinet | Vinet (isothermal) | K0=40.40, K0'=5.04, V0=37.73 Å³ |

Sata form: $P = P_r (V/V_0)^{-2/3}\exp\!\left[-(3K_r/P_r-2)\left((V/V_0)^{1/3}-1\right)\right]$.

### Sodium chloride NaCl (B1 structure)

| Source | Model | Main parameters |
| --- | --- | --- |
| Brown99 | spline of a P-V-T table | T=300–1200 K |
| Matsui12 | BM4 + Mie-Grüneisen-Debye | K0=23.7, K0'=5.14, K0''=−0.392; θ0=279, γ0=1.56, q=0.96, n=2 |
| Skelton84 | spline of a P-V-T table (linear strain 1−a/a0) | T=0–298 K |

### Corundum Al2O3

| Source | Model | Main parameters |
| --- | --- | --- |
| Dubrovinsky98 | BM3 (K0, V0 temperature-corrected) | K0=258, K0'=4.88, ∂K/∂T=−0.020; thermal expansion a=2.6e−5, b=1.81e−9, c=−0.67 |

BM3 is evaluated with $K_T=258+(\partial K/\partial T)(T-300)$ and the thermally expanded $V_0(T)=V_0\exp\!\left[a(T-T_0)+\tfrac{b}{2}(T^2-T_0^2)-c(1/T-1/T_0)\right]$.

### Rhenium (Re)

| Source | Model | Main parameters |
| --- | --- | --- |
| Zha04 | spline of a P-V-T table | x=1−V/V0=0–0.20, T=300–3000 K |
| Anz | Vinet (isothermal) | K0=352.6, K0'=4.56, V0=29.467 Å³ |
| Sakai | Vinet (isothermal) | K0=358, K0'=4.8, V0=29.47 Å³ |
| Dub | BM4 (isothermal) | K0=342, K0'=6.15, K0''=−0.029, V0=29.46 Å³ |

### Molybdenum (Mo)

| Source | Model | Main parameters |
| --- | --- | --- |
| Huang16 | BM3 + Mie-Grüneisen-Debye | K0=255, K0'=4.25; θ0=470, γ0=2.01, q=0.6, n=1, z=2 |
| Zhao00 | BM4 + thermal-expansion correction (T-dependence) | K0=268, K0'=3.81, K0''=−0.0141, ∂K/∂T=−0.0213; thermal expansion A=1.31e−5, B=11.2e−9 |

Zhao00 evaluates BM4 with $K_{T0}=K_0+(\partial K/\partial T)(T-T_0)$ and a thermally corrected $V_0(T)$.

### Lead (Pb)

| Source | Model | Main parameters |
| --- | --- | --- |
| Strassle14 | Vinet (K0, K0', a0 temperature-interpolated) | B(T), B'(T), a0(T) linearly interpolated from measured tables (B/B' over 0–300 K, a0 over 0–310 K) |

## Related pages

- For registering crystals and the crystal list display, see related pages such as [Profile information](4-profile-parameter.md).
