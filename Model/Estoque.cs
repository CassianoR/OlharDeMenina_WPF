//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Estoque
    {
        public int ID { get; set; }
        public int NumLote { get; set; }
        public int TotalProdutosLote { get; set; }
        public string Frete { get; set; }
        public string Fornecedor { get; set; }
        public string DataCompra { get; set; }
        public string PrecoLote { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string Validade { get; set; }
        public int FK_CodigoProduto { get; set; }
    
        public virtual Produtos Produtos { get; set; }
    }
}
