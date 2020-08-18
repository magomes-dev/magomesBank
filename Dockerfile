FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MagomesBank.Presentation.UI/MagomesBank.Presentation.UI.csproj", "MagomesBank.Presentation.UI/"]
RUN dotnet restore "MagomesBank.Presentation.UI/MagomesBank.Presentation.UI.csproj"
COPY . .
WORKDIR "/src/MagomesBank.Presentation.UI"
RUN dotnet build "MagomesBank.Presentation.UI.csproj" -c Release -o /app/build

RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_10.x | bash - && \
    apt-get install -y build-essential nodejs

FROM build AS publish
RUN dotnet publish "MagomesBank.Presentation.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagomesBank.Presentation.UI.dll"]