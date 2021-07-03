CREATE PROCEDURE sp_insercaoestoque
	@NumLote int,
	@TotalProdutosLote int,
	@Frete decimal (15,2),
	@Fornecedor varchar (80),
	@DataCompra date,
	@PrecoLote decimal (15,2),
	@Quantidade int,
	@Validade date,
	@FK_CodigoProduto int
AS
BEGIN
	INSERT INTO Estoque VALUES (@NumLote,@TotalProdutosLote,@Frete,@Fornecedor,@DataCompra,@PrecoLote,@Quantidade,@Validade,@FK_CodigoProduto)
END