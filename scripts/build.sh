#!/usr/bin/env bash

set -eu
set -o pipefail

# build
dotnet build ./Swashbuckle.AspNetCore.ExampleBuilder.sln

# ut

for PROJECT in $(ls -d -1 test/*)
do
  echo "start running test $PROJECT"
  dotnet test $PROJECT
done

# pack nuget
# dotnet pack ./src/Swashbuckle.AspNetCore.ExampleBuilder/Swashbuckle.AspNetCore.ExampleBuilder.csproj -c Release -o ./artifacts

# push nuget
# dotnet nuget push ./artifacts/*.nupkg -k $NUGET_APIKEY -s https://api.nuget.org/v3/index.json






