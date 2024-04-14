#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Systems/Identity/Cake_store.Identity/Cake_store.Identity.csproj", "Systems/Identity/Cake_store.Identity/"]
COPY ["Data/NetSchool.Context/Cake_store.Context.csproj", "Data/NetSchool.Context/"]
COPY ["Services/Cake_store.Services.Settings/Cake_store.Services.Settings.csproj", "Services/Cake_store.Services.Settings/"]
COPY ["Shared/Cake_store.Common/Cake_store.Common.csproj", "Shared/Cake_store.Common/"]
COPY ["Data/Cake_store.Context.Entities/Cake_store.Context.Entities.csproj", "Data/Cake_store.Context.Entities/"]
COPY ["Systems/Api/Cake_store.Api.Settings/Cake_store.Api.Settings.csproj", "Systems/Api/Cake_store.Api.Settings/"]
RUN dotnet restore "./Systems/Identity/Cake_store.Identity/./Cake_store.Identity.csproj"
COPY . .
WORKDIR "/src/Systems/Identity/Cake_store.Identity"
RUN dotnet build "./Cake_store.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Cake_store.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cake_store.Identity.dll"]