FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
LABEL io.k8s.display-name="app name" \
      io.k8s.description="container description..." \
      io.openshift.expose-services="8080:http"
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["OpenShiftTestApp.csproj", ""]
RUN dotnet restore "./OpenShiftTestApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "OpenShiftTestApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenShiftTestApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenShiftTestApp.dll"]