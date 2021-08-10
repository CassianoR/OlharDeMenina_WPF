using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class VendasViewModel : ObservableObject
    {
        private Exceptions exc = new Exceptions();

        #region Properties

        private ObservableCollection<Venda> _lstVendas;

        public ObservableCollection<Venda> lstVendas
        {
            get { return _lstVendas; }
            set
            {
                _lstVendas = value;
                OnPropertyChanged(nameof(lstVendas));
            }
        }

        private Venda _selectedVenda;

        public Venda SelectedVenda
        {
            get { return _selectedVenda; }
            set
            {
                _selectedVenda = value;
                OnPropertyChanged(nameof(SelectedVenda));
            }
        }

        private Venda _venda = new Venda();

        public Venda Venda
        {
            get { return _venda; }
            set
            {
                _venda = value;
                OnPropertyChanged(nameof(Venda));
            }
        }

        private OlharMeninaBDEntities vendaEntities;

        /// <summary>
        /// TO-DO: Colocar a propriedade Message e as demais que se remetem na BaseViewModel
        /// </summary>
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
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
                    if (lstVendas != null)
                        lstVendas.Clear();
            }
        }

        #endregion Properties

        public VendasViewModel()
        {
            vendaEntities = new OlharMeninaBDEntities();
            AddVendasCommand = new Command((s) => true, AddVendas);
            UpdateCommand = new Command((s) => true, Update);
        }

        #region Methods

        private void GetResults(string search)
        {
            if (_search == "*")
            {
                LoadVendas();
                return;
            }
            if (lstVendas != null)
                lstVendas.Clear();

            lstVendas = new ObservableCollection<Venda>();
            var ObjQuery = vendaEntities.Venda.Where(x => x.MetodoPagamento.Contains(_search)).ToList();
            foreach (var funcionario in ObjQuery)
            {
                lstVendas.Add(funcionario);
            }
        }

        private void AddVendas(object obj)
        {
            LoadVendas();
            if (lstVendas == null)
            {
                LoadVendas();
            }
            Venda.CodigoVendas = vendaEntities.Clientes.Count();
            vendaEntities.Venda.Add(Venda);
            try
            {
                vendaEntities.SaveChanges();
                lstVendas.Add(Venda);
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                vendaEntities.Dispose();
                vendaEntities = new OlharMeninaBDEntities();
            }
            Venda = new Venda();
        }

        private void Update(object obj) //Update, recarrega
        {
            SelectedVenda = obj as Venda;
            LoadVendas();
        }

        private void LoadVendas() //Read
        {
            vendaEntities = new OlharMeninaBDEntities();
            lstVendas = new ObservableCollection<Venda>(vendaEntities.Venda);
        }

        #endregion Methods

        #region Commands

        public ICommand AddVendasCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        #endregion Commands
    }
}