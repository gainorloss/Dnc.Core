# Dnc.Core

## First
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