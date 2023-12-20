#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ststa.WebApi/Ststa.WebApi.csproj", "Ststa.WebApi/"]
RUN dotnet restore "Ststa.WebApi/Ststa.WebApi.csproj"
COPY . .
WORKDIR "/src/Ststa.WebApi"
RUN dotnet build "Ststa.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ststa.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ststa.WebApi.dll"]