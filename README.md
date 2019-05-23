Dnc.Core
===

[![Dnc.Core/1.1.0.7](https://img.shields.io/badge/nuget-1.1.0.7-blue.svg)](https://www.nuget.org/packages/Dnc.Core/1.1.0.7)

## Infrastructure
> install-package Dnc.Core

## Data
> install-package Dnc.Data

## Dnc.Dispatcher
> install-package Dnc.Dispatcher

## Domain seedwork
> install-package Dnc.Seedwork

## Events
> install-package Dnc.Events

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


