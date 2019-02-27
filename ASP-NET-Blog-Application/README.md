
# Build and run blog application with Docker Compose:

### NOTE: 
This example has been taken from https://github.com/MicrosoftDocs/Virtualization-Documentation/tree/live/windows-container-samples/ASP-NET-Blog-Application and modified to be at a 'working state' !

* Create your docker network:
  - `docker network create --driver nat test`
  
* Run application 'manually'
  - `docker run -it --name "db" -p 1433:1433 <db container image>`
  - `docker run -it -p 80:80 <web container image>`

* Get the Windows Server Core Docker image:
  - `docker pull microsoft/windowsservercore`
  - https://hub.docker.com/r/microsoft/windowsservercore/

* Get the SQL Server 2016 Express Docker image:
  -`docker pull microsoft/mssql-server-windows-express`
  - https://hub.docker.com/r/microsoft/mssql-server-windows-express/

* Create a custom NAT network
```
networks:
 default:
  driver: nat
  ipam:
   driver: default
   config:
   - subnet: <Your chosen subnet prefix>
```

* Major blocker why `zip` file needs to be manually ported over instead of a download:
  - https://github.com/docker/for-win/issues/1976
