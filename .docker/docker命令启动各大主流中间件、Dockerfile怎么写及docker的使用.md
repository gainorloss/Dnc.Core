# Docker的使用

### Command模式启动中间件实例

1. mysql volume挂载启动
* [x] [my.cnf](./configs/my.cnf)
```
docker run -d --name aspnet-mysql -p 3306:3306 -v /docker/mysql/conf/my.cnf:/etc/mysql/my.cnf -v /docker/mysql/db/mysql:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=p@ssw0rd mysql/mysql-server:5.7
```
* 进入mysql容器

```
docker exec -it aspnet-mysql bash
```
* 认证

```
mysql -uroot -p

```
* 进入系统库mysql
```
use mysql;
show variables like 'character%';
select user,host from user;
update user set host='%' where user='root' and host='localhost';
grant all privileges on *.* to 'root'@'%' identified by 'p@ssw0rd' with grant option;
flush privileges;
```

2. mongo volume挂载启动

* [ ] 第一种方式：
```
docker run -d --name mongo -v /docker/mongo/conf:/data/configdb -v /docker/mongo/db:/data/db -p 27017:27017 mongo:4 --auth
```

* [x] 第二种方式：
```
docker run -d -p 27017:27017 --name aspnet-mongo -v /docker/mongo/db:/data/db -v /docker/mongo/conf:/data/configdb  mongo
```

3. redis volume挂载启动
* [ ] 经过测试
```
docker run -d -p 6379:6379 --name redis -v /docker/redis/redis.conf:/etc/redis/redis.conf -v /docker/redis/data:/data -d redis:alpine redis-server /etc/redis/redis.conf --appendonly yes
```

4. elasticsearch volume挂载启动
* [ ] 经过测试
```
docker run -d --name es -p 9200:9200 -p 9300:9300 -v /docker/es/config:/usr/share/elasticsearch/config -v /usr/local/docker/es/data:/usr/share/elasticsearch/data -v /usr/local/docker/es/plugins:/usr/share/elasticsearch/plugins elasticsearch:6.5.0 
```

### Dockerfile编写及镜像的构建

使用的底层镜像

|底层镜像名称|标签|简介|适用程序|使用环境|
|:------|:------:|:------|:------:|------:|
|microsoft/dotnet|sdk|带命令行的dotnetcore运行环境|Console|Dev|
|microsoft/dotnet|runtime|不包含命令行dotnetcore运行环境|Console|Dev;Prod|
|microsoft/dotnet|runtime-deps|自包含的dotnetcore运行环境|Console|Dev;Prod|
|microsoft/aspnet|sdk|带命令行的dotnetcore运行环境|WebApp|Dev|
|microsoft/aspnet|runtime|不带带命令行的dotnetcore运行环境|WebApp|Dev;Prod|

### Dockerfile编写

在应用程序*.csproj的同级目录新建文件**Dockerfile**

~~一般 最后的入口使用CMD或者ENTRYPOINT~~

1. 控制台应用

* [ ] 经过验证
```
# 开发环境
FROM microsoft/dotnet
WORKDIR /app

COPY . /app
CMD ["dotnet","run"]

# 生产环境
# 思路：隔离编译目录 /code 和构建目录 /app，编译时先行逐个拷贝各层的*csproj至/code，dotnet restore,然后拷贝所有文件dotnet 
# publish -c release -o out 生成到/code/out,接着拷贝编译后的文件至/app，依赖于runtime镜像构建应用镜像

FROM microsoft/dotnet:sdk AS build-env
WORKDIR /code

COPY *.csproj /code
RUN dotnet restore

COPY . /code
RUN dotnet publish -c release -o out

FROM microsoft/dotnet:runtime
WORKDIR /app

COPY --from=build-env /code/out /app

ENTRYPOINT ["dotnet","console.dll"]

```
2. Web应用

    1. 单层应用的Dockerfile文件怎么写？
    * [ ] 经过测试

    ```
    from microsoft/dotnet:2.2-sdk as build-env
    workdir /code 

    copy Crafts.RobotEduPlat.Mvc.csproj /
    run dotnet restore /Crafts.RobotEduPlat.Mvc.csproj

    copy . /code
    run dotnet publish /Crafts.RobotEduPlat.Mvc.csproj -c release -o /code/out

    from microsoft/dotnet:2.2-aspnetcore-runtime 
    workdir /app


    copy --from=build-env /code/out /app
    expose 80
    entrypoint ["dotnet","Crafts.RobotEduPlat.Mvc.dll"]

    ```

    2. 多层架构应用的Dockerfile文件怎么写？
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
