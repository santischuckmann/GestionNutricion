#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GestionNutricion.Api/GestionNutricion.Api.csproj", "GestionNutricion.Api/"]
COPY ["GestionNutricion.Infrastructure/GestionNutricion.Infrastructure.csproj", "GestionNutricion.Infrastructure/"]
COPY ["GestionNutricion.Core/GestionNutricion.Core.csproj", "GestionNutricion.Core/"]
RUN dotnet restore "GestionNutricion.Api/GestionNutricion.Api.csproj"
COPY . .
WORKDIR "/src/GestionNutricion.Api"
RUN dotnet build "GestionNutricion.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GestionNutricion.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GestionNutricion.Api.dll"]