-- TODO : replace 'project' with app name
SET SEARCH_PATH = 'project';

CREATE VIEW view_restaurant AS
    SELECT r.restaurant_id,
           m.menu_id,
           mi.menu_item_id,
           r.name AS restaurant_name,
           r.address,
           mi.name AS meal_name,
           mi.price,
           mi.description,
           mi.available
    FROM restaurant AS r
    LEFT JOIN menu AS m ON r.menu_id = m.menu_id
    -- TODO: Erreur ici
    LEFT JOIN menu_item AS mi ON m.menu_item_id = mi.menu_item_id;

