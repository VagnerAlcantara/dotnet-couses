use TesteEntrevista
go



IF OBJECT_ID('dbo.Permissao', 'U') IS NOT NULL 
	DROP TABLE dbo.Permissao; 


CREATE TABLE Permissao (
    Id	int  not null identity primary key,
	IdUsuario int FOREIGN KEY REFERENCES Usuario(Id),
	IdPerfil int FOREIGN KEY REFERENCES Perfil(Id)
	
);
