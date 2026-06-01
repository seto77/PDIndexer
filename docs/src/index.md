<!-- 260601Cl: English landing page for the PDIndexer Pages manual (content migrated from the legacy docx + yseto.net web manual). -->
# PDIndexer Manual

**PDIndexer** is a free, MIT-licensed Windows application for analyzing one-dimensional powder diffraction patterns (laboratory / synchrotron X-ray, neutron TOF). It displays measured profiles, overlays calculated diffraction lines from crystal structures, processes and calibrates profiles, fits peaks to refine lattice constants by least squares, and estimates pressure from the equations of state of standard materials.

![PDIndexer main window](assets/cap-en-auto/FormMain.png)

## Find by goal

| Goal | Start here | Main next steps |
|------|------------|-----------------|
| Load and display a measured profile | [2. Pattern profiles](en/2-pattern-profiles.md) | [1. Main window](en/1-main-window.md), [File formats](en/appendix/file-formats.md) |
| Identify phases by overlaying known crystals | [3. Crystal parameter](en/3-crystal-parameter.md) | [2. Pattern profiles](en/2-pattern-profiles.md) |
| Process / calibrate a profile | [4. Profile parameter](en/4-profile-parameter.md) | [3. Crystal parameter](en/3-crystal-parameter.md) |
| Fit peaks and refine lattice constants | [6. Fitting diffraction peaks](en/6-fitting-diffraction-peaks.md) | [3. Crystal parameter](en/3-crystal-parameter.md) |
| Estimate pressure from a standard material | [5. Equation of states](en/5-equation-of-states.md) | [6. Fitting diffraction peaks](en/6-fitting-diffraction-peaks.md) |
| Batch-process a series of profiles | [7. Sequential analysis](en/7-sequential-analysis.md) | [8. Macro](en/8-macro.md) |
| Automate tasks with scripts | [8. Macro](en/8-macro.md) | [7. Sequential analysis](en/7-sequential-analysis.md) |

## Contents

- [0. Overview](en/0-overview.md) — what PDIndexer does and its main features
- [1. Main window](en/1-main-window.md) — layout, menus, toolbar, profile/crystal lists
- [2. Pattern profiles](en/2-pattern-profiles.md) — profile data, supported formats, loading
- [3. Crystal parameter](en/3-crystal-parameter.md) — diffraction-line display, crystal information, database
- [4. Profile parameter](en/4-profile-parameter.md) — profile processing, axis settings, operators
- [5. Equation of states](en/5-equation-of-states.md) — pressure from standard-material EOS
- [6. Fitting diffraction peaks](en/6-fitting-diffraction-peaks.md) — peak fitting and lattice refinement
- [7. Sequential analysis](en/7-sequential-analysis.md) — batch analysis over a profile series
- [8. Macro](en/8-macro.md) — IronPython scripting and function reference

### Appendix

- [Runtime and installation](en/appendix/runtime-and-installation.md)
- [File formats](en/appendix/file-formats.md)
- [Troubleshooting](en/appendix/troubleshooting.md)

## Quick start

1. Download and install from [Releases](https://github.com/seto77/PDIndexer/releases/latest), then launch *PDIndexer*.
2. Open a measured profile (drag & drop a file, or paste a profile copied from [IPAnalyzer](https://github.com/seto77/IPAnalyzer)).
3. Add known crystals from the built-in database (or import a CIF/AMC file) to overlay their diffraction lines.
4. Fit the peaks to refine lattice constants, or estimate pressure from a standard material's equation of state.

## System requirements

| Item | Requirement |
|------|-------------|
| OS | Windows with [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) (**not** the .NET Runtime) |
| Recommended | 64-bit Windows 10/11, 16 GB or more memory, 8-core or higher CPU |

See [Runtime and installation](en/appendix/runtime-and-installation.md) for details.

!!! note
    Source code, releases, and the issue tracker are on [GitHub](https://github.com/seto77/PDIndexer). PDIndexer is distributed under the [MIT License](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md).
