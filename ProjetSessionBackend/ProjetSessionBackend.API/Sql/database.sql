-- TODO : change project with app name
CREATE SCHEMA IF NOT EXISTS project;

SET SEARCH_PATH TO project;

\ir Sql/tables.sql;

set session "project.encryption_key" = 'yaxN62KQXT7snMnALpbEsd/eMxAlnT2gUI5WNxTfX0hbs4bkXir/Jv2sIjYlrR/MaduntmR/mVKtNDOkrOcUIw==';
