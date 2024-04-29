# WixInstDotNetCoreAndJava

Installs Java .jar file (Maven Java project).

This Wix project show how to install java application from .jar fajl and how create application shortcut to start java application inside .jar file on Windows platform.

## Prerequisite:

Visual Studio 2022
Wix AddIn for VS2022
Wix 3.14

## How to Build

1. Go to TicTacToeMaven folder
2. To compile use: mvn compile
3. To build use: mvn package
4. Output will be gaenerate on ".\TicTacToeMaven\target\TicTacToe-1.1.0.jar"
5. Open solution fajl WixInstallerJava.sln in VS 2022
6. Build project WixInstallerTicTacToe for x86 and x64 platform.
6. x86 application version will be generate on location ".\WixInstallerTicTacToe\bin\x64\Debug\en-US\WixInstallerTicTacToe.msi"
7. x64 application version will be generate on location ".\WixInstallerTicTacToe\bin\x86\Debug\en-US\WixInstallerTicTacToe.msi"
