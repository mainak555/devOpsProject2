FROM microsoft/dotnet:latest
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
#COPY . ./
RUN dotnet publish -c Release -o out
#FROM microsoft/aspnetcore:2.0
#WORKDIR /app
COPY --from=/app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "devOpsProject2.dll"]
