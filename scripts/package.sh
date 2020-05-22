#!/bin/bash

dotnet pack ./src/Swashbuckle.AspNetCore.ExampleBuilder/Swashbuckle.AspNetCore.ExampleBuilder.csproj -c Release --include-symbols -o ./artifacts

# sign
# nuget sign ./artifacts/Swashbuckle.AspNetCore.ExampleBuilder.1.2.0.nupkg -CertificatePath ./artifacts/nugetcert.pfx

# push nuget
# dotnet nuget push ./artifacts/Swashbuckle.AspNetCore.ExampleBuilder.1.1.0.nupkg -k $1 -s https://api.nuget.org/v3/index.json

