# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY ./ ./

RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as prod

WORKDIR /app

COPY --from=build /app/out ./

EXPOSE 80

CMD ["dotnet", "Api.dll"]
