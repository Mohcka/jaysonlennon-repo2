FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN apt-get install -y curl \
  && curl -sL https://deb.nodesource.com/setup_12.x | bash - \
  && apt-get install -y nodejs \
  && curl -L https://www.npmjs.com/install.sh | sh
WORKDIR /src
COPY ["Project2/AptMgmtPortal/AptMgmtPortal.csproj", "Project2/AptMgmtPortal/"]
RUN dotnet restore "Project2/AptMgmtPortal/AptMgmtPortal.csproj"
COPY . .
WORKDIR "/src/Project2/AptMgmtPortal"
RUN dotnet build "AptMgmtPortal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AptMgmtPortal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AptMgmtPortal.dll"]
