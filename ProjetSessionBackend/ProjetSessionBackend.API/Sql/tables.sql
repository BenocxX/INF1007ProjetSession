CREATE TABLE IF NOT EXISTS person(
    person_id serial,
    firstname TEXT,
    lastname TEXT,
    email TEXT,
    phone TEXT,
    CONSTRAINT pk_person_id PRIMARY KEY (person_id)
);

CREATE TABLE IF NOT EXISTS "user"(
    user_id serial,
    person_id INT,
    username TEXT,
    password VARCHAR,
    created_at TIMESTAMP DEFAULT NOW(),
    created_by INT DEFAULT get_user_id(),
    updated_at TIMESTAMP DEFAULT NULL,
    updated_by INT DEFAULT get_user_id(),
    CONSTRAINT pk_user_id PRIMARY KEY (user_id),
    CONSTRAINT fk_user_person_id FOREIGN KEY (person_id) REFERENCES person(person_id)
);

CREATE TABLE IF NOT EXISTS client(
    client_id serial,
    person_id INT,
    user_id INT,
    address VARCHAR DEFAULT NULL,
    card_name VARCHAR DEFAULT NULL,
    card_number VARCHAR DEFAULT NULL,
    cvv VARCHAR DEFAULT NULL,
    expiry_date VARCHAR DEFAULT NULL,
    created_at TIMESTAMP DEFAULT NOW(),
    created_by INT DEFAULT get_user_id(),
    updated_at TIMESTAMP DEFAULT NULL,
    updated_by INT DEFAULT get_user_id(),
    CONSTRAINT pk_client_id PRIMARY KEY (client_id)
    CONSTRAINT fk_client_person_id FOREIGN KEY (person_id) REFERENCES person(person_id)
    CONSTRAINT fk_client_user_id FOREIGN KEY (user_id) REFERENCES "user"(user_id)
);