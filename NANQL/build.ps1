#!/usr/bin/env pwsh

param (
    [switch]$run = $false,
    [switch]$publish = $false,
    [string]$query = $null,
    [string]$target = $null,
    [switch]$help = $false,
    [string]$proj = "NANQL.fsproj",
    [switch]$version
)

$versionNumber = "0.2.0"


if ($help) {
    Write-Host "Usage: build.ps1 [-codegeneration] [-run <target>] [-publish] [-target <target>] [-help]"
    Write-Host "  -run: Run the application"
    Write-Host "  -publish: Publish the application"
    Write-Host "  -query: The query to run"
    Write-Host "  -target: The target to publish for OR the file to run"
    Write-Host "  -proj: Specify the project to build"
    Write-Host "  -help: Show this help"
    exit
}
if ($version) {
    Write-Host "NANQL version $versionNumber"
    exit
}

if ($run) {
    if ($target -eq $null) {
        throw "A file to run must be specified"
    }
    return dotnet run --project $proj $query $target
}

if ($publish) {
    if ($target -eq $null) {
        throw "Target must be specified"
    }
    $singleFile = "true" # for cross-platform
    $projFile = "NANQLCross.fsproj"

    if ($target -eq "win-x64" -or $target -eq "linux-x64") {
        $singleFile = "false"
        $projFile = "NANQL.fsproj"
    }

    return dotnet publish $projFile -c Release --self-contained true -r $target -p:PublishTrimmed=true -p:PublishReadyToRun=true -p:PublishSingleFile=$singleFile
}

