/* Drop Database if exists */
IF EXISTS ( SELECT name FROM master.dbo.sysdatabases WHERE name = N'SuperheroesDB')
BEGIN 
	ALTER DATABASE [SuperheroesDB] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [SuperheroesDB] SET ONLINE; 
	DROP DATABASE [SuperheroesDB];
END

/* Creating the database  */ 
CREATE DATABASE [SuperheroesDB];
GO

