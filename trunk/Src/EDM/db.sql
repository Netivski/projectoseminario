1 - criar a bd iselsample
2 - criar o utilizador iselsample com a pwd iselsample
3 - atribuir ao utilizador iselsample permissões dbowner na base de dados iselsample
3 - criar a tabela Artista

use iselsample

GO

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Artista
	(
	ID int NOT NULL identity(1, 1),
	idArtista int NOT NULL,
	nome varchar(255) NOT NULL,
	nacionalidade varchar(3) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Artista ADD CONSTRAINT
	PK_Artista PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
