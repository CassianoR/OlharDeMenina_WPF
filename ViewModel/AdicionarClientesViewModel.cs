using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class AdicionarClientesViewModel : ObservableObject
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

        private OlharMeninaBDEntities clientesEntities;
        private Exceptions exc = new Exceptions();

        #endregion Properties

        #region Constructor

        public AdicionarClientesViewModel()
        {
            clientesEntities = new OlharMeninaBDEntities();
            AddClienteCommand = new Command((s) => true, AddCliente);
        }

        #endregion Constructor

        #region Methods

        private void AddCliente(object obj)
        {
            if (clientesEntities == null)
                clientesEntities = new OlharMeninaBDEntities();

            if (ValidaCPF.IsCpf(Clientes.CPF))
            {
                Clientes.ID = clientesEntities.Clientes.Count();
                clientesEntities.Clientes.Add(Clientes);
                try
                {
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
            else
            {
                Message = "CPF Inválido";
            }
        }

        #endregion Methods

        #region Commands

        public ICommand AddClienteCommand { get; set; }

        #endregion Commands
    }
}