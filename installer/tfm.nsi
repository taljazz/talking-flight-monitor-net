!include "MUI2.nsh"
!include "LogicLib.nsh"
!include "x64.nsh"
Unicode true
CRCCheck on
ManifestSupportedOS all
Name "Talking Flight Monitor"
Caption "Talking Flight Monitor ${VERSION} Setup"

OutFile "tfm-${VERSION}-setup.exe"
InstallDir "$PROGRAMFILES\talking flight monitor"
InstallDirRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\talking-flight-monitor" "InstallLocation"
RequestExecutionLevel admin
SetCompress auto
SetCompressor /solid lzma
SetDatablockOptimize on
VIProductVersion "0.0.0.0" ;Needs to be here so other version info shows up
VIAddVersionKey "ProductName" "Talking Flight Monitor"
VIAddVersionKey "LegalCopyright" "${COPYRIGHT}"
VIAddVersionKey "FileDescription" "Talking Flight Monitor installer"
VIAddVersionKey "FileVersion" "${VERSION}"
VIAddVersionKey "ProductVersion" "${VERSION}"

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
File /r ..\source\bin\debug\*

CreateShortCut "$DESKTOP\Talking flight Monitor.lnk" "$INSTDIR\tfm.exe"
!insertmacro MUI_STARTMENU_WRITE_BEGIN startmenu
CreateDirectory "$SMPROGRAMS\$StartMenuFolder"
CreateShortCut "$SMPROGRAMS\$StartMenuFolder\tfm.lnk" "$INSTDIR\tfm.exe"
CreateShortCut "$SMPROGRAMS\$StartMenuFolder\Talking Flight Monitor Website.lnk" "http://www.talkingflightmonitor.net"
CreateShortCut "$SMPROGRAMS\$StartMenuFolder\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
!insertmacro MUI_STARTMENU_WRITE_END
WriteUninstaller "$INSTDIR\Uninstall.exe"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\tfm" "DisplayName" "Talking Flight Monitor"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\tfm" "UninstallString" '"$INSTDIR\uninstall.exe"'
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall" "InstallLocation" $INSTDIR
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall" "Publisher" "Jason Fayre"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "DisplayVersion" "0.95"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "URLInfoAbout" "http://www.talkingflightmonitor.net"
WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "VersionMajor" 0
WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "VersionMinor" 95
WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "NoModify" 1
WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\twblue" "NoRepair" 1
SectionEnd
Section "Uninstall"
SetShellVarContext All
DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\tfm"
RMDir /r /REBOOTOK $INSTDIR
Delete "$DESKTOP\tfm.lnk"
!insertmacro MUI_STARTMENU_GETFOLDER startmenu $StartMenuFolder
RMDir /r "$SMPROGRAMS\$StartMenuFolder"
SectionEnd
Function .onInit
${If} ${RunningX64}
StrCpy $instdir "$programfiles64\talking flight monitor"
${EndIf}
!insertmacro MUI_LANGDLL_DISPLAY
FunctionEnd
