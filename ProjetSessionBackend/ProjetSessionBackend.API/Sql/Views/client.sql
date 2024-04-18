-- TODO : replace 'project' with app name
SET SEARCH_PATH = 'project';

CREATE VIEW view_client AS
    SELECT c.client_id,
           (decrypt(p.firstname) || ' ' || decrypt(p.lastname)) as fullname,
           decrypt(p.email) AS email,
           decrypt(p.phone) AS phone,
           decrypt(c.address) AS address
    FROM client AS c
    LEFT JOIN person AS p ON c.person_id = p.person_id;

CREATE VIEW view_client_billing AS
    SELECT c.client_id,
           decrypt(card_name) AS card_name,
           decrypt(card_number) AS card_number,
           decrypt(expiry_date) AS expiry_date,
           decrypt(cvv) AS cvv
    FROM client AS c;
