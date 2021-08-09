USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	email varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	password_reset_code varchar(50) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE cities (
	city_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	city_name nvarchar(50) NOT NULL
)

CREATE TABLE agencies (
	agency_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	agency_name nvarchar(50) NOT NULL,
	address nvarchar(64) NOT NULL,
	address2 nvarchar(64),
	state nvarchar(30) NOT NULL,
	city_id int FOREIGN KEY REFERENCES cities(city_id),
	postal_code nvarchar(20) NOT NULL,
	agency_description nvarchar(255) NOT NULL,
)

CREATE TABLE pets (
	pet_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	pet_name nvarchar(50) NOT NULL,
	pet_type nvarchar(50) NOT NULL,
	pet_breed nvarchar(50) NOT NULL,
	pet_age int NOT NULL,
	pet_description nvarchar(255) NOT NULL, 
	pet_image_url nvarchar(255),
	agency_id int FOREIGN KEY REFERENCES agencies(agency_id)
)

CREATE TABLE traits (
trait_id int IDENTITY(1000,1) PRIMARY KEY,
trait_name nvarchar(30) NOT NULL
)

CREATE TABLE pet_traits (
pet_id int FOREIGN KEY REFERENCES pets(pet_id),
trait_id int FOREIGN KEY REFERENCES traits(trait_id)
)

--populate default data
-- user/password
INSERT INTO users (username, email, password_hash, salt, password_reset_code, user_role) VALUES ('user', 'user@user.com', 'Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'ssrpcgg4b3c','user');
--admin/password
INSERT INTO users (username, email, password_hash, salt, password_reset_code, user_role) VALUES ('admin', 'admin@admin.com','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=', 'ssrp48g4b3c', 'admin');

INSERT INTO cities (city_name) VALUES ('Columbus');
INSERT INTO agencies (agency_name, address, state, city_id, postal_code, agency_description) VALUES ('Franklin County Dog Shelter & Adoption Center', '4340 Tamarack Blvd', 'Ohio', 1, '43229', 'We provide compassionate care for impounded animals at the shelter, as well as adoption and lost dog services to the community. We also educate the public and teach dog owners to be more responsible citizens.');

INSERT INTO pets (pet_name, pet_type, pet_breed, pet_age, pet_description, pet_image_url, agency_id)
VALUES ('Bobo', 'Dog', 'GSD', 3, 'A good boy', 'https://pet-uploads.adoptapet.com/d/7/5/552365685.jpg', 1);

INSERT INTO traits (trait_name)
VALUES('X-Small'), ('Small'), ('Medium'), ('Large'), ('X-Large'), ('XX-Large'), ('High Energy'), ('Medium Energy'), ('Low Energy'), ('Affectionate'), ('Dominant'), ('Submissive'), ('Nervous'), ('Territorial'), ('Easy-Going')

GO