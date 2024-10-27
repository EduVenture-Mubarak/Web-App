FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EduVentureMubarakWebApp/EduVentureMubarakWebApp/EduVentureMubarakWebApp.csproj", "EduVentureMubarakWebApp/EduVentureMubarakWebApp/"]
COPY ["EduVentureMubarakWebApp/EduVentureMubarakWebApp.Client/EduVentureMubarakWebApp.Client.csproj", "EduVentureMubarakWebApp/EduVentureMubarakWebApp.Client/"]
RUN dotnet restore "EduVentureMubarakWebApp/EduVentureMubarakWebApp/EduVentureMubarakWebApp.csproj"
COPY . .
WORKDIR "/src/EduVentureMubarakWebApp/EduVentureMubarakWebApp"
RUN dotnet build "EduVentureMubarakWebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EduVentureMubarakWebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EduVentureMubarakWebApp.dll"]
