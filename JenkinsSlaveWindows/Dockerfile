FROM openjdk:8-jdk-windowsservercore-1809

ARG DOCKER_VERSION=18.09.0

ARG DOTNET_VERSION=4.7.2

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

# Install chocolatey
RUN Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

# Install dotnet
RUN choco install dotnet$env:DOTNET_VERSION -y

# Remoting versions can be found in Remoting sub-project changelog
# https://github.com/jenkinsci/remoting/blob/master/CHANGELOG.md
ARG SLAVE_FILENAME=slave.jar

ARG REMOTING_VERSION=3.23

ARG SLAVE_HASH_FILENAME=$SLAVE_FILENAME.sha1

# Get the Slave from the Jenkins Artifacts Repository
RUN Invoke-WebRequest "https://repo.jenkins-ci.org/public/org/jenkins-ci/main/remoting/$env:REMOTING_VERSION/remoting-$env:REMOTING_VERSION.jar" -OutFile $env:SLAVE_FILENAME -UseBasicParsing; \
    Invoke-WebRequest "https://repo.jenkins-ci.org/public/org/jenkins-ci/main/remoting/$env:REMOTING_VERSION/remoting-$env:REMOTING_VERSION.jar.sha1" -OutFile $env:SLAVE_HASH_FILENAME -UseBasicParsing; \
    if ((Get-FileHash $env:SLAVE_FILENAME -Algorithm SHA1).Hash -ne $(Get-Content $env:SLAVE_HASH_FILENAME)) {exit 1};
	
#Copy launch script used by entry point
COPY "docker-entrypoint.ps1" ".\docker-entrypoint.ps1"

ENTRYPOINT .\docker-entrypoint.ps1