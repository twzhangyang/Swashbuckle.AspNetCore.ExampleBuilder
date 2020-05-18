FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src

COPY . . 
WORKDIR Petstore
RUN dotnet restore

RUN dotnet publish -c Release -o /app 

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "Petstore.dll"]
