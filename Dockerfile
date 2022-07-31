#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /appSource
EXPOSE 5000
EXPOSE 44325

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /appBuild
COPY ["OgretmenAtama/Presentation/OgretmenAtama.API/OgretmenAtama.API.csproj", "/Presentation/OgretmenAtama.API/"]
COPY ["OgretmenAtama/Infrastructure/OgretmenAtama.Persistance/OgretmenAtama.Persistance.csproj", "/Infrastructure/OgretmenAtama.Persistance/"]
COPY ["OgretmenAtama/Core/OgretmenAtama.Domain/OgretmenAtama.Domain.csproj", "/Core/OgretmenAtama.Domain/"]
COPY ["OgretmenAtama/Infrastructure/OgretmenAtama.Infrastructure/OgretmenAtama.Infrastructure.csproj", "/Infrastructure/OgretmenAtama.Infrastructure/"]
RUN dotnet restore "/Presentation/OgretmenAtama.API/OgretmenAtama.API.csproj"
COPY . .
WORKDIR "/appBuild/Presentation/OgretmenAtama.API"
RUN dotnet build "OgretmenAtama.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OgretmenAtama.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /appSource
COPY --from=publish /appSource .
#ENTRYPOINT ["dotnet", "OgretmenAtama.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet OgretmenAtama.API.dll