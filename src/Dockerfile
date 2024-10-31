FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet publish -o out Apps/API/FactorInvesting.Apps.API.csproj

FROM build as dev
WORKDIR /src
COPY . .
EXPOSE 5000
RUN dotnet restore "Apps/API/FactorInvesting.Apps.API.csproj"
ENTRYPOINT ["dotnet", "watch", "--non-interactive", "--project", "Apps/API", "run", "--urls", "http://0.0.0.0:5000"]

# From to make unit tests
FROM build as test
WORKDIR /src
COPY . .
RUN dotnet restore "Apps/API/FactorInvesting.Apps.API.csproj"
ENTRYPOINT [ "dotnet", "test", "--logger:trx" ]

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "FactorInvesting.Apps.API.dll", "--urls", "http://0.0.0.0:5000"]