#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY  *.sln .

COPY ProductService.Host/*.csproj ./ProductService.Host/
COPY ProductService.Domain/*.csproj ./ProductService.Domain/
COPY ProductService.Infrastructure/*.csproj ./ProductService.Infrastructure/

RUN dotnet restore -r alpine-x64

COPY ProductService.Host/. ./ProductService.Host/
COPY ProductService.Domain/. ./ProductService.Domain/
COPY ProductService.Infrastructure/. ./ProductService.Infrastructure/

RUN dotnet build

RUN dotnet publish -c Release -o /out -r alpine-x64

FROM mcr.microsoft.com/dotnet/runtime-deps:7.0-alpine AS publish

WORKDIR /app

COPY --from=build /out .

EXPOSE 80

ENTRYPOINT [ "./ProductService.Host" ]