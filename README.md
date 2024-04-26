# Projet Session INF1007

## Développement

Pour développer, il est nécessaire de lancer le frontend et le backend, ainsi qu'une base de données PostgreSQL.

### Frontend

Dans le dossier `/projet-session-frontend` se trouve un projet React.

```bash
cd ./projet-session-frontend
npm i
npm run dev
```

#### Router

Pour le router, on utilise [TanStack Router](https://tanstack.com/router/latest/docs/framework/react/overview)

### Backend

Dans le dossier `/ProjetSessionBackend` se trouve un ASP.Net Core Web API.

```bash
cd ./ProjetSessionBackend/ProjetSessionBackend.API
dotnet run
```

### Database

Code first database

Pour faire une nouvelle migration:
```bash
./migration.sh [NomDeLaMigration]
```

Pour revert la dernière migration (la supprimer)
```bash
./revert-migration.sh
```

Pour update la database via les précédentes migrations:
```bash
./update-db.sh
```
