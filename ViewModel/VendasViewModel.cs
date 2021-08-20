using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class VendasViewModel : ObservableObject
    {
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

        private ObservableCollection<Produtos> _lstProdutos2;

        public ObservableCollection<Produtos> lstProdutos2
        {
            get { return _lstProdutos2; }
            set
            {
                _lstProdutos2 = value;
                OnPropertyChanged(nameof(lstProdutos2));
            }
        }

        private ObservableCollection<Produtos> _lstProdutos;

        public ObservableCollection<Produtos> lstProdutos
        {
            get { return _lstProdutos; }
            set
            {
                _lstProdutos = value;
                OnPropertyChanged(nameof(lstProdutos));
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

        private Produtos _produtos = new Produtos();

        public Produtos Produtos
        {
            get { return _produtos; }
            set
            {
                _produtos = value;
                OnPropertyChanged(nameof(Produtos));
            }
        }

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

        private OlharMeninaBDEntities vendaEntities;
        private Exceptions exc = new Exceptions();

        #endregion Properties

        #region Constructor

        public VendasViewModel()
        {
            vendaEntities = new OlharMeninaBDEntities();
            UpdateCommand = new Command((s) => true, Update);
            UpdateGridCommand = new Command((s) => true, UpdateGrid);
        }

        #endregion Constructor

        #region Methods

        private async void GetResults(string search)
        {
            if (_search == "*")
            {
                LoadVendas();
                return;
            }
            if (lstVendas != null)
                lstVendas.Clear();

            lstVendas = new ObservableCollection<Venda>();
            var ObjQuery = await vendaEntities.Venda.Where(x => x.MetodoPagamento.Contains(_search) || x.Funcionarios.LoginFuncionario.Contains(_search) | x.Clientes.CPF.Contains(_search)).ToListAsync();
            foreach (var venda in ObjQuery)
            {
                lstVendas.Add(venda);
            }
        }

        private void Update(object obj) //Update, recarrega
        {
            SelectedVenda = obj as Venda;
            LoadVendas();
        }

        private async void LoadVendas() //Read
        {
            vendaEntities = new OlharMeninaBDEntities();
            var lista1 = await vendaEntities.Venda.ToListAsync();
            lstVendas = new ObservableCollection<Venda>(lista1);

            var lista2 = await vendaEntities.Produtos.ToListAsync();
            lstProdutos = new ObservableCollection<Produtos>(lista2);
        }

        private void UpdateGrid(object obj)
        {
            LoadGridVendas();
        }

        private async void LoadGridVendas()
        {
            var grid = await vendaEntities.Produtos.Where(o => o.Codigo == Produtos.Codigo).FirstOrDefaultAsync();
            lstProdutos2.Add(grid);
        }

        #endregion Methods

        #region Commands

        public ICommand UpdateCommand { get; set; }

        public ICommand UpdateGridCommand { get; set; }

        #endregion Commands
    }
}