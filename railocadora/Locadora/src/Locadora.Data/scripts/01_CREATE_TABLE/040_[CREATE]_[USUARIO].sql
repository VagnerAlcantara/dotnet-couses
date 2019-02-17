use TesteEntrevista
go



IF OBJECT_ID('dbo.Usuario', 'U') IS NOT NULL 
	DROP TABLE dbo.Usuario; 


CREATE TABLE Usuario (
    Id	int  not null identity primary key,
	Senha varchar(150) not null,
	Ativo bit not null,
	IdPessoa int FOREIGN KEY REFERENCES Pessoa(Id)
);
