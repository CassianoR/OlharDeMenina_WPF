CREATE TABLE [dbo].[Estoque] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [NumLote]           INT             NOT NULL,
    [TotalProdutosLote] INT             NOT NULL,
    [Frete]             VARCHAR (20)	 NOT NULL,
    [Fornecedor]        VARCHAR (80)    NOT NULL,
    [DataCompra]        VARCHAR (40)    NOT NULL,
    [PrecoLote]         VARCHAR (20)	NOT NULL,
    [QuantidadeEstoque] INT             NOT NULL,
    [Validade]          VARCHAR (40)    NOT NULL,
    [FK_CodigoProduto]  INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Estoque] FOREIGN KEY ([FK_CodigoProduto]) REFERENCES [dbo].[Produtos] ([Codigo])
);

