use TesteEntrevista
go



IF OBJECT_ID('dbo.Locacao', 'U') IS NOT NULL 
	DROP TABLE dbo.Locacao; 


CREATE TABLE Locacao (
    Id	int  not null identity primary key,
	IdFilme	 int FOREIGN KEY REFERENCES Filme(Id),
	IdCliente int FOREIGN KEY REFERENCES Cliente(Id),
	DataRetirada Datetime not null,
	DataEntrega Datetime not null
);
