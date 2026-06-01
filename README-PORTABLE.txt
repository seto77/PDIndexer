PDIndexer portable ZIP package (260601Ch)
=========================================

The MSI installer is the recommended installation method for PDIndexer.
This portable ZIP package is provided as an alternative for managed Windows
PCs where MSI installation, administrator approval, or separate .NET Desktop
Runtime installation is difficult. In this document, "portable" means
"no installer required"; PDIndexer still uses the current user's AppData
folder for settings and copied default data. (260601Ch)

How to run
----------

1. Extract the ZIP file to a user-writable folder.
   Example: Documents\PDIndexer or Desktop\PDIndexer

2. Run PDIndexer.exe from the extracted PDIndexer folder.

3. Do not run PDIndexer.exe directly from inside the ZIP viewer.
   Extract the full folder first so that the bundled DLLs, database files,
   localization files, and documents remain next to PDIndexer.exe.

Runtime
-------

This portable package is self-contained for Windows x64. A separate .NET
Desktop Runtime 10 installation is not required; the required .NET runtime
files are bundled in this folder. When Microsoft releases .NET runtime
security updates, this package should be rebuilt and redistributed so that
the bundled runtime is also updated. (260601Ch)

Notes for managed PCs
---------------------

- Administrator privileges are not required by PDIndexer itself.
- PDIndexer stores user settings and copied default data under the current
  user's application data folder.
- PDIndexer may also store per-user options under HKCU
  (HKEY_CURRENT_USER\Software\Crystallography\PDIndexer).
- Windows Defender SmartScreen or institutional security software may still
  warn about newly downloaded unsigned research software. Download PDIndexer
  only from the official GitHub Releases page:
  https://github.com/seto77/PDIndexer/releases/latest

Verification
------------

If SHA256SUMS.txt is provided with the release, you can verify the downloaded
ZIP file in PowerShell:

  Get-FileHash .\PDIndexer-*-win-x64-portable.zip -Algorithm SHA256
