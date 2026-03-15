FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["src/UserApi/UserApi.csproj", "src/UserApi/"]
RUN dotnet restore "src/UserApi/UserApi.csproj"
COPY src/UserApi/ src/UserApi/
WORKDIR "/src/src/UserApi"
RUN dotnet build "UserApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserApi.dll"]
