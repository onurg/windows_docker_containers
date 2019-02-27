# Sample Windows Containers
- Built on a Linux environment running VirtualBox
- Tested on Windows Server 2016
- VM created needs to have enough space (at least somewhere around 40gb) for the windows images to be downloaded
  - Each image is around 11gb+ 

## Steps to Follow:
1. Setup your VM following these steps: https://blog.couchbase.com/windows-server-2016-virtualbox-docker/
2. Through PowerShell as an administrator, install following:
   1. Install Docker-EE: https://docs.docker.com/install/windows/docker-ee/ 
   2. Install docker-compose: https://www.ntweekly.com/2018/05/16/install-docker-compose-windows-server-2016/
   3. Install any additional tools such as Git, Python, Notepad++ as you require
3. Clone the repository in default directory on Powershell
4. Create a docker network:
   `docker network create --driver nat test`
5. Reset default network settings in Server 2016:
   `Get-NetNat | Remove-NetNat`
6. Now we're ready to build and deploy containers locally.

### Useful commands:
Build from Dockerfile in Powershell:
- `Get-Content Dockerfile | docker build -`

Build from Dockerfile in CMD:
- `docker build - < Dockerfile`

View running containers:
- `docker ps`

View all containers:
- `docker ps -a`

View services running under docker-compose:
- `docker-compose ps`

View container images:
- `docker images`

View container network info:
- `docker inspect <CONTAINER ID>`

Remove running containers and networks:
- `docker-compose down -v`

Remove container image:
- `docker rmi <IMAGE ID>`

Remove container:
- `docker rm <CONTAINER ID>`

Remove all containers and networks:
- `docker system prune -f`

