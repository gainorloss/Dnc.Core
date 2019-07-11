1. Centos 7.6+nginx
```
yum -y install yum-utils
yum-config-manager --enable rhui-REGION-rhel-server-extras rhui-REGION-rhel-server-optional
sudo yum install certbot python2-certbot-nginx
sudo certbot --nginx
```

*ps:报错处理(importError: No module named 'requests.packages.urllib3')*

``` shell
pip install --upgrade --force-reinstall 'requests==2.6.0' urllib3
```

然后继续执行

```
sudo certbot --nginx
```