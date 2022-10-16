FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR testlilapi


EXPOSE 80
EXPOSE 8080

#Copiar archivos de proyecto
COPY ["TestLil/TestLil.csproj", "TestLil/"]
COPY ["TestLil.Abstraction/TestLil.Abstraction.csproj","TestLil.Abstraction/"]
COPY ["TestLil.Aplication/TestLil.Aplication.csproj", "TestLil.Aplication/"]
COPY ["TestLil.Entities/TestLil.Entities.csproj", "TestLil.Entities/"]
COPY ["TestLil.DataAccess/TestLil.DataAccess.csproj", "TestLil.DataAccess/"]
COPY ["TestLil.Repository/TestLil.Repository.csproj", "TestLil.Repository/"]
RUN dotnet restore "TestLil/TestLil.csproj"

#Copiar todos los demas archivos del proyecto
COPY . .
WORKDIR "/testlilapi/TestLil"
RUN dotnet publish "TestLil.csproj" -c Release -o out

#Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /testlilapi
COPY --from=build /testlilapi/TestLil/out .
ENTRYPOINT ["dotnet", "TestLil.dll"]