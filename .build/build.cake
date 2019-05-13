var target=Argument("target","default");

var solution="../Dnc.Core.sln";
var configuration=Argument("configuration","Release");
var verbosity=Argument("verbosity",Verbosity.Minimal);

Task("build").Does(()=>{
    if (IsRunningOnWindows())
    {
		DotNetCorePublish(solution,new DotNetCorePublishSettings{
			OutputDirectory="publish"});
    }else{
	}	
});


Task("default").IsDependentOn("build");

RunTarget(target);