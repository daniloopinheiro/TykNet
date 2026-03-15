FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["src/OrderApi/OrderApi.csproj", "src/OrderApi/"]
RUN dotnet restore "src/OrderApi/OrderApi.csproj"
COPY src/OrderApi/ src/OrderApi/
WORKDIR "/src/src/OrderApi"
RUN dotnet build "OrderApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApi.dll"]
