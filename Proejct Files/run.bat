@if (@CodeSection == @Batch) @then
@echo off
    set SendKeys=CScript //nologo //E:JScript "%~F0"
    start chrome /new-window https://www.youtube.com/watch?v=dQw4w9WgXcQ
        timeout /t 4 /nobreak >nul
    %SendKeys% "+(.)"
    %SendKeys% "+(.)"
    %SendKeys% "+(.)"
@end
var WshShell = WScript.CreateObject("WScript.Shell");
WshShell.SendKeys(WScript.Arguments(0));