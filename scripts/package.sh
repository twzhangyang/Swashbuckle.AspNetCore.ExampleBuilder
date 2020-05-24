#!/bin/bash

dotnet pack ./src/Swashbuckle.AspNetCore.SchemaBuilder/Swashbuckle.AspNetCore.SchemaBuilder.csproj -c Release --include-symbols -o ./artifacts

# sign
# nuget sign ./artifacts/Swashbuckle.AspNetCore.SchemaBuilder.1.2.0.nupkg -CertificatePath ./artifacts/nugetcert.pfx

# nuget verify -Signatures ./artifacts/Swashbuckle.AspNetCore.SchemaBuilder.1.3.0.nupkg -CertificateFingerprint "b2358a567a375ff8fddc48c893e30694f952e2f4fe238a8041f7166b43e0f9a7" -Verbosity detailed

# push nuget
# dotnet nuget push ./artifacts/Swashbuckle.AspNetCore.SchemaBuilder.1.1.0.nupkg -k $1 -s https://api.nuget.org/v3/index.json

#
#nuget setApiKey oy2b643mbnytvf7m6fzqbn6qnblyryqencupx3dnoxpk3y


# DO456@6uwHoGSdyinh$xL2u5uVInB3Eu
