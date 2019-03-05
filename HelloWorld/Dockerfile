FROM mcr.microsoft.com/windows/servercore:1809

# Enable IIS
RUN dism.exe /online /enable-feature /all /featurename:iis-webserver /NoRestart

ENV DOCKER_VERSION 18.09.0

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

# Install innoextract
RUN Invoke-WebRequest 'http://constexpr.org/innoextract/files/innoextract-1.6-windows.zip' -OutFile 'innoextract.zip' -UseBasicParsing ; \
    Expand-Archive innoextract.zip -DestinationPath C:\ ; \
    Remove-Item -Path innoextract.zip

# Download docker
RUN [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12 ; \
    Invoke-WebRequest $('https://github.com/docker/toolbox/releases/download/v{0}/DockerToolbox-{0}.exe' -f $env:DOCKER_VERSION) -OutFile 'dockertoolbox.exe' -UseBasicParsing

# Install docker
RUN /innoextract.exe dockertoolbox.exe

# Add docker to PATH from extracted dir
RUN setx path '%path%;C:\app'

RUN echo "Hello World !" > c:\inetpub\wwwroot\index.html

EXPOSE 80