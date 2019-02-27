FROM microsoft/windowsservercore

# BlogEngine.NET dependencies
RUN dism.exe /online /enable-feature /all /featurename:iis-webserver /NoRestart
RUN powershell add-windowsfeature web-asp-net45 

# # Copy and extract BlogEngine.NET project files
COPY BlogEngineNETSrc.zip C:/BlogEngineNETSrc.zip
RUN powershell -Command \
    $ErrorActionPreference = 'Stop'; \
	Expand-Archive -Path c:\BlogEngineNETSrc.zip -DestinationPath c:\inetpub\wwwroot\blogengine ; \
	Remove-Item c:\BlogEngineNETSrc.zip -Force

# Configure Web App
COPY buildapp.ps1 C:/
RUN powershell.exe C:\buildapp.ps1

# Overwrite Web.config file so that web service points to db service
COPY Web.config C:/inetpub/wwwroot/blogengine

