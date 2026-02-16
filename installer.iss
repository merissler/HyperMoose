[Setup]
AppName=HyperMoose
AppVersion=2.3
AppPublisher=Miles Rissler
DefaultDirName={autopf}\HyperMoose
DefaultGroupName=HyperMoose
OutputDir=Installer
OutputBaseFilename=HyperMoose-Installer
Compression=lzma
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64compatible
ArchitecturesAllowed=x64compatible

[Files]
Source: "HyperMoose\bin\Publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs

[Icons]
Name: "{group}\HyperMoose"; Filename: "{app}\HyperMoose.exe"

[Registry]
; Run on startup for current user
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "HyperMoose"; ValueData: """{app}\HyperMoose.exe"""; Flags: uninsdeletevalue

[Run]
Filename: "{app}\HyperMoose.exe"; Description: "Launch HyperMoose"; Flags: nowait postinstall skipifsilent
