# ExpenseTracker API

ASP.NET Core Web API for tracking expenses and income. Uses EF Core + SQL Server and exposes CRUD endpoints documented with Swagger.

## Tech Stack
- ASP.NET Core (.NET 7)
- Entity Framework Core 7
- SQLite
- AutoMapper
- Swagger

## Run Locally (SQLite)

This API now uses **SQLite** for persistence (no SQL Server / Docker required).

### Prereqs
- .NET 7 SDK

### Run
From the solution folder:

```bash
cd Expenses
dotnet restore
dotnet run


## Endpoints
- `GET /api/expenses`
- `GET /api/expenses/{id}`
- `POST /api/expenses`
- `PUT /api/expenses/{id}`
- `PATCH /api/expenses/{id}`
- `DELETE /api/expenses/{id}`
