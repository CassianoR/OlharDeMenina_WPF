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
    
    public partial class Vendas
    {
        public int Codigo { get; set; }
        public int FK_IDFuncionario { get; set; }
        public int FK_IDCliente { get; set; }
        public decimal Valor { get; set; }
        public string MetodoPagamento { get; set; }
        public System.DateTime DataHora { get; set; }
        public int Quantidade { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Funcionarios Funcionarios { get; set; }
    }
}
