CREATE PROCEDURE sp_novoproduto
	@FK_CodigoCategoria int,
	@Nome  varchar (50),
	@UnidadeMedida varchar(15),
	@Marca varchar (100),
	@Categoria char (1),
	@Descricao varchar(100),
	@Valor decimal (15,2)
AS
BEGIN
	INSERT INTO Produtos VALUES(@FK_CodigoCategoria, @Nome, @UnidadeMedida, @Marca, @Descricao, @Valor)
END