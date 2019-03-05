FROM mcr.microsoft.com/windows/servercore:1809

RUN dism.exe /online /enable-feature /all /featurename:iis-webserver /NoRestart

RUN echo "Hello World !" > c:\inetpub\wwwroot\index.html

EXPOSE 80

CMD [ "cmd" ]
