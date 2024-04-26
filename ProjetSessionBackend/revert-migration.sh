#!/bin/bash

# Change directory to ProjetSessionBackend.Core
cd ./ProjetSessionBackend.Core/ || exit

# Path to the API project
API_PROJECT="../ProjetSessionBackend.API/ProjetSessionBackend.API.csproj"

# Remove the last added migration
dotnet ef migrations remove --startup-project $API_PROJECT

# Return to the original directory
cd - || exit