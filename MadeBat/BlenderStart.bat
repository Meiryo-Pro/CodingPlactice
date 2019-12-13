@echo off
rem 文字コードをUTF-8に設定
chcp 65001

rem バッチファイルから起動した場合
@if "%1"=="" (
D:
cd "Program Files"/"Blender Foundation"/"Blender 2.81"
blender.exe
)

rem バッチファイルにBlenderファイルをドラッグ＆ドロップした場合
set search=%~x1
set blend=.blend

@if %search%==%blend% (
%1
)
