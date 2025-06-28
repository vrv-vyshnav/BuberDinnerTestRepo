# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy everything and restore dependencies
COPY . ./
RUN dotnet restore

# Publish the app
RUN dotnet publish "./BuberDinner.Api/BuberDinner.Api.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build-env /app/publish .

# Set the app to listen on all interfaces
ENV ASPNETCORE_URLS=http://0.0.0.0:5184

# Run the app
ENTRYPOINT ["dotnet", "BuberDinner.Api.dll"]
