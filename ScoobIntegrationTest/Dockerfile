#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ScoobIntegrationTest/ScoobIntegrationTest.csproj", "ScoobIntegrationTest/"]
COPY ["ScoobyRelationshipAPI/ScoobyRelationshipAPI.csproj", "ScoobyRelationshipAPI/"]
RUN dotnet restore "ScoobIntegrationTest/ScoobIntegrationTest.csproj"
COPY . .
WORKDIR "/src/ScoobIntegrationTest"
RUN dotnet build "ScoobIntegrationTest.csproj" -c Release -o /app/build

FROM build AS ScoobIntegrationTest
WORKDIR /src/ScoobIntegrationTest
CMD ["dotnet", "test"]
