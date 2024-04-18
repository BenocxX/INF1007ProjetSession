-- TODO : replace 'project' with app name
SET SEARCH_PATH = 'project';

CREATE FUNCTION encrypt_person() RETURNS TRIGGER AS
$BODY$
BEGIN
    NEW.firstname = project.encrypt(NEW.firstname);
    NEW.lastname = project.encrypt(NEW.lastname);
    NEW.email = project.encrypt(NEW.email);
    NEW.phone = project.encrypt(NEW.phone);
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

CREATE FUNCTION encrypt_person_firstname_update() RETURNS TRIGGER AS
$BODY$
BEGIN
    NEW.firstname = project.encrypt(NEW.firstname);
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

CREATE FUNCTION encrypt_person_lastname_update() RETURNS TRIGGER AS
$BODY$
BEGIN
    NEW.lastname = project.encrypt(NEW.lastname);
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

CREATE FUNCTION encrypt_person_email_update() RETURNS TRIGGER AS
$BODY$
BEGIN
    NEW.email = project.encrypt(NEW.email);
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

CREATE FUNCTION encrypt_person_phone_update() RETURNS TRIGGER AS
$BODY$
BEGIN
    NEW.phone = project.encrypt(NEW.phone);
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER encrypt_person_trigger
    BEFORE INSERT ON person
    FOR EACH ROW
EXECUTE PROCEDURE encrypt_person();

CREATE TRIGGER encrypt_person_firstname_update_trigger
    BEFORE UPDATE ON person
    FOR EACH ROW
    WHEN (OLD.firstname IS DISTINCT FROM NEW.firstname)
EXECUTE PROCEDURE encrypt_person_firstname_update();

CREATE TRIGGER encrypt_person_lastname_update_trigger
    BEFORE UPDATE ON person
    FOR EACH ROW
    WHEN (OLD.lastname IS DISTINCT FROM NEW.lastname)
EXECUTE PROCEDURE encrypt_person_lastname_update();

CREATE TRIGGER encrypt_person_email_update_trigger
    BEFORE UPDATE ON person
    FOR EACH ROW
    WHEN (OLD.email IS DISTINCT FROM NEW.email)
EXECUTE PROCEDURE encrypt_person_email_update();

CREATE TRIGGER encrypt_person_phone_update_trigger
    BEFORE UPDATE ON person
    FOR EACH ROW
    WHEN (OLD.phone IS DISTINCT FROM NEW.phone)
EXECUTE PROCEDURE encrypt_person_phone_update();
