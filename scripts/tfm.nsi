!include "MUI2.nsh"
!include "LogicLib.nsh"
!include "x64.nsh"
Unicode true
CRCCheck on
ManifestSupportedOS all
XPStyle on
Name "Talking Flight Monitor"
OutFile "tfm-setup.exe"
InstallDir "$PROGRAMFILES\talking flight monitor"
InstallDirRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\talking-flight-monitor" "InstallLocation"
RequestExecutionLevel admin
SetCompress auto
SetCompressor /solid lzma
SetDatablockOptimize on
VIAddVersionKey ProductName "Talking Flight Monitor"
VIAddVersionKey LegalCopyright "Copyright 2020 Jason Fayre and Andy Borka."
VIAddVersionKey ProductVersion "0.95"
VIAddVersionKey FileVersion "0.95"
VIProductVersion "0.95.0.0"
VIFileVersion "0.95.0.0"
!insertmacro MUI_PAGE_WELCOME
!define MUI_LICENSEPAGE_RADIOBUTTONS
!insertmacro MUI_PAGE_LICENSE "license.txt"
!insertmacro MUI_PAGE_DIRECTORY
var StartMenuFolder
!insertmacro MUI_PAGE_STARTMENU startmenu $StartMenuFolder
!insertmacro MUI_PAGE_INSTFILES
!define MUI_FINISHPAGE_LINK "Visit the Talking Flight Monitor website"
!define MUI_FINISHPAGE_LINK_LOCATION "http://www.talkingflightmonitor.net"
!insertmacro MUI_PAGE_FINISH
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_LANGUAGE "English"
!insertmacro MUI_RESERVEFILE_LANGDLL
Section
SetShellVarContext All
SetOutPath "$INSTDIR"
File /r source\bin\debug\*

CreateShortCut "$DESKTOP\Talking flight Monitor.lnk" "$INSTDIR\tfm.exe"
!insertmacro MUI_STARTMENU_WRITE_BEGIN startmenu
CreateDirectory "$SMPROGRAMS\$StartMenuFolder"
CreateShortCut "$SMPROGRAMS\$StartMenuFolder\TWBlue.lnk" "$INSTDIR\TWBlue.exe"
CreateShortCut "$SMPROGRAMS\$StartMenuFolder\TWBlue on the web.lnk" "http://twblue.es"
CreateShortCut "$SMPROGRAMS\$StartMenuFolder\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
!insertmacro MUI_STARTMENU_WRITE_END
WriteUninstaller "$INSTDIR\Uninstall.exe"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\tfm" "DisplayName" "Talking Flight Monitor"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\tfm" "UninstallString" '"$INSTDIR\uninstall.exe"'
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall" "InstallLocation" $INSTDIR
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall" "Publisher" "Jason Fayre"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "DisplayVersion" "0.95"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "URLInfoAbout" "http://twblue.es"
WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "VersionMajor" 0
WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "VersionMinor" 95
WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "NoModify" 1
WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "NoRepair" 1
SectionEnd
Section "Uninstall"
SetShellVarContext All
DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue"
RMDir /r /REBOOTOK $INSTDIR
Delete "$DESKTOP\TWBlue.lnk"
!insertmacro MUI_STARTMENU_GETFOLDER startmenu $StartMenuFolder
RMDir /r "$SMPROGRAMS\$StartMenuFolder"
SectionEnd
Function .onInit
${If} ${RunningX64}
StrCpy $instdir "$programfiles64\twblue"
${EndIf}
!insertmacro MUI_LANGDLL_DISPLAY
FunctionEnd
