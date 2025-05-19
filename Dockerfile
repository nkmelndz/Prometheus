# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia solo el archivo del proyecto primero
COPY *.csproj ./
RUN dotnet restore

# Ahora copia el resto del proyecto
COPY . ./
RUN dotnet publish ClienteAPI.csproj -c Release -o /out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "ClienteAPI.dll"]
