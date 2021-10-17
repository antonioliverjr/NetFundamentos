CREATE DATABASE EstrelaDaMorte

USE EstrelaDaMorte

CREATE TABLE Planetas(
	IdPlaneta INT NOT NULL PRIMARY KEY,
	Nome VARCHAR(50) NOT NULL,
	Rotacao FLOAT NOT NULL,
	Orbita FLOAT NOT NULL,
	Diametro FLOAT NOT NULL,
	Clima VARCHAR(50) NOT NULL,
	Populacao INT NOT NULL,
)
GO

CREATE TABLE Naves(
	IdNave INT NOT NULL PRIMARY KEY,
	Nome VARCHAR(100) NOT NULL,
	Modelo VARCHAR(150) NOT NULL,
	Passageiros INT NOT NULL,
	Carga FLOAT NOT NULL,
	Classe VARCHAR(100) NOT NULL,
)
GO

CREATE TABLE Pilotos(
	IdPiloto INT NOT NULL PRIMARY KEY,
	Nome VARCHAR(200) NOT NULL,
	AnoNascimento VARCHAR(10) NOT NULL,
	IdPlaneta INT NOT NULL,
)
GO
ALTER TABLE Pilotos  ADD  CONSTRAINT FK_Pilotos_Planetas FOREIGN KEY(IdPlaneta) REFERENCES Planetas (IdPlaneta)
GO
ALTER TABLE Pilotos CHECK CONSTRAINT FK_Pilotos_Planetas
GO

CREATE TABLE PilotosNaves(
	IdPiloto INT NOT NULL,
	IdNave INT NOT NULL,
	FlagAutorizado BIT NOT NULL DEFAULT(1),
)
GO
ALTER TABLE PilotosNaves ADD CONSTRAINT PK_PilotosNaves PRIMARY KEY (IdPiloto, IdNave);
GO
ALTER TABLE PilotosNaves  ADD CONSTRAINT FK_PilotosNaves_Pilotos FOREIGN KEY(IdPiloto) REFERENCES Pilotos (IdPiloto)
GO
ALTER TABLE PilotosNaves  ADD CONSTRAINT FK_PilotosNaves_Naves FOREIGN KEY(IdNave) REFERENCES Naves (IdNave)
GO

CREATE TABLE HistoricoViagens(
	IdNave INT NOT NULL,
	IdPiloto INT NOT NULL,
	DtSaida DATETIME NOT NULL,
	DtChegada DATETIME NULL
)
GO
ALTER TABLE HistoricoViagens ADD CONSTRAINT PK_HistoricoViagens_PilotoNaves PRIMARY KEY(IdPiloto, IdNave)
GO
ALTER TABLE HistoricoViagens  ADD  CONSTRAINT FK_HistoricoViagens_PilotosNaves FOREIGN KEY(IdPiloto, IdNave) REFERENCES PilotosNaves (IdPiloto, IdNave)
GO
ALTER TABLE HistoricoViagens CHECK CONSTRAINT FK_HistoricoViagens_PilotosNaves
GO