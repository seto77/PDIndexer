<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Troubleshooting

If you run into a problem while using PDIndexer, check the items below first. Most issues are resolved by installing the runtime or reviewing a setting.

## The application will not start

These requirements apply to .NET 11 builds from this source tree. For published releases, follow the runtime requirement stated for that release.

The MSI installation of PDIndexer requires the **.NET Desktop Runtime** specified by that release (builds from this source tree target .NET 11). The no-install ZIP includes its runtime. If the runtime is not installed for an MSI installation, you may see an error at startup, or the program may exit without doing anything.

!!! warning "Fix"
    Follow [Runtime and Installation](runtime-and-installation.md) to install the **.NET Desktop Runtime** required by the release you use, matching the application architecture (x64 or Arm64), then restart PDIndexer.

## The UI language does not switch

<!-- 261124Cl changed: the old text described an English/Japanese choice and a manual restart; now there are 11 languages and PDIndexer restarts itself after a confirmation dialog -->
Choose the display language (11 languages, each shown by its own name) from **Language** at the right end of the menu bar. Switching the language requires a restart: choose **Yes** in the confirmation dialog, and PDIndexer restarts automatically in the selected language.

!!! note
    The restart discards unsaved work (loaded profiles and edits in progress), so save what you need before switching. If you choose **No**, the language does not change.

## Reset corrupted settings

Window positions, color settings, and various options are saved in the registry. If the settings become corrupted and the program misbehaves, you can clear the registry to return to the initial state.

1. From the menu, check **Option** ▸ **Clear Registry (check and restart)**.
2. Close PDIndexer. All saved settings are cleared on exit.
3. Start PDIndexer again; it will launch in its initial (default) state.

!!! warning
    This clears all saved settings, including window layout and options. It cannot be undone until you restart and the settings are reset.

## Clipboard import from IPAnalyzer / CSManager not working

Profiles and crystals copied in sibling apps such as [IPAnalyzer](https://github.com/seto77/IPAnalyzer) and [CSManager](https://github.com/seto77/CSManager) can be imported into PDIndexer automatically via the clipboard. If nothing is imported, clipboard watching may be disabled.

- Check that **Option** ▸ **Watch Clipboard** is enabled in the menu.
- When enabled, profiles/crystals copied from other apps are read automatically.

!!! tip
    If you want to automatically read newly created `.pdi` files in a specific folder, use **Option** ▸ **Watch File**.

## Intensity ratios are not calculated

To calculate theoretical diffraction intensities, the crystal structure must contain **atomic positions (atomic coordinates)**. If atomic positions are not entered, peak positions (\(d\)-values) can still be calculated, but intensity ratios are not.

!!! note "Fix"
    On [Crystal Parameter](../3-crystal-parameter.md), enter the element, coordinates, and occupancy for each atom. Once atomic positions are entered, intensity ratios are computed from the structure factor.

## Fitting reports NA (not available) lattice constants

When refining lattice constants with peak fitting, an insufficient number of independent reflections leaves the lattice constants undetermined. In that case the program keeps the original cell shape and changes only its overall scale, and the error fields show NA (not available). When the number of reflections equals the number of independent lattice constants, the residuals cannot provide standard errors, so the error fields also show NA.

- Depending on the crystal system, you must supply enough reflections for the number of independent lattice constants to be determined (e.g. only \(a\) for cubic, but six values \(a, b, c, \alpha, \beta, \gamma\) for triclinic).
- If the reflections are linearly dependent (biased toward one direction), certain lattice constants cannot be determined. Include reflections of different orientations.

!!! note "Fix"
    See [Fitting Diffraction Peaks](../6-fitting-diffraction-peaks.md) and make sure the fit includes enough independent reflections.

## Still not resolved

For problems that the steps above do not solve, or for reproducible bugs and feature requests, please report them on the GitHub issue tracker. If possible, include the steps to reproduce, the file you used, and a screenshot.

- Issue tracker: <https://github.com/seto77/PDIndexer/issues>
