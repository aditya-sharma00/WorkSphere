# WorkHub — Backend API

ASP.NET Core 9 Web API + SQL Server (EF Core) for WorkSphere. The frontend lives in `../WorkDesk`.

## Structure

```
WorkHub/
├── Controllers/        # API controllers (api/[controller])
├── Data/
│   ├── AppDbContext.cs # EF Core DbContext
│   └── Migrations/     # EF Core migrations
├── Models/             # Entities (inherit BaseEntity)
├── Properties/launchSettings.json
├── Program.cs
├── WorkHub.csproj
└── appsettings.json    # Connection string, CORS origins
```

## Prerequisites

- .NET 9 SDK
- SQL Server (default connection: `.\SQLEXPRESS`, database `WorkHubDb`)
- EF Core CLI: `dotnet tool install -g dotnet-ef`

## Run

```bash
cd WorkHub
dotnet ef database update   # create/upgrade the database
dotnet run                  # http://localhost:5261
```

- Swagger UI: http://localhost:5261/swagger
- Health check: http://localhost:5261/api/health

## Adding an entity

1. Create the class in `Models/` (inherit `BaseEntity`).
2. Add a `DbSet<T>` to `AppDbContext`.
3. `dotnet ef migrations add <Name> -o Data/Migrations`
4. `dotnet ef database update`

To use a different SQL Server, change `ConnectionStrings:DefaultConnection` in `appsettings.json`.
