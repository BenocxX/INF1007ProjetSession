FROM postgres:14-bullseye

# Install french language locale
RUN localedef -i fr_CA -c -f UTF-8 -A /usr/share/locale/locale.alias fr_CA.UTF-8
ENV LANG fr_CA.UTF-8

# Timezone
ENV TZ "America/Montreal"

# Init
COPY ProjetSessionBackend/ProjetSessionBackend.Infrastructure/database.sql /docker-entrypoint-initdb.d/
COPY ProjetSessionBackend/ProjetSessionBackend.Infrastructure/Sql /docker-entrypoint-initdb.d/Sql
