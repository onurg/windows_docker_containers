FROM microsoft/aspnet:4.7.2

# Move built solution dlls
#ARG site_root=.\\HelloWorldASP\\bin

# Move current folder (if only built locally produced output dir)
ARG site_root=.

# Copy solution for ASP.Net
COPY ${site_root} /inetpub/wwwroot