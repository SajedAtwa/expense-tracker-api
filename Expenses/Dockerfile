# Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Run
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .

# Render sets $PORT automatically. Your Program.cs uses it.
EXPOSE 10000

ENTRYPOINT ["dotnet", "Expenses.dll"]
