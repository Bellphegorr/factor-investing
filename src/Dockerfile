FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
COPY . ./

FROM base AS dev
WORKDIR /app
EXPOSE 5000
RUN dotnet restore "Apps/API/FactorInvesting.Apps.API.csproj"
ENTRYPOINT ["dotnet", "watch", "--non-interactive", "--project", "Apps/API", "run", "--urls", "http://0.0.0.0:5000"]

FROM base AS test
WORKDIR /app
ENTRYPOINT [ "dotnet", "test", "--logger:trx" ]

FROM base AS publish
WORKDIR /app
RUN dotnet publish "Apps/API/FactorInvesting.Apps.API.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/out ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "FactorInvesting.Apps.API.dll", "--urls", "http://0.0.0.0:5000"]