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

    public partial class Funcionarios:INotifyPropertyChanged
    {
        private int _iD;
        private string _loginFuncionario;
        private string _cargo;
        private string _nome;
        private string _cPF;
        private string _senha;
        private string _endereco;
        private string _telefone;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionarios()
        {
            this.Venda = new HashSet<Venda>();
        }

        public int ID
        {
            get => _iD; set
            { _iD = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public string LoginFuncionario
        {
            get => _loginFuncionario; set
            { _loginFuncionario = value;
                OnPropertyChanged(nameof(LoginFuncionario));
            }
        }
        public string Cargo
        {
            get => _cargo; set
            {
                _cargo = value;
                OnPropertyChanged(nameof(Cargo));
            }

        }
        public string Nome
        {
            get => _nome; set
            { _nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }
        public string CPF
        {
            get => _cPF; set
            { _cPF = value;
                OnPropertyChanged(nameof(CPF));
            }
        }
        public string Senha
        {
            get => _senha; set
            { _senha = value;
                OnPropertyChanged(nameof(Senha));
            }
        }
        public string Endereco
        {
            get => _endereco; set
            { _endereco = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }
        public string Telefone
        {
            get => _telefone; set
            { _telefone = value;
                OnPropertyChanged(nameof(Telefone));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venda> Venda { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
