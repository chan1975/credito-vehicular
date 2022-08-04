FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WSProductos1001.API/WSProductos1001.API.csproj", "WSProductos1001.API/"]
RUN dotnet restore "WSProductos1001.API/WSProductos1001.API.csproj"
COPY . .
WORKDIR "/src/WSProductos1001.API"
RUN dotnet build "WSProductos1001.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WSProductos1001.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WSProductos1001.API.dll"]
