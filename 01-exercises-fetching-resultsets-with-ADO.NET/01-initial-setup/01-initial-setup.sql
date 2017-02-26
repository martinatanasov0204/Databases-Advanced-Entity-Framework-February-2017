--Create Tables

CREATE TABLE Towns (
	Id int identity primary key,
	TownName nvarchar(50),
	CountryName nvarchar(50)
)

CREATE TABLE Minions (
	Id int identity primary key,
	MinionName nvarchar(50),
	Age int,
	TownId int FOREIGN KEY REFERENCES Towns(Id),
)

CREATE TABLE Villians (
	Id int identity primary key,
	VillianName nvarchar(50),
	EvilnessFactor varchar(11) CHECK(EvilnessFactor IN('Good', 'Bad', 'Evil', 'Super Evil')), 
)

CREATE TABLE VilliansMinions (
	VillianId int FOREIGN KEY REFERENCES Villians(Id),
	MinionId int FOREIGN KEY REFERENCES Minions(Id)
)

--Fill the tables

INSERT INTO Towns 
	VALUES	('Kanalak', 'Bulgaria'),
			('Sofia', 'Bulgaria'),
			('Berlin', 'Germany'),
			('Moscow', 'Russia'),
			('Longon', 'UK')

INSERT INTO Minions 
	VALUES	('Pesho', 12, 1),
			('Gosho', 15, 3),
			('Lesho', 11, 2),
			('Kesho', 16, 4),
			('Mesho', 22, 1)

INSERT INTO Villians 
	VALUES	('Momyk', 'Good'),
			('Qryk', 'Evil'),
			('Karyk', 'Super Evil'),
			('Oryk2', 'Bad'),
			('Taryk', 'Good')

INSERT INTO VilliansMinions 
	VALUES	(1, 3),
			(3, 2),
			(2, 3),
			(4, 1),
			(5, 2)