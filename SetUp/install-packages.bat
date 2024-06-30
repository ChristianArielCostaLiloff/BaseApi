@echo off
echo Installing NuGet packages for Presentation project...
cd ../Presentation
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.15
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.15
dotnet add package Newtonsoft.Json --version 13.0.3
dotnet add package Swashbuckle.AspNetCore --version 6.5.0
cd ..

echo Installing NuGet packages for Domain.Services project...
cd Domain.Services
dotnet add package Newtonsoft.Json --version 13.0.3
cd ..

echo Installing NuGet packages for Infraestructure.Core project...
cd Infraestructure.Core
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.15
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.15
dotnet add package Microsoft.EntityFrameworkCore.Relational --version 7.0.15
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.15
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.15
cd ..

echo Installing NuGet packages for Infraestructure.Entity project...
cd Infraestructure.Entity
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.15
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.15
dotnet add package Microsoft.EntityFrameworkCore.Relational --version 7.0.15
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.15
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.15
cd ..

echo Installing NuGet packages for Test project...
cd Test
dotnet add package coverlet.collector --version 3.2.0
dotnet add package Microsoft.NET.Test.Sdk --version 17.5.0
dotnet add package xunit --version 2.4.2
dotnet add package xunit.runner.visualstudio --version 2.4.5
cd ..

echo All packages installed successfully.
pause