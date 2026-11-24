<!-- 261124Cl added: Q&A page, compiled anonymously from GitHub issues and support e-mails to the author (2006–2026); reviewed with codex2 (2 rounds). Lead language: ja/appendix/faq.md -->
# Q&A

This page collects questions that users have actually asked, focusing on common ones and on points that are easy to misunderstand. For errors and start-up problems, see also [Troubleshooting](troubleshooting.md).

## What to try first {#first-steps}

### Something is wrong (no diffraction lines appear, a file cannot be read, an error appears at start-up). What should I try first?

First look for the entry on this page that matches your symptom. When no diffraction lines appear, the cause is almost always the radiation or wavelength setting ([Diffraction lines and the crystal list](#peaks-and-crystals)). If that does not help, try the following in this order.

1. Update to the latest version (`Help` ▸ `Program Updates`, or download it from the [release page](https://github.com/seto77/PDIndexer/releases/latest)).
2. Check `Option` ▸ `Clear Registry (check and restart)`, then quit and restart PDIndexer. PDIndexer stores window positions, beam settings and so on in the registry, and settings inherited from an older version can cause trouble.
3. If the crystal list looks wrong, run `File` ▸ `Revert crystals to the initial state`.

!!! warning "What is lost"
    - **Clearing the registry** removes the saved settings and **the macros registered in the macro window**. Export the macros you need as `.mcr` files first. The crystal list is not stored in the registry but in a separate file (`%APPDATA%\PDIndexer\PDIndexer\default.xml`), so clearing the registry does not remove it.
    - **Reverting the crystal list** discards the crystals you have added or edited. Save the crystals you need first with `File` ▸ `Save crystals`.

### When I use PDIndexer together with IPAnalyzer, I get errors or wrong values.

[IPAnalyzer](https://github.com/seto77/IPAnalyzer) and PDIndexer share a common library and exchange data through the clipboard. If only one of them is updated, the exchange format may not match, which can cause errors or wrong values. **Keep both up to date at the same time.**

## Installation and start-up {#install}

### I cannot install PDIndexer on a PC without administrator rights, or a policy blocks the MSI.

Use the **no-install ZIP package** (`PDIndexer-v.<ver>.zip` for x64, `PDIndexer-v.<ver>_arm64.zip` for Arm64). It bundles the runtime, so you need neither the MSI nor a separate .NET Desktop Runtime. Extract the whole folder to a location you can write to and run `PDIndexer.exe` in the extracted folder. PDIndexer itself runs with ordinary user rights.

See [Runtime and installation](runtime-and-installation.md) for the differences between the MSI and ZIP packages.

!!! note
    PDIndexer is unsigned research software, so Windows (SmartScreen) or your browser may warn you when you download or first run it. In the browser's download list choose `More info` ▸ `Keep`; at the run-time warning choose `More info` ▸ `Run anyway`.

### It says "You must install .NET Desktop Runtime", although I installed .NET.

The cause is usually one of the following.

- **Wrong major version.** The required .NET version changes between PDIndexer versions. Install the **Desktop Runtime** of the version stated for the release you use. The plain ".NET Runtime" is not enough.
- **Wrong architecture.** The x64 build of PDIndexer needs the x64 runtime; the Arm64 build needs the Arm64 runtime. On Arm-based Windows (Snapdragon PCs, etc.), use the Arm64 installer `PDIndexer-setup_arm64.msi`.
- If it still does not work, the **no-install ZIP package**, which bundles the runtime, is the most reliable choice.

## Diffraction lines and the crystal list {#peaks-and-crystals}

### I check a crystal but no diffraction lines appear, or they are far off.

Check the following first.

- [`Show peaks over profiles`](../3-crystal-parameter.md) is on, and the crystal is checked in the crystal list.
- **The radiation and wavelength (or energy) of the measurement are set correctly.** Text data such as CSV often contain no wavelength information; in that case, specify the radiation and wavelength used for the measurement in the dialog shown when the file is read. Check the radiation and wavelength used for display on the [`Horizontal Axis` tab](../1-main-window.md#horizontal-axis-tab) of the main window.
- The lines are not outside the drawing range. Try widening the horizontal range (especially for neutron TOF).
- If only one crystal does not appear, check that its lattice constants and atomic positions are not far off, and compare it with the same substance in the built-in database.

### I dragged a diffraction line and the lattice constants changed. Restarting does not restore them.

Lattice constants changed by dragging a diffraction line are saved when PDIndexer closes, because `Option` ▸ `Save the crystal list when closing` is on by default. Restarting therefore does not undo the change.

- To return to the lattice constants the crystal had when it was loaded in the current session, right-click the crystal information and choose `Revert cell constants`.
- To return the whole crystal list to its state just after installation, choose `File` ▸ `Revert crystals to the initial state`.

### The crystal list contains strange values or duplicates, or a pressure standard (Au, Pt, etc.) is missing.

`File` ▸ `Revert crystals to the initial state` restores the initial crystal list, including the pressure standards. Crystals you added yourself are lost, so save them first if needed.

### Intensity ratios are not calculated; all lines have the same height.

To calculate intensity ratios, the crystal needs atomic positions and [`Calculate intensity ratio`](../3-crystal-parameter.md) must be on. Wrong radiation settings also give wrong intensities. See [Troubleshooting](troubleshooting.md) for details.

### How do I import crystals from CSManager or from CIF files?

- **From CSManager**: open the `Crystal Parameter` window of PDIndexer and turn on `Option` ▸ `Watch Clipboard` first, then select the crystal in CSManager. You do not need to export a CIF first.
- **CIF / AMC files** can be dragged and dropped onto the crystal information area of the Crystal Parameter window.
- You can also search the **built-in crystal database** (AMCSD). See [Crystal parameter](../3-crystal-parameter.md).

In every case the crystal appears in the crystal information area. Press `Add` to keep it in the crystal list.

### Can I overlay X-ray data and electron (or other-wavelength) data on the same horizontal axis?

Yes. PDIndexer has a single horizontal axis, and every loaded profile is converted to the radiation and wavelength chosen on the `Horizontal Axis` tab. For example, an electron-diffraction profile can be shown on the 2θ scale of Cu Kα.

If `After reading profile, change horizontal axis` on the `Horizontal Axis` tab is on, the axis settings switch to those of each newly loaded file. Clear this option to keep a fixed axis for comparison.

## Reading profiles and the horizontal axis {#profiles-and-axis}

### What is the difference between the `Horizontal Axis` tab of the main window and `Axis setting` in the profile parameter window?

- The `Horizontal Axis` tab (main window) only decides **how the data are displayed**; the profile data themselves do not change.
- [`Axis setting`](../4-profile-parameter.md#axis-setting) (profile parameter window) rewrites **the conditions under which the profile was measured** (radiation type, wavelength, take-off angle, etc.). If you chose the wrong radiation or wavelength when reading the file, correct it here. If you entered values in the wrong **unit**, read the original file again.

### Energy-dispersive (white X-ray) data (`.npd` / `.nxs`) have a wrong horizontal axis, or no diffraction lines appear.

In the dialog shown when the file is read, check that the **energy unit (eV / keV)**, **2θ**, and, for `.nxs`, the **channel-to-energy calibration coefficients** match the measurement. `.npd` files use the energy column in the file, so also check the values and unit in the original file. A wrong unit shifts the peak positions a lot.

### Can PDIndexer read GSAS `.gsa` files (2θ in centidegrees) or data on a q (wave-number) axis?

Yes.

- For a `.gsa` file (three space-separated columns with 2θ in centidegrees), choose 2θ as the horizontal axis and `Centi-degree` as the unit in the data-conversion dialog.
- For data on a q (wave-number) axis, choose q as the horizontal axis. You can also refine lattice constants on the q axis.

## Peak fitting and lattice constants {#fitting}

### What value should I use for `Search Range`? The volume changes when I change it.

`Search Range` is the search width on each side of the peak centre. Start from **2–3 times the full width at half maximum (FWHM)** of the peak, and make it narrower if the neighbouring peak overlaps. Too wide a range picks up other peaks or the background, and too narrow a range cuts off the peak tails; both shift the fitted position. Using many **high-angle peaks** improves the precision of the lattice constants.

### Are the values shown in `Optimized cell constants` already applied to the crystal?

No. `Optimized cell constants` only **displays** the values obtained from the selected reflections and the fitting conditions. To overwrite the crystal's lattice constants, press `Apply to the crystal`. To use the values without changing the crystal, use `Copy to Clipboard`. Pressing `Apply to the crystal` a few times may help convergence, because the calculated line positions are updated each time.

### I select the same reflections, but the error of the volume suddenly becomes large.

Peak fitting (fitting a function to each peak) and lattice-constant refinement are separate calculations. PDIndexer only looks for a peak inside the search range of each reflection, so if a peak of another phase or noise falls inside the range, a wrong d-value enters the lattice-constant calculation.

- Check the fit of each reflection in the reflection list and exclude doubtful or weak peaks.
- When the signal-to-noise ratio is poor, first refine with the strong peaks only and add weaker peaks afterwards. You need at least as many independent reflections as there are independent lattice constants for the crystal system (1 for cubic, 6 for triclinic), and more than that to estimate the errors.
- For weak or heavily overlapping patterns, whole-pattern fitting such as Rietveld analysis may be more suitable.

See [Algorithms](algorithms.md#lattice-refinement) for how the lattice constants and their errors are calculated.

## Sequential analysis and macros {#sequential-and-macro}

### I want to fit many profiles (time-resolved, pressure steps, etc.) automatically and obtain lattice constants or pressures.

Use [Sequential analysis](../7-sequential-analysis.md) (open it from the toolbar of the main window or with `Ctrl+Shift+S`). **Open the peak-fitting window** and choose the crystal and reflections before running it. At least four profiles are needed. The results can be saved automatically.

- Reading thousands of profiles at once uses a lot of memory. Settle the conditions with about 100 profiles first, then run the whole set.
- Reading directly from a network folder is slow. Copy the files to a local disk before the analysis.
- If the lattice constants change a lot during the series, a peak may leave its search range and another peak may be picked up. With `Tolerance factor` turned on, points whose volume differs from **the volume at the start of the run** by more than the set value (%) are output as NaN.

### Can sequential analysis fit several phases (e.g. the sample and a pressure marker) at the same time?

The peaks of all checked crystals are fitted (with pattern decomposition set to `between crystals`, overlapping peaks of different phases are separated together). However, each sequential run records lattice constants and pressure only for the one crystal selected in the peak-fitting window. To obtain the results for another phase, select that crystal and run again, or use a [macro](../8-macro.md) that switches between the crystals.

### I ran a stress analysis on profiles split by azimuth, but the `Singh` tab is empty.

Stress-analysis mode is selected only when **the name of the first profile in the profile list ends with `whole`**. For the second and later profiles, the text **after the last hyphen** of the name is read as the azimuth in degrees (e.g. `sample-30`). Also check that at least four profiles are loaded and that the peak-fitting window is open. In an ordinary run (not in stress mode), the `Singh's equation` tab is left empty. See [Sequential analysis](../7-sequential-analysis.md) for details.

### With a comma as the decimal separator, the columns of the sequential-analysis CSV are shifted.

The sequential-analysis CSV reuses the numbers shown on screen, so with a comma decimal separator (`1,5`) the decimals cannot be told apart from the column separators. For now, use `Copy` on the result tab to copy the table as tab-separated text, and paste it into your spreadsheet as tab-separated data. The CSV export of the profiles themselves (`File` ▸ `Export the selected profile(s)`) always writes `.` as the decimal separator, regardless of the regional settings.

### In which language are macros written? How should I write file paths?

Macros are written in **Python (IronPython)**. Write Windows paths with forward slashes (`'C:/data/sample.pdi2'`) or as raw strings (`r'C:\data\sample.pdi2'`). The available functions are listed in the function reference of [Macro](../8-macro.md).

## Equations of state {#eos}

### I entered a temperature. Is the result valid as a high-temperature pressure?

Some equations of state (EOS) have no temperature term in the original paper (isothermal equations), and the temperature you enter is not used. EOS that interpolate tables from the literature give **inaccurate pressures outside the temperature and volume range of the table**. Check the source and the range of validity of the EOS in [Equation of states](../5-equation-of-states.md).

## Other questions {#others}

### What should I send when I report a bug?

Report it in the [GitHub Issues](https://github.com/seto77/PDIndexer/issues) with the following.

- The PDIndexer version (`Help` ▸ `About Me`) and the Windows version
- A minimal, shareable set of files that reproduces the problem (profiles, the crystal-list `.xml`, IPAnalyzer setting files, etc.)
- The steps you took, and the error message or a screenshot
- The result you expected (the value you believe is correct)

### May I introduce or redistribute PDIndexer on a beamline or laboratory web page?

Yes. PDIndexer is distributed under the [MIT License](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md). When you redistribute it, include the copyright notice and the license text.
