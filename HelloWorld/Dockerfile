FROM mcr.microsoft.com/windows/servercore:1809

RUN dism.exe /online /enable-feature /all /featurename:iis-webserver /NoRestart

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

ENV DOCKER_VERSION 18.09.0

RUN Invoke-WebRequest 'http://constexpr.org/innoextract/files/innoextract-1.6-windows.zip' -OutFile 'innoextract.zip' -UseBasicParsing ; \
    Expand-Archive innoextract.zip -DestinationPath C:\ ; \
    Remove-Item -Path innoextract.zip

RUN [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12 ; \
    Invoke-WebRequest $('https://github.com/docker/toolbox/releases/download/v{0}/DockerToolbox-{0}.exe' -f $env:DOCKER_VERSION) -OutFile 'dockertoolbox.exe' -UseBasicParsing

RUN /innoextract.exe dockertoolbox.exe

RUN echo "Hello World !" > c:\inetpub\wwwroot\index.html

EXPOSE 80

WORKDIR C:\\app