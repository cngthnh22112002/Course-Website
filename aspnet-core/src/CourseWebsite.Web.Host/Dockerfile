FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/CourseWebsite.Web.Host/CourseWebsite.Web.Host.csproj", "src/CourseWebsite.Web.Host/"]
COPY ["src/CourseWebsite.Web.Core/CourseWebsite.Web.Core.csproj", "src/CourseWebsite.Web.Core/"]
COPY ["src/CourseWebsite.Application/CourseWebsite.Application.csproj", "src/CourseWebsite.Application/"]
COPY ["src/CourseWebsite.Core/CourseWebsite.Core.csproj", "src/CourseWebsite.Core/"]
COPY ["src/CourseWebsite.EntityFrameworkCore/CourseWebsite.EntityFrameworkCore.csproj", "src/CourseWebsite.EntityFrameworkCore/"]
WORKDIR "/src/src/CourseWebsite.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/CourseWebsite.Web.Host", "src/CourseWebsite.Web.Host"]
COPY ["src/CourseWebsite.Web.Core", "src/CourseWebsite.Web.Core"]
COPY ["src/CourseWebsite.Application", "src/CourseWebsite.Application"]
COPY ["src/CourseWebsite.Core", "src/CourseWebsite.Core"]
COPY ["src/CourseWebsite.EntityFrameworkCore", "src/CourseWebsite.EntityFrameworkCore"]
WORKDIR "/src/src/CourseWebsite.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "CourseWebsite.Web.Host.dll"]
