#!/bin/bash

# Change directory to ProjetSessionBackend.Core
cd ./ProjetSessionBackend.Core/ || exit

# Path to the API project
API_PROJECT="../ProjetSessionBackend.API/ProjetSessionBackend.API.csproj"

# Run the EF database update command
dotnet ef database update --startup-project $API_PROJECT

# Return to the original directory
cd - || exit
