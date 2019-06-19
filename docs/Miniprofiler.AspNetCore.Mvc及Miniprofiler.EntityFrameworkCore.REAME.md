1. _ViewImports.cshtml里引入

``` csharp 
@using StackExchange.Profiling
@addTagHelper *, MiniProfiler.AspNetCore.Mvc
```

2. _Layout.cshtml 里使用TagHelper <mini-profiler/>

``` csharp
<mini-profiler/>
```

3. 访问
/profiler/results-index
/profiler/results
/profiler/results-list