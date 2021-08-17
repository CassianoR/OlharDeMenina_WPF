using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class ClientesViewModel : ObservableObject
    {
        #region Properties

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private ObservableCollection<Clientes> _lstClientes;

        public ObservableCollection<Clientes> lstClientes
        {
            get { return _lstClientes; }
            set
            {
                _lstClientes = value;
                OnPropertyChanged(nameof(lstClientes));
            }
        }

        private Clientes _selectedCliente;

        public Clientes SelectedCliente
        {
            get { return _selectedCliente; }
            set
            {
                _selectedCliente = value;
                OnPropertyChanged(nameof(SelectedCliente));
            }
        }

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

        private string _search;

        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                if (value.Length > 2 || value == "*")
                    GetResults(_search);

                if (value == null || value == string.Empty)
                    if (lstClientes != null)
                        lstClientes.Clear();
            }
        }

        private Exceptions exc = new Exceptions();

        private OlharMeninaBDEntities clientesEntities;

        #endregion Properties

        #region Constructor

        public ClientesViewModel()
        {
            clientesEntities = new OlharMeninaBDEntities();
            DeleteCommand = new Command((s) => true, Delete);
            UpdateCommand = new Command((s) => true, Update);
        }

        #endregion Constructor

        #region Methods

        private async void GetResults(string search)
        {
            if (search == "*")
            {
                LoadCliente();
                return;
            }
            clientesEntities = new OlharMeninaBDEntities();
            lstClientes = new ObservableCollection<Clientes>();
            var ObjQuery = await clientesEntities.Clientes.Where(x => x.Nome.Contains(search) || x.CPF.Contains(search) || x.Telefone.Contains(search)).ToListAsync();
            foreach (var cliente in ObjQuery)
            {
                lstClientes.Add(cliente);
            }
        }

        private void Update(object obj) //Update, recarrega
        {
            SelectedCliente = obj as Clientes;
            LoadCliente();
        }

        private void Delete(object obj) //Delete
        {
            System.Windows.MessageBoxResult deletarConfirma = System.Windows.MessageBox.Show("Você tem certeza que quer deletar esse cliente?", "Deletar?", System.Windows.MessageBoxButton.OKCancel);
            if (deletarConfirma == System.Windows.MessageBoxResult.Cancel)
            {
                return;
            }
            var cl = obj as Clientes;
            clientesEntities.Clientes.Remove(cl);
            try
            {
                clientesEntities.SaveChanges();
                lstClientes.Remove(cl);
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                clientesEntities.Dispose();
            }
        }

        private async void LoadCliente() //Read
        {
            clientesEntities = new OlharMeninaBDEntities();
            var lista = await clientesEntities.Clientes.ToListAsync();
            lstClientes = new ObservableCollection<Clientes>(lista);
        }

        #endregion Methods

        #region Commands

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        #endregion Commands
    }
}