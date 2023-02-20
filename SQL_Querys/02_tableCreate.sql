/* Setting to use the right Database */
USE [SuperheroesDB];
GO

/* Creating the Superhero table */
CREATE TABLE Superhero (
	[Id] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Alias] NVARCHAR(30),
	[Origin] NVARCHAR(100),
	CONSTRAINT [PK_SuperheroId] PRIMARY KEY CLUSTERED ([Id])
);
GO

/* Creating the Assistant table */
CREATE TABLE Assistant (
	[Id] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_AssistantId] PRIMARY KEY CLUSTERED([Id])
);
GO

/* Creating the Power table */ 
CREATE TABLE Superpower(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(100),
	CONSTRAINT [PK_SuperpowerId] PRIMARY KEY CLUSTERED([Id])
);
GO

