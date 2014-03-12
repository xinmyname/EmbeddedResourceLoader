if (test-path .\build) { ri -r -fo .\build }
mkdir .\build | out-null
.\tools\psake\psake.ps1 default.ps1 default 3.5
.\tools\psake\psake.ps1 default.ps1 default 4.0
.\Tools\nuget\NuGet.exe pack .\EmbeddedResourceLoader.nuspec -BasePath .\build -OutputDirectory .\build
