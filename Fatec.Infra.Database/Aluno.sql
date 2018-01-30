CREATE TABLE [dbo].[Aluno]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdPessoa] INT NOT NULL, 
    [RA] VARCHAR(50) NOT NULL, 
    [Curso] VARCHAR(100) NOT NULL, 
    [DataMatricula] DATETIME NOT NULL, 
    CONSTRAINT [FK_Aluno_Pessoa] FOREIGN KEY ([IdPessoa]) REFERENCES [Pessoa]([Id])
)
