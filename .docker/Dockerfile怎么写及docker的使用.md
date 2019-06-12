# Docker的使用

### Command模式启动中间件实例

1. mysql volume挂载启动
* [ ] [mysql.cnf](./configs/mysql.cnf)
```
docker run -d --name mysql -p 3306:3306 -v /usr/local/docker/mysql/config/mysqld.cnf:/etc/mysql/mysql.conf.d/mysqld.cnf -v /usr/local/docker/mysql/data/mysql:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=123456 mysql:5.7
```

2. mongo volume挂载启动

* [ ] 第一种方式：
```
docker run -d --name mongo -v /usr/local/docker/mongo/configdb:/data/configdb -v /usr/local/docker/mongo/data:/data/db -p 27017:27017 mongo:4 --auth
```

* [ ] 第二种方式：
```
docker run -d -p 27017:27017 --name aspnet-mongo -v /docker/mongo/db:/data/db -v /docker/mongo/conf:/data/configdb
```

3. redis volume挂载启动
* [ ] 经过测试
```
docker run -d -p 6379:6379 --name redis -v /usr/local/docker/redis/redis.conf:/etc/redis/redis.conf -v /usr/local/docker/redis/data:/data -d redis:alpine redis-server /etc/redis/redis.conf --appendonly yes
```

4. elasticsearch volume挂载启动
* [ ] 经过测试
```
docker run -d --name es -p 9200:9200 -p 9300:9300 -v /usr/local/docker/es/config:/usr/share/elasticsearch/config -v /usr/local/docker/es/data:/usr/share/elasticsearch/data -v /usr/local/docker/es/plugins:/usr/share/elasticsearch/plugins elasticsearch:6.5.0 
```

### 单层应用的Dockerfile文件怎么写？
* [ ] 经过测试
```
from microsoft/dotnet:2.2-sdk as build-env
workdir /code 

copy src/Web/Crafts.RobotEduPlat.Mvc/Crafts.RobotEduPlat.Mvc.csproj src/Web/Crafts.RobotEduPlat.Mvc/
copy src/Services/Infrastructure/Infrastructure.csproj src/Services/Infrastructure/
run dotnet restore src/Web/Crafts.RobotEduPlat.Mvc/Crafts.RobotEduPlat.Mvc.csproj

copy . /code
run dotnet publish src/Web/Crafts.RobotEduPlat.Mvc/Crafts.RobotEduPlat.Mvc.csproj -c release -o /code/out

from microsoft/dotnet:2.2-aspnetcore-runtime 
workdir /app


copy --from=build-env /code/out /app
expose 5001
entrypoint ["dotnet","Crafts.RobotEduPlat.Mvc.dll"]

```

### 多层架构应用的Dockerfile文件怎么写？
* [ ] 经过测试
```
FROM microsoft/dotnet:sdk AS build-env
workdir /code

copy src/Services/Crafts.RobotEduPlat.Api/Crafts.RobotEduPlat.Api.csproj src/Services/Crafts.RobotEduPlat.Api/
copy src/Services/Crafts.RobotEduPlat.App/Crafts.RobotEduPlat.App.csproj src/Services/Crafts.RobotEduPlat.App/
copy src/Services/Crafts.RobotEduPlat.Domain/Crafts.RobotEduPlat.Domain.csproj src/Services/Crafts.RobotEduPlat.Domain/
copy src/Services/Crafts.RobotEduPlat.Repository/Crafts.RobotEduPlat.Repository.csproj src/Services/Crafts.RobotEduPlat.Repository/
copy src/Services/Infrastructure/Infrastructure.csproj  src/Services/Infrastructure/
run dotnet restore src/Services/Crafts.RobotEduPlat.Api/Crafts.RobotEduPlat.Api.csproj

copy . /code
run dotnet publish src/Services/Crafts.RobotEduPlat.Api/Crafts.RobotEduPlat.Api.csproj -c release -o /code/out

from microsoft/dotnet:2.2-aspnetcore-runtime 
workdir  /app
copy --from=build-env /code/out /app

expose 5000 
entrypoint ["dotnet","Crafts.RobotEduPlat.Api.dll"]
```
