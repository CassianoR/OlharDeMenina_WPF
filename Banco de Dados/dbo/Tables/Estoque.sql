CREATE TABLE [dbo].[Estoque] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [NumLote]           INT             NOT NULL,
    [TotalProdutosLote] INT             NOT NULL,
    [Frete]             DECIMAL (15, 2) NOT NULL,
    [Fornecedor]        VARCHAR (80)    NOT NULL,
    [DataCompra]        DATE            NOT NULL,
    [PrecoLote]         DECIMAL (15, 2) NOT NULL,
    [QuantidadeEstoque] INT             NOT NULL,
    [Validade]          DATE            NULL,
    [FK_CodigoProduto]  INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Estoque] FOREIGN KEY ([FK_CodigoProduto]) REFERENCES [dbo].[Produtos] ([Codigo])
);

