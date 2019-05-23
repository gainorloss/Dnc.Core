docker run -d --name mysql -p 3306:3306 -v /usr/local/docker/mysql/config/mysqld.cnf:/etc/mysql/mysql.conf.d/mysqld.cnf -v /usr/local/docker/mysql/data/mysql:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=123456 mysql:5.7

docker run -d -p 6379:6379 --name redis -v /usr/local/docker/redis/redis.conf:/etc/redis/redis.conf -v /usr/local/docker/redis/data:/data -d redis:alpine redis-server /etc/redis/redis.conf --appendonly yes

docker run -d --name mongo -v /usr/local/docker/mongo/configdb:/data/configdb -v /usr/local/docker/mongo/data:/data/db -p 27017:27017 mongo:4 --auth

docker run -d --name es -p 9200:9200 -p 9300:9300 -v /usr/local/docker/es/config:/usr/share/elasticsearch/config -v /usr/local/docker/es/data:/usr/share/elasticsearch/data -v /usr/local/docker/es/plugins:/usr/share/elasticsearch/plugins elasticsearch:6.5.0 