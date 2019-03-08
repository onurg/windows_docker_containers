FROM microsoft/aspnet:4.7.2

# Move built solution dlls
ARG site_root=.

# Copy local solution for ASP.Net
COPY ${site_root} /inetpub/wwwroot

WORKDIR /inetpub/wwwroot