# AzureCLIasMSIX

Azure CLI has .msi installer. Installer can be found [here](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?tabs=azure-cli). This application upon installation sets its script path details in the PATH Environment variable. This path doesn’t have any .exe. Hence, we can not directly apply AppExecutionAlias here and MSIX doesn’t allows applications to set anything in the environment variable. 

All the scripts which are there in this path location are calling python which is present within the package along with some fixed set of arguments + all the arguments passed via CLI.

Use this project as a workaround by building it and using the output executable to add in the package at a location as mentioned in the [AppxManifest.xml](https://github.com/ravishroshanms/AzureCLIasMSIX/AppxManifest.xml). You can build the project using Visual Studio. Additionally you can use [AppxManifest.xml](https://github.com/ravishroshanms/AzureCLIasMSIX/AppxManifest.xml) to create AppExecutionAlias for the executable generated from the project.


