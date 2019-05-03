Dnc.Core
===

Dnc.Core:[![Dnc.Core/1.0.8.4](https://img.shields.io/badge/nuget-1.0.8.4-blue.svg)](https://www.nuget.org/packages/Dnc.Core/1.0.8.4)

Dnc.AspNetCore:[![Dnc.AspNetCore/1.0.0.4](https://img.shields.io/badge/nuget-1.0.0.4-blue.svg)](https://www.nuget.org/packages/Dnc.AspNetCore/1.0.0.4)

Dnc.AspNetCore.Ui:[![Dnc.AspNetCore.Ui/0.0.1.1](https://img.shields.io/badge/nuget-0.0.1.1-blue.svg)](https://www.nuget.org/packages/Dnc.AspNetCore.Ui/0.0.1.1)

Dnc.WPF:[![Dnc.WPF/0.0.2.2](https://img.shields.io/badge/nuget-0.0.2.1-blue.svg)](https://www.nuget.org/packages/Dnc.WPF/0.0.2.2)

> install-package Dnc.Core


## Use this in the entry point of your application: 

```c#
var fx = Framework.Construct<DefaultFrameworkConstruction>()
                .Build();

var sp = fx.ServiceProvider;
```


