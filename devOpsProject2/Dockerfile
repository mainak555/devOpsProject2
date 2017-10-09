#FROM microsoft/aspnetcore:2.0
#ENV ASPNETCORE_URLS="http://+:80"
#ARG source
#WORKDIR /app
#EXPOSE 80
#RUN dotnet publish ./devOpsProject2.sln -c Release -o ./obj/Docker/publish
#COPY ${source:-obj/Docker/publish} .
#ENTRYPOINT ["dotnet", "devOpsProject2.dll"]

FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
#COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
#COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/dotnet:2.0
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "dotnetapp.dll"]
