Dnc.Core
===

[![Dnc.Core/1.0.7.12](https://img.shields.io/badge/nuget-1.0.7.12-blue.svg)](https://www.nuget.org/packages/Dnc.Core/1.0.7.12)

[![Dnc.AspNetCore/1.0.0](https://img.shields.io/badge/nuget-1.0.0-blue.svg)](https://www.nuget.org/packages/Dnc.AspNetCore/1.0.0)

[![Dnc.AspNetCore.Ui/0.0.1.1](https://img.shields.io/badge/nuget-0.0.1.1-blue.svg)](https://www.nuget.org/packages/Dnc.AspNetCore.Ui/0.0.1.1)

[![Dnc.WPF/0.0.2.1](https://img.shields.io/badge/nuget-0.0.2.1-blue.svg)](https://www.nuget.org/packages/Dnc.WPF/0.0.2.1)

> install-package Dnc.Core


## Use this in the entry point of your application: 

```c#
var fx = Framework.Construct<DefaultFrameworkConstruction>()
                .Build();

var sp = fx.ServiceProvider;
```


