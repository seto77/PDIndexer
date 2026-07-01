# PDIndexer

[![Documentation](https://img.shields.io/badge/%F0%9F%93%96_Documentation-blue)](https://seto77.github.io/PDIndexer/)
[![Latest Release](https://img.shields.io/github/v/release/seto77/PDIndexer?logo=github)](https://github.com/seto77/PDIndexer/releases/latest)
[![License: MIT](https://img.shields.io/badge/License-MIT-green)](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md)

*PDIndexer* is a free and open-source GUI-based application for analyzing one-dimensional powder diffraction patterns from laboratory / synchrotron X-rays and neutron time-of-flight (TOF) measurements. It displays measured profiles, overlays the diffraction lines calculated from crystal structures, processes and calibrates profiles, fits peaks to refine lattice constants by least squares, and estimates pressure from the equations of state (EOS) of standard materials. *PDIndexer* assists a wide range of researchers working in high-pressure science, powder X-ray diffraction, and synchrotron/neutron crystallography.

*PDIndexer* has been continuously developed since 2005 and is distributed together with its sister application [*IPAnalyzer*](https://github.com/seto77/IPAnalyzer), which converts two-dimensional detector images into the one-dimensional profiles that *PDIndexer* analyzes.

***[See the manual to learn how to use!](https://seto77.github.io/PDIndexer/)***

![PDIndexer main window](https://seto77.github.io/PDIndexer/assets/cap-en-auto/FormMain.png)

## Author

*PDIndexer* is developed by [Seto Y.](https://yseto.net/) (Osaka Metropolitan University, Japan).

***

## Install

* Access https://github.com/seto77/PDIndexer/releases/latest and download the latest release.
* Recommended: download `PDIndexer-setup.msi` (x64) and run the installer. For Windows on Arm (e.g. Snapdragon PCs), download `PDIndexer-setup_arm64.msi` instead. <!-- 260625Cl WiX asset names + arm64 -->
* Alternative for managed Windows PCs: download the portable ZIP (`PDIndexer-v.<ver>.zip` for x64, or `PDIndexer-v.<ver>_arm64.zip` for Arm), extract it to a user-writable folder, and run `PDIndexer.exe` from the extracted folder.
* The MSI installer requires ***.Net Desktop Runtime 10.0*** (NOT ***.Net Runtime 10.0***), which can be installed from [here](https://dotnet.microsoft.com/download/dotnet/10.0). On Windows on Arm, install the **Arm64** build of the Desktop Runtime.
* The portable ZIP package is self-contained for the matching architecture (x64 or Arm64) and does not require a separate .NET Desktop Runtime installation. It is a no-install package, but it still stores user settings and copied default data under the current user's AppData folder. <!-- 260601Ch -->
* *PDIndexer* is distributed under the **MIT license** (free for anyone to use, modify, and redistribute).

### Note on Windows Security Warnings

* Please download *PDIndexer* only from the official GitHub Releases page: https://github.com/seto77/PDIndexer/releases/latest
* On some Windows systems, Microsoft Defender SmartScreen or Smart App Control may display a warning before the installer is executed. This may happen for newly built or narrowly distributed research software, and the warning itself does not necessarily mean that the installer is malicious.
* If you would like to verify a downloaded file yourself, you can calculate its SHA256 hash in PowerShell:

```powershell
Get-FileHash .\PDIndexer-setup.msi -Algorithm SHA256
Get-FileHash .\PDIndexer-v.*.zip -Algorithm SHA256
```

* For an additional check, you may also scan the downloaded file with a multi-engine service such as VirusTotal.

## Privacy

*PDIndexer* is a local desktop application. It does **not** collect, store, or transmit any personal or usage data, and it contains no telemetry or analytics. It runs fully offline; the bundled crystal database and all analysis features work without a network connection.

## Manual

* Online manual (English / Japanese) : https://seto77.github.io/PDIndexer/
* The manual offers full-text search, a light / dark theme, and English / 日本語 language tabs.

***

## Main Features

### Profile Display and Processing

* Overlay and compare multiple one-dimensional diffraction profiles in a single window.
* The horizontal axis can be switched between *2θ*, *d*-spacing, and *q*, and the vertical axis between linear and other scales.
* Supports many file formats (e.g. csv, tsv, ras, nxs, npd, chi, xbm, rpt, and more).
* Profile processing: smoothing, K<sub>α2</sub> stripping, background subtraction, band-pass filtering, normalization, interpolation, and 2θ offset/calibration.
* Can receive a profile directly from [*IPAnalyzer*](https://github.com/seto77/IPAnalyzer) via the clipboard, and can automatically watch the clipboard or a folder to load newly created profiles/crystals.

### Crystal Database and Diffraction Lines

* Calculates the diffraction lines (positions and relative intensities) of known crystals and overlays them on the observed profile for phase identification.
* Built-in crystal database (~80 crystals bundled at first launch); search crystals by name, composition, lattice parameters, density, and *d*-spacing.
* Import / export **CIF** and **AMCSD** structure files.

### Peak Fitting and Lattice Refinement

* Fits the position, full width at half maximum (FWHM), and intensity of diffraction peaks with pseudo-Voigt and related profile functions.
* Refines lattice constants from peak positions by least squares.
* The **Cell Finder** searches for candidate lattice constants from a set of peak positions.

### Pressure / Temperature from Equations of State

* Estimates pressure (and temperature) from the cell volume of a standard material using built-in equations of state (EOS), such as NaCl, Au, Pt, and MgO.
* Useful for *in situ* high-pressure diffraction experiments using a diamond anvil cell (DAC) or multi-anvil press.

### Sequential Analysis

* Batch-processes a series of profiles, tracking the evolution of 2θ, *d*-spacing, cell constants, FWHM, intensity, and pressure across the series.
* Results can be exported as CSV for further plotting and analysis.

### Macro

* Python-syntax ([IronPython](https://ironpython.net/)) macro scripting for task automation.
  * Example: batch-load a folder of profiles, run sequential analysis, and export the results to CSV.
  * PDIndexer-specific functions are available through the `PDI` object.
  * The full function reference is available in the [manual](https://seto77.github.io/PDIndexer/8-macro/).

### Import / Export

* Import crystal structures from CIF and AMC files.
* Export profiles and results to CSV, TSV, and **GSAS** (Rietveld) formats.

***

## Screenshots

<img src="https://seto77.github.io/PDIndexer/assets/cap-en-auto/FormMain.png" height="320px" alt="Main window">
<img src="https://seto77.github.io/PDIndexer/assets/cap-en-auto/FormCrystal.png" height="320px" alt="Crystal parameter / database">
<img src="https://seto77.github.io/PDIndexer/assets/cap-en-auto/FormProfileSetting.png" height="320px" alt="Profile settings">
<img src="https://seto77.github.io/PDIndexer/assets/cap-en-auto/FormFitting.png" height="320px" alt="Fitting diffraction peaks">
<img src="https://seto77.github.io/PDIndexer/assets/cap-en-auto/FormEOS.png" height="320px" alt="Equation of states">
<img src="https://seto77.github.io/PDIndexer/assets/cap-en-auto/FormSequentialAnalysis.png" height="320px" alt="Sequential analysis">
<img src="https://seto77.github.io/PDIndexer/assets/cap-en-auto/FormMacro.png" height="320px" alt="Macro">
