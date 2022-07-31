#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/OgretmenAtama.API/OgretmenAtama.API.csproj", "Presentation/OgretmenAtama.API/"]
COPY ["Infrastructure/OgretmenAtama.Persistance/OgretmenAtama.Persistance.csproj", "Infrastructure/OgretmenAtama.Persistance/"]
COPY ["Core/OgretmenAtama.Domain/OgretmenAtama.Domain.csproj", "Core/OgretmenAtama.Domain/"]
COPY ["Infrastructure/OgretmenAtama.Infrastructure/OgretmenAtama.Infrastructure.csproj", "Infrastructure/OgretmenAtama.Infrastructure/"]
RUN dotnet restore "Presentation/OgretmenAtama.API/OgretmenAtama.API.csproj"
COPY . .
WORKDIR "/src/Presentation/OgretmenAtama.API"
RUN dotnet build "OgretmenAtama.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OgretmenAtama.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "OgretmenAtama.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet OgretmenAtama.API.dll