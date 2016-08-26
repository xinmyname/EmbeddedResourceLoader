if ((Test-Path .\build)) { Remove-AllChildItems -r -fo .\build }
New-Item -ItemType Directory .\build\lib\4.0
msbuild /p:Configuration=Release /m
Copy-Item -r .\src\bin\Release\* .\build\lib\4.0
Remove-Item .\build\*.vshost.*
Remove-Item .\build\*.pdb
Remove-Item .\build\*.xml
.\Tools\nuget\NuGet.exe pack .\EmbeddedResourceLoader.nuspec -BasePath .\build -OutputDirectory .\build
