@ECHO OFF
echo ׼��ж�ط���
pause
REM The following directory is for .NET 4.0
set DOTNETFX2=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX2%
echo ��װж�ط���...
echo ---------------------------------------------------
InstallUtil /u PushWebSocketService.exe
echo ---------------------------------------------------
echo ж�سɹ���
pause