
# Imagem que sera usada de base
FROM ubuntu:20.04 

# Diretório raiz, onde vai ser o "root"
WORKDIR /App

#Instala as dependências
RUN apt-get update && apt-get upgrade -y \
  && DEBIAN_FRONTEND=noninteractive apt-get install -y  wget ca-certificates

RUN dpkg --purge packages-microsoft-prod

# Installing the .NET Core SDK.
RUN apt-get install -y gpg 

RUN wget -O - https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o microsoft.asc.gpg 

RUN mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/ && \
  wget https://packages.microsoft.com/config/ubuntu/20.04/prod.list && \
  mv prod.list /etc/apt/sources.list.d/microsoft-prod.list && \
  chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg && \
  chown root:root /etc/apt/sources.list.d/microsoft-prod.list && \
  apt-get update && \
  apt-get install -y dotnet-sdk-6.0

# verify the installation
RUN dotnet --version && apt update

# copy everything
COPY . .

# restore as distinct layers
# RUN dotnet restore

# #  build and publish a release
# RUN dotnet publish -c release -o out

# WORKDIR /App/out

EXPOSE 5000

ENTRYPOINT ["dotnet", "run"]




# FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /src
# COPY ["DontPanicBabyApi.csproj", "."]
# RUN dotnet restore "./DontPanicBabyApi.csproj"
# COPY . .
# WORKDIR "/src/."
# RUN dotnet build "DontPanicBabyApi.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "DontPanicBabyApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "DontPanicBabyApi.dll"]
