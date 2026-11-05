<!-- 261105Cl: docs/drafts/261105-cloud — draft list of all windows. Not yet merged into docs/src. -->
# List of windows (forms)

> Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

All windows that PDIndexer opens, mapped to the manual chapters. Titles come from each form's `$this.Text` (`<Form>.resx`; some are set in code at run time); menu and button names come from `FormMain.Designer.cs` / `FormMain.resx`. Labels without backticks below are descriptions, not exact UI strings. `(Controls)` marks forms from the shared library `Crystallography.Controls`.

## 1. Forms in the PDIndexer application

| Form (class) | Title | How to open | Function | Chapter |
| --- | --- | --- | --- | --- |
| `FormMain` | `PDIndexer   ver4.465 (2026/10/26)` (set at run time) | at start-up | profile plot, profile list, crystal list, menus and toolbar | [1](../../../src/en/1-main-window.md) |
| `FormCrystal` | `Crystal Parameter` | toolbar `Crystal Parameter (C)`, Ctrl+Shift+C | cell constants, symmetry, atoms, diffraction-line display, crystal database | [3](../../../src/en/3-crystal-parameter.md) |
| `FormProfileSetting` | `Profile Parameter` | toolbar `Profile Parameter (P)` | masking, smoothing, band-pass, Kα2 stripping, normalisation, background, 2θ offset, axis settings, profile arithmetic | [4](../../../src/en/4-profile-parameter.md) |
| `FormTwoThetaCalibration` | `2θ Calibration` | `Calibration using an internal standard` in Profile Parameter (enabled only while the Fitting window is shown) | determine the 2θ offset coefficients $c_0,c_1,c_2$ from an internal standard | 4 |
| `FormEOS` | `Equation of States` | toolbar `Equation of State (E)`, Ctrl+Shift+E | pressure from the cell constants of the reserved crystals (crystal list rows 1–10) | [5](../../../src/en/5-equation-of-states.md) |
| `FormFitting` | `FormFitting` (title not set; class name shown) | toolbar `Fitting Diffraction Peaks (F)`, Ctrl+Shift+F | peak fitting and least-squares refinement of cell constants | [6](../../../src/en/6-fitting-diffraction-peaks.md) |
| `FormSequentialAnalysis` | `Sequential Analysis` | toolbar `Sequential Analysis`, Ctrl+Shift+S | sequential fitting of all profiles; cell constants, pressure, stress analysis | [7](../../../src/en/7-sequential-analysis.md) |
| `FormCellFinder` | `Cell Finder` | toolbar `Cell Finder`, `Send d-values` in the Fitting window | search for cell constants from d-values (indexing) | one line in ch. 1 (**no dedicated chapter**) |
| `FormAtomicPositionFinder` | `Atomic Position Finder` | toolbar `Atomic Position Finder` (**button hidden**: `FormMain.resx` `toolStripButtonAtomicPositonFinder.Visible=False`) | search for atomic coordinates from observed intensities (contains `UserControlIonicRadius`) | one line in ch. 1 (**no dedicated chapter**) |
| `FormLPO` | `FormLPO` (class name shown) | toolbar `LPO Analysis` (**button hidden**: `toolStripButtonLPO.Visible=False`) | lattice preferred orientation (LPO) analysis | one line in ch. 1 (**no dedicated chapter**) |
| `FormDataConverter` | `Data Converter` | when loading a profile other than pdi / pdi2 | specify axis type, exposure time, EDX calibration, etc. for loading | [2](../../../src/en/2-pattern-profiles.md), [File formats](../../../src/en/appendix/file-formats.md) |
| `FormPrintOption` | `Print Option` | File > print / print preview | what to print, position of the profile name | **not documented** |
| `FormAboutMe` | `About Me` | Help > `About Me` | version, author, terms of use, history | 1 |
| `FormExportGSAS` | `Export GSAS file -option-` | **never opened** (GSAS export writes the file directly, with no dialog) | — | (conflicts with ch. 2 and the appendix) |
| `FormLimitChanger` | `FormLimitChanger` | **never opened** | — | — |

## 2. Forms from the shared library (Crystallography.Controls)

| Form | Title | How to open | Function | Chapter |
| --- | --- | --- | --- | --- |
| `FormMacro` | `Macro` | Macro > `Editor` | edit and run IronPython macros | [8](../../../src/en/8-macro.md) |
| `CommonDialog` | initialisation messages | at start-up, Help > `Hint` | start-up progress, hints | 1 (hints only) |
| `FormCrystalSelection` | `Select load / save items` | File > read / add / save crystal list; drag-and-drop of xml | choose which crystals to read or write | **not documented** |
| `FormChemicalComposition` | `Details of the chemical composition` | right-click the crystal control in Crystal Parameter > `Details of the chemical composition` (ver4.465) | oxide / halide / sulfide conversion, valences | **not documented** |
| `FormBeamInteraction` | `Beam Interaction` | crystal-control right-click > `Beam Interaction` | interaction with X-rays, electrons and neutrons (scattering factors, etc.) | **not documented** |
| `FormSymmetryInformation` | `Symmetry Information` | crystal-control right-click > `Symmetry Information` | space-group information (Wyckoff positions, reflection conditions, symmetry operations, etc.) | **not documented** |
| `FormSuperStructure` | `Set superstructure size` | crystal-control right-click > `Convert to a superstructure` | convert to a supercell | **not documented** |
| `FormAnotherSpaceGroup` | `Convert to another spacegroup` | crystal-control right-click > `Change the axes/origin setting` | change axis / origin setting | **not documented** |
| `FormStrain` | `Strain Control` | crystal-control right-click > `Strain Control` | lattice strain from elastic constants (the Japanese title still contains "(invisible)") | **not documented** |
| `FormNumericUpdownControl` | `NumericUpdown Control` | right-click the threshold box in Crystal Parameter | increment settings, etc. | **not documented** |

The crystal-control right-click menu also contains `Convert to P1 Space Group`, `Revert cell constants`, reading from a CIF or AMC file, exporting as a CIF file, and `Send this crystal to other software` (`Crystallography.Controls/Crystal/CrystalControl.Designer.cs`).

## 3. Suggestions for the manual structure

- Cell Finder is mentioned in only one line of chapter 1 and has no chapter explaining its use. The Atomic Position Finder and LPO Analysis toolbar buttons are hidden, so a decision is needed on whether to keep or remove their one-line mentions in chapter 1 (the chapter 3 audit suggests Atomic Position Finder may not work on .NET 10).
- The forms opened from the crystal-control right-click menu (chemical composition, beam interaction, symmetry information, superstructure, another space group, strain) would fit naturally in a new chapter 3 section, "Crystal-control right-click menu". Because the control is shared with ReciPro, linking to the ReciPro manual is another option.
- [methods.md](methods.md) is intended to be merged as a revised version of the "Algorithms" appendix.

<!-- screenshot: Crystal Parameter window with the crystal-control right-click menu open -->

## To be confirmed

- Is it intended that `FormFitting` and `FormLPO` have no title (class name shown)?
- Are `FormExportGSAS` / `FormLimitChanger` to be removed or reconnected (which way should the manual's GSAS export description go)?
- Is "(invisible)" in the Japanese title of `FormStrain` left over by mistake?
- Should chapters be added for Cell Finder / Atomic Position Finder / LPO?
