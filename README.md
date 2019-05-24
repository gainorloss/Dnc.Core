Dnc.Core
===

[![Dnc.Core/1.1.0.10](https://img.shields.io/badge/nuget-1.1.0.10-blue.svg)](https://www.nuget.org/packages/Dnc.Core/1.1.0.10)

## Infrastructure
> install-package Dnc.Core

## Data
> install-package Dnc.Data

## Dispatcher
> install-package Dnc.Dispatcher

## Domain seedwork
> install-package Dnc.Seedwork

## Events
> install-package Dnc.Events
> install-package Dnc.Events.InMemory

## Spider
> install-package Dnc.Spider 
> install-package Dnc.Spider.HttpRequest
> install-package Dnc.Spider.Puppeteer

## AspNetCore
> install-package Dnc.AspNetCore
> install-package Dnc.AspNetCore.Ui

## Business
> install-package Dnc.Biz.Users
> install-package Dnc.Biz.Admin

## WPF
> install-package Dnc.WPF

## Use this in the entry point of your application: 

```c#
Fx.Construct<FrameworkConstruction>()
  .Build();
Fx.Resolve<TService>();
```


