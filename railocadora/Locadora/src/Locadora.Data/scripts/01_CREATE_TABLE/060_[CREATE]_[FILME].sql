use TesteEntrevista
go



IF OBJECT_ID('dbo.Filme', 'U') IS NOT NULL 
	DROP TABLE dbo.Filme; 


CREATE TABLE Filme (
    Id	int  not null identity primary key,
	Titulo varchar(150) not null,
	Ano int not null,
);


/*Carga*/

IF NOT EXISTS (SELECT TOP 1 * FROM FILME WHERE TITULO = 'Tropa de Elite')
BEGIN
INSERT INTO [dbo].[Filme]
           ([Titulo]
           ,[Ano])
     VALUES
           ('Tropa de Elite'
           ,2010)
END
GO

IF NOT EXISTS (SELECT TOP 1 * FROM FILME WHERE TITULO = 'A lagoa azul')
BEGIN
INSERT INTO [dbo].[Filme]
           ([Titulo]
           ,[Ano])
     VALUES
           ('A lagoa azul'
           ,1989)
END
GO

IF NOT EXISTS (SELECT TOP 1 * FROM FILME WHERE TITULO = 'Batman Begins')
BEGIN
INSERT INTO [dbo].[Filme]
           ([Titulo]
           ,[Ano])
     VALUES
           ('Batman Begins'
           ,2005)
END
GO


