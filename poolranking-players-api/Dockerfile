FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 3020
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "poolranking-players-api.dll"]
