# .NET Core 6.0 RESTful API Project Template
## Overview
This project serves as a template for developing RESTful APIs using .NET Core 6.0 with layered architecture.

## Project Structure
```bash
BaseApi/
├── Presentation.BaseApi/
│   ├── Controllers/
│   ├── Configurator/
│   │   ├── DependencyInjectionConfigurator.cs
│   ├── Dtos/
│   │   ├── UserDto.cs
├── Domain.Services/
│   ├── Interfaces/
│   │   ├── IUserService.cs
│   ├── Dtos/
│   │   ├── UserDto.cs
│   ├── UserService.cs
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
├── Infrastructure.Entity/
│   ├── Models/
│   │   ├── Secuirity/
│   │   │   ├── PermissionEntity.cs
│   │   │   ├── RoleEntity.cs
│   │   │   ├── RolePermissionEntity.cs
│   │   │   ├── UserEntity.cs
├── Common.BaseApi/
│   ├── Exceptions.cs
│   ├── Enums.cs
├── Tests.Domain.Services/
│   ├── GlobalUsings.cs
│   ├── UnitTest/
│   │   ├── UserServiceTest.cs
├── README.md
```
## Setup and Execution

Follow these steps to set up and run the project:

1. [Detailed instructions, e.g., installation commands, database configuration, etc.]

## Dependencies

The main dependencies of the project are:

- [List of dependencies and their purpose.]

## Testing

Run tests using:

```bash
dotnet test