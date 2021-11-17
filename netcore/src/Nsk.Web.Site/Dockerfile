FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Nsk.Data/Nsk.Data.csproj", "src/Nsk.Data/"]
COPY ["src/Nsk.Commands/Nsk.Commands.csproj", "src/Nsk.Commands/"]
COPY ["src/MvcCoreMate/MvcCoreMate.csproj", "src/MvcCoreMate/"]
COPY ["src/Nsk.Web.Site.Areas.My/Nsk.Web.Site.Areas.My.csproj", "src/Nsk.Web.Site.Areas.My/"]
COPY ["src/Nsk.Web.Site/Nsk.Web.Site.csproj", "src/Nsk.Web.Site/"]
COPY ["src/Nsk.Web.Services/Nsk.Web.Services.csproj", "src/Nsk.Web.Services/"]
COPY ["src/Nsk.Web.Site.Areas.Admin/Nsk.Web.Site.Areas.Admin.csproj", "src/Nsk.Web.Site.Areas.Admin/"]
RUN dotnet restore "src/Nsk.Web.Site/Nsk.Web.Site.csproj"
COPY . .
WORKDIR "/src/src/Nsk.Web.Site"
RUN dotnet build "Nsk.Web.Site.csproj" -c Release -o /app/build

FROM build AS publish
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_14.x | bash \
    && apt-get install nodejs -yq
RUN dotnet publish "Nsk.Web.Site.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nsk.Web.Site.dll"]
