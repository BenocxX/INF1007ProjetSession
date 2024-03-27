-- TODO : replace 'project' with app name
SET SEARCH_PATH = 'project';

CREATE VIEW view_restaurant AS
    SELECT r.restaurant_id,
           m.menu_id,
           ml.meal_id,
           r.name AS restaurant_name,
           r.address,
           ml.name AS meal_name,
           ml.price,
           ml.description,
           ml.available
    FROM restaurant AS r
    LEFT JOIN menu AS m ON r.menu_id = m.menu_id
    LEFT JOIN meal AS ml ON m.meal_id = ml.meal_id;

