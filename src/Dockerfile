FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet publish -o out Apps/API/FactorInvesting.Apps.API.csproj

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "FactorInvesting.Apps.API.dll"]