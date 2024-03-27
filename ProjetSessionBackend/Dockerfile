FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ProjetSessionBackend.sln ./
COPY ProjetSessionBackend.API/*.csproj ./ProjetSessionBackend.API/
COPY ProjetSessionBackend.Core/*.csproj ./ProjetSessionBackend.Core/
COPY ProjetSessionBackend.Infrastructure/*.csproj ./ProjetSessionBackend.Infrastructure/
RUN dotnet restore

RUN dotnet tool install --global dotnet-ef --version 7.0
ENV PATH="${PATH}:/root/.dotnet/tools"

COPY . .
WORKDIR /src/ProjetSessionBackend.Core
RUN dotnet restore
RUN dotnet ef dbcontext scaffold "Host=database;Database=projet-session;Username=dev;Password=dev" Npgsql.EntityFrameworkCore.PostgreSQL -o Entities --context DatabaseContext --force
RUN dotnet build -c Release -o /app

WORKDIR /src/ProjetSessionBackend.Infrastructure
RUN dotnet build -c Release -o /app

WORKDIR /src/ProjetSessionBackend.API
RUN dotnet build -c Release -o /app


FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProjetSessionBackend.API.dll"]