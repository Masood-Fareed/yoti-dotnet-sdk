FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY Examples/Profile/CoreExample/CoreExample.csproj Examples/Profile/CoreExample/
COPY Yoti.Auth/Yoti.Auth.csproj Yoti.Auth/
COPY . .
WORKDIR /src/Examples/Profile/CoreExample

FROM build AS publish
RUN dotnet publish CoreExample.csproj -c Release -r linux-x64 -o /app -p:TargetFrameworks=netcoreapp2.2 -f netcoreapp2.2

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoreExample.dll"]
