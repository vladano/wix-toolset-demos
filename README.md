# Wix toolset demo projects

1. Build solution inside WixInstallerJava folder
   - This Wix project show how to install java application from .jar fajl and how create application shortcut to start java application inside .jar file on Windows platform.

2. Build project inside folder WixInstDotNetCoreAndJava
   - Build .msi installtion file that installs .NET Core with ALL files for .NET CORE and Java .jar file.

3. Build Wix toolset project inside folder WixInstallerSample
   - Build .msi installtion file that demonstarate Old and NEW way to dimaicaly create struture of files inside installation folder (folder "SoftwareToInstall"). All inside this folder will be automatically pack to .msi generated installation file and install to installation folder during install.

4. Build Wix toolset project inside folder WixDemoInstall
   - Build .msi installtion file that installs the defined files and all files in the defined installation folder.

5. Build Wix toolset project inside folder ExampleWindowsService
   - Build .msi installtion file that installation application as Windows service on destination computer.

6. Build Wix toolset project inside folder WixIISAppInstall
   - Build .msi installtion file that install demo web site on Windows IIS server.

   - The first demo show how to install demo web site on Windows IIS serve using Wix toolset.
	 Demo inside folder "Setup" create .msi installer that install "WebHelloWorld" web application on IIS server on port 8081.
     Note:
     There is no any installation sreen during installation.

   - The second demo inside folder "SetupNew" create .msi installer that install "WebHelloWorld" web application on IIS server on choosen port during installation.
     Note:
     This .msi installatio demonstarate how to use "custom screen" inside installer to enter port number on what IIS web application will start.

## Note:

All demos can be build using VS 2022 or command line (CI/CD).
For the build using command line look at WixInstallerSample and WixDemoInstall.

For more information look documentation at link https://wixtoolset.org/docs/intro/#msbuild.
