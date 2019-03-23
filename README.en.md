Dnc.Core
===

## First

[![Dnc.Core/1.0.7.3](https://img.shields.io/badge/nuget-1.0.7.3-blue.svg)](https://www.nuget.org/packages/Dnc.Core/1.0.7.3)

> install-package Dnc.Core


## Use this in the entry point of your application: 

```c#
var framework = Framework.Construct<DefaultFrameworkConstruction>()
                .Build();
```

## Using Extensions.

> namespace:
```c#
using Dnc.Extensions;
```

## Using Helpers.
> namespace:
```c#
using Dnc.Helpers; 
```

## Using Dispatcher (Base on Quartz.net)

1. Install-Packget Quartz
2. Define a job like below:
```c#
  class HelloJob
        : AbstractJob
    {
        public override async Task ExecuteJobAsync(IJobExecutionContext context)
        {
            await Task.Run(() => Console.WriteLine($"{DateTime.Now.ToLongTimeString()}"));
        }
    }
```

3. Framework enable dispatcher.

```c#
var framework = Framework.Construct<DefaultFrameworkConstruction>()
                .UseScheduleCenter()
                .Build();
           
            var scheduler = framework.ScheduleCenter;

            scheduler.RunScheduleAsync()
                .ConfigureAwait(false)
                .GetAwaiter();//sample schedule.

            scheduler.CreateAndRunScheduleAsync("gainorloss",
                "Dnc.WpfApp.Jobs.HelloJob",
                "* */1 * ? * *",
                "Dnc.WpfApp.exe")
                .ConfigureAwait(false)
                .GetAwaiter();
```

## Using TasksManager(Base on Parallel and Tasks).

## LinqExtensions 

```c#
var items = Enumerable.Range(0, 100);//批次任务

            items.Page(30, selected =>
            {
                System.Console.WriteLine(string.Join(",", selected));//同步处理
            });

            var log = items.Parallel(30, selected =>
              {
                  System.Console.WriteLine(string.Join(",", selected));//并行处理
              });
         System.Console.WriteLine(log);
```