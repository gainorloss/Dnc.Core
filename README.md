DNC Framework with .NETStandard 2.0
===

# Dnc简介
基于StandardLibrary的快速开发框架，提供了稳定强大、方便易用的事件处理机制和高性能高吞吐的CQRS组件。

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

# Packages

|Package Name|Package Icon|Version|
|:-------|:-------:|------:|
|Dnc.Core|[![Dnc.Core/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.Core/1.1.0.16)|1.1.0.16|
|Dnc.Dispatcher|[![Dnc.Core/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.Dispatcher/1.1.0.16)|1.1.0.16|
|Dnc.Data|[![Dnc.Core/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.Data/1.1.0.16)|1.1.0.12|
|Dnc.SeedWork|[![Dnc.Core/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.SeedWork/1.1.0.16)|1.1.0.16|
|Dnc.WPF|[![Dnc.Core/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.WPF/1.1.0.16)|1.1.0.16|
|Dnc.WPF.UI|[![Dnc.Core/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.WPF.UI/1.1.0.16)|1.1.0.16|
|Dnc.Spider|[![Dnc.Core/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.Spider/1.1.0.16)|1.1.0.16|
|Dnc.Spider.HttpRequest|[![Dnc.Spider.HttpRequest/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Spider.HttpRequest/1.1.0.16)|1.1.0.16|
|Dnc.Spider.Puppeteer|[![Dnc.Spider.Puppeteer/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.Spider.Puppeteer/1.1.0.16)|1.1.0.16|
|Dnc.Events|[![Dnc.Events/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.Events/1.1.0.16)|1.1.0.12|
|Dnc.Events.InMemory|[![Dnc.Events.InMemory/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.Events.InMemory/1.1.0.16)|1.1.0.16|
|Dnc.Events.RabbitMQ|[![Dnc.Events.RabbitMQ/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.Events.RabbitMQ/1.1.0.16)|1.1.0.16|
|Dnc.Events.MySql|[![Dnc.Events.MySql/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.Events.MySql/1.1.0.16)|1.1.0.16|
|Dnc.CQRS|[![Dnc.CQRS/1.1.0.16](https://img.shields.io/badge/nuget-1.1.0.12-blue.svg)](https://www.nuget.org/packages/Dnc.CQRS/1.1.0.16)|1.1.0.16|

# Getting Started
```c#
Fx.Construct<FrameworkConstruction>()
  .Build();
Fx.Resolve<TService>();
```

# Development Logs

* 2019-05-30 修复了一个bug,该bug曾导致FrameworkEnvironment获取失败
* 2019-05-29 调整IEventHandlerExecutionContext默认注入，使用者无须关注注入


