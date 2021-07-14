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
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public partial class Funcionarios
    {
        private int id;
        private string cargo;
        private string nome;
        private string cpf;
        private string senha;
        private string endereco;
        private string telefone;
        private object _validationErrors;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionarios()
        {
            this.Venda = new HashSet<Venda>();
        }
    
        public int ID 
        { 
            get => id; set
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public string Cargo
        {
            get => cargo; set
            {
                cargo = value;
                OnPropertyChanged(nameof(Cargo));
            }
        }
        [Required]
        public string Nome
        {
            get => nome; set
            {
                nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }
        [StringLength(1)]
        public string CPF
        {
            get => cpf; set
            {
                cpf = value;
                OnPropertyChanged(nameof(CPF));
            }
        }


        public string Senha
        {
            get => senha; set
            {
                senha = value;
                OnPropertyChanged(nameof(Senha));
            }
        }
        public string Endereco
        {
            get => endereco; set
            {
                endereco = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }
        public string Telefone
        {
            get => telefone; set
            {
                telefone = value;
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
