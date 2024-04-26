# Wix toolset demo projects

1. Build Maven project inside folder TicTacToeMaven
  - This is a Java/Mavenized version of the popular classic game Tic-Tac-Toe.
2. Build project inside folder WixInstDotNetCoreAndJava 
    - Build .msi installtion file that installs .NET Core with ALL files for .NET CORE and Java .jar file from previous step (1.1).

3. Build Wix toolset project inside folder WixInstallerSample
   - Build .msi installtion file that demonstarate Old and NEW way to dimaicaly create struture of files inside installation folder (folder "SoftwareToInstall"). All inside this folder will be automatically pack to .msi generated installation file and install to installation folder during install.

4. Build Wix toolset project inside folder WixDemoInstall
   - Build .msi installtion file that installs the defined files and all files in the defined installation folder.

5. Build Wix toolset project inside folder ExampleWindowsService
   - Build .msi installtion file that installation application as Windows service on destination computer.

6. Build Wix toolset project inside folder WixIISAppInstall
   - Build .msi installtion file that install demo web site on Windows IIS server.
   
## Note:
All demos can be build using VS 2022 or command line (CI/CD).
For the build using command line look at WixInstallerSample and WixDemoInstall.

For more information look documentation at link https://wixtoolset.org/docs/intro/#msbuild.
