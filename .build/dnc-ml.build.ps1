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

$packPath=join-path $workspace 'src/Dnc.ML'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.ML.$version.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json
