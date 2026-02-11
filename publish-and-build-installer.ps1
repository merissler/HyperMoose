$ErrorActionPreference = "Stop"

# Publish the project
Write-Host "Publishing HyperMoose..." -ForegroundColor Cyan
dotnet publish "$PSScriptRoot\HyperMoose\HyperMoose.csproj" -p:PublishProfile=FolderProfile

if ($LASTEXITCODE -ne 0) {
    Write-Host "Publish failed!" -ForegroundColor Red
    exit 1
}

# Build the installer
Write-Host "Building installer..." -ForegroundColor Cyan
iscc "$PSScriptRoot\installer.iss"

if ($LASTEXITCODE -ne 0) {
    Write-Host "Installer build failed!" -ForegroundColor Red
    exit 1
}

Write-Host "Build complete! Installer at: Installer\HyperMoose-Installer.exe" -ForegroundColor Green
