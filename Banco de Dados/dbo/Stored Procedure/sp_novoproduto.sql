CREATE PROCEDURE sp_novoproduto
	@Nome  varchar (50),
	@Marca varchar (100),
	@Categoria char (1),
	@Descricao varchar(100),
	@Valor decimal (15,2)
AS
BEGIN
	INSERT INTO Produtos VALUES(@Nome, @Marca, @Categoria, @Descricao, @Valor)
END