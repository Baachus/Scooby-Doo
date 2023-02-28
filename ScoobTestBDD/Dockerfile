#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ScoobTestBDD/ScoobTestBDD.csproj", "ScoobTestBDD/"]
COPY ["ScoobTestFramework/ScoobTestFramework.csproj", "ScoobTestFramework/"]
COPY ["ScoobyRelationshipAPI/ScoobyRelationshipAPI.csproj", "ScoobyRelationshipAPI/"]
RUN dotnet restore "ScoobTestBDD/ScoobTestBDD.csproj"
COPY . .
WORKDIR "/src/ScoobTestBDD"
RUN dotnet build "ScoobTestBDD.csproj" -c Release -o /app/build

FROM build AS ScoobTestBDD
WORKDIR /src/ScoobTestBDD
RUN ["chmod", "+x", "../Scripts/WaitAndRun.sh"]
ENTRYPOINT [ "../Scripts/WaitAndRun.sh" ]
