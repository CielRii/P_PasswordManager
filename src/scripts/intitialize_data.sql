-- Definition of the database to use
USE setup_database;

-- Insertion of test data in user table
INSERT INTO USER_ (username, masterPassword, salt, administrator) VALUES
('alice', '$2a$10$1234567890abcdef1234567890abcdef1234567890abcdef123456', 's@lta1', TRUE),
('bob',   '$2a$10$abcdef1234567890abcdef1234567890abcdef1234567890abcdef', 's@ltb2', FALSE),
('carol', '$2a$10$7890abcdef1234567890abcdef1234567890abcdef1234567890', 's@ltc3', FALSE);

-- Insertion of test data in website table
INSERT INTO WEBSITE (name, username, password) VALUES
('Google',    'alice.google', 'pwd_Goo@123'),
('Facebook',  'bob.fb',       'pwd_Fb@456'),
('Twitter',   'carol.tw',     'pwd_Tw@789'),
('LinkedIn',  'alice.li',     'pwd_Ln@321');

-- Insertion of test data in manage table
INSERT INTO manage (user_id, task_id) VALUES
(1, 1),  -- alice → Google
(2, 2),  -- bob → Facebook
(3, 3),  -- carol → Twitter
(1, 4);  -- alice → LinkedIn