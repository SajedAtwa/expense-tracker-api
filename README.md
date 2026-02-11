# ExpenseTracker API

ASP.NET Core Web API for tracking expenses and income. Uses EF Core + SQL Server and exposes CRUD endpoints documented with Swagger.

## Tech Stack
- ASP.NET Core (.NET 7)
- Entity Framework Core 7
- SQL Server (Docker)
- AutoMapper
- Swagger

## Run with Docker (recommended)
1. Copy env template:
   - `cp .env.example .env`
2. Start:
   - `docker compose up --build`
3. Open Swagger:
   - `http://localhost:8080/swagger`

## Run locally (without Docker)
- Start SQL Server (Docker or local)
- Set connection string using user-secrets:
  - `dotnet user-secrets set "ConnectionStrings:ExpenseTrackerConnection" "Server=localhost,1433;Database=ExpenseTrackerDb;User Id=sa;Password=...;TrustServerCertificate=True;"`
- Run:
  - `dotnet run`

## Endpoints
- `GET /api/expenses`
- `GET /api/expenses/{id}`
- `POST /api/expenses`
- `PUT /api/expenses/{id}`
- `PATCH /api/expenses/{id}`
- `DELETE /api/expenses/{id}`
