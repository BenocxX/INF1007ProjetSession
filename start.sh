#!/usr/bin/env bash

docker compose up -d
cd ./ProjetSessionBackend
./update-db.sh

cd ../

echo ""
echo "============================"
echo "La base de donnée est prête."
echo "============================"
echo ""
echo "Pour démarrer l'API:"
echo ">   cd ./ProjetSessionBackend"
echo ">   dotnet run --project ProjetSessionBackend.API"
echo ""
echo "Pour démarrer le site web:"
echo ">   cd ./projet-session-frontend"
echo ">   npm i"
echo ">   npm run dev"
