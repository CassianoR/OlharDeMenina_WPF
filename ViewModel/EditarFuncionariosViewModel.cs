using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class EditarFuncionariosViewModel : ObservableObject
    {
        #region Properties

        private Funcionarios _funcionarios = new Funcionarios();

        public Funcionarios Funcionarios
        {
            get { return _funcionarios; }
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

        private Funcionarios _selectedProduto = new Funcionarios();


        public bool buttonenablebool = false;
        public double buttonopacidadedouble = 0.5;
        public Funcionarios SelectedFuncionario
        {
            get { return _selectedProduto; }
            set
            {
                _selectedProduto = value;
                OnPropertyChanged(nameof(SelectedFuncionario));
            }
        }

        private OlharMeninaBDEntities funcionariosEntities;
        private Exceptions exc = new Exceptions();
        private int _codigo;

        #endregion Properties

        #region Constructor

        public EditarFuncionariosViewModel(int codigo)
        {
            _codigo = codigo;
            funcionariosEntities = new OlharMeninaBDEntities();
            EditFuncionarioCommand = new Command((s) => true, EditFuncionario);
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
        private void EditFuncionario(object obj)
        {
            try
            {
                Hash _hash = new Hash();
                var senha = _hash.Encrypt(Funcionarios.Senha.ToString());
                var uRow = funcionariosEntities.Funcionarios.Where(w => w.ID == _codigo).FirstOrDefault();
                uRow.Nome = Funcionarios.Nome;
                uRow.Telefone = Funcionarios.Telefone;
                uRow.Endereco = Funcionarios.Endereco;
                uRow.Senha = senha;
                uRow.Atividade = Funcionarios.Atividade;
                uRow.LoginFuncionario = Funcionarios.LoginFuncionario;
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

        #endregion Methods

        #region Commands

        public ICommand EditFuncionarioCommand { get; set; }

        #endregion Commands
    }
}