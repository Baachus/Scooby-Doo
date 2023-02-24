#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ScoobWebApp/ScoobWebApp.csproj", "ScoobWebApp/"]
RUN dotnet restore "ScoobWebApp/ScoobWebApp.csproj"
COPY . .
WORKDIR "/src/ScoobWebApp"
RUN dotnet build "ScoobWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScoobWebApp.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://*:8002
EXPOSE 8002
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScoobWebApp.dll"]