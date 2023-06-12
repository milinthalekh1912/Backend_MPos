#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TCCPOS.Backend/TCCPOS.Backend.SaleService.WebApi/TCCPOS.Backend.SaleService.WebApi.csproj", "TCCPOS.Backend/TCCPOS.Backend.SaleService.WebApi/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.SaleService.Application/TCCPOS.Backend.SaleService.Application.csproj", "TCCPOS.Backend/TCCPOS.Backend.SaleService.Application/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.SaleService.Infrastructure/TCCPOS.Backend.SaleService.Infrastructure.csproj", "TCCPOS.Backend/TCCPOS.Backend.SaleService.Infrastructure/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.SaleService/TCCPOS.Backend.SaleService.csproj", "TCCPOS.Backend/TCCPOS.Backend.SaleService/"]
RUN dotnet restore "TCCPOS.Backend/TCCPOS.Backend.SaleService.WebApi/TCCPOS.Backend.SaleService.WebApi.csproj"
COPY . .
WORKDIR "/src/TCCPOS.Backend/TCCPOS.Backend.SaleService.WebApi"
RUN dotnet build "TCCPOS.Backend.SaleService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCCPOS.Backend.SaleService.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV TZ="Asia/Bangkok"
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCCPOS.Backend.SaleService.WebApi.dll"]