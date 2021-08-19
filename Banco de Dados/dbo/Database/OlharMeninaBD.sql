CREATE DATABASE OlharMeninaBD;
USE OlharMeninaBD;

CREATE TABLE [dbo].[Clientes] (
    [ID]       INT          IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (50) NOT NULL,
    [CPF]      CHAR (14)    NOT NULL,
    [Endereco] VARCHAR (80) NOT NULL,
    [Telefone] VARCHAR (20) NOT NULL,
    [DataNasc] VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([CPF] ASC)
);

CREATE TABLE [dbo].[Funcionarios] (
    [ID]               INT          IDENTITY (1, 1) NOT NULL,
    [Cargo]            VARCHAR (50) NOT NULL,
    [loginfuncionario] VARCHAR (40) NOT NULL,
    [Nome]             VARCHAR (50) NOT NULL,
    [CPF]              CHAR (14)    NOT NULL,
    [Senha]            NVARCHAR(68) NOT NULL,
    [Endereco]         VARCHAR (80) NOT NULL,
    [Telefone]         VARCHAR (20) NOT NULL,
	[Atividade]        VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([CPF] ASC),
    UNIQUE NONCLUSTERED ([loginfuncionario] ASC)
);

CREATE TABLE [dbo].[Categoria] (
    [NomeCategoria]   VARCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([NomeCategoria] ASC)
);

CREATE TABLE [dbo].[Produtos] (
    [Codigo]             INT             IDENTITY (1, 1) NOT NULL,
    [FK_NomeCategoria]    VARCHAR(40)    NOT NULL,
    [NomeProduto]        VARCHAR (50)    NOT NULL,
    [UnidadeMedida]      VARCHAR (15)    NOT NULL,
    [Marca]              VARCHAR (100)   NOT NULL,
    [Descricao]          VARCHAR (100)   NOT NULL,
    [Valor]              DECIMAL (15, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Codigo] ASC),
    CONSTRAINT [fk_produtos] FOREIGN KEY ([FK_NomeCategoria]) REFERENCES [dbo].[Categoria] ([NomeCategoria])
);

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



CREATE TABLE [dbo].[Venda] (
    [CodigoVendas]      INT             IDENTITY (1, 1) NOT NULL,
    [FK_IDFuncionario]  INT             NOT NULL,
    [FK_IDCliente]      INT                     ,
    [Valor]             DECIMAL (15, 2) NOT NULL,
    [MetodoPagamento]   VARCHAR (50)    NOT NULL,
    [Data]              VARCHAR (40)    NOT NULL,
    PRIMARY KEY CLUSTERED ([CodigoVendas] ASC),
    CONSTRAINT [FK_Venda] FOREIGN KEY ([FK_IDFuncionario]) REFERENCES [dbo].[Funcionarios] ([ID]),
    CONSTRAINT [FK_Venda2] FOREIGN KEY ([FK_IDCliente]) REFERENCES [dbo].[Clientes] ([ID])
);

CREATE TABLE [dbo].[VendaDetalhes] (
    [Codigo]            INT IDENTITY (1, 1) NOT NULL,
    [FK_CodigoVendas]       INT             NOT NULL,
    [FK_CodigoProduto]      INT             NOT NULL,
    [Quantidade]            INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Codigo] ASC),
    CONSTRAINT [FK_VendaDetalhes1] FOREIGN KEY ([FK_CodigoVendas]) REFERENCES [dbo].[Venda] ([CodigoVendas]),
    CONSTRAINT [FK_VendaDetalhes2] FOREIGN KEY ([FK_CodigoProduto]) REFERENCES [dbo].[Produtos] ([Codigo])
);

insert into Funcionarios (LoginFuncionario,Cargo, Nome, CPF, Senha, Endereco, Telefone, Atividade) values ('João@gmail.com','Administrador', 'João','111.111.111-11', 'gdyb21LQTcIANtvYMT7QVQ==                                        ', 'Rua do Palmito','99999-9999','Ativo');