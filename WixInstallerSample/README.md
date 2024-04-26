# WixInstallerSample

This demo demonstarate Old and NEW way to dimaicaly create struture of files inside installation folder (folder "SoftwareToInstall"). All inside this folde will be automatically pack inside .msi generated installation file and install to installation location during install.

<!-- OK - Old way to get content of folders -->
<Target Name="PreBuild" BeforeTargets="PreBuildEvent">
    <Exec Command="&quot;C:\Program Files (x86)\WiX Toolset v5.0\bin\x86\heat.exe&quot; dir &quot;$(SolutionDir)WixSampleInstaller\SoftwareToInstall\SubFolder1&quot; -dr SubFolder1Dir -cg SubFolder1Components -gg -g1 -sf -srd -var &quot;var.SubFolder1SourceDir&quot; -out &quot;$(SolutionDir)WixSampleInstaller\SubFolder1.wxs&quot;&#xA;&quot;C:\Program Files (x86)\WiX Toolset v5.0\bin\x86\heat.exe&quot; dir &quot;$(SolutionDir)WixSampleInstaller\SoftwareToInstall\SubFolder2&quot; -dr SubFolder2Dir -cg SubFolder2Components -gg -g1 -sf -srd -var &quot;var.SubFolder2SourceDir&quot; -out &quot;$(SolutionDir)WixSampleInstaller\SubFolder2.wxs&quot;" />
</Target>

and

<!-- Harvest file components from publish folder - OK - NEW way to get content of folders-->

<HeatDirectory OutputFile="SubFolder1.wxs"
			   DirectoryRefId="SubFolder1Dir"
			   ComponentGroupName="SubFolder1Components"
			   SuppressCom="true"
			   Directory="$(SolutionDir)WixSampleInstaller\SoftwareToInstall\SubFolder1"
			   SuppressFragments="true"
			   SuppressRegistry="true"
			   SuppressRootDirectory="true"
			   AutoGenerateGuids="false"
			   GenerateGuidsNow="true"
			   ToolPath="$(WixToolPath)"
			   PreprocessorVariable="var.SubFolder1SourceDir" />
<HeatDirectory OutputFile="SubFolder2.wxs"
			   DirectoryRefId="SubFolder2Dir"
			   ComponentGroupName="SubFolder2Components"
			   SuppressCom="true"
			   Directory="$(SolutionDir)WixSampleInstaller\SoftwareToInstall\SubFolder2"
			   SuppressFragments="true"
			   SuppressRegistry="true"
			   SuppressRootDirectory="true"
			   AutoGenerateGuids="false"
			   GenerateGuidsNow="true"
			   PreprocessorVariable="var.SubFolder2SourceDir" />
</Target>

## Prerequisite:

Visual Studio 2022
Wix AddIn for VS2022
Wix 3.14

## How to build using VS 2002

1. Open ".\WixSampleInstaller.sln" in VS 2022
2. Build project
3. Inside the folder ".\WixSampleInstaller\bin\x86\Debug" will be generate .msi installation file => WixSampleInstaller.msi

## How to build from command line

If you look at the VS 2022 output console, you can find all the commands you need to run to generate the .msi package from the command line.

On Windows platform you need to execute folloving command from command line:

C:\Users\username\.nuget\packages\wixtoolset.heat\5.0.0\tools\net472\x64\heat.exe dir .\WixSampleInstaller\SoftwareToInstall\SubFolder1 -cg SubFolder1Components -dr SubFolder1Dir -scom -sreg -srd -var var.SubFolder1SourceDir -gg -sfrag -out SubFolder1.wxs

C:\Users\username\.nuget\packages\wixtoolset.heat\5.0.0\tools\net472\x64\heat.exe dir .\WixSampleInstaller\SoftwareToInstall\SubFolder2 -cg SubFolder2Components -dr SubFolder2Dir -scom -sreg -srd -var var.SubFolder2SourceDir -gg -sfrag -out SubFolder2.wxs

C:\Users\username\.nuget\packages\wixtoolset.sdk\5.0.0\tools\net472\x64\wix.exe build -platform x86 -out obj\x86\Debug\WixSampleInstaller.msi -outputType Package -pdb obj\x86\Debug\WixSampleInstaller.wixpdb -pdbType full -culture null -d SubFolder1SourceDir=SoftwareToInstall\SubFolder1 -d SubFolder2SourceDir=SoftwareToInstall\SubFolder2 -d "DevEnvDir=C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\\" -d SolutionDir=.\ -d SolutionExt=.sln -d SolutionFileName=WixSampleInstaller.sln -d SolutionName=WixSampleInstaller -d SolutionPath=.\WixSampleInstaller.sln -d Configuration=Debug -d OutDir=bin\x86\Debug\ -d InstallerPlatform=x86 -d Platform=x86 -d ProjectDir=.\WixSampleInstaller\ -d ProjectExt=.wixproj -d ProjectFileName=WixSampleInstaller.wixproj -d ProjectName=WixSampleInstaller -d ProjectPath=.\WixSampleInstaller\WixSampleInstaller.wixproj -d TargetDir=.\WixSampleInstaller\bin\x86\Debug\ -d TargetExt=.msi -d TargetFileName=WixSampleInstaller.msi -d TargetName=WixSampleInstaller -d TargetPath=.\WixSampleInstaller\bin\x86\Debug\WixSampleInstaller.msi -ext C:\Users\username\.nuget\packages\wixtoolset.util.wixext\5.0.0\wixext5\WixToolset.Util.wixext.dll -ext C:\Users\username\.nuget\packages\wixtoolset.ui.wixext\5.0.0\wixext5\WixToolset.UI.wixext.dll -intermediatefolder obj\x86\Debug\ -trackingfile obj\x86\Debug\WixSampleInstaller.wixproj.BindTracking-neutral.txt -nologo  Product.wxs SubFolder1.wxs SubFolder2.wxs

C:\Users\username\.nuget\packages\wixtoolset.sdk\5.0.0\tools\net472\x64\wix.exe msi validate obj\x86\Debug\WixSampleInstaller.msi -pdb obj\x86\Debug\WixSampleInstaller.wixpdb -intermediatefolder obj\x86\Debug\ -nologo

echo F | xcopy /F /Y ".\WixSampleInstaller\obj\x86\Debug\WixSampleInstaller.msi" ".\WixSampleInstaller\bin\x86\Debug\WixSampleInstaller.msi"

echo F | xcopy /F /Y ".\WixSampleInstaller\obj\x86\Debug\WixSampleInstaller.wixpdb" ".\WixSampleInstaller\bin\x86\Debug\WixSampleInstaller.wixpdb"
