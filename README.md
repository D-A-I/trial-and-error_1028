# trial-and-error_1028
メモ
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="2.1.4" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="2.1.4" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.1.4" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer.Design" Version="1.1.6" />
  </ItemGroup>
  <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.3" />
  </ItemGroup>

</Project>
```
