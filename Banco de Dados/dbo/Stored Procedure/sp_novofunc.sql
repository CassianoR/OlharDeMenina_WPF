CREATE PROCEDURE sp_novofunc
	@Cargo varchar(50),
	@Nome  varchar(50),
	@CPF   char(14),
	@Endereco varchar (60),
	@Telefone varchar (20),
	@Senha varchar (20)
AS
BEGIN
	INSERT INTO Funcionarios VALUES (@Cargo, @Nome, @CPF, @Endereco, @Telefone, @Senha)
END