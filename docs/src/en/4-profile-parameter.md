<!-- 260531Ch: Initial profile-parameter page skeleton. -->
# Profile Parameter

The `Profile Parameter` tool edits settings for loaded profiles.

## Profile List

The profile list mirrors the profile list on the main window. It controls selection, order, visibility, deletion, and drawing color.

## Smoothing

Smoothing applies a Savitzky-Golay-style local fit to the selected profile. The detailed parameter descriptions should be migrated from the legacy manual and checked against the current GUI.

## Background

Background subtraction can be calculated automatically. When the automatic curve is not suitable, edit mode lets the user adjust control points manually on the profile view.

## Related Operations

Profile operations in the current application also include axis adjustment, profile arithmetic, K-alpha2 removal, and other processing tools. These should be split into subsections as the content migration proceeds.
