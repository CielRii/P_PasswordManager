-- Definition of the database to use
USE setup_database;

-- Insertion of test data in user table
INSERT INTO t_user (username, masterPassword, salt, administrator) VALUES
('alice', 'hashpass1', NULL, TRUE),
('bob', 'hashpass2', NULL, FALSE),
('charlie', 'hashpass3', NULL, FALSE);

-- Insertion of test data in website table
INSERT INTO t_website (name, username, password) VALUES
('Gmail', 'alice@gmail.com', 'gmailpass1'),
('Facebook', 'bob_fb', 'fbpass1'),
('Twitter', 'charlie_tw', 'twpass1'),
('LinkedIn', 'alice_ln', 'lnpass1');

-- Insertion of test data in manage table
INSERT INTO manage (user_id, website_id) VALUES
(1, 1),  -- alice → Gmail
(2, 2),  -- bob → Facebook
(3, 3),  -- charlie → Twitter
(1, 4);  -- alice → LinkedIn

DELIMITER //

CREATE PROCEDURE hash_user_passwords()
BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE uid INT;
    DECLARE uname VARCHAR(50);
    DECLARE rawPass VARCHAR(72);
    DECLARE salt BINARY(8);
    DECLARE concatBytes BLOB;
    DECLARE hashed BINARY(32);
    DECLARE final BLOB;
    DECLARE cur CURSOR FOR 
        SELECT user_id, username, masterPassword FROM t_user WHERE salt IS NULL;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

    OPEN cur;
    read_loop: LOOP
        FETCH cur INTO uid, uname, rawPass;
        IF done THEN
            LEAVE read_loop;
        END IF;

        -- Générer un sel de 8 octets aléatoires
        SET salt = UNHEX(SHA2(CONCAT(RAND(), NOW()), 256));
        SET salt = LEFT(salt, 8);

        -- Concaténer password et sel
        SET concatBytes = CONCAT(CONVERT(rawPass USING utf8mb4), salt);

        -- Hacher SHA-256
        SET hashed = UNHEX(SHA2(concatBytes, 256));

        -- Concaténer sel + hash
        SET final = CONCAT(salt, hashed);

        -- Encoder en base64
        SET @b64 = TO_BASE64(final);

        -- Mise à jour dans la table utilisateur
        UPDATE t_user 
        SET masterPassword = @b64, salt = HEX(salt) 
        WHERE user_id = uid;

    END LOOP;
    CLOSE cur;
END //

DELIMITER ;