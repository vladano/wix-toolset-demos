# ExampleWindowsService

This demo demonstarate installation application as Windows service.

Note:
Before installation check if exist folder "c:\temp"

## Prerequisite:

Visual Studio 2022
Wix AddIn for VS2022
Wix 3.14

## How to build

1. Open ".\ExampleWindowsService.sln" in VS 2022
2. Build project ExampleWindowsService
3. Build project ExampleWindowsServicePackage
4. Inside the folder ".\ExampleWindowsServicePackage\bin\en-US" .msi installation file will be generated => ExampleWindowsServicePackage.msi
