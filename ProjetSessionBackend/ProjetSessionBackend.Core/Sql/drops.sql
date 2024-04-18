-- TODO : replace 'project' with app name
SET SEARCH_PATH = 'project';

-- Drop the views
DROP VIEW IF EXISTS view_order;
DROP VIEW IF EXISTS view_client;
DROP VIEW IF EXISTS view_client_billing;
DROP VIEW IF EXISTS view_user;
DROP VIEW IF EXISTS view_restaurant;

-- Drop tables
DROP TABLE IF EXISTS restaurant;
DROP TABLE IF EXISTS menu;
DROP TABLE IF EXISTS meal;
DROP TABLE IF EXISTS "order";
DROP TABLE IF EXISTS client;
DROP TABLE IF EXISTS "user";
DROP TABLE IF EXISTS person;

-- Drop the functions, triggers and procedures
DROP FUNCTION IF EXISTS get_user_id();
DROP FUNCTION IF EXISTS encrypt(plaintext TEXT);
DROP FUNCTION IF EXISTS decrypt(cipher TEXT);
DROP FUNCTION IF EXISTS encrypt_person();
DROP FUNCTION IF EXISTS encrypt_person_firstname_update();
DROP FUNCTION IF EXISTS encrypt_person_lastname_update();
DROP FUNCTION IF EXISTS encrypt_person_email_update();
DROP FUNCTION IF EXISTS encrypt_person_phone_update();
DROP FUNCTION IF EXISTS encrypt_client();
DROP FUNCTION IF EXISTS encrypt_client_address_update();
DROP FUNCTION IF EXISTS encrypt_client_card_name_update();
DROP FUNCTION IF EXISTS encrypt_client_card_number_update();
DROP FUNCTION IF EXISTS encrypt_client_cvv_update();
DROP FUNCTION IF EXISTS encrypt_client_expiry_date_update();

-- Drop the extensions
DROP EXTENSION IF EXISTS pgcrypto;

-- Drop types
DROP TYPE IF EXISTS PAYMENT_METHOD;
DROP TYPE IF EXISTS ORDER_STATUS;
DROP TYPE IF EXISTS USER_TYPE;
