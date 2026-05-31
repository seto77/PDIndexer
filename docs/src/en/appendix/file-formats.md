<!-- 260531Ch: Initial file-format appendix. -->
# File Formats

PDIndexer works with profile files, crystal-list files, and crystal-structure import files.

## Profile Data

Known profile-related formats include `pdi`, `pdi2`, `csv`, `tsv`, `ras`, `nxs`, `npd`, `chi`, `xbm`, and `rpt`. The exact behavior should be verified against the current loader code during the detailed migration.

## Crystal Data

Crystal lists are saved as XML. Crystal structures can be imported from CIF and AMC/AMCSD-style files.

## Export

Profile data can be exported as CSV, and drawings can be saved as EMF metafiles for use in applications such as PowerPoint or Word.
