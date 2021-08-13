CREATE TABLE [dbo].[Venda] (
    [CodigoVendas]      INT             IDENTITY (1, 1) NOT NULL,
    [FK_IDFuncionario]  INT             NOT NULL,
    [FK_IDCliente]      INT             NOT NULL,
    [FK_CodigoProduto]  INT             NOT NULL,
    [Valor]             VARCHAR (20)    NOT NULL,
    [MetodoPagamento]   VARCHAR (50)    NOT NULL,
    [Data]              DECIMAL (15, 2) NOT NULL,
    [QuantidadeVendida] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([CodigoVendas] ASC),
    CONSTRAINT [FK_Venda] FOREIGN KEY ([FK_IDFuncionario]) REFERENCES [dbo].[Funcionarios] ([ID]),
    CONSTRAINT [FK_Venda2] FOREIGN KEY ([FK_IDCliente]) REFERENCES [dbo].[Clientes] ([ID]),
    CONSTRAINT [FK_Venda3] FOREIGN KEY ([FK_CodigoProduto]) REFERENCES [dbo].[Produtos] ([Codigo])
);


GO
CREATE TRIGGER tgr_baixa_estoque
ON Venda
FOR INSERT
AS
BEGIN
	DECLARE @CodigoProduto int,
			@QuantidadeVendida int
	select  @CodigoProduto = FK_CodigoProduto,  @QuantidadeVendida = QuantidadeVendida from inserted
	update Estoque
	set QuantidadeEstoque = QuantidadeEstoque - @QuantidadeVendida
	where FK_CodigoProduto = @CodigoProduto;
end