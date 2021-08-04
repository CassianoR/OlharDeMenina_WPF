using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LojaOlharDeMenina_WPF.Model
{
    public class FuncionariosDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        private string loginfuncionario;
        private string cargo;
        private string nome;
        private string cpf;
        private string senha;
        private string endereco;
        private string telefone;
        private string atvidade;

        public int ID
        {
            get => id; set
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string LoginFuncionario
        {
            get => loginfuncionario; set
            {
                loginfuncionario = value;
                OnPropertyChanged(nameof(LoginFuncionario));
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

        [Required(ErrorMessage = " O campo Nome é obrigatório.")]
        public string Nome
        {
            get => nome; set
            {
                nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }

        [Required(ErrorMessage = " O campo CPF é obrigatório.")]
        [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", ErrorMessage = "O CPF precisa estar no formato correto. (000.000.000-00)")]
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

        [Required(ErrorMessage = " O campo Endereço é obrigatório.")]
        public string Endereco
        {
            get => endereco; set
            {
                endereco = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }

        [Required(ErrorMessage = " O campo Telefone é obrigatório.")]
        [RegularExpression(@"(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})", ErrorMessage = "O Telefone precisa estar no formato correto. (00 00000-0000)")]
        public string Telefone
        {
            get => telefone; set
            {
                telefone = value;
                OnPropertyChanged(nameof(Telefone));
            }
        }

        public string Atividade
        {
            get => atvidade; set
            {
                atvidade = value;
                OnPropertyChanged(nameof(Atividade));
            }
        }

    }
}