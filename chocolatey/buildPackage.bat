
REM Builds a Chocolatey package. Requires msbuild and cpack on the path.

msbuild ..\ResxDiff.sln /p:Configuration=Release
del resxdiff /Q
xcopy ..\ResxDiffConsole\bin\Release resxdiff\ /E
del resxdiff\*.pdb /Q
cpack
