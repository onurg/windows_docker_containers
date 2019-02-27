# Sample Hello World Application

1. Create your docker network:
   `docker network create --driver nat test`
2. Simply run:
   `docker-compose build` (unless the images are build already)
   `docker-compose up`
3. If Step.2 does not work:
   `Get-Content Dockerfile | docker build -`
   `docker run -itd --network=test -p "80:80" <IMAGE_ID>`
4. Once the container running, run following to get the IP of the container:
   `docker inspect --format "{{ .NetworkSettings.IPAddress }}" <container_name_id>`
5. Browse to:
   http://<CONTAINER_IP>:80/