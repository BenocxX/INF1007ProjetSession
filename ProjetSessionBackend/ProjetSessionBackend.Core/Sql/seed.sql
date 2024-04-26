-- Insert roles
INSERT INTO "role" (name) 
VALUES ('Admin'), ('Client'), ('Employee');

-- Insert persons
-- INSERT INTO "person" (person_id, firstname, lastname, email, phone)
-- VALUES (1, 'Admin', 'Admin', 'admin@example.com', '1234567890'),
--        (2, 'Employee', 'Employee', 'employee@example.com', '0987654321');
-- 
-- -- Insert users
-- INSERT INTO "user" (person_id, role_id, password, password_salt, created_at)
-- VALUES (1, 1, 'Omega123', 'admin_salt', NOW()),
--        (2, 2, 'Omega123', 'employee_salt', NOW());
