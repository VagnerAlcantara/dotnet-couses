use TesteEntrevista
go



IF OBJECT_ID('dbo.Cliente', 'U') IS NOT NULL 
	DROP TABLE dbo.Cliente; 


CREATE TABLE Cliente (
    Id	int  not null identity primary key,
	Matricula int not null,
	Ativo bit not null,
	IdPessoa int FOREIGN KEY REFERENCES Pessoa(Id)
);
