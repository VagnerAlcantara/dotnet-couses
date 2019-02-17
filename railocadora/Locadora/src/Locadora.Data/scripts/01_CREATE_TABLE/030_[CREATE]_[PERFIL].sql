use TesteEntrevista
go



IF OBJECT_ID('dbo.Perfil', 'U') IS NOT NULL 
	DROP TABLE dbo.Perfil; 


CREATE TABLE Perfil (
    Id	int  not null identity primary key,
	Nome varchar(100) not null,
	Ativo bit not null,
);
