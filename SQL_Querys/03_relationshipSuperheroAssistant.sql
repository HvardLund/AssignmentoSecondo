/* Setting to use the right Database */
USE [SuperheroesDB];
GO

/* ALter assistant table to reference the foregn key from the Superhero table */
ALTER TABLE Assistant ADD Superhero_Id INT;
ALTER TABLE Assistant ADD CONSTRAINT FK_Assistant_Superhero FOREIGN KEY (Superhero_Id) REFERENCES Superhero(Id); 
GO

/* Creating a junction table for specific table called UniqSuperpower*/

CREATE TABLE UniqSuperpower (
	[Id] INT IDENTITY NOT NULL,
	[Superpower_Id] INT,
	[Superhero_Id] INT,
	CONSTRAINT PK_UniqSuperpower PRIMARY KEY ([Id]),
	CONSTRAINT FK_UniqSuperpower_Superhero FOREIGN KEY (Superhero_Id) REFERENCES Superhero(Id),
	CONSTRAINT FK_UniqSuperpower_Superpower FOREIGN KEY (Superpower_Id) REFERENCES Superpower(Id)
);
GO
