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

CREATE TABLE IF NOT EXISTS "user"
(
    user_id SERIAL,
    person_id INT UNIQUE,
    username TEXT,
    password VARCHAR,
    user_type USER_TYPE DEFAULT 'EMPLOYEE',
    created_at TIMESTAMP DEFAULT NOW(),
    created_by INT DEFAULT get_user_id(),
    updated_at TIMESTAMP DEFAULT NULL,
    updated_by INT DEFAULT get_user_id(),
    CONSTRAINT pk_user_id PRIMARY KEY (user_id),
    CONSTRAINT fk_user_person_id FOREIGN KEY (person_id) REFERENCES person(person_id)
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
    CONSTRAINT pk_client_id PRIMARY KEY (client_id)
    CONSTRAINT fk_client_person_id FOREIGN KEY (person_id) REFERENCES person(person_id)
    CONSTRAINT fk_client_user_id FOREIGN KEY (user_id) REFERENCES "user"(user_id)
);

CREATE TABLE IF NOT EXISTS "order"
(
    order_id SERIAL,
    client_id INT UNIQUE,
    status ORDER_STATUS DEFAULT 'OPEN',
    payment PAYMENT_METHOD NOT NULL,
    tps_value DECIMAL DEFAULT 5,
    tvq_value DECIMAL DEFAULT 9.975,
    subtotal DECIMAL(20, 2) DEFAULT 0.0,
    total DECIMAL(20, 2) DEFAULT 0.0,
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NULL,
    CONSTRAINT pk_order_id PRIMARY KEY (order_id),
    CONSTRAINT fk_client_id FOREIGN KEY (client_id) REFERENCES client(client_id)
);

CREATE TABLE IF NOT EXISTS meal
(
    meal_id SERIAL,
    name VARCHAR NOT NULL,
    price DECIMAL(10,2) DEFAULT 0,
    description TEXT DEFAULT NULL,
    available BOOL DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT NOW(),
    created_by INT DEFAULT get_user_id(),
    updated_at TIMESTAMP DEFAULT NULL,
    updated_by INT DEFAULT get_user_id(),
    CONSTRAINT pk_meal_id PRIMARY KEY (meal_id)
);

CREATE TABLE IF NOT EXISTS menu
(
    menu_id SERIAL,
    meal_id INT UNIQUE,
    CONSTRAINT pk_menu_id PRIMARY KEY (menu_id),
    CONSTRAINT fk_meal_id FOREIGN KEY (meal_id) REFERENCES meal(meal_id)
);

CREATE TABLE IF NOT EXISTS restaurant
(
    restaurant_id SERIAL,
    menu_id INT UNIQUE,
    address VARCHAR NOT NULL,
    CONSTRAINT pk_restaurant_id PRIMARY KEY (restaurant_id),
    CONSTRAINT fk_menu_id FOREIGN KEY (menu_id) REFERENCES menu(menu_id)
);
