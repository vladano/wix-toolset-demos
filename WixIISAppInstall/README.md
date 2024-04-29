# WixIISAppInstall

This demo show how to install demo web site on Windows IIS serve using Wix toolset.

Demo inside folder "Setup" create .msi installer that install "WebHelloWorld" web application on IIS server on port 8081.
Note:
There is no any installation sreen during installation.

Demo inside folder "SetupNew" create .msi installer that install "WebHelloWorld" web application on IIS server on choosen port during installation.

Note:
This .msi installatio demonstarate how to use "custom screen" inside installer to enter port number on what IIS web application will start.

## Prerequisite:

Visual Studio 2022
Wix AddIn for VS2022
Wix 3.14

## How to Build Wix installer from Setup folder

1. Open solution WebInstaller.sln in VS 2022
2. Build project WebHelloWorld
3. Build project Setup
4. Inside the folder ".\Setup\bin\x86\Debug\" installation Setup.msi will be generate.

## How to Build Wix installer from SetupNew folder

1. Open solution WebInstaller.sln in VS 2022
2. Build project WebHelloWorld
3. Build project Setup
4. Inside the folder ".\Setup\bin\x86\Debug\en-US\" installation SetupWebHelloWorld.msi will be generate.
