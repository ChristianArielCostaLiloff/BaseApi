﻿# .NET Core 6.0 RESTful API Project Template
## Overview
This project serves as a template for developing RESTful APIs using .NET Core 6.0 with layered architecture.

## Project Structure
```bash
BaseApi/
├── Presentation.BaseApi/
│   ├── Controllers/
│   │   ├── UserController.cs
│   ├── Dtos/
│   │   ├── UserDto.cs
│   ├── Filters/
│   │   ├── CustomExceptionFilter.cs
│   ├── Properties/
│   │   ├── launchSettings.json
├── IoC.BaseApi/
│   ├── Configurator/
│   │   ├── DependencyInjectionConfigurator.cs
├── Domain.Services/
│   ├── Dtos/
│   │   ├── UserDto.cs
│   ├── Services/
│   │   ├── Interfaces/
│   │   │   ├── IUserService.cs
│   │   ├── UserService.cs
├── Infrastructure.Core/
│   ├── Database/
│   │   ├── BaseApiDbContext.cs
│   │   ├── SeedDb.cs
│   ├── Migrations/
│   ├── Repositories/
│   │   ├── Interfaces/
│   │   │   ├── IRepository.cs
│   │   ├── Repository.cs
│   ├── UnitOfWork/
│   │   ├── Interfaces/
│   │   │   ├── IUnitOfWork.cs
│   │   ├── UnitOfWork.cs
├── Infrastructure.Database/
│   │   ├── Security/
│   │   │   ├── Tables/
│   │   │   │   ├── Permissions.cs
│   │   │   │   ├── RolePermissions.cs
│   │   │   │   ├── Roles.cs
│   │   │   │   ├── Users.cs
│   │   │   ├── Security.sql
├── Infrastructure.Entity/
│   ├── Models/
│   │   ├── Secuirity/
│   │   │   ├── Permission.cs
│   │   │   ├── Role.cs
│   │   │   ├── RolePermission.cs
│   │   │   ├── User.cs
├── Common.BaseApi/
│   ├── Resources/
│   │   ├── BusinessException.cs
│   │   ├── HttpResponseException.cs
│   ├── Enums.cs
│   ├── Resources/
│   │   ├── CrudMessages.resx
│   │   ├── StatusCodeMessages.resx
├── Tests.BaseApi/
│   ├── GlobalUsings.cs
│   ├── UnitTest/
│   │   ├── UserServiceTest.cs
├── README.md
```
## Setup and Execution

Follow these steps to set up and run the project:

1. [Detailed instructions, e.g., installation commands, database configuration, etc.]

## Dependencies

### Presentation.BaseApi
- [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/) v7.0.15: Provides design-time support for Entity Framework Core.
- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/) v7.0.15: Entity Framework Core SQL Server database provider.
- [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/) v6.5.0: Library to generate Swagger documents for your API.

### IoC.BaseApi
- No external dependencies.

### Domain.Services
- No external dependencies.

### Infraestructure.Core
- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/) v7.0.15: Entity Framework Core.
- [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/) v7.0.15: Design-time support for Entity Framework Core.
- [Microsoft.EntityFrameworkCore.Relational](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Relational/) v7.0.15: Shared components for relational database providers.
- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/) v7.0.15: Entity Framework Core SQL Server database provider.
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/) v7.0.15: Additional tools for Entity Framework Core.

### Infraestructure.Entity
- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/) v7.0.15: Entity Framework Core.
- [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/) v7.0.15: Design-time support for Entity Framework Core.
- [Microsoft.EntityFrameworkCore.Relational](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Relational/) v7.0.15: Shared components for relational database providers.
- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/) v7.0.15: Entity Framework Core SQL Server database provider.
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/) v7.0.15: Additional tools for Entity Framework Core.

### Common.BaseApi
- No external dependencies.

### Test.Domain.Services
- [coverlet.collector](https://www.nuget.org/packages/coverlet.collector/) v3.2.0: Code coverage collector for xUnit.
- [Microsoft.NET.Test.Sdk](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/) v17.5.0: The .NET Test SDK provides a set of assemblies that are used in conjunction with Test Explorer runners.
- [xunit](https://www.nuget.org/packages/xunit/) v2.4.2: xUnit.net is a free, open-source, community-focused unit testing tool for .NET.
- [xunit.runner.visualstudio](https://www.nuget.org/packages/xunit.runner.visualstudio/) v2.4.5: xUnit.net runner for Visual Studio and Visual Studio Code.


## Testing

Run tests using:

```bash
dotnet test