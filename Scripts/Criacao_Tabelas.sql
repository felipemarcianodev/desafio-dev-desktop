DROP TABLE IF EXISTS [Cliente];
CREATE TABLE[dbo].[Cliente] (
    [Id]                    INT IDENTITY (1, 1) NOT NULL,
    [Nome]                  VARCHAR (100)  NOT NULL,
    [Cpf]                   VARCHAR (11)  NOT NULL,
    [Email]                 VARCHAR (100) NOT NULL,
    [Telefone]              VARCHAR (20) NOT NULL,
    [DataInclusao]          DATETIME NOT NULL,
    [DataAlteracao]         DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
