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

## How to build

1.Open ".\WixSampleInstaller.sln" in VS 2022
2.Build project
3.Inside the folder ".\WixSampleInstaller\bin\x86\Debug" will be generate .msi installation file => WixSampleInstaller.msi
