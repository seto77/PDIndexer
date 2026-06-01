<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Troubleshooting

If you run into a problem while using PDIndexer, check the items below first. Most issues are resolved by installing the runtime or reviewing a setting.

## The application will not start

PDIndexer requires the **.NET Desktop Runtime 10.0**. If the runtime is not installed, you may see an error at startup, or the program may exit without doing anything.

!!! warning "Fix"
    Follow [Runtime and Installation](runtime-and-installation.md) to install the latest **.NET Desktop Runtime 10.0** (x64), then restart PDIndexer.

## The UI language does not switch

You can change the UI language from the menu under **Option** ▸ **Language**, choosing **English (need restart)** or **Japanese (need restart)**. However, a language change takes effect only **after a restart**.

!!! note
    It is normal that the display does not change immediately after you pick a language. Close PDIndexer and start it again.

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

When refining lattice constants with peak fitting, an insufficient number of independent reflections can leave the lattice constants undetermined, and the result may be reported as NA (not available).

- Depending on the crystal system, you must supply enough reflections for the number of independent lattice constants to be determined (e.g. only \(a\) for cubic, but six values \(a, b, c, \alpha, \beta, \gamma\) for triclinic).
- If the reflections are linearly dependent (biased toward one direction), certain lattice constants cannot be determined. Include reflections of different orientations.

!!! note "Fix"
    See [Fitting Diffraction Peaks](../6-fitting-diffraction-peaks.md) and make sure the fit includes enough independent reflections.

## Still not resolved

For problems that the steps above do not solve, or for reproducible bugs and feature requests, please report them on the GitHub issue tracker. If possible, include the steps to reproduce, the file you used, and a screenshot.

- Issue tracker: <https://github.com/seto77/PDIndexer/issues>
