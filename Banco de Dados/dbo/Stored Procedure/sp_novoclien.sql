CREATE PROCEDURE sp_novoclien
	@Nome varchar (80),
	@CPF  char(14),
	@Endereco varchar (80),
	@Telefone varchar (20),
	@DataNasc date
AS
BEGIN
	INSERT INTO Clientes VALUES(@Nome, @CPF, @Endereco, @Telefone, @DataNasc)
END