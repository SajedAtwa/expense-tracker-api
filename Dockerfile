# Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Restore + publish the actual project (not the solution)
RUN dotnet restore Expenses/Expenses.csproj
RUN dotnet publish Expenses/Expenses.csproj -c Release -o /app/publish --no-restore

# Run
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .

# Render provides $PORT; your Program.cs binds to it.
ENTRYPOINT ["dotnet", "Expenses.dll"]
