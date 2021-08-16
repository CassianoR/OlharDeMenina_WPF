using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class AdicionarFuncionariosViewModel : ObservableObject
    {
        #region Properties

        private Funcionarios _funcionarios = new Funcionarios();

        public bool buttonenablebool = false;
        public double buttonopacidadedouble = 0.5;

        public Funcionarios Funcionarios
        {
            get
            {
                return _funcionarios;
            }
            set
            {
                _funcionarios = value;
                OnPropertyChanged(nameof(Funcionarios));
            }
        }

        private string message;

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private OlharMeninaBDEntities funcionariosEntities;
        private Exceptions exc = new Exceptions();

        #endregion Properties

        #region Constructor

        public AdicionarFuncionariosViewModel()
        {
            funcionariosEntities = new OlharMeninaBDEntities();
            AddFuncionarioCommand = new Command((s) => true, AddFuncionario);
        }

        #endregion Constructor

        #region Methods
        private void ButtonAtivado()
        {
            if (Funcionarios.Nome == null || Funcionarios.CPF == null || Funcionarios.LoginFuncionario == null || Funcionarios.Cargo == null || Funcionarios.Senha == null || Funcionarios.Endereco == null || Funcionarios.Telefone == null || Funcionarios.Atividade == null)
            {
                buttonenablebool = false;
            }
            else
            {
                buttonenablebool = true;
            }
            //talvez tenha que dar tostring em tudo mas vamos ver
            //o problema é que nem ta vindo nas funções
        }
        private void ButtonOpacidade()
        {
            if (Funcionarios.Nome == null || Funcionarios.CPF == null || Funcionarios.LoginFuncionario == null || Funcionarios.Cargo == null || Funcionarios.Senha == null || Funcionarios.Endereco == null || Funcionarios.Telefone == null || Funcionarios.Atividade == null)
            {
                buttonopacidadedouble = 0.5;
            }
            else
            {
                buttonopacidadedouble = 1;
            }
        }
        private void AddFuncionario(object obj)
        {
            if (funcionariosEntities == null)
                funcionariosEntities = new OlharMeninaBDEntities();

            if (ValidaCPF.IsCpf(Funcionarios.CPF))
            {
                Funcionarios.ID = funcionariosEntities.Funcionarios.Count();
                Hash _hash = new Hash();
                var senha = _hash.Encrypt(Funcionarios.Senha);
                Funcionarios.Senha = senha;
                Funcionarios.Atividade = "Ativo";
                funcionariosEntities.Funcionarios.Add(Funcionarios);
                try
                {
                    funcionariosEntities.SaveChanges();
                    Funcionarios = new Funcionarios();
                }
                catch (DbEntityValidationException ex)
                {
                    string exceptionMessage = exc.concatenaExceptions(ex);
                    Message = exceptionMessage;
                    funcionariosEntities.Dispose();
                    funcionariosEntities = new OlharMeninaBDEntities();
                }
            }
            else
            {
                Message = "CPF Inválido";
            }
        }

        #endregion Methods

        #region Commands

        public ICommand AddFuncionarioCommand { get; set; }

        #endregion Commands
    }
}