<!-- 260531Ch: Initial pattern-profile page skeleton. -->
# Pattern Profiles

Pattern profiles are angle-intensity or converted-axis intensity datasets loaded into PDIndexer.

## Loading Profiles

Profiles can be loaded from the `File` menu, by drag-and-drop, or through clipboard transfer from IPAnalyzer. PDIndexer tries to read common two-column text data as well as dedicated profile formats.

## Display Modes

Profiles can be shown in single-profile or multi-profile mode. Multi-profile mode keeps multiple loaded profiles in the list and draws checked profiles together.

## Display Processing

Profile display and processing settings include smoothing, background subtraction, color selection, intensity offset between profiles, and horizontal-axis conversion.

## Data Integrity

Display conversions do not necessarily change the original profile data. When documenting a control, prefer the current GUI label from the `.resx` files over older wording from the legacy manual.
