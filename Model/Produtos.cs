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
    using LojaOlharDeMenina_WPF.Core;
    using System;
    using System.Collections.Generic;

    public partial class Produtos : ObservableObject
    {
        private int codigo;
        private string fK_NomeCategoria;
        private string nomeProduto;
        private string unidadeMedida;
        private string marca;
        private string descricao;
        private decimal valor;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produtos()
        {
            this.Estoque = new HashSet<Estoque>();
            this.VendaDetalhes = new HashSet<VendaDetalhes>();
        }

        public int Codigo 
        { 
            get => codigo;
            set
            {
                codigo = value;
                OnPropertyChanged(nameof(Codigo));
            } 
        }
        public string FK_NomeCategoria
        {
            get => fK_NomeCategoria;
            set
            {
                fK_NomeCategoria = value;
                OnPropertyChanged(nameof(FK_NomeCategoria));
            }
        }
        public string NomeProduto 
        { 
            get => nomeProduto;
            set 
            {
                nomeProduto = value;
                OnPropertyChanged(nameof(NomeProduto));
            }
        }
        public string UnidadeMedida 
        { 
            get => unidadeMedida;
            set 
            {
                unidadeMedida = value;
                OnPropertyChanged(nameof(UnidadeMedida));
            }
        }
        public string Marca 
        { 
            get => marca;
            set 
            {
                marca = value;
                OnPropertyChanged(nameof(Marca));
            }
        }
        public string Descricao 
        { 
            get => descricao;
            set 
            {
                descricao = value;
                OnPropertyChanged(nameof(Descricao));
            }
        }
        public decimal Valor 
        { 
            get => valor;
            set 
            {
                valor = value;
                OnPropertyChanged(nameof(Valor));
            }
        }

        public virtual Categoria Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estoque> Estoque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendaDetalhes> VendaDetalhes { get; set; }
    }
}
