-- TODO : replace 'project' with app name
SET SEARCH_PATH = 'project';

CREATE TYPE PAYMENT_METHOD AS enum ('CASH', 'DEBIT', 'CREDIT');
CREATE TYPE ORDER_STATUS AS enum ('OPEN', 'PREPARING', 'PICK-UP', 'SHIPPED', 'PAYED', 'ARCHIVED');
CREATE TYPE USER_TYPE AS enum ('EMPLOYEE', 'MANAGER', 'ADMIN', 'PRESIDENT');

CREATE TABLE IF NOT EXISTS person
(
    person_id SERIAL,
    firstname TEXT,
    lastname TEXT,
    email TEXT,
    phone TEXT,
    CONSTRAINT pk_person_id PRIMARY KEY (person_id)
);


CREATE TABLE IF NOT EXISTS "role"
(
    role_id SERIAL,
    name VARCHAR,
    CONSTRAINT pk_role_id PRIMARY KEY (role_id)
);

CREATE TABLE IF NOT EXISTS "user"
(
    user_id SERIAL,
    person_id INT UNIQUE,
    role_id INT,
    password VARCHAR,
    password_salt VARCHAR,
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NULL,
    CONSTRAINT pk_user_id PRIMARY KEY (user_id),
    CONSTRAINT fk_user_person_id FOREIGN KEY (person_id) REFERENCES person(person_id),
    CONSTRAINT fk_user_role_id FOREIGN KEY (role_id) REFERENCES role(role_id)
);

CREATE TABLE IF NOT EXISTS client
(
    client_id SERIAL,
    person_id INT UNIQUE,
    user_id INT UNIQUE,
    address VARCHAR DEFAULT NULL,
    card_name VARCHAR DEFAULT NULL,
    card_number VARCHAR DEFAULT NULL,
    cvv VARCHAR DEFAULT NULL,
    expiry_date VARCHAR DEFAULT NULL,
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NULL,
    CONSTRAINT pk_client_id PRIMARY KEY (client_id),
    CONSTRAINT fk_client_person_id FOREIGN KEY (person_id) REFERENCES person(person_id),
    CONSTRAINT fk_client_user_id FOREIGN KEY (user_id) REFERENCES "user"(user_id)
);

CREATE TABLE IF NOT EXISTS "order"
(
    order_id SERIAL,
    client_id INT UNIQUE,
    status ORDER_STATUS DEFAULT 'OPEN',
    payment PAYMENT_METHOD DEFAULT 'CASH',
    tps_value DECIMAL DEFAULT 5,
    tvq_value DECIMAL DEFAULT 9.975,
    subtotal DECIMAL(20, 2) DEFAULT 0.0,
    total DECIMAL(20, 2) DEFAULT 0.0,
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NULL,
    CONSTRAINT pk_order_id PRIMARY KEY (order_id),
    CONSTRAINT fk_client_id FOREIGN KEY (client_id) REFERENCES client(client_id)
);

CREATE TABLE IF NOT EXISTS menu_item
(
    menu_item_id SERIAL,
    name VARCHAR NOT NULL,
    price DECIMAL(10,2) DEFAULT 0,
    description TEXT DEFAULT NULL,
    available BOOL DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT NOW(),
--     created_by INT DEFAULT get_user_id(),
    updated_at TIMESTAMP DEFAULT NULL,
--     updated_by INT DEFAULT get_user_id(),
    CONSTRAINT pk_meal_id PRIMARY KEY (menu_item_id)
);

CREATE TABLE IF NOT EXISTS menu
(
    menu_id SERIAL,
    name VARCHAR NOT NULL,
    created_at TIMESTAMP DEFAULT NOW(),
--     created_by INT DEFAULT get_user_id(),
    updated_at TIMESTAMP DEFAULT NULL,
--     updated_by INT DEFAULT get_user_id(),
    CONSTRAINT pk_menu_id PRIMARY KEY (menu_id)
);

CREATE TABLE IF NOT EXISTS menu_menu_item
(
    menu_item_id INT,
    menu_id INT,
    CONSTRAINT pk_menu_menu_item PRIMARY KEY (menu_item_id, menu_id),
    CONSTRAINT fk_menu_menu_item_menu_item FOREIGN KEY (menu_item_id) REFERENCES menu_item(menu_item_id),
    CONSTRAINT fk_menu_menu_item_menu FOREIGN KEY (menu_id) REFERENCES menu(menu_id)
    );

CREATE TABLE IF NOT EXISTS restaurant
(
    restaurant_id SERIAL,
    menu_id INT UNIQUE,
    name VARCHAR NOT NULL,
    address VARCHAR NOT NULL,
    CONSTRAINT pk_restaurant_id PRIMARY KEY (restaurant_id),
    CONSTRAINT fk_menu_id FOREIGN KEY (menu_id) REFERENCES menu(menu_id)
);
