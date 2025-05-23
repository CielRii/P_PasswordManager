DELIMITER $$

CREATE PROCEDURE hash_user_passwords()
BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE v_user_id INT;
    DECLARE v_password VARCHAR(255);


    DECLARE cur CURSOR FOR 
        SELECT user_id, masterPassword FROM t_user WHERE salt IS NULL;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

    OPEN cur;
      read_loop: LOOP
        FETCH cur INTO v_user_id, v_password;
        IF done THEN
          LEAVE read_loop;
        END IF;

        -- G�n�rer un salt binaire de 20 octets
        SET @salt := UNHEX(SHA2(CONCAT(RAND(), NOW()), 256)); -- SHA2 donne 32 octets, on tronque apr�s
        SET @salt := LEFT(@salt, 20);

        -- Concat�ner password et salt comme en C#
        SET @password_bytes := CONVERT(v_password USING utf8mb4);
        SET @salted := CONCAT(@password_bytes, @salt);

        -- Hacher le mot de passe sal�
        SET @hashed := UNHEX(SHA2(@salted, 256));

        -- Concat�ner salt + hash
        SET @final := TO_BASE64(CONCAT(@salt, @hashed));

        -- Mettre � jour
        UPDATE t_user
        SET masterPassword = @final, salt = @salt
        WHERE user_id = v_user_id;

    END LOOP;
    CLOSE cur;
END $$

CALL `hash_user_passwords`();