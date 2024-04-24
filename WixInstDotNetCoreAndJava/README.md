# WixInstDotNetCoreAndJava

Installs .NET Core with ALL files for .NET CORE + Java .jar file (Maven Java project). 
The Wix project get everything found in the defined folder and create 2 shortucts, for .NET Core app and Java app.

## Prerequisite:

Visual Studio 2022
Wix AddIn for VS2022
Wix 3.14

## How to Build 

1.Build Maven project from folder "TicTacToeMaven"

2.Open ".\ConsoleApp1\ConsoleApp1.csproj" in VS 2022
3.Build
4.Publish to folder .\ConsoleApp1\bin\Release\netcoreapp2.0\publish

5.From publish folder copy all files to apptoinstall folder
6.Copy from folder ..\TicTacToeMaven\target generated .jar file to apptoinstall folder

7. Open solution file ".\ConsoleApp1.sln"
8.Build project ConsoleApp1.Installer
9. Inside folder will be generate .\ConsoleApp1.Installer\Installs .msi installation file => TicTacToe-1.3.0.0-Debug-x64.msi


File TicTacToe-1.3.0.0-Debug-x64.msi install .NET Core App and Java TicTacToe app to computer
