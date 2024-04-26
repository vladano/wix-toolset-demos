# WixDemoInstall

A demo that installs the defined files and everything in the defined installation folder.

## Prerequisite:

Visual Studio 2022
Wix toolset extension for VS2022 -> https://marketplace.visualstudio.com/items?itemName=WixToolset.WixToolsetVisualStudio2022Extension
Wix toolset 3.14 -> https://github.com/wixtoolset/wix3/releases/tag/wix3141rtm

## How to build using VS 2002

1. Open "WixDemoInstall.sln" in VS 2022
2. Build project
3. Inside the folder ".\bin\x86\Debug", will be generate .msi installation file => WixDemoInstall.msi

File WixDemoInstall.msi install image tropical_island.jpg, William_Shakespeare.txt and ALL files inside folder "NaturePictures" to destination computer and create 3 shotcuts on desktop and inside ProgramMenuDir

## How to build from command line

If you look at output console of VS 2022 you can find all command that you need to run to generate .msi package from command line

On Windows platform you need to execute folloving command from command line:

"C:\Users\username\\.nuget\packages\wixtoolset.sdk\5.0.0\tools\net472\x64\wix.exe" build -platform x86 -out "obj\x86\Debug\WixDemoInstall.msi" -outputType Package -pdb "obj\x86\Debug\WixDemoInstall.wixpdb" -pdbType full -culture null -d SubFolderSourceDir=NaturePictures -d "DevEnvDir=C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\\" -d SolutionDir=.\ -d SolutionExt=.sln -d SolutionFileName=WixDemoInstall.sln -d SolutionName=WixDemoInstall -d SolutionPath=.\WixDemoInstall.sln -d Configuration=Debug -d OutDir=bin\x86\Debug\ -d InstallerPlatform=x86 -d Platform=x86 -d ProjectDir=.\WixDemoInstall\ -d ProjectExt=.wixproj -d ProjectFileName=WixDemoInstall.wixproj -d ProjectName=WixDemoInstall -d ProjectPath=.\WixDemoInstall\WixDemoInstall.wixproj -d TargetDir=.\WixDemoInstall\bin\x86\Debug\ -d TargetExt=.msi -d TargetFileName=WixDemoInstall.msi -d TargetName=WixDemoInstall -d TargetPath=.\WixDemoInstall\bin\x86\Debug\WixDemoInstall.msi -ext C:\Users\username\\.nuget\packages\wixtoolset.util.wixext\5.0.0\wixext5\WixToolset.Util.wixext.dll -ext C:\Users\username\.nuget\packages\wixtoolset.ui.wixext\5.0.0\wixext5\WixToolset.UI.wixext.dll -intermediatefolder obj\x86\Debug\ -trackingfile obj\x86\Debug\WixDemoInstall.wixproj.BindTracking-neutral.txt -nologo .\Product.wxs .\SubFolder.wxs

wix.exe msi validate obj\x86\Debug\WixDemoInstall.msi -pdb obj\x86\Debug\WixDemoInstall.wixpdb -intermediatefolder obj\x86\Debug\ -nologo

echo F | xcopy /F /Y ".\WixDemoInstall\obj\x86\Debug\WixDemoInstall.msi" ".\WixDemoInstall\bin\x86\Debug\WixDemoInstall.msi"

echo F | xcopy /F /Y ".\WixDemoInstall\obj\x86\Debug\WixDemoInstall.wixpdb" ".\WixDemoInstall\bin\x86\Debug\WixDemoInstall.wixpdb"

These commands will generate installation .msi package inside the folder ".\bin\x86\Debug",  => WixDemoInstall.msi
