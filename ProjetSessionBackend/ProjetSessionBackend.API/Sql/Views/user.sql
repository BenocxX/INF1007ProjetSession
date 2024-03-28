-- TODO : replace 'project' with app name
SET SEARCH_PATH = 'project';

CREATE VIEW view_user AS
    SELECT u.user_id,
           (decrypt(p.firstname) || ' ' || decrypt(p.lastname)) as fullname,
           u.password,
           decrypt(p.email) AS email,
           decrypt(p.phone) AS phone,
           u.user_type
    FROM user AS u
    LEFT JOIN person AS p ON u.person_id = p.person_id;