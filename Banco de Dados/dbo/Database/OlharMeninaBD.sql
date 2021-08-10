CREATE DATABASE OlharMeninaBD;
USE OlharMeninaBD;

CREATE TABLE Clientes (
	ID INT not null IDENTITY (1,1),
	Nome VARCHAR (50) not null,
	CPF VARCHAR (14) not null UNIQUE,
	Endereco VARCHAR (80) not null,
	Telefone VARCHAR (20) not null,
	DataNasc varchar (10) not null,
	PRIMARY KEY (ID)
)
GO

CREATE TABLE Funcionarios (
	ID INT not null IDENTITY (1,1),
	LoginFuncionario varchar (40) not null unique,
	Cargo VARCHAR (50) not null,
	Nome VARCHAR (50) not null,
	CPF CHAR (14) not null UNIQUE,
	Senha nchar (64),
	Endereco VARCHAR (80) not null,
	Telefone VARCHAR (20) not null,
	Atividade VARCHAR (20) not null,
	PRIMARY KEY (ID)
)
GO

CREATE TABLE Categoria (
	NomeCategoria VARCHAR(40),
	CodigoCategoria INT not null IDENTITY,
	PRIMARY KEY (NomeCategoria)
)
GO

CREATE TABLE Produtos (
	Codigo INT not null IDENTITY (1,1),
	UnidadeMedida varchar (15) not null,
	NomeProduto VARCHAR(50) not null,
	Marca VARCHAR (100) not null,
	Categoria CHAR (1)not null,
	Descricao VARCHAR (100) not null,
	Valor DECIMAL (15,2) not null,
	FK_NomeCategoria varchar (40),
	CONSTRAINT FK_Produto FOREIGN KEY (FK_NomeCategoria) REFERENCES Categoria (NomeCategoria),
	PRIMARY KEY (Codigo)
)
GO

CREATE TABLE Estoque (
	ID INT not null IDENTITY (1,1),
	NumLote INT not null,
	TotalProdutosLote INT not null,
	Frete DECIMAL (15,2) not null,
	Fornecedor VARCHAR (80) not null,
	DataCompra DATE not null,
	PrecoLote DECIMAL (15,2) not null,
	QuantidadeEstoque INT not null,
	Validade DATE,
	FK_CodigoProduto INT not null,
	CONSTRAINT FK_Estoque FOREIGN KEY (FK_CodigoProduto) REFERENCES Produtos (Codigo),
	PRIMARY KEY (ID)
)
GO

CREATE TABLE Venda (
	CodigoVendas INT not null IDENTITY (1,1),
	FK_IDFuncionario INT not null,
	FK_IDCliente INT not null,
	FK_CodigoProduto INT not null,
	Valor DECIMAL (15,2) not null,
	MetodoPagamento VARCHAR (50) not null,
	DataHora DATETIME not null,
	QuantidadeVendida INT not null,
	CONSTRAINT FK_Venda  FOREIGN KEY (FK_IDFuncionario) REFERENCES Funcionarios (ID),
	CONSTRAINT FK_Venda2 FOREIGN KEY (fK_IDCliente)		REFERENCES Clientes (ID),
	CONSTRAINT FK_Venda3 FOREIGN KEY (FK_CodigoProduto) REFERENCES Produtos (Codigo),
	PRIMARY KEY (CodigoVendas)
)
GO

insert into Funcionarios (LoginFuncionario,Cargo, Nome, CPF, Senha, Endereco, Telefone, Atividade) values ('João@gmail.com','Adminstrador', 'João','111.111.111-11', 'gdyb21LQTcIANtvYMT7QVQ==                                        ', 'Rua do Palmito','99999-9999','Ativo');