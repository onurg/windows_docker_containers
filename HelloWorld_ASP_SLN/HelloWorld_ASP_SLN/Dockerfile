FROM microsoft/aspnet:4.7.2

# Add docker to PATH from extracted dir
RUN setx path '%path%;C:\Windows\Microsoft.NET\Framework\v4.0.30319'

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

# Install dotnet compiler (on demand)
#RUN Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force; \
#  	 Install-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -Force

# Install chocolatey
RUN Set-ExecutionPolicy Bypass -Scope Process -Force; \
	iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

# Install dotnet and build tools
RUN choco install dotnet4.7.2 \
	netfx-4.7.2-devpack \
	microsoft-build-tools -y

# Move built solution dlls
ARG site_root=.

# Copy local solution for ASP.Net
COPY ${site_root} /inetpub/wwwroot

WORKDIR /inetpub/wwwroot

RUN msbuild /t:Build