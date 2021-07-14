CREATE PROCEDURE sp_novofunc
	@Cargo varchar(50),
	@loginFuncionario varchar (40),
	@Nome  varchar(50),
	@CPF   char(14),
	@Senha int,
	@Endereco varchar (80),
	@Telefone varchar (20)
AS
BEGIN
	INSERT INTO Funcionarios VALUES (@Cargo, @loginFuncionario, @Nome, @CPF,@Senha, @Endereco, @Telefone)
END