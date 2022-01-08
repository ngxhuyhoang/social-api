FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["social-api.csproj", "./"]
RUN dotnet restore "./social-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "social-api.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "social-api.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "social-api.dll"]