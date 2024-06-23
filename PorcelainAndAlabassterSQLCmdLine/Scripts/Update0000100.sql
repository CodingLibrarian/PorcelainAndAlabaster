BEGIN TRANSACTION
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
		holdings VARCHAR(MAX),
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
		bibID INT FOREIGN KEY REFERENCES BibRecords(id),
		holdId INT
	)
	CREATE TABLE LibraryEvents(
		id INT PRIMARY KEY,
		title VARCHAR(MAX),
		eventDescription VARCHAR(MAX),
		imageURL VARCHAR(MAX)
	)
	CREATE TABLE HoldingsRecords(
		id INT PRIMARY KEY,
		holdingLocation VARCHAR(MAX),
		callNumber VARCHAR(MAX),
		items VARCHAR(MAX),
		publicationPattern VARCHAR(MAX),
		bibRecordID INT FOREIGN KEY REFERENCES BibRecords(id),
	)
	CREATE TABLE AboutLibrary(
		id INT PRIMARY KEY,
		aboutTheLibrary VARCHAR(MAX),
		missionStatement VARCHAR(MAX),
		visionStatement VARCHAR(MAX)
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
	CREATE TABLE Users(
		id INT PRIMARY KEY,
		userName VARCHAR(100) NOT NULL,
		passwd VARCHAR(100) NOT NULL,
		settings VARCHAR(MAX),
		patronId INT FOREIGN KEY REFERENCES Patrons(id)
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
	CREATE TYPE dbo.BibRecordType AS TABLE  
	(  
		id int,
		title varchar(max),
		author varchar(max),
		publisher varchar(max),
		publisherLocation varchar(max),
		publicationYear int,
		created date,
		lastUpdate date,
		isDeleted bit,
		items varchar(max),
		marcRecord varchar(max)
	)
	CREATE TYPE dbo.ItemRecordType AS TABLE  
	(  
		id int,
		barcode varchar(max),
		dueDate varchar(max),
		itemType varchar(max),
		circulationStatsIds varchar(max),
		patronId varchar(max),
		bibrecordId int,
		holdId int
	)
	CREATE TYPE dbo.LibraryEventType AS TABLE  
	(  
		id int,
		title VARCHAR(MAX),
		eventDescription VARCHAR(MAX),
		imageURL VARCHAR(MAX)
	)
	CREATE TYPE dbo.AboutLibraryType AS TABLE  
	(  
		id int,
		aboutTheLibrary VARCHAR(MAX),
		missionStatement VARCHAR(MAX),
		visionStatement VARCHAR(MAX)
	)
COMMIT TRANSACTION