-- TODO : replace 'project' with app name
SET SEARCH_PATH = 'project';

CREATE EXTENSION IF NOT EXISTS pgcrypto;

CREATE FUNCTION get_user_id() RETURNS INT
    LANGUAGE PLPGSQL AS $$
DECLARE
    user_id INT;
BEGIN
    BEGIN
        user_id := current_setting('project.user_id')::integer;
    EXCEPTION
        WHEN OTHERS THEN user_id := null;
    END;
    RETURN user_id;
END;
$$;

CREATE FUNCTION encrypt(plaintext TEXT) RETURNS TEXT
    LANGUAGE PLPGSQL AS $$
DECLARE
    encryption_key TEXT;
BEGIN
    -- Will raise error if the encryption_key isn't defined
    encryption_key := current_setting('project.encryption_key')::text;
    RETURN encode(project.pgp_sym_encrypt(plaintext, encryption_key, 'cipher-algo=aes256, s2k-mode=1'::text), 'base64');
END;
$$;

CREATE FUNCTION decrypt(cipher TEXT) RETURNS TEXT
    LANGUAGE PLPGSQL AS $$
DECLARE
    encryption_key TEXT;
BEGIN
    BEGIN

        -- IF the encryption_key isn't defined, do not raise error
        encryption_key := current_setting('project.encryption_key')::text;

        -- If decryption is invalid due to message corruption or wrong key, it will raise an error
        RETURN project.pgp_sym_decrypt(decode(cipher, 'base64')::bytea, encryption_key, 'cipher-algo=aes256, s2k-mode=1'::text)::text;

    EXCEPTION

        -- When a error arise (encryption_key not defined or failed decryption) return default encrypted notice
        WHEN OTHERS THEN RETURN '###ENCRYPTED###';
    END;
END;
$$;
