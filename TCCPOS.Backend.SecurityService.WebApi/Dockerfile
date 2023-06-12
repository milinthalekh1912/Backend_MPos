#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TCCPOS.Backend/TCCPOS.Backend.SecurityService.WebApi/TCCPOS.Backend.SecurityService.WebApi.csproj", "TCCPOS.Backend/TCCPOS.Backend.SecurityService.WebApi/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.SecurityService.Application/TCCPOS.Backend.SecurityService.Application.csproj", "TCCPOS.Backend/TCCPOS.Backend.SecurityService.Application/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.SecurityService.Infrastructure/TCCPOS.Backend.SecurityService.Infrastructure.csproj", "TCCPOS.Backend/TCCPOS.Backend.SecurityService.Infrastructure/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.SecurityService/TCCPOS.Backend.SecurityService.csproj", "TCCPOS.Backend/TCCPOS.Backend.SecurityService/"]
RUN dotnet restore "TCCPOS.Backend/TCCPOS.Backend.SecurityService.WebApi/TCCPOS.Backend.SecurityService.WebApi.csproj"
COPY . .
WORKDIR "/src/TCCPOS.Backend/TCCPOS.Backend.SecurityService.WebApi"
RUN dotnet build "TCCPOS.Backend.SecurityService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCCPOS.Backend.SecurityService.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV TZ="Asia/Bangkok"
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCCPOS.Backend.SecurityService.WebApi.dll"]