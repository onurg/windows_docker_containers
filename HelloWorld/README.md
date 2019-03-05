# Sample Hello World Application
   
1. Simply run:
   - `docker-compose build` (unless the images are build already)
   - `docker-compose up`
   
2. If Step.2 does not work:
   - `Get-Content Dockerfile | docker build -`
   - `docker run -itd -p "80:80" <IMAGE_ID>`
   
3. Once the container running, run following to get the IP of the container:
   - `docker inspect --format "{{ .NetworkSettings.IPAddress }}" <container_name_id>`
   
4. Browse to:
   - http://<CONTAINER_IP>:80/
