FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OnlineJobs/OnlineJobs.csproj", "OnlineJobs/"]
RUN dotnet restore "OnlineJobs/OnlineJobs.csproj"
COPY . .
WORKDIR "/src/OnlineJobs"
RUN dotnet build "OnlineJobs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineJobs.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineJobs.dll"]
