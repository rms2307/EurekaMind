#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EurekaMind/EurekaMind.csproj", "EurekaMind/"]
RUN dotnet restore "EurekaMind/EurekaMind.csproj"
COPY . .
WORKDIR "/src/EurekaMind"
RUN dotnet build "EurekaMind.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EurekaMind.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EurekaMind.dll"]