FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY ./hack4good.Web/hack4good.Web.csproj /hack4good.Web.csproj
COPY ./hack4good.Infrastructure/hack4good.Infrastructure.csproj /hack4good.Infrastructure.csproj
COPY ./hack4good.BLL/hack4good.BLL.csproj /hack4good.BLL.csproj
COPY ./hack4good.DAL/hack4good.DAL.csproj /hack4good.DAL.csproj
COPY ./hack4good.Web.Models/hack4good.Web.Models.csproj /hack4good.Web.Models.csproj

# restore only main project, it references everything that is required
RUN dotnet restore /hack4good.Web.csproj

COPY . .

RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "hack4good.Web.dll"]