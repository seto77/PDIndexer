<!-- 260531Ch: Initial main-window page skeleton. -->
# Main Window

The main window is the hub for loading profiles, selecting crystals, changing display axes, and opening analysis tools.

## File Menu

The `File` menu covers profile input/output, crystal list input/output, CIF/AMC import, printing, metafile export, and application close.

## Option and Help Menus

The `Option` menu includes behavior such as tooltips and clipboard watching. The `Help` menu provides version information, hints, and manual access.

## Horizontal Axis

The horizontal-axis panel changes how the loaded profile is displayed. Typical display modes include `2θ`, X-ray scattering angle, electron scattering angle, energy, and d-spacing.

## Profile View

The central profile view displays measured profiles and calculated diffraction lines. Mouse operations are used for zooming, panning, and moving calculated diffraction lines when the related crystal is selected.

## Side Lists

The profile list controls which loaded profiles are shown. The crystal list controls which crystal diffraction lines are overlaid.

!!! note "Next migration target"
    The old HTML manual already contains detailed explanations for each menu item and side-list operation. Those sections should be migrated here after the screenshot policy is finalized.
