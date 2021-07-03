CREATE TABLE [dbo].[Funcionarios] (
    [ID]       INT          IDENTITY (1, 1) NOT NULL,
    [Cargo]    VARCHAR (50) NOT NULL,
    [Nome]     VARCHAR (50) NOT NULL,
    [CPF]      CHAR (14)    NOT NULL,
    [Senha]    INT          NOT NULL,
    [Endereco] VARCHAR (80) NOT NULL,
    [Telefone] VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([CPF] ASC)
);

