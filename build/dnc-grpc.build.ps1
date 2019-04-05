<#
.description 
Used to release my project,generate nuget and push it to nuget.org automatically.
.example 
build.ps1 -version 1.0.7.3
#>
[cmdletbinding()]
param(
   [parameter(mandatory=$true)]
   [string]$projectName='Grpc',
   [string]$typeName='Grpc'
)
$workspace=split-path -Parent $psscriptroot
echo $workspace

$projectPath=join-path $workspace $projectName

$protoc=join-path $workspace "tools\protoc.exe"
$plugin=join-path $workspace "tools\grpc_csharp_plugin.exe"

echo $protoc
echo $plugin

$plugin -I $projectName --csharp_out=$projectName  $projectName\$typeName.proto --grpc_out=$projectName --plugin=protoc-gen-grpc=$plugin


