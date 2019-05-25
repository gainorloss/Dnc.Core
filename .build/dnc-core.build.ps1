<#
.description 
Used to release my project,generate nuget and push it to nuget.org automatically.
.example 
build.ps1 -version 1.0.7.3
#>
[cmdletbinding()]
param(
   [parameter(mandatory=$true)]
   [string]$version=1.0.7.3
)
$workspace=split-path -Parent $psscriptroot
echo $workspace


$packPath=join-path $workspace 'src/Dnc.Core'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Core.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Seedwork'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Seedwork.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Events'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Events.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Events.InMemory'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Events.InMemory.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Events.RabbitMQ'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Events.RabbitMQ.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Events.MySql'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Events.MySql.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.AspNetCore'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.AspNetCore.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.AspNetCore.Ui'
cd $packPath
dotnet pack -c release 
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.AspNetCore.Ui.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Dispatcher'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Dispatcher.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Spider'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Spider.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Spider.Puppeteer'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Spider.Puppeteer.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Spider.HttpRequest'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Spider.HttpRequest.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Data'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Data.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Biz.Users'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Biz.Users.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Biz.Admin'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Biz.Admin.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.RPC'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.RPC.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Validation'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Validation.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.Sender'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Sender.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.SignalR'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.SignalR.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.PerformanceCounter'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.PerformanceCounter.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json