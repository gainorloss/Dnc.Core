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
$env:path+=';'+$psscriptroot

$workspace=split-path -Parent $psscriptroot
echo $workspace

$packPath=join-path $workspace 'src/Dnc.WPF.Ui'
cd $packPath
nuget setApiKey "oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4"
nuget spec
nuget pack Dnc.WPF.Ui.csproj -Prop Configuration=Release -IncludeReferencedProjects
nuget push Dnc.WPF.Ui.$version.nupkg  -source nuget.org