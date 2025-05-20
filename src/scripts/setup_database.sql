-- Database creation
CREATE DATABASE IF NOT EXISTS setup_database;

-- Definition of the database to use
USE setup_database;

-- User table creation
CREATE TABLE IF NOT EXISTS t_user(
   user_id INT AUTO_INCREMENT,
   username VARCHAR(50) NOT NULL,
   masterPassword VARCHAR(72) NOT NULL,
   salt VARBINARY(20),
   administrator BOOLEAN NOT NULL,
   PRIMARY KEY(user_id),
   UNIQUE(username)
);

-- Website table creation
CREATE TABLE IF NOT EXISTS t_website(
   website_id INT AUTO_INCREMENT,
   name VARCHAR(50) NOT NULL,
   username VARCHAR(50) NOT NULL,
   password VARCHAR(50) NOT NULL,
   PRIMARY KEY(website_id),
   UNIQUE(password)
);

-- Manage table creation
CREATE TABLE IF NOT EXISTS manage(
   user_id INT,
   website_id INT,
   PRIMARY KEY(user_id, website_id),
   FOREIGN KEY(user_id) REFERENCES t_user(user_id),
   FOREIGN KEY(website_id) REFERENCES t_website(website_id)
);