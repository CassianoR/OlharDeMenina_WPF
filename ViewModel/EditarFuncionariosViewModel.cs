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

        private void EditFuncionario(object obj)
        {
            try
            {
                var uRow = funcionariosEntities.Funcionarios.Where(w => w.ID == _codigo).FirstOrDefault();
                uRow.Nome = Funcionarios.Nome;
                uRow.Telefone = Funcionarios.Telefone;
                uRow.Endereco = Funcionarios.Endereco;
                funcionariosEntities.SaveChanges();
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