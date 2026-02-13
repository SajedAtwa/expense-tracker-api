## ExpenseTracker API

ASP.NET Core Web API for tracking expenses and income. Includes CRUD endpoints and Swagger UI.

### Tech Stack
- .NET 7 / ASP.NET Core Web API
- EF Core 7
- PostgreSQL (Supabase)
- AutoMapper
- Swagger

---

## Running Locally

### Prereqs
- .NET 7 SDK

### Configure database connection (local)
Set an environment variable named:

`ConnectionStrings__DefaultConnection`

Example (macOS/Linux):
```bash
export ConnectionStrings__DefaultConnection="postgresql://postgres:PASSWORD@HOST:5432/postgres?sslmode=require"
