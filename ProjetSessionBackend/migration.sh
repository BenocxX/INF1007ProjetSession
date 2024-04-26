#!/bin/bash

# Change directory to ProjetSessionBackend.Core
cd ./ProjetSessionBackend.Core/ || exit

if [ -z "$1" ]; then
    echo "Please provide a name for the migration"
    exit 1
fi

# Add a new migration
dotnet ef migrations add "$1"

# Return to the original directory
cd - || exit