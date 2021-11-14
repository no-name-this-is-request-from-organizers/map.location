#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Map.Location.API/Map.Location.API.API/Map.Location.API.API.csproj", "Map.Location.API/Map.Location.API.API/"]
COPY ["Map.Location.API/Map.Location.API.BI/Map.Location.API.BI.csproj", "Map.Location.API/Map.Location.API.BI/"]
COPY ["Map.Location.API/Map.Location.API.Data/Map.Location.API.Data.csproj", "Map.Location.API/Map.Location.API.Data/"]
COPY ["Map.Location.API/Map.Location.API.General/Map.Location.API.General.csproj", "Map.Location.API/Map.Location.API.General/"]
RUN dotnet restore "Map.Location.API/Map.Location.API.API/Map.Location.API.API.csproj"
COPY . .
WORKDIR "/src/Map.Location.API/Map.Location.API.API"
RUN dotnet build "Map.Location.API.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Map.Location.API.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Map.Location.API.API.dll"]