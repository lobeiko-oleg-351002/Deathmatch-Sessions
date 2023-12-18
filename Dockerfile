#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Api/Deathmatch-Sessions/Deathmatch-Sessions.csproj", "Api/Deathmatch-Sessions/"]
COPY ["Common/Application.Common/Application.Common.csproj", "Common/Application.Common/"]
COPY ["Common/Infrastructure.Common/Infrastructure.Common.csproj", "Common/Infrastructure.Common/"]
COPY ["Common/Domain/Domain.csproj", "Common/Domain/"]
COPY ["Locations/Application.Locations/Application.Locations.csproj", "Locations/Application.Locations/"]
COPY ["Locations/Infrastructure.Locations/Infrastructure.Locations.csproj", "Locations/Infrastructure.Locations/"]
COPY ["PlayerProfiles/Application.PlayerProfiles/Application.PlayerProfiles.csproj", "PlayerProfiles/Application.PlayerProfiles/"]
COPY ["PlayerProfiles/Infrastructure.PlayerProfiles/Infrastructure.PlayerProfiles.csproj", "PlayerProfiles/Infrastructure.PlayerProfiles/"]
COPY ["Sessions/Application.Sessions/Application.Sessions.csproj", "Sessions/Application.Sessions/"]
COPY ["Sessions/Infrastructure.Sessions/Infrastructure.Sessions.csproj", "Sessions/Infrastructure.Sessions/"]
RUN dotnet restore "Api/Deathmatch-Sessions/Deathmatch-Sessions.csproj"
COPY . .
WORKDIR "/src/Api/Deathmatch-Sessions"
RUN dotnet build "Deathmatch-Sessions.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Deathmatch-Sessions.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Deathmatch-Sessions.dll"]