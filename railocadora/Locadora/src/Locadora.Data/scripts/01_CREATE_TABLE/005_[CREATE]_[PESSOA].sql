use TesteEntrevista
go



IF OBJECT_ID('dbo.Pessoa', 'U') IS NOT NULL 
	DROP TABLE dbo.Pessoa; 


CREATE TABLE Pessoa (
    Id	int  not null identity primary key,
	Cpf varchar(15) not null,
    Nome varchar(100) not null,
    DataNascimento date  null,
	Telefone varchar(20) not null,
	Email varchar(50) not null
);

