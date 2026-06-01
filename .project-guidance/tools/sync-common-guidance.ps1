param(
    [string]$SourceRepo = "",
    [switch]$Apply
)

$ErrorActionPreference = "Stop"

# 260601Ch: Synchronize/check shared .project-guidance files across the four sibling repositories.
$repoNames = @("ReciPro", "PDIndexer", "CSManager", "IPAnalyzer")
$commonFiles = @(
    "project-guidance運用方針(共通).md",
    "github pages編集方針(共通).md",
    "ツールチップ編集方針(共通).md",
    # 260601Cl: WinForms_ToolTip_共通注意点.md を廃止（正本: ツールチップ編集方針(共通).md）。削除は $removedCommonFiles で伝播。
    "WinForms UI編集方針(共通).md",
    "ローカライズ・用語方針(共通).md",
    "共有ライブラリ編集方針(共通).md",
    "tools\sync-common-guidance.ps1"
)

# 260601Cl 追加: 廃止した共通ファイル。-Apply で全リポジトリから削除し、check では残存を [LINGER] として検出する。
$removedCommonFiles = @(
    "WinForms_ToolTip_共通注意点.md"
)

function Get-RepoRootFromScript {
    $toolsDir = Split-Path -Path $PSCommandPath -Parent
    $guidanceDir = Split-Path -Path $toolsDir -Parent
    return (Split-Path -Path $guidanceDir -Parent)
}

function Resolve-SourceRoot([string]$sourceRepo, [string]$defaultRoot, [string]$baseDir) {
    if ([string]::IsNullOrWhiteSpace($sourceRepo)) {
        return (Resolve-Path -LiteralPath $defaultRoot).Path
    }

    if (Test-Path -LiteralPath $sourceRepo) {
        return (Resolve-Path -LiteralPath $sourceRepo).Path
    }

    $candidate = Join-Path $baseDir $sourceRepo
    if (Test-Path -LiteralPath $candidate) {
        return (Resolve-Path -LiteralPath $candidate).Path
    }

    throw "Source repository not found: $sourceRepo"
}

function Test-IsUnderRoot([string]$path, [string]$root) {
    $fullPath = [System.IO.Path]::GetFullPath($path)
    $fullRoot = [System.IO.Path]::GetFullPath($root).TrimEnd([System.IO.Path]::DirectorySeparatorChar, [System.IO.Path]::AltDirectorySeparatorChar)
    return $fullPath.StartsWith($fullRoot + [System.IO.Path]::DirectorySeparatorChar, [System.StringComparison]::OrdinalIgnoreCase)
}

$defaultSourceRoot = Get-RepoRootFromScript
$baseDir = Split-Path -Path $defaultSourceRoot -Parent
$sourceRoot = Resolve-SourceRoot $SourceRepo $defaultSourceRoot $baseDir
$sourceRepoName = Split-Path -Path $sourceRoot -Leaf

if ($repoNames -notcontains $sourceRepoName) {
    throw "Source repository must be one of: $($repoNames -join ', '). Actual: $sourceRepoName"
}

$hadMismatch = $false

foreach ($repoName in $repoNames) {
    $repoRoot = Join-Path $baseDir $repoName
    if (-not (Test-Path -LiteralPath $repoRoot)) {
        Write-Host "[MISSING-REPO] $repoName"
        $hadMismatch = $true
        continue
    }

    $guidanceRoot = Join-Path $repoRoot ".project-guidance"
    if (-not (Test-IsUnderRoot $guidanceRoot $repoRoot)) {
        throw "Safety check failed for guidance path: $guidanceRoot"
    }

    foreach ($relativeFile in $commonFiles) {
        $src = Join-Path (Join-Path $sourceRoot ".project-guidance") $relativeFile
        $dst = Join-Path $guidanceRoot $relativeFile

        if (-not (Test-Path -LiteralPath $src)) {
            Write-Host "[MISSING-SOURCE] $relativeFile"
            $hadMismatch = $true
            continue
        }

        if ($Apply) {
            if (-not (Test-IsUnderRoot $dst $repoRoot)) {
                throw "Safety check failed for destination path: $dst"
            }
            if ([System.IO.Path]::GetFullPath($src) -eq [System.IO.Path]::GetFullPath($dst)) {
                Write-Host "[SOURCE] $repoName :: $relativeFile"
                continue
            }
            $dstDir = Split-Path -Path $dst -Parent
            if (-not (Test-Path -LiteralPath $dstDir)) {
                New-Item -ItemType Directory -Path $dstDir | Out-Null
            }
            Copy-Item -LiteralPath $src -Destination $dst -Force
            Write-Host "[SYNCED] $repoName :: $relativeFile"
            continue
        }

        if (-not (Test-Path -LiteralPath $dst)) {
            Write-Host "[MISSING] $repoName :: $relativeFile"
            $hadMismatch = $true
            continue
        }

        $srcHash = (Get-FileHash -LiteralPath $src -Algorithm SHA256).Hash
        $dstHash = (Get-FileHash -LiteralPath $dst -Algorithm SHA256).Hash
        if ($srcHash -eq $dstHash) {
            Write-Host "[OK] $repoName :: $relativeFile"
        } else {
            Write-Host "[DIFF] $repoName :: $relativeFile"
            $hadMismatch = $true
        }
    }

    # 260601Cl 追加: 廃止ファイルの削除伝播 / 残存検出。
    foreach ($relativeFile in $removedCommonFiles) {
        $dst = Join-Path $guidanceRoot $relativeFile
        if (-not (Test-Path -LiteralPath $dst)) {
            if (-not $Apply) { Write-Host "[REMOVED-OK] $repoName :: $relativeFile" }
            continue
        }
        if ($Apply) {
            if (-not (Test-IsUnderRoot $dst $repoRoot)) {
                throw "Safety check failed for removal path: $dst"
            }
            Remove-Item -LiteralPath $dst -Force
            Write-Host "[DELETED] $repoName :: $relativeFile"
        } else {
            Write-Host "[LINGER] $repoName :: $relativeFile"
            $hadMismatch = $true
        }
    }
}

if ($hadMismatch -and -not $Apply) {
    exit 1
}
