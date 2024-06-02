﻿BEGIN TRANSACTION
	CREATE TABLE BibRecords(
		id INT PRIMARY KEY,
		title VARCHAR(MAX) NOT NULL,
		author VARCHAR(MAX) NOT NULL,
		publisher VARCHAR(MAX),
		publisherLocation VARCHAR(MAX),
		publicationYear DATE,
		created DATE,
		lastUpdate DATE,
		isDeleted BIT,
		items VARCHAR(MAX),
		marcRecord VARCHAR(MAX)
	)
	CREATE TABLE ItemRecords(
		id INT PRIMARY KEY,
		barcode INT,
		dueDate DATE,
		itemType VARCHAR(MAX),
		circulationStatsIds VARCHAR(MAX),
		patronId INT,
		bibRecordId INT,
		holdId INT
	)
	CREATE TABLE Users(
		id INT PRIMARY KEY,
		userName VARCHAR(100) NOT NULL,
		passwd VARCHAR(100) NOT NULL,
		settings VARCHAR(MAX),
		patronId INT FOREIGN KEY
	)
	CREATE TABLE Patrons(
		id INT PRIMARY KEY,
		firstName VARCHAR(100) NOT NULL,
		middleName VARCHAR(100),
		lastName VARCHAR(100) NOT NULL,
		passwd VARCHAR(100),
		address1 VARCHAR(250),
		address2 VARCHAR(250),
		email VARCHAR(250),
		homePhone VARCHAR(25),
		cellPhone VARCHAR(25),
		settings VARCHAR(MAX)
	)
	CREATE TABLE Circulation(
		id INT PRIMARY KEY,
		checkoutDate DATE NOT NULL,
		itemId int NOT NULL,
		patronId int NOT NULL
	)	
	CREATE TABLE Hold(
		id INT PRIMARY KEY,
		patronsId VARCHAR(MAX) NOT NULL,
		itemId int NOT NULL
	)
	CREATE TABLE Fines(
		id INT PRIMARY KEY,
		cost DECIMAL NOT NULL,
		itemId int NOT NULL,
		patronId int NOT NULL,
		fineStatus VARCHAR(255)
	)
	CREATE TYPE dbo.PatronType AS TABLE  
	(  
		firstName varchar(100),
		middleName varchar(100),
		lastName varchar(100),
		passwd varchar(100),
		address1 varchar(250),
		address2 varchar(250),
		email varchar(250),
		homePhone varchar(25),
		cellPhone varchar(25),
		settings varchar(max)
	)
	CREATE TYPE dbo.UserType AS TABLE  
	(  
		username varchar(100)
	)
COMMIT TRANSACTION