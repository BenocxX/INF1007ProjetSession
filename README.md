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

Pour la base de données, vous pouvez utiliser le fichier `docker-compose.dev.yml` pour lancer une instance de PostgreSQL.

```bash
docker compose up
```

Pour scaffold la bd:
```bash
dotnet ef dbcontext scaffold "Host=localhost;Database=projet-session;
Username=dev;Password=dev" Npgsql.EntityFrameworkCore.PostgreSQL -o Entities --context DatabaseContext --force
```
