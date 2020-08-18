#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MagomesBank.Presentation.WEB/MagomesBank.Presentation.WEB.csproj", "MagomesBank.Presentation.WEB/"]
RUN dotnet restore "MagomesBank.Presentation.WEB/MagomesBank.Presentation.WEB.csproj"
COPY . .
WORKDIR "/src/MagomesBank.Presentation.WEB"
RUN dotnet build "MagomesBank.Presentation.WEB.csproj" -c Release -o /app/build

 RUN apt-get update && \
     apt-get install -y wget && \
     apt-get install -y gnupg2 && \
     wget -qO- https://deb.nodesource.com/setup_10.x | bash - && \
     apt-get install -y build-essential nodejs

FROM build AS publish
RUN dotnet publish "MagomesBank.Presentation.WEB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagomesBank.Presentation.WEB.dll"]