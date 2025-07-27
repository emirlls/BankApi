FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
# Copy csproj and restore
COPY host/BankManagement.HttpApi.Host/BankManagement.HttpApi.Host.csproj ./
COPY NuGet.Config ./
RUN dotnet restore && rm NuGet.Config
# Copy everything
COPY . ./
RUN dotnet publish host/BankManagement.HttpApi.Host/BankManagement.HttpApi.Host.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "BankManagement.HttpApi.Host.dll"]