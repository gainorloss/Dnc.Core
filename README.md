# Dnc.Core

## First
![Dnc.Core/1.0.7.3](https://www.nuget.org/packages/Dnc.Core/1.0.7.3)
> install-package Dnc.Core


## Use this in the entry point of your application: 

```c#
new DefaultFrameworkConstruction()
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
var framework = new DefaultFrameworkConstruction()
                   .UseScheduleCenter()
                   .Build();
            framework.ScheduleCenter.RunScheduleAsync().Wait();//sample schedule.
            framework.ScheduleCenter
                .CreateAndRunScheduleAsync("gainorloss", "Dnc.WpfApp.Jobs.HelloJob", "* 5 13 ? * *", "Dnc.WpfApp.exe")
                .Wait();
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