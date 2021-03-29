FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 3000
ENV ASPNETCORE_URLS=http://+:3000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./my-new-app.csproj", "dealership-api-dotnet/"]
RUN dotnet restore "dealership-api-dotnet\my-new-app.csproj"
WORKDIR "/src/dealership-api-dotnet"
COPY . .
RUN dotnet build "my-new-app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "my-new-app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "my-new-app.dll"]
