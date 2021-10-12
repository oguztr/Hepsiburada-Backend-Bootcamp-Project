#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["HB.Api/HB.Api.csproj", "HB.Api/"]
COPY ["HB.Application/HB.Application.csproj", "HB.Application/"]
COPY ["HB.Infrastructure/HB.Infrastructure.csproj", "HB.Infrastructure/"]
COPY ["HB.Core/HB.Domain.csproj", "HB.Core/"]
RUN dotnet restore "HB.Api/HB.Api.csproj"
COPY . .
WORKDIR "/src/HB.Api"
RUN dotnet build "HB.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HB.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HB.Api.dll"]