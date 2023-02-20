/* Creating a junction table for specific table called UniqSuperpower*/

CREATE TABLE UniqSuperpower (
	[Superpower_Id] INT,
	[Superhero_Id] INT,
	CONSTRAINT PK_UniqSuperpower PRIMARY KEY (Superpower_Id,Superhero_Id),
	CONSTRAINT FK_UniqSuperpower_Superhero FOREIGN KEY (Superhero_Id) REFERENCES Superhero(Id),
	CONSTRAINT FK_UniqSuperpower_Superpower FOREIGN KEY (Superpower_Id) REFERENCES Superpower(Id)
);
GO


