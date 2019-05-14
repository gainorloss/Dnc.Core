Dnc.Core&&Dnc.AspNetCore
===

Dnc.Core:[![Dnc.Core/1.0.8.7](https://img.shields.io/badge/nuget-1.0.8.7-blue.svg)](https://www.nuget.org/packages/Dnc.Core/1.0.8.7)

Dnc.AspNetCore:[![Dnc.AspNetCore/1.0.0.14](https://img.shields.io/badge/nuget-1.0.0.14-blue.svg)](https://www.nuget.org/packages/Dnc.AspNetCore/1.0.0.14)

> install-package Dnc.Core
> install-package Dnc.AspNetCore

## Use this in the entry point of your application: 

```c#
var fx = Framework.Construct<DefaultFrameworkConstruction>()
                .Build();

var sp = fx.ServiceProvider;
```


