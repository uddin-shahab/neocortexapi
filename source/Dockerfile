# Fetch base image from DockerHub

# Runtime environment image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime-env
WORKDIR /app


# Build environment image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src

# Copy everything
COPY . .

# Restore dependent projects
RUN dotnet restore NeoCortexApi/NeoCortexApi.csproj
RUN dotnet restore NeoCortexArrayLib/NeoCortexArrayLib.csproj
RUN dotnet restore NeoCortexEntities/NeoCortexEntities.csproj
RUN dotnet restore NeoCortexUtils/NeoCortexUtils.csproj
RUN dotnet restore GridCell/GridCell.csproj
RUN dotnet restore Samples/NeoCortexApiSample/NeoCortexApiSample.csproj

# Restore solution
RUN dotnet restore NeoCortexApi.sln

WORKDIR "/src/"

RUN dotnet build Samples/NeoCortexApiSample/NeoCortexApiSample.csproj -c Release -o /app/build
FROM build-env AS publish

RUN dotnet publish Samples/NeoCortexApiSample/NeoCortexApiSample.csproj -c Release -o /app/publish
FROM runtime-env AS final

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "NeoCortexApiSample.dll"]