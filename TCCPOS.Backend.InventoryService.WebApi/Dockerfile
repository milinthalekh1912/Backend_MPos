#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TCCPOS.Backend/TCCPOS.Backend.InventoryService.WebApi/TCCPOS.Backend.InventoryService.WebApi.csproj", "TCCPOS.Backend/TCCPOS.Backend.InventoryService.WebApi/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.InventoryService.Application/TCCPOS.Backend.InventoryService.Application.csproj", "TCCPOS.Backend/TCCPOS.Backend.InventoryService.Application/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.InventoryService.Infrastructure/TCCPOS.Backend.InventoryService.Infrastructure.csproj", "TCCPOS.Backend/TCCPOS.Backend.InventoryService.Infrastructure/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.InventoryService/TCCPOS.Backend.InventoryService.csproj", "TCCPOS.Backend/TCCPOS.Backend.InventoryService/"]
RUN dotnet restore "TCCPOS.Backend.InventoryService.WebApi/TCCPOS.Backend.InventoryService.WebApi.csproj"
COPY . .
WORKDIR "/src/TCCPOS.Backend.InventoryService.WebApi"
RUN dotnet build "TCCPOS.Backend.InventoryService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCCPOS.Backend.InventoryService.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV TZ="Asia/Bangkok"
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCCPOS.Backend.InventoryService.WebApi.dll"]