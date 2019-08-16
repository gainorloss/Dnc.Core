# Nginx配置部署WebApp详解

## Nginx配置文件目录

``` shell
vi /etc/nginx/nginx.conf
```
*注释:http配置下server的默认配置内容 原因:nginx会加载 /etc/nginx/conf.d文件夹下所有的conf文件的配置*

## 在/etc/nginx/conf.d下新建一个配置文件.conf

``` shell
server {
    listen       80;
    server_name     admin.ehappyrobot.com;
    client_max_body_size 1G;# body 上传的最大限制尺寸
    location / {
        proxy_pass    http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }
}
```

## 重启nginx,使配置生效

``` shell
nginx -s reload;
```

## ps

1. 工作进程 nginx.conf配置

``` shell
worker_processes    8;# 服务器几核配置几
```

2. 事件处理模型 nginx.conf配置

``` shell
events{
    worker_connections  102400;
    accept_mutex    on;
    multi_accept    on;
    use epoll;
}
```

3. http 传输优化 gzip 单独文件配置 拷贝即用，更改 server_name location proxy_pass

``` shell
gzip on;
gzip_min_length 1k;
gzip_buffers    4 32k;
gzip_http_version   1.0;
gzip_comp_level 8;
gzip_types  text/plain application/x-javascript text/css application/xml;
gzip_vary   on;
server {
    listen       80;
    server_name     admin.ehappyrobot.com;
    client_max_body_size 1G;# body 上传的最大限制尺寸
    location / {
        proxy_pass    http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }
}
```

