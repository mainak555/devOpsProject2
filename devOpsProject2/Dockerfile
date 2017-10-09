FROM microsoft/aspnetcore:2.0
ENV ASPNETCORE_URLS="http://+:80"
ARG source
WORKDIR /app
EXPOSE 80
RUN dotnet publish ./devOpsProject2.sln -c Release -o ./obj/Docker/publish
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "devOpsProject2.dll"]
