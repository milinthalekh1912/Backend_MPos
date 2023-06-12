#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TCCPOS.Backend/TCCPOS.Backend.Gateway.WebApi/TCCPOS.Backend.Gateway.WebApi.csproj", "TCCPOS.Backend/TCCPOS.Backend.Gateway.WebApi/"]
RUN dotnet restore "TCCPOS.Backend/TCCPOS.Backend.Gateway.WebApi/TCCPOS.Backend.Gateway.WebApi.csproj"
COPY . .
WORKDIR "/src/TCCPOS.Backend/TCCPOS.Backend.Gateway.WebApi"
RUN dotnet build "TCCPOS.Backend.Gateway.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCCPOS.Backend.Gateway.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCCPOS.Backend.Gateway.WebApi.dll"]