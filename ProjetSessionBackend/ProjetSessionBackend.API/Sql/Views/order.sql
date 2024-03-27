-- TODO : replace 'project' with app name
SET SEARCH_PATH = 'project';

CREATE VIEW view_order AS
    SELECT o.order_id,
           c.client_id,
           o.status,
           (decrypt(p.firstname) || ' ' || decrypt(p.lastname)) as fullname,
           decrypt(p.email) AS email,
           decrypt(p.phone) AS phone,
           o.payment,
           o.tps_value,
           o.tvq_value,
           o.subtotal,
           o.total,
           o.created_at,
           o.updated_at
    FROM order AS o
    LEFT JOIN client AS c ON o.client_id = c.client_id
    LEFT JOIN person AS p ON c.person_id = p.person_id;
