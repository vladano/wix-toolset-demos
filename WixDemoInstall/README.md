# WixDemoInstall

A demo that installs the defined files and everything in the defined installation folder.

## Prerequisite:

Visual Studio 2022
Wix toolset extension for VS2022 -> https://marketplace.visualstudio.com/items?itemName=WixToolset.WixToolsetVisualStudio2022Extension
Wix toolset 3.14 -> https://github.com/wixtoolset/wix3/releases/tag/wix3141rtm

## How to build

1. Open "WixDemoInstall.sln" in VS 2022
2. Build project
3. Inside the folder ".\bin\x86\Debug", will be generate .msi installation file => WixDemoInstall.msi

File WixDemoInstall.msi install image tropical_island.jpg, William_Shakespeare.txt and ALL files inside folder "NaturePictures" to destination computer and create 3 shotcuts on desktop and inside ProgramMenuDir
