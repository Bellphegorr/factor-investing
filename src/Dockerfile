FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
COPY . ./

FROM base AS dev
WORKDIR /app
EXPOSE 5000
RUN dotnet restore "Apps/API/FactorInvesting.Apps.API.csproj"
ENTRYPOINT ["sleep", "infinity"]

FROM base AS test
WORKDIR /app
ENTRYPOINT [ "dotnet", "test", "--filter", "FullyQualifiedName~UnitTests", "--logger:trx" ]

FROM base AS migration
WORKDIR /app
RUN dotnet tool install --global dotnet-ef --version 8.0.22
ENV PATH="/root/.dotnet/tools:${PATH}"
ENTRYPOINT [ "dotnet", "ef", "database", "update", "--project", "Modules/Assets/Infrastructure"] 

FROM base AS publish
WORKDIR /app
ARG CONFIGURATION=Release
RUN dotnet publish "Apps/API/FactorInvesting.Apps.API.csproj" -c $CONFIGURATION -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/out ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "FactorInvesting.Apps.API.dll", "--urls", "http://0.0.0.0:5000"]