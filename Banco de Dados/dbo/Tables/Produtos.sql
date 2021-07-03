CREATE TABLE [dbo].[Produtos] (
    [Codigo]      INT             IDENTITY (1, 1) NOT NULL,
    [NomeProduto] VARCHAR (50)    NOT NULL,
    [Marca]       VARCHAR (100)   NOT NULL,
    [Categoria]   CHAR (1)        NOT NULL,
    [Descricao]   VARCHAR (100)   NOT NULL,
    [Valor]       DECIMAL (15, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Codigo] ASC)
);

