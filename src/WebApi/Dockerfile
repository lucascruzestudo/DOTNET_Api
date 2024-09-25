FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY src/WebApi/WebApi.csproj ./src/WebApi/
COPY src/Application/Application.csproj ./src/Application/
COPY src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/
COPY src/Domain/Domain.csproj ./src/Domain/
RUN dotnet restore

COPY . .

WORKDIR /app/src/WebApi
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /out .

EXPOSE 5000

ENTRYPOINT ["dotnet", "WebApi.dll"]