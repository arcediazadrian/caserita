# Azure Function Project

## Overview

This project is a C# Azure Function application that provides serverless computing capabilities using Azure Functions. It includes RESTful endpoints for managing user data, utilizing Entity Framework Core for database interactions and AutoMapper for mapping between DTOs and entities.

## Features

- Serverless architecture with Azure Functions
- RESTful API endpoints for user management
- Entity Framework Core for database interactions
- AutoMapper for object-to-object mapping
- Dependency injection and logging support

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [Azure Functions Core Tools](https://docs.microsoft.com/azure/azure-functions/functions-run-local) (version 3.x or later)
- [Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli) (optional, for Azure deployment)

## Getting Started

### 1. Clone the repository

```console
git clone https://github.com/arcediazadrian/caserita.git
```

### 2. Set up the database

Ensure you have an Azure SQL Database or a local SQL Server instance. Update the local.settings.json file with your connection string.

local.settings.json:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
  },
  "ConnectionStrings": {
    "CaseritaDb": "Server=tcp:localhost,1433;Initial Catalog=caserita;User Id=sa;Password=caseritaDB!23;Persist Security Info=False;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;"
  }
}
```

### 3. Apply Migrations

To update the DB with a command you need to open a Package Manager console (Tools > NuGet Package Manager > Package Manager Console) in Visual Studio and run:

```PM console
Update-Database -Project Caserita_Data -StartupProject Caserita_Presentation
```

And if you need to add a Migration after changing some code:

```PM console
Add-Migration MakeColumnsNullable -Project Caserita_Data -StartupProject Caserita_Presentation

```

## Project Structure

azure-function-project/
│
├── Caserita_Presentation/          # Azure Function App layer
│   ├── Controllers/                # Function HTTP trigger controllers
│   ├── DTOs/                       # Data Transfer Objects
│   ├── MappingProfiles/            # AutoMapper Profiles
│   ├── Middlewares/            # Custom Middlewares
│   └── Program.cs                  # Application entry point
│
├── Caserita_Data/                  # Data access layer
│   ├── CaseritaDbContext.cs        # EF Core DbContext
│   ├── Repos/                      # Repositories to handle data
│   └── Migrations/                 # EF Core migrations
│
├── Caserita_Domain/                # Domain layer
│   ├── Entities/                   # Domain entities
│   ├── Exceptions/                 # Custom exceptions
│   └── Interfaces/                 # Repository and service interfaces
│
├── Business/                       # Business logic layer
│   └── Services/                   # Business services
│
└── local.settings.json                # Application configuration

## Usage

### Create User

POST /api/users
Content-Type: application/json

{
  "FullName": "John Doe",
  "Email": "john.doe@example.com",
  "BirthDate": "1996-10-18",
  "Age": 42,
  "SettingIds": []
}

### Get User

GET /api/users/{id}

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any bugs, improvements, or new features.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Acknowledgments

Azure Functions Documentation
Entity Framework Core Documentation
AutoMapper Documentation
