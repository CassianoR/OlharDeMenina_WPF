CREATE TABLE [dbo].[Categoria] (
    [CodigoCategoria] INT          IDENTITY (1, 1) NOT NULL,
    [NomeCategoria]   VARCHAR (40) NULL,
    PRIMARY KEY CLUSTERED ([CodigoCategoria] ASC)
);

