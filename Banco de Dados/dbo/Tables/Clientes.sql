CREATE TABLE [dbo].[Clientes] (
    [ID]       INT          IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (50) NOT NULL,
    [CPF]      CHAR (14)    NOT NULL,
    [Endereco] VARCHAR (80) NOT NULL,
    [Telefone] VARCHAR (20) NOT NULL,
    [DataNasc] VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([CPF] ASC)
);

