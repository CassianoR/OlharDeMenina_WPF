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

    public partial class Funcionarios : ObservableObject
    {
        private int iD;
        private string cargo;
        private string loginFuncionario;
        private string nome;
        private string cPF;
        private string senha;
        private string endereco;
        private string telefone;
        private string atividade;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionarios()
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
        public string Cargo 
        { 
            get => cargo;
            set 
            { 
                cargo = value;
                OnPropertyChanged(nameof(Cargo));
            }
        }
        public string LoginFuncionario 
        { 
            get => loginFuncionario;
            set 
            {
                loginFuncionario = value;
                OnPropertyChanged(nameof(LoginFuncionario));
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
        public string Senha 
        { 
            get => senha; 
            set 
            {
                senha = value;
                OnPropertyChanged(Senha);
            } 
        }
        public string Endereco 
        { 
            get => endereco; 
            set 
            {
                endereco = value;
                OnPropertyChanged(Endereco);
            } 
        }
        public string Telefone 
        { 
            get => telefone; 
            set 
            {
                telefone = value;
                OnPropertyChanged(Telefone);
            } 
        }
        public string Atividade 
        { 
            get => atividade; 
            set 
            {
                atividade = value;
                OnPropertyChanged(Atividade);
            } 
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
