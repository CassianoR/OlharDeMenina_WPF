using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class EditarClientesViewModel : ObservableObject
    {
        #region Properties

        private Clientes _clientes = new Clientes();

        public Clientes Clientes
        {
            get { return _clientes; }
            set
            {
                _clientes = value;
                OnPropertyChanged(nameof(Clientes));
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

        private Clientes _selectedCliente = new Clientes();

        public bool buttonenablebool = false;
        public double buttonopacidadedouble = 0.5;

        public Clientes SelectedCliente
        {
            get { return _selectedCliente; }
            set
            {
                _selectedCliente = value;
                OnPropertyChanged(nameof(SelectedCliente));
            }
        }

        private OlharMeninaBDEntities clientesEntities;
        private Exceptions exc = new Exceptions();
        private int _codigo;

        #endregion Properties

        #region Constructor

        public EditarClientesViewModel(int codigo)
        {
            _codigo = codigo;
            clientesEntities = new OlharMeninaBDEntities();
            EditClienteCommand = new Command((s) => true, EditCliente);
        }

        #endregion Constructor

        #region Methods

        private void ButtonAtivado()
        {
            if (Clientes.Nome == null || Clientes.CPF == null || Clientes.Endereco == null || Clientes.Telefone == null || Clientes.DataNasc == null)
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
            if (Clientes.Nome == null || Clientes.CPF == null || Clientes.Endereco == null || Clientes.Telefone == null || Clientes.DataNasc == null)
            {
                buttonopacidadedouble = 0.5;
            }
            else
            {
                buttonopacidadedouble = 1;
            }
        }

        private void EditCliente(object obj)
        {
            try
            {
                var uRow = clientesEntities.Clientes.Where(w => w.ID == _codigo).FirstOrDefault();
                uRow.Nome = Clientes.Nome;
                uRow.Telefone = Clientes.Telefone;
                uRow.Endereco = Clientes.Endereco;
                clientesEntities.SaveChanges();
                Clientes = new Clientes();
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                clientesEntities.Dispose();
                clientesEntities = new OlharMeninaBDEntities();
            }
        }

        #endregion Methods

        #region Commands

        public ICommand EditClienteCommand { get; set; }

        #endregion Commands
    }
}