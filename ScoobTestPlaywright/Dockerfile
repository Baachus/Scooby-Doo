#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/playwright:latest

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ScoobTestPlaywright/ScoobTestPlaywright.csproj", "ScoobTestPlaywright/"]
COPY ["ScoobyRelationshipAPI/ScoobyRelationshipAPI.csproj", "ScoobyRelationshipAPI/"]
RUN dotnet restore "ScoobTestPlaywright/ScoobTestPlaywright.csproj"
COPY . .
WORKDIR "/src/ScoobTestPlaywright"
RUN dotnet build "ScoobTestPlaywright.csproj" -c Release -o /app/build

#Install plawyright browsers
RUN pwsh "./bin/Debug/net7.0/playwright.ps1 install"

FROM build AS ScoobTestPlaywright
WORKDIR /src/ScoobTestPlaywright
CMD ["dotnet", "test"]
