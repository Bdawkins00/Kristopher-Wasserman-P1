#Docker is like a virtual OS 

from mcr.microsoft.com/dotnet/sdk:latest as build

workdir /app

copy *.sln ./
copy LJCApi/*.csproj LJCApi/
copy LakeJacksonCyclingBL/*.csproj LakeJacksonCyclingBL/
copy LakeJacksonCyclingDL/*.csproj LakeJacksonCyclingDL/
copy LakeJacksonCyclingModel/*.csproj LakeJacksonCyclingModel/
copy LakeJacksonTest/*.csproj LakeJacksonTest/

copy . ./

run dotnet publish -c Release -o publish

from mcr.microsoft.com/dotnet/aspnet:latest as runtime

workdir /app
copy --from=build  app/publish ./

cmd ["dotnet","LJCApi.dll"]

expose 80