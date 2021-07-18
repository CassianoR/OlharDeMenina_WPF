CREATE TABLE [dbo].[Produtos] (
    [Codigo]             INT             IDENTITY (1, 1) NOT NULL,
    FK_NomeCategoria     VARCHAR(40)    NOT NULL,
    [NomeProduto]        VARCHAR (50)    NOT NULL,
    [UnidadeMedida]      VARCHAR (15)    NOT NULL,
    [Marca]              VARCHAR (100)   NOT NULL,
    [Descricao]          VARCHAR (100)   NOT NULL,
    [Valor]              DECIMAL (15, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Codigo] ASC),
    CONSTRAINT [fk_produtos] FOREIGN KEY ([FK_NomeCategoria]) REFERENCES [dbo].[Categoria] ([NomeCategoria])
);

