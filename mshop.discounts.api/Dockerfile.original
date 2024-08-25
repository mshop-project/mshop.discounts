#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["mshop.discounts.api/mshop.discounts.api.csproj", "mshop.discounts.api/"]
COPY ["mshop.discounts.application/mshop.discounts.application.csproj", "mshop.discounts.application/"]
COPY ["mshop.discounts.domain/mshop.discounts.domain.csproj", "mshop.discounts.domain/"]
COPY ["mshop.discounts.infrastructure/mshop.discounts.infrastructure.csproj", "mshop.discounts.infrastructure/"]
RUN dotnet restore "./mshop.discounts.api/./mshop.discounts.api.csproj"
COPY . .
WORKDIR "/src/mshop.discounts.api"
RUN dotnet build "./mshop.discounts.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./mshop.discounts.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mshop.discounts.api.dll"]