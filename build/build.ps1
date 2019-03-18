$workspace=split-path -Parent $psscriptroot
echo $workspace


$packPath=join-path $workspace 'src/Dnc.Core'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.Core.1.0.7.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json

$packPath=join-path $workspace 'src/Dnc.AspNetCore'
cd $packPath
dotnet pack -c release -o bin/release
$nugetPath=join-path $packPath 'bin/release/'
cd $nugetPath
dotnet nuget push Dnc.AspNetCore.1.0.0.nupkg -k oy2jhggtncepirf5it4qtbuyrppwfhke7mi4tswqf4mbf4 -s https://api.nuget.org/v3/index.json
