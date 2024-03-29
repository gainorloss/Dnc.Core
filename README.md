﻿*DNC Framework with .NETStandard 2.0*
===

# Dnc简介
基于**StandardLibrary**的快速开发框架，提供了稳定强大、方便易用的事件处理机制和高性能高吞吐的CQRS组件。
![](https://github.com/gainorloss/Dnc.Core/workflows/build/badge.svg)
# Dnc特性

* 稳定强大、方便易用的事件处理机制
* 高性能高吞吐的CQRS组件
* 稳定强大、方便易用的数据库仓储
* 按需安装加载的插件模式
* 按需安装加载的业务模块取用机制
* 为快速方便构建实践DDD提供开箱即用的基础设置
* 强大易用的任务调度插件
* 快捷的wpf开发组件包含完整的MVVM基础设施
* 开箱即用的数据采集组件

# 比较有用的文档目录
* *Vue*
  * [x] [VueCli安装及创建App](./.vue/VueCli安装及创建App.md)
  * [x] [Vuev-model原理及示例](./.vue/Vuev-model原理及示例.md)
  * [x] [VuePress搭建在綫文檔](./.vue/VuePress搭建在綫文檔.md)
* *react*
  * [x] [reactconfig-overrides.js配置](./.react/react config-overrides.js配置.md)
* *docker*
  * [x] [docker的特点和优势](./.docker/docker的特点和优势.md)
  * [x] [docker命令启动各大主流中间件、Dockerfile怎么写及docker的使用[拷贝即用]](./.docker/docker命令启动各大主流中间件、Dockerfile怎么写及docker的使用.md)
  * [x] [docker-compose.yml怎么写[拷贝即用]](./.docker/docker-compose.yml怎么写.md)
* *csharp*
  * [x] [CSharp编码规范](./.csharp/CSharp编码规范.md)
* *server*
  * [x] [Nginx配置部署WebApp详解](./.server/Nginx配置部署WebApp详解.md)
  * [x] [CertbotSSL](./.server/CertbotSSL.md)


# Packages
* [x] *Dnc.Core*
* [x] *Dnc.AspNetCore*
* [x] *Dnc.AspNetCore.Ui*
* [x] *Dnc.AspNetCore.Web*
* [x] *Dnc.AspNetCore.WebApi*

|**Package Name**|**Description**|
|:-------|:-------|
|*Dnc.Core*|核心类库|
|*Dnc.Dispatcher*|调度插件,基于Quartz.net实现|
|*Dnc.Data*|EntityFrameworkCore扩展|
|*Dnc.Redis*|redis插件，基于csredis实现|
|*Dnc.SeedWork*|DDD基础设施库|
|*Dnc.Events*|事件驱动实现接口定义|
|*Dnc.Events.InMemory*|事件驱动内存级别实现包含事件总线和事件存储（文本存储json格式）|
|*Dnc.Events.RabbitMQ*|事件驱动,事件总线rabbitmq实现|
|*Dnc.Events.MySql*|事件驱动，事件存储mysql实现|
|*Dnc.CQRS*|CQRS简单实现基于注入容器|
|*Dnc.Aspects*|AOP插件|

# Getting Started
Fx,代表框架本身兼具框架构建、初始化和解析服务的职责，并提供了一个服务注册事件用于使用者可能需要的自定义服务注册。
Fx.Build()正常服务生成;
Fx.AspectsBuild() 服务注册构建并启用AOP。
```c#
Fx.Construct<FrameworkConstruction>()
  .Build();
Fx.Resolve<TService>();
```
# Release Logs
* 2019-06-13 15:23 发布 [![Dnc.Core/1.1.1](https://img.shields.io/badge/nuget-1.1.1-blue.svg)](https://www.nuget.org/packages/Dnc.Core/1.1.1)
* 2019-06-06 13:43 发布 [![Dnc.Core/1.1.0.18](https://img.shields.io/badge/nuget-1.1.0.18-blue.svg)](https://www.nuget.org/packages/Dnc.Core/1.1.0.18)

# Development Logs

* 2019-07-12 10:53 *IOSSClient,AliyunOSSClient(未测试)*

* 2019-06-27 10:53 *Dnc.Seedwork:IUnitOfWork,DomainObject,IdentifiedDomainObject,IdentifiedValueObject;IConcurrencySafe,ConcurrencySafeEntity*

* 2019-06-19 16:37 Dnc.AspNetCore.Web添加**MiniProfiler.AspNetCore.Mvc**和**MiniProfiler.EntityFrameworkCore**支持,*Dnc.AspNetCore.WebApi*添加跨域支持，默认接受任何请求

* 2019-06-12 10:53 *IObjectSerializer BytesToObject&ObjectToBytes* 开发及测试完成

* 2019-06-10 16:44 *DateTime.UtcNow&TimeSpan&IEnumrable<T>&T .ToHumanization()* 开发及测试完成
  
* 2019-06-06 13:36 修复了一个bug，该bug曾导致*IPluginInitializer*不能正常获取实现类的集合
  
* 2019-06-06 11:08 UnitTests结构调整优化,Dnc.Redis单元测试构建及测试通过，Dnc.Core-samples.sln,准备构建功能测试界面
  
* 2019-06-05 13:56 *HystrixCommandInterceptorAttribute(Aspects)*
  
* 2019-06-05 12:04 Core Construct调整,Configuration 注入放入Construct,而不是构造函数中,使用IPluginInitializer注入Plugin服务
  
* 2019-06-04 16:38 缓存AOP *MemoryCachingInterceptor* 开发及测试完成

* 2019-05-31 13:25 release all 1.1.0.17,更新README.md

* 2019-05-30 修复了一个bug,该bug曾导致*FrameworkEnvironment*获取失败

* 2019-05-29 调整*IEventHandlerExecutionContext*,默认注入，使用者无须关注注入

# More...

* 持续更新中，开发、文档和使用手册尚未完全，敬请期待，如有兴趣请给我Star，您的支持是我继续下去的最大动力...


