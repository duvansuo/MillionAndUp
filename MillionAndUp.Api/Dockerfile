#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MillionAndUp.Api/MillionAndUp.Api.csproj", "MillionAndUp.Api/"]
COPY ["MillionAndUp.Domain/MillionAndUp.Domain.csproj", "MillionAndUp.Domain/"]
COPY ["MillionAndUp.Infraestructure.Data/MillionAndUp.Infraestructure.Data.csproj", "MillionAndUp.Infraestructure.Data/"]
COPY ["MillionAndUp.Infraestructure/MillionAndUp.Infraestructure.csproj", "MillionAndUp.Infraestructure/"]
RUN dotnet restore "MillionAndUp.Api/MillionAndUp.Api.csproj"
COPY . .
WORKDIR "/src/MillionAndUp.Api"
RUN dotnet build "MillionAndUp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MillionAndUp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MillionAndUp.Api.dll"]