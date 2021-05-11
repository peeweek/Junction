!define APP_NAME "Junction"
!define COMP_NAME "PeeWeeK.NET"
!define WEB_SITE "http://www.peeweek.net"
!define VERSION "1.10.00.00"
!define COPYRIGHT "WTF-PL"
!define DESCRIPTION "Junction"
!define LICENSE_TXT "LICENCE.txt"
!define INSTALLER_NAME "Junction Installer 1.1.0.exe"
!define MAIN_APP_EXE "Junction.exe"

Name "Junction Installer"
OutFile "..\Junction Installer 1.1.0.exe"
LicenseData "LICENCE.txt"
InstallDir $PROGRAMFILES\Junction
RequestExecutionLevel admin

Function WriteRegistry
	WriteRegStr HKCR  "Directory\Shell" "" "none"
	WriteRegStr HKCR  "Directory\Shell\Junction" "" "Create Junction to this folder..."
    WriteRegStr HKCR  "Directory\Shell\Junction" "Position" "bottom"
	WriteRegStr HKCR  "Directory\Shell\Junction\command" "" "$\"$INSTDIR\Junction.exe$\" $\"%V$\""
	WriteRegStr HKCR  "Directory\*" "" "none"
	WriteRegStr HKCR  "Directory\*\Junction" "" "Create Junction to this folder..."
    WriteRegStr HKCR  "Directory\*\Junction" "Position" "bottom"
	WriteRegStr HKCR  "Directory\*\Junction\command" "" "$\"$INSTDIR\Junction.exe$\" /F $\"%V$\""
FunctionEnd

Page license 
Page instfiles
UninstPage uninstConfirm
UninstPage instfiles

Section
	SetOutPath $INSTDIR
	File "..\Junction\bin\Release\Junction.exe"
    Call WriteRegistry
SectionEnd