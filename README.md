# Sample Windows Containers
- Images are built on a MacOS using WinServer2016 and/or a remote VM using Windows Server 1809
- VM created needs to have enough space (at least somewhere around 40gb) for the windows images to be downloaded
  - Core image 11gb
  - OpenJDK 5.1gb

## Steps to Follow:
1. Setup your VM following these steps: https://blog.couchbase.com/windows-server-2016-virtualbox-docker/
2. Through PowerShell as an administrator, install following:
   1. Install Docker-EE: https://docs.docker.com/install/windows/docker-ee/ 
   2. Install docker-compose: https://www.ntweekly.com/2018/05/16/install-docker-compose-windows-server-2016/
   3. Install any additional tools such as Git, Python, Notepad++ as you require
3. Clone the repository in default directory on Powershell
4. Refactor docker network settings:
    ```
    Stop-Service docker
    Get-ContainerNetwork | Remove-ContainerNetwork -Force -ea SilentlyContinue
    Get-NetNat | Remove-NetNat
    Get-VMSwitch | Remove-VMSwitch -Force -ea SilentlyContinue
    Start-Service docker
    ```
5. Now we're ready to build and deploy containers locally.

### Useful commands:
Build from Dockerfile in Powershell:
- `Get-Content Dockerfile | docker build -`

Build from Dockerfile in CMD:
- `docker build - < Dockerfile`
