#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/RestAPI/Reservation.API/Reservation.API.csproj", "Services/RestAPI/Reservation.API/"]
COPY ["Services/RestAPI/Reservation.API.Infrastructure/Reservation.API.Infrastructure.csproj", "Services/RestAPI/Reservation.API.Infrastructure/"]
COPY ["Services/RestAPI/Reservation.API.Models/Reservation.API.Models.csproj", "Services/RestAPI/Reservation.API.Models/"]
COPY ["Services/RestAPI/Reservation.API.Services/Reservation.API.Services.csproj", "Services/RestAPI/Reservation.API.Services/"]
RUN dotnet restore "Services/RestAPI/Reservation.API/Reservation.API.csproj"
COPY . .
WORKDIR "/src/Services/RestAPI/Reservation.API"
RUN dotnet build "Reservation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reservation.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reservation.API.dll"]