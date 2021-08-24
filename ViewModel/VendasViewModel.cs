using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System;
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

        private ObservableCollection<Funcionarios> _lstFuncionarios;

        public ObservableCollection<Funcionarios> lstFuncionarios
        {
            get { return _lstFuncionarios; }
            set
            {
                _lstFuncionarios = value;
                OnPropertyChanged(nameof(lstFuncionarios));
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

        // Mensagem
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        // Valor líquido
        private decimal valorLiquido;

        public decimal ValorLiquido
        {
            get
            {
                return valorLiquido;
            }
            set
            {
                valorLiquido = value;
                OnPropertyChanged("ValorLiquido");
            }
        }

        // Valor pago
        private decimal valorPago;

        public decimal ValorPago
        {
            get
            {
                return valorPago;
            }
            set
            {
                valorPago = value;
                OnPropertyChanged("ValorPago");
            }
        }

        // Troco
        private decimal troco;

        public decimal Troco
        {
            get
            {
                return troco;
            }
            set
            {
                troco = value;
                OnPropertyChanged("Troco");
            }
        }

        // Pesquisa
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
            if (search == "*")
            {
                LoadVendas();
                return;
            }
            if (lstVendas != null)
                lstVendas.Clear();

            lstVendas = new ObservableCollection<Venda>();
            var ObjQuery = await vendaEntities.Venda.Where(x => x.MetodoPagamento.Contains(search) || x.Funcionarios.LoginFuncionario.Contains(search) | x.Clientes.CPF.Contains(search)).ToListAsync();
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

            var listaClientes = await vendaEntities.Clientes.ToListAsync();
            lstClientes = new ObservableCollection<Clientes>(listaClientes);

            var listaFuncionarios = await vendaEntities.Funcionarios.ToListAsync();
            lstFuncionarios = new ObservableCollection<Funcionarios>(listaFuncionarios);
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

        private void CalculaVendas()
        {
            foreach (var item in lstProdutos2)
            {
                ValorLiquido += item.Valor;
            }
            Troco = ValorPago - ValorLiquido;
        }

        #endregion Methods

        #region Commands

        public ICommand UpdateCommand { get; set; }

        public ICommand UpdateGridCommand { get; set; }

        #endregion Commands
    }
}