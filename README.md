# .NET Core 6.0 RESTful API Project Template
## Overview
This project serves as a template for developing RESTful APIs using .NET Core 6.0 with layered architecture.

## Project Structure
```bash
.
└── TemplateAPI/
    ├── Common/
    │   ├── Constants/
    │   │   ├── AuthConstants.cs
    │   │   └── Enums.cs
    │   ├── Exceptions/
    │   │   ├── BusinessException.cs
    │   │   ├── CacheException.cs
    │   │   └── HttpResponseException.cs
    │   ├── Helpers/
    │   │   └── PasswordHelper.cs
    │   └── Messages/
    │       ├── AuthMessages.resx
    │       ├── CrudMessages.resx
    │       └── StatusCodeMessages.resx
    ├── Domain.Services/
    │   ├── Dtos/
    │   │   ├── Login/
    │   │   │   ├── LoginRequestDto.cs
    │   │   │   └── LoginResponseDto.cs
    │   │   └── User/
    │   │       ├── AddUserDto.cs
    │   │       ├── UpdateUserDto.cs
    │   │       └── UserDto.cs
    │   └── Services/
    │       ├── Interfaces/
    │       │   ├── IAuthService.cs
    │       │   ├── IRolePermissionCacheService.cs
    │       │   └── IUserService.cs
    │       ├── AuthService.cs
    │       ├── RolePermissionCacheService.cs
    │       └── UserService.cs
    ├── Infraestructure.Core/
    │   ├── Database/
    │   │   ├── ApiDbContext.cs
    │   │   └── SeedDb.cs
    │   ├── Migrations
    │   ├── Repositories/
    │   │   ├── Interface/
    │   │   │   └── IRepository.cs
    │   │   └── Repository.cs
    │   └── UnitOfWork/
    │       ├── Interfaces/
    │       │   └── IUnitOfWork.cs
    │       └── UnitOfWork.cs
    ├── Infraestructure.Entity/
    │   └── Models/
    │       └── Security/
    │           ├── Permission.cs
    │           ├── Role.cs
    │           ├── RolePermission.cs
    │           └── User.cs
    ├── IoC/
    │   └── Configurators/
    │       ├── DependencyInjectionConfigurator.cs
    │       └── JwtAuthConfigurator.cs
    ├── Presentation/
    │   ├── Properties/
    │   │   └── launchSettings.json
    │   ├── Controllers/
    │   │   ├── AuthController.cs
    │   │   └── UserController.cs
    │   ├── Dtos/
    │   │   └── ResponseDto.cs
    │   ├── Filters/
    │   │   ├── CustomExceptionFilter.cs
    │   │   └── CustomPermissionFilter.cs
    │   ├── appsettings.json
    │   └── Program.cs
    └── Test
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
