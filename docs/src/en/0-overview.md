<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Overview

![PDIndexer main window](../assets/cap-en-auto/FormMain.png)

PDIndexer is a software application for analyzing one-dimensional powder X-ray diffraction patterns. It can display and analyze diffraction profiles obtained from powder X-ray diffraction instruments, from synchrotron X-rays measured with Debye-Scherrer transmission optics, and from neutron time-of-flight (TOF) measurements.

It provides a full set of tools for powder diffraction analysis, including overlaid display of multiple profiles, comparison with the diffraction lines of known crystals, temperature and pressure calibration against standard materials, profile fitting, and least-squares refinement of lattice parameters.

!!! note "About this manual"
    This page is an overview only. For detailed instructions on each feature, see the dedicated pages.

## Key features

PDIndexer offers the following features.

| Feature | Description |
| --- | --- |
| Display and comparison of profiles | Overlay and compare multiple diffraction profiles. The horizontal axis (\(2\theta\) / \(d\) / \(q\)) and vertical-axis scales can be switched flexibly. |
| Comparison with known crystals | Calculate the diffraction lines of known crystals and overlay them on the observed profile for identification. See [Crystal Parameter](3-crystal-parameter.md) for details. |
| Calibration with standards | Using equations of state (EOS) such as NaCl EOS and Pt EOS, estimate temperature and pressure from the cell volume of a standard material. See [Equation of State (EOS)](5-equation-of-states.md) for details. |
| Peak fitting | Fit the position, full width at half maximum (FWHM), and intensity of diffraction peaks. See [Fitting](6-fitting-diffraction-peaks.md) for details. |
| Lattice-parameter refinement | Refine lattice constants from peak positions by least squares. The **Cell Finder** can also search for lattice constants from peak positions. |
| Sequential Analysis | Batch-process a series of files with the **Sequential Analysis** feature. See [Sequential Analysis](7-sequential-analysis.md) for details. |
| Import / export | Import crystal structures from CIF and AMC files, and export to CSV, TSV, and GSAS (Rietveld) formats. |
| Automatic loading | Watch the clipboard or a folder to automatically read profiles/crystals copied from other apps (e.g. IPAnalyzer) or newly created files. |

!!! tip "Supported data"
    A wide range of profiles can be handled, including those from powder X-ray diffraction instruments, synchrotron X-rays (Debye-Scherrer transmission optics), and neutron time-of-flight (TOF) measurements.

## License

This software is distributed under the **MIT License** ([LICENSE.md](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md)). Anyone is free to use this software at no cost, provided the following conditions are accepted.

- You may freely copy, distribute, modify, redistribute modified versions, use commercially, sell for a fee, or otherwise use the software in any way.
- When redistributing, include the copyright notice of this software and the full text of this license in the source code, or in a separate license file bundled with the source code.
- This software comes with no warranty whatsoever. The author bears no responsibility for any problems arising from the use of this software.

## Feedback

Please send your comments and requests via GitHub [Issues](https://github.com/seto77/PDIndexer/issues). The source code is published at [github.com/seto77/PDIndexer](https://github.com/seto77/PDIndexer).

## Installation and system requirements

PDIndexer requires a Windows OS capable of running **.NET Desktop Runtime 6.0 or later**. Some features require substantial computing resources; multithreading and GPU acceleration are used to improve speed. For comfortable use, a 64-bit Windows 10/11 with 16 GB or more of memory and an 8-core or higher CPU is recommended.

For detailed installation steps and system requirements, see [Runtime and Installation](appendix/runtime-and-installation.md).
