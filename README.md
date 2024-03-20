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

### Backend

Dans le dossier `/ProjetSessionBackend` se trouve un ASP.Net Core Web API.

```bash
cd ./ProjetSessionBackend/ProjetSessionBackend.API
dotnet run
```

### Database

Pour la base de données, vous pouvez utiliser le fichier `docker-compose.dev.yml` pour lancer une instance de PostgreSQL.

```bash
docker compose -f docker-compose.dev.yml up
```

## Production

Pour visualiser le projet en format "production", il est possible de lancer le frontend et le backend, ainsi qu'une base de données PostgreSQL. Pour se faire, vous pouvez utiliser le fichier `docker-compose.yml`.

```bash
docker compose up
```

Une fois les containers créés, vous pouvez accéder au:

- [Frontend React](http://localhost:5001/)
- [ASP.Net Core Web API](http://localhost:5000/)
- PostgreSQL (port 5432)
