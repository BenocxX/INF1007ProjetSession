# Projet Session INF1007

## William

Pour te faciliter la tache, nous avons prévu un petit scripts bash qui va start un container docker
pour la base de données Postgres. Le script va aussi remplir la base de données de plusieurs données
de test afin de rendre le système un peu plus intéressant.

Le script va ensuite te donner les indications nécessaires pour start le backend/frontent.

```bash
./start.sh
```

Nous avons inclus 3 comptes par défauts (rien t'empêche d'en créer d'autres via le frontend ou
en passant directement par l'API):

- Admin:

  - email: admin@outlook.com
  - password: Omega123\*

- Employee:

  - email: bob.dole@outlook.com
  - password: Omega123\*

- Customer:
  - email: john.doe@outlook.com
  - password: Omega123\*

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
cd ProjetSessionBackend/ProjetSessionBackend.Core/
dotnet ef migrations add [MigrationName]
```

Pour update la database via les précédentes migrations:

```bash
./update-db.sh
```
