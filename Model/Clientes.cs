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

    public partial class Clientes : ObservableObject
    {
        private int iD;
        private string nome;
        private string cPF;
        private string endereco;
        private string telefone;
        private string dataNasc;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            this.Venda = new HashSet<Venda>();
        }

        public int ID
        {
            get => iD;
            set
            {
                iD = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }
        public string CPF 
        { 
            get => cPF;
            set 
            {
                cPF = value;
                OnPropertyChanged(nameof(CPF));
            }
        }
        public string Endereco 
        { 
            get => endereco;
            set 
            {
                endereco = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }
        public string Telefone 
        { 
            get => telefone;
            set 
            {
                telefone = value;
                OnPropertyChanged(nameof(Telefone));
            }
        }
        public string DataNasc 
        { 
            get => dataNasc;
            set 
            {
                dataNasc = value;
                OnPropertyChanged(nameof(DataNasc));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
