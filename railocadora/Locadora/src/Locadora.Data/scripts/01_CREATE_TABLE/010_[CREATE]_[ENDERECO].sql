use TesteEntrevista
go



IF OBJECT_ID('dbo.Endereco', 'U') IS NOT NULL 
	DROP TABLE dbo.Endereco; 


CREATE TABLE Endereco (
    Id	int  not null identity primary key,
	Cep varchar(10) not null,
	Numero int not null,
    Complemento varchar(100),
	IdPessoa int FOREIGN KEY REFERENCES Pessoa(Id)
);
