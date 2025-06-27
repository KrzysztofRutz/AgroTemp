# Zobacz https://aka.ms/customizecontainer, aby dowiedzieć się, jak dostosować kontener debugowania i jak program Visual Studio używa tego pliku Dockerfile do kompilowania obrazów w celu szybszego debugowania.

# Ten etap jest używany podczas uruchamiania z programu VS w trybie szybkim (domyślnie dla konfiguracji debugowania)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


# Ten etap służy do kompilowania projektu usługi
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AgroTemp.Api/AgroTemp.Api.csproj", "AgroTemp.Api/"]
COPY ["AgroTemp.Application/AgroTemp.Application.csproj", "AgroTemp.Application/"]
COPY ["AgroTemp.Domain/AgroTemp.Domain.csproj", "AgroTemp.Domain/"]
COPY ["AgroTemp.Infrastructure/AgroTemp.Infrastructure.csproj", "AgroTemp.Infrastructure/"]
COPY ["AgroTemp.Presentation/AgroTemp.Presentation.csproj", "AgroTemp.Presentation/"]
RUN dotnet restore "./AgroTemp.Api/AgroTemp.Api.csproj"
COPY . .
WORKDIR "/src/AgroTemp.Api"
RUN dotnet build "./AgroTemp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Ten etap służy do publikowania projektu usługi do skopiowania do etapu końcowego
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AgroTemp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Ten etap jest używany w środowisku produkcyjnym lub w przypadku uruchamiania z programu VS w trybie regularnym (domyślnie, gdy nie jest używana konfiguracja debugowania)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgroTemp.Api.dll"]