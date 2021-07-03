CREATE PROCEDURE sp_novavenda 
	@FK_IDFuncionario int,
	@FK_IDCliente int,
	@FK_CodigoProduto int,
	@Valor decimal (15,2),
	@MetodoPagamento varchar (50),
	@Data date,
	@QuantidadeVendida int
AS
BEGIN
	INSERT INTO Venda VALUES(@FK_IDFuncionario, @FK_IDCliente, @FK_CodigoProduto, @Valor, @MetodoPagamento, @Data, @QuantidadeVendida)
END