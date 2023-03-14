#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LibraryLivros.API/LibraryLivros.API.csproj", "LibraryLivros.API/"]
COPY ["LibraryLivros.Application/LibraryLivros.Application.csproj", "LibraryLivros.Application/"]
COPY ["LibraryLivros.Domain/LibraryLivros.Domain.csproj", "LibraryLivros.Domain/"]
COPY ["LibraryLivros.Infra/LibraryLivros.Infra.csproj", "LibraryLivros.Infra/"]
RUN dotnet restore "LibraryLivros.API/LibraryLivros.API.csproj"
COPY . .
WORKDIR "/src/LibraryLivros.API"
RUN dotnet build "LibraryLivros.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryLivros.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryLivros.API.dll"]