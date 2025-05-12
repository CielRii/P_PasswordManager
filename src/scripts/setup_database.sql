-- Database creation
CREATE DATABASE IF NOT EXISTS setup_database;

-- Definition of the database to use
USE setup_database;

-- User table creation
CREATE TABLE IF NOT EXISTS USER_(
   user_id INT AUTO_INCREMENT,
   username VARCHAR(50) NOT NULL,
   masterPassword VARCHAR(72) NOT NULL,
   salt VARCHAR(20) NOT NULL,
   administrator BOOLEAN NOT NULL,
   PRIMARY KEY(user_id),
   UNIQUE(username)
);

-- Website table creation
CREATE TABLE IF NOT EXISTS WEBSITE(
   task_id INT AUTO_INCREMENT,
   name VARCHAR(50) NOT NULL,
   username VARCHAR(50) NOT NULL,
   password VARCHAR(50) NOT NULL,
   PRIMARY KEY(task_id),
   UNIQUE(password)
);

-- Manage table creation
CREATE TABLE IF NOT EXISTS manage(
   user_id INT,
   task_id INT,
   PRIMARY KEY(user_id, task_id),
   FOREIGN KEY(user_id) REFERENCES USER_(user_id),
   FOREIGN KEY(task_id) REFERENCES WEBSITE(task_id)
);