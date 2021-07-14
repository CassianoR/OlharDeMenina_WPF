﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LojaOlharDeMenina_WPF.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OlharMeninaBDEntities : DbContext
    {
        public OlharMeninaBDEntities()
            : base("name=OlharMeninaBDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<Venda> Venda { get; set; }
        public virtual DbSet<Produtos_add_Quantidade> Produtos_add_Quantidade { get; set; }
    
        public virtual int sp_insercaoestoque(Nullable<int> numLote, Nullable<int> totalProdutosLote, Nullable<decimal> frete, string fornecedor, Nullable<System.DateTime> dataCompra, Nullable<decimal> precoLote, Nullable<int> quantidade, Nullable<System.DateTime> validade, Nullable<int> fK_CodigoProduto)
        {
            var numLoteParameter = numLote.HasValue ?
                new ObjectParameter("NumLote", numLote) :
                new ObjectParameter("NumLote", typeof(int));
    
            var totalProdutosLoteParameter = totalProdutosLote.HasValue ?
                new ObjectParameter("TotalProdutosLote", totalProdutosLote) :
                new ObjectParameter("TotalProdutosLote", typeof(int));
    
            var freteParameter = frete.HasValue ?
                new ObjectParameter("Frete", frete) :
                new ObjectParameter("Frete", typeof(decimal));
    
            var fornecedorParameter = fornecedor != null ?
                new ObjectParameter("Fornecedor", fornecedor) :
                new ObjectParameter("Fornecedor", typeof(string));
    
            var dataCompraParameter = dataCompra.HasValue ?
                new ObjectParameter("DataCompra", dataCompra) :
                new ObjectParameter("DataCompra", typeof(System.DateTime));
    
            var precoLoteParameter = precoLote.HasValue ?
                new ObjectParameter("PrecoLote", precoLote) :
                new ObjectParameter("PrecoLote", typeof(decimal));
    
            var quantidadeParameter = quantidade.HasValue ?
                new ObjectParameter("Quantidade", quantidade) :
                new ObjectParameter("Quantidade", typeof(int));
    
            var validadeParameter = validade.HasValue ?
                new ObjectParameter("Validade", validade) :
                new ObjectParameter("Validade", typeof(System.DateTime));
    
            var fK_CodigoProdutoParameter = fK_CodigoProduto.HasValue ?
                new ObjectParameter("FK_CodigoProduto", fK_CodigoProduto) :
                new ObjectParameter("FK_CodigoProduto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_insercaoestoque", numLoteParameter, totalProdutosLoteParameter, freteParameter, fornecedorParameter, dataCompraParameter, precoLoteParameter, quantidadeParameter, validadeParameter, fK_CodigoProdutoParameter);
        }
    
        public virtual int sp_insersaocategoria(string nomeCategoria)
        {
            var nomeCategoriaParameter = nomeCategoria != null ?
                new ObjectParameter("NomeCategoria", nomeCategoria) :
                new ObjectParameter("NomeCategoria", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_insersaocategoria", nomeCategoriaParameter);
        }
    
        public virtual int sp_novavenda(Nullable<int> fK_IDFuncionario, Nullable<int> fK_IDCliente, Nullable<int> fK_CodigoProduto, Nullable<decimal> valor, string metodoPagamento, Nullable<System.DateTime> data, Nullable<int> quantidadeVendida)
        {
            var fK_IDFuncionarioParameter = fK_IDFuncionario.HasValue ?
                new ObjectParameter("FK_IDFuncionario", fK_IDFuncionario) :
                new ObjectParameter("FK_IDFuncionario", typeof(int));
    
            var fK_IDClienteParameter = fK_IDCliente.HasValue ?
                new ObjectParameter("FK_IDCliente", fK_IDCliente) :
                new ObjectParameter("FK_IDCliente", typeof(int));
    
            var fK_CodigoProdutoParameter = fK_CodigoProduto.HasValue ?
                new ObjectParameter("FK_CodigoProduto", fK_CodigoProduto) :
                new ObjectParameter("FK_CodigoProduto", typeof(int));
    
            var valorParameter = valor.HasValue ?
                new ObjectParameter("Valor", valor) :
                new ObjectParameter("Valor", typeof(decimal));
    
            var metodoPagamentoParameter = metodoPagamento != null ?
                new ObjectParameter("MetodoPagamento", metodoPagamento) :
                new ObjectParameter("MetodoPagamento", typeof(string));
    
            var dataParameter = data.HasValue ?
                new ObjectParameter("Data", data) :
                new ObjectParameter("Data", typeof(System.DateTime));
    
            var quantidadeVendidaParameter = quantidadeVendida.HasValue ?
                new ObjectParameter("QuantidadeVendida", quantidadeVendida) :
                new ObjectParameter("QuantidadeVendida", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_novavenda", fK_IDFuncionarioParameter, fK_IDClienteParameter, fK_CodigoProdutoParameter, valorParameter, metodoPagamentoParameter, dataParameter, quantidadeVendidaParameter);
        }
    
        public virtual int sp_novoclien(string nome, string cPF, string endereco, string telefone, Nullable<System.DateTime> dataNasc)
        {
            var nomeParameter = nome != null ?
                new ObjectParameter("Nome", nome) :
                new ObjectParameter("Nome", typeof(string));
    
            var cPFParameter = cPF != null ?
                new ObjectParameter("CPF", cPF) :
                new ObjectParameter("CPF", typeof(string));
    
            var enderecoParameter = endereco != null ?
                new ObjectParameter("Endereco", endereco) :
                new ObjectParameter("Endereco", typeof(string));
    
            var telefoneParameter = telefone != null ?
                new ObjectParameter("Telefone", telefone) :
                new ObjectParameter("Telefone", typeof(string));
    
            var dataNascParameter = dataNasc.HasValue ?
                new ObjectParameter("DataNasc", dataNasc) :
                new ObjectParameter("DataNasc", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_novoclien", nomeParameter, cPFParameter, enderecoParameter, telefoneParameter, dataNascParameter);
        }
    
        public virtual int sp_novofunc(string cargo, string loginfuncionario, string nome, string cPF, string endereco, string telefone, string senha)
        {
            var cargoParameter = cargo != null ?
                new ObjectParameter("Cargo", cargo) :
                new ObjectParameter("Cargo", typeof(string));
    
            var loginfuncionarioParameter = loginfuncionario != null ?
                new ObjectParameter("loginfuncionario", loginfuncionario) :
                new ObjectParameter("loginfuncionario", typeof(string));
    
            var nomeParameter = nome != null ?
                new ObjectParameter("Nome", nome) :
                new ObjectParameter("Nome", typeof(string));
    
            var cPFParameter = cPF != null ?
                new ObjectParameter("CPF", cPF) :
                new ObjectParameter("CPF", typeof(string));
    
            var enderecoParameter = endereco != null ?
                new ObjectParameter("Endereco", endereco) :
                new ObjectParameter("Endereco", typeof(string));
    
            var telefoneParameter = telefone != null ?
                new ObjectParameter("Telefone", telefone) :
                new ObjectParameter("Telefone", typeof(string));
    
            var senhaParameter = senha != null ?
                new ObjectParameter("Senha", senha) :
                new ObjectParameter("Senha", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_novofunc", cargoParameter, loginfuncionarioParameter, nomeParameter, cPFParameter, enderecoParameter, telefoneParameter, senhaParameter);
        }
    
        public virtual int sp_novoproduto(string nome, string unidadeMedida, string marca, string categoria, string descricao, Nullable<decimal> valor)
        {
            var nomeParameter = nome != null ?
                new ObjectParameter("Nome", nome) :
                new ObjectParameter("Nome", typeof(string));
    
            var unidadeMedidaParameter = unidadeMedida != null ?
                new ObjectParameter("UnidadeMedida", unidadeMedida) :
                new ObjectParameter("UnidadeMedida", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var categoriaParameter = categoria != null ?
                new ObjectParameter("Categoria", categoria) :
                new ObjectParameter("Categoria", typeof(string));
    
            var descricaoParameter = descricao != null ?
                new ObjectParameter("Descricao", descricao) :
                new ObjectParameter("Descricao", typeof(string));
    
            var valorParameter = valor.HasValue ?
                new ObjectParameter("Valor", valor) :
                new ObjectParameter("Valor", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_novoproduto", nomeParameter, unidadeMedidaParameter, marcaParameter, categoriaParameter, descricaoParameter, valorParameter);
        }
    
        public virtual int sp_user_login(string loginfuncionario, string senha)
        {
            var loginfuncionarioParameter = loginfuncionario != null ?
                new ObjectParameter("loginfuncionario", loginfuncionario) :
                new ObjectParameter("loginfuncionario", typeof(string));
    
            var senhaParameter = senha != null ?
                new ObjectParameter("senha", senha) :
                new ObjectParameter("senha", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_user_login", loginfuncionarioParameter, senhaParameter);
        }
    }
}
