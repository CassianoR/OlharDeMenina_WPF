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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;


    public partial class Produtos : ObservableObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produtos()
        {
            this.Estoque = new HashSet<Estoque>();
            this.Venda = new HashSet<Venda>();
        }

        private int codigo;
        private string fk_nomecategoria;
        private string nomeproduto;
        private string unidademedida;
        private string marca;
        private string descricao;
        private decimal valor;

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
            get => fk_nomecategoria;
            set
            {
                fk_nomecategoria = value;
                OnPropertyChanged(nameof(FK_NomeCategoria));
            }
        }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string NomeProduto
        {
            get => nomeproduto;
            set
            {
                nomeproduto = value;
                OnPropertyChanged(nameof(NomeProduto));
            }
        }

        [Required(ErrorMessage = "O campo Unidade de medida é obrigatório.")]
        public string UnidadeMedida
        {
            get => unidademedida;
            set
            {
                unidademedida = value;
                OnPropertyChanged(nameof(UnidadeMedida));
            }
        }

        [Required]
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

        [Required]
        //[RegularExpression(@"/^[+-]?([0-9]+\.?[0-9]*|\.[0-9]+)$/", ErrorMessage = "O campo Valor precisa estar no formato correto. (00.0)")]
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
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
