[![Build Status](https://tsew.visualstudio.com/TSEW/_apis/build/status/WHSClamAV?branchName=master)](https://tsew.visualstudio.com/TSEW/_build/latest?definitionId=7&branchName=master)
## WHSClamAV - Anitvirus for Windows Home Server v1

For more information visit http://whsclamav.tsew.com/

Solution files are provided for both VS2015 and VS2010.  You will need VS2010 if you want to perform remote debugging as the later versions of Visual Studio do not support Windows Server 2003 (x86).

### Requirements

You will need the SDK files from a Windows Home Server Installtion.

The following DLLs have been added to the root of the git repo:
* HomeServerControls.dll
* HomeServerExt.dll
* Microsoft.HomeServer.SDK.Interop.v1.dll
* WHSCommon.dll

#### WiX Toolset 
You should download the WiX toolset from:

https://marketplace.visualstudio.com/items?itemName=RobMensching.WixToolsetVisualStudio2010Extension
