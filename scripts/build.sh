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






