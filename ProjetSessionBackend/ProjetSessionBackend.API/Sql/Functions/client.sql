-- TODO : replace 'project' with app name
SET SEARCH_PATH = 'project';

CREATE FUNCTION encrypt_client() RETURNS TRIGGER AS
$BODY$
BEGIN
    NEW.address = project.encrypt(NEW.address);
    NEW.card_name = project.encrypt(NEW.card_name);
    NEW.card_number = project.encrypt(NEW.card_number);
    NEW.cvv = project.encrypt(NEW.cvv);
    NEW.expiry_date = project.encrypt(NEW.cvv);
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

CREATE FUNCTION encrypt_client_address_update() RETURNS TRIGGER AS
$BODY$
BEGIN
    NEW.address = project.encrypt(NEW.address);
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

CREATE FUNCTION encrypt_client_card_name_update() RETURNS TRIGGER AS
$BODY$
BEGIN
    NEW.card_name = project.encrypt(NEW.card_name);
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

CREATE FUNCTION encrypt_client_card_number_update() RETURNS TRIGGER AS
$BODY$
BEGIN
    NEW.card_number = project.encrypt(NEW.card_number);
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

CREATE FUNCTION encrypt_client_cvv_update() RETURNS TRIGGER AS
$BODY$
BEGIN
    NEW.cvv = project.encrypt(NEW.cvv);
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

CREATE FUNCTION encrypt_client_expiry_date_update() RETURNS TRIGGER AS
$BODY$
BEGIN
    NEW.expiry_date = project.encrypt(NEW.expiry_date);
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER encrypt_client_trigger
    BEFORE INSERT ON client
    FOR EACH ROW
EXECUTE PROCEDURE encrypt_client();

CREATE TRIGGER encrypt_client_address_update_trigger
    BEFORE UPDATE ON client
    FOR EACH ROW
    WHEN (OLD.address IS DISTINCT FROM NEW.address)
EXECUTE PROCEDURE encrypt_client_address_update();

CREATE TRIGGER encrypt_client_card_name_update_trigger
    BEFORE UPDATE ON client
    FOR EACH ROW
    WHEN (OLD.card_name IS DISTINCT FROM NEW.card_name)
EXECUTE PROCEDURE encrypt_client_card_name_update();

CREATE TRIGGER encrypt_client_card_number_update_trigger
    BEFORE UPDATE ON client
    FOR EACH ROW
    WHEN (OLD.card_number IS DISTINCT FROM NEW.card_number)
EXECUTE PROCEDURE encrypt_client_card_number_update();

CREATE TRIGGER encrypt_client_cvv_update_trigger
    BEFORE UPDATE ON client
    FOR EACH ROW
    WHEN (OLD.cvv IS DISTINCT FROM NEW.cvv)
EXECUTE PROCEDURE encrypt_client_cvv_update();

CREATE TRIGGER encrypt_client_expiry_date_update_trigger
    BEFORE UPDATE ON client
    FOR EACH ROW
    WHEN (OLD.expiry_date IS DISTINCT FROM NEW.expiry_date)
EXECUTE PROCEDURE encrypt_client_expiry_date_update();
