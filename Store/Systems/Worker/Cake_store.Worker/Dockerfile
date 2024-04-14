#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Systems/Worker/Cake_store.Worker/Cake_store.Worker.csproj", "Systems/Worker/Cake_store.Worker/"]
COPY ["Data/NetSchool.Context/Cake_store.Context.csproj", "Data/NetSchool.Context/"]
COPY ["Services/Cake_store.Services.Settings/Cake_store.Services.Settings.csproj", "Services/Cake_store.Services.Settings/"]
COPY ["Shared/Cake_store.Common/Cake_store.Common.csproj", "Shared/Cake_store.Common/"]
COPY ["Data/Cake_store.Context.Entities/Cake_store.Context.Entities.csproj", "Data/Cake_store.Context.Entities/"]
COPY ["Services/Cake_store.Services.Actions/Cake_store.Services.Actions.csproj", "Services/Cake_store.Services.Actions/"]
COPY ["Services/Cake_store.Services.RabbitMq/Cake_store.Services.RabbitMq.csproj", "Services/Cake_store.Services.RabbitMq/"]
COPY ["Services/Cake_store.Services.Logger/Cake_store.Services.Logger.csproj", "Services/Cake_store.Services.Logger/"]
RUN dotnet restore "./Systems/Worker/Cake_store.Worker/./Cake_store.Worker.csproj"
COPY . .
WORKDIR "/src/Systems/Worker/Cake_store.Worker"
RUN dotnet build "./Cake_store.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Cake_store.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cake_store.Worker.dll"]