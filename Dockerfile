# Base runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5153

# Build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WebApi.csproj", "./"]
RUN dotnet restore "WebApi.csproj"
COPY . .
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

# Publish application
FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final runtime environment
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "WebApi.dll", "--urls", "http://0.0.0.0:5153"]
