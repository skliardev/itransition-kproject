FROM mcr.microsoft.com/dotnet/sdk:6.0.102 AS build
WORKDIR /src
COPY ./ ./
RUN dotnet restore
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0.2
WORKDIR /app
LABEL maintainer="sklardev@gmail.com"
COPY --from=build /app ./
CMD dotnet project.dll