#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MagomesBank.Presentation.API/MagomesBank.Presentation.API.csproj", "MagomesBank.Presentation.API/"]
COPY ["MagomesBank.Infra.Data.Context/MagomesBank.Infra.Data.Context.csproj", "MagomesBank.Infra.Data.Context/"]
COPY ["MagomesBank.Dominio/MagomesBank.Domain.csproj", "MagomesBank.Dominio/"]
COPY ["MagomesBank.Application/MagomesBank.Application.csproj", "MagomesBank.Application/"]
RUN dotnet restore "MagomesBank.Presentation.API/MagomesBank.Presentation.API.csproj"
COPY . .
WORKDIR "/src/MagomesBank.Presentation.API"
RUN dotnet build "MagomesBank.Presentation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MagomesBank.Presentation.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagomesBank.Presentation.API.dll"]
