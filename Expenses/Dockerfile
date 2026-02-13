# -------- BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy csproj first for better caching
COPY Expenses/Expenses.csproj Expenses/
RUN dotnet restore Expenses/Expenses.csproj

# Copy everything else
COPY . .

# Publish the PROJECT (not the solution)
RUN dotnet publish Expenses/Expenses.csproj -c Release -o /app/publish

# -------- RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .

# Render provides $PORT; Program.cs binds to it
EXPOSE 10000

ENTRYPOINT ["dotnet", "Expenses.dll"]
