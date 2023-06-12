#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TCCPOS.Backend/TCCPOS.Backend.ReportService.WebApi/TCCPOS.Backend.ReportService.WebApi.csproj", "TCCPOS.Backend/TCCPOS.Backend.ReportService.WebApi/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.ReportService.Application/TCCPOS.Backend.ReportService.Application.csproj", "TCCPOS.Backend/TCCPOS.Backend.ReportService.Application/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.ReportService.Infrastructure/TCCPOS.Backend.ReportService.Infrastructure.csproj", "TCCPOS.Backend/TCCPOS.Backend.ReportService.Infrastructure/"]
COPY ["TCCPOS.Backend/TCCPOS.Backend.ReportService/TCCPOS.Backend.ReportService.csproj", "TCCPOS.Backend/TCCPOS.Backend.ReportService/"]
RUN dotnet restore "TCCPOS.Backend/TCCPOS.Backend.ReportService.WebApi/TCCPOS.Backend.ReportService.WebApi.csproj"
COPY . .
WORKDIR "/src/TCCPOS.Backend/TCCPOS.Backend.ReportService.WebApi"
RUN dotnet build "TCCPOS.Backend.ReportService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCCPOS.Backend.ReportService.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV TZ="Asia/Bangkok"
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCCPOS.Backend.ReportService.WebApi.dll"]