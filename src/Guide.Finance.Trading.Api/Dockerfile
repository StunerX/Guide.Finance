FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Guide.Finance.Trading.Api/Guide.Finance.Trading.Api.csproj", "src/Guide.Finance.Trading.Api/"]
RUN dotnet restore "src/Guide.Finance.Trading.Api/Guide.Finance.Trading.Api.csproj"
COPY . .
WORKDIR "/src/src/Guide.Finance.Trading.Api"
RUN dotnet build "Guide.Finance.Trading.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Guide.Finance.Trading.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Guide.Finance.Trading.Api.dll"]
