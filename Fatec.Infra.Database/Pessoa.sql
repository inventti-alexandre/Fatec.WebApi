﻿CREATE TABLE [dbo].[Pessoa]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(100) NOT NULL, 
    [Idade] INT NOT NULL, 
    [Email] VARCHAR(100) NOT NULL
)
