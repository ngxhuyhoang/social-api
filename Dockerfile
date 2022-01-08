FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet publish "social-api.csproj" -r linux-musl-x64 --self-contained true -c Release -o /app

FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS deploy
WORKDIR /app
EXPOSE 80
COPY --from=build /app .
ENTRYPOINT ["./social-api"]
