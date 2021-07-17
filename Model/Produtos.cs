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
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class Produtos
    {
        private int _codigo;
        private int _fK_CodigoCategoria;
        private string _nomeProduto;
        private string _unidadeMedida;
        private string _marca;
        private string _categoria;
        private string _descricao;
        private decimal _valor;

        public event PropertyChangedEventHandler PropertyChanged;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produtos()
        {
            this.Estoque = new HashSet<Estoque>();
            this.Venda = new HashSet<Venda>();
        }


        public int Codigo
        {
            get => _codigo;
            set
            {
                _codigo = value;
                OnPropertyChanged(nameof(Codigo));
            }
        }
        public int FK_CodigoCategoria
        {
            get => _fK_CodigoCategoria;
            set
            {
                _fK_CodigoCategoria = value;
                OnPropertyChanged(nameof(FK_CodigoCategoria));
            }
        }
        public string NomeProduto
        {
            get => _nomeProduto;
            set
            {
                _nomeProduto = value;
                OnPropertyChanged(nameof(NomeProduto));
            }
        }
        public string UnidadeMedida
        {
            get => _unidadeMedida;
            set
            {
                _unidadeMedida = value;
                OnPropertyChanged(nameof(UnidadeMedida));
            }
        }
        public string Marca
        {
            get => _marca;
            set
            {
                _marca = value;
                OnPropertyChanged(nameof(Marca));
            }
        }
        public string Categoria
        {
            get => _categoria;
            set
            {
                _categoria = value;
                OnPropertyChanged(nameof(Categoria));
            }
        }
        public string Descricao
        {
            get => _descricao;
            set
            {
                _descricao = value;
                OnPropertyChanged(nameof(Descricao));
            }
        }
        public decimal Valor
        {
            get => _valor;
            set
            {
                _valor = value;
                OnPropertyChanged(nameof(Valor));
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estoque> Estoque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
