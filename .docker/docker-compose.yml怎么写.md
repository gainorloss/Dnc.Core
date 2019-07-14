```
version: '3'

services:  
  postgres:
    container_name: aspnet-postgres
    image: postgres
    restart: always
    environment:
      POSTGRES_PASSWORD: p@ssw0rd
    volumes:
      - /docker/postgres/db:/var/lib/postgresql/data
    ports:
      - 5432:5432
    networks:
      - aspnet-network
  mysql:
    container_name: aspnet-mysql
    image: mysql/mysql-server
    restart: always
    environment:
      MYSQL_USER: mysql
      MYSQL_PASSWORD: p@ssw0rd
      MYSQL_ROOT_PASSWORD: p@ssw0rd
    volumes:
      - /docker/mysql/conf/my.cnf:/etc/my.cnf
      - /docker/mysql/db:/var/lib/mysql
    ports:
      - 3306:3306 
    networks:
      - aspnet-network  
  mongo:
    container_name: aspnet-mongo
    image: mysql/mysql-server
    restart: always
    environment:
      POSTGRES_PASSWORD: p@ssw0rd
    volumes:
      - /docker/mongo/conf:/db/configdb
      - /docker/mongo/data:/data/db
    ports:
      - 27017:27017
    networks:
      - aspnet-network  
  redis:
    container_name: aspnet-redis
    image: redis
    restart: always
    environment:
      POSTGRES_PASSWORD: p@ssw0rd
    volumes:
      - /docker/redis/db:/var/lib/postgresql/data
    ports:
      - 6379:6379
    networks:
      - aspnet-network
  rabbitmq:
    container_name: aspnet-rabbitmq
    image: rabbitmq:management
    restart: always
    ports:
      - 4369:4369    
      - 5671:5671    
      - 5672:5672   
      - 15671:15671 
      - 15672:15672 
      - 25672:25672
    networks:
      - aspnet-network
  web-mvc:
    container_name: web-mvc
    image: postgres
    restart: always
    environment:
      POSTGRES_PASSWORD: p@ssw0rd
    volumes:
      - docker/postgres/db:/var/lib/postgresql/data
    ports:
      - 5432:5432
    depends_on:
      - postgres
      - mysql
      - mongo
      - redis
      - rabbitmq
    networks:
      - aspnet-network
  nginx:
    container_name: aspnet-nginx
    image: nginx
    restart: always
    ports:
      - 80:80 
      - 443:443 
    volumes:
      - /docker/nginx/conf/nginx.conf:/etc/nginx/conf.d/default.conf 
    links: 
      - web-mvc
    networks:
      - aspnet-network  
networks:
  aspnet-network: 
    driver: bridge
      

```