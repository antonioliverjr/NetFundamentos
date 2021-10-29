CREATE DATABASE JOGOS
GO

USE JOGOS
GO

CREATE TABLE Jogo
(
	Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	Nome VARCHAR(Max) NOT NULL,
	Produtora VARCHAR(Max) NOT NULL,
	Preco FLOAT NOT NULL
)
GO

INSERT INTO Jogo (Nome, Produtora, Preco) VALUES
('Fifa 19',	'EA', 180),
('Fifa 18',	'EA', 170),
('Grand Theft Auto V',	'Rockstar', 190),
('Fifa 20',	'EA', 190),
('Street Fighter V', 'Capcom', 80),
('Fifa 21',	'EA', 200)
GO

CREATE PROCEDURE [dbo].[ObterJogosPaginados] 
	@pagina INT = 1, 
	@quantidade INT = 5
AS	
DECLARE @paginacao INT
SET @paginacao = (@pagina - 1) * @quantidade
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Jogo]
	ORDER BY Id
	OFFSET @paginacao ROWS
	FETCH NEXT @quantidade ROWS ONLY;
END
GO

CREATE PROCEDURE [dbo].[ObterJogosPorId] 
	@Id VARCHAR(Max)
AS		
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Jogo]
	WHERE [Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[InserirJogo] 
	@Nome VARCHAR(Max),
	@Produtora VARCHAR(Max),
	@Preco FLOAT
AS	
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Jogo] (Nome, Produtora, Preco) VALUES (@Nome, @Produtora, @Preco)

END
GO

CREATE PROCEDURE [dbo].[AtualizarJogo] 
	@Id VARCHAR(Max),
	@Nome VARCHAR(Max),
	@Produtora VARCHAR(Max),
	@Preco FLOAT
AS	
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[Jogo] SET Nome = @Nome ,Produtora = @Produtora , Preco = @Preco
	WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[RemoverJogo]
	@Id VARCHAR(Max)
AS	
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[Jogo]
	WHERE Id = @Id

END
GO