using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel

{
    public class ProdutosViewModel : ObservableObject
    {
        #region Properties

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

        private Produtos _selectedProdutos;

        public Produtos SelectedProduto
        {
            get { return _selectedProdutos; }
            set
            {
                _selectedProdutos = value;
                OnPropertyChanged(nameof(SelectedProduto));
            }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
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
                    if (lstProdutos != null)
                        lstProdutos.Clear();
            }
        }

        private readonly ObservableCollection<string> _results = new ObservableCollection<string>();

        public ObservableCollection<string> Results
        {
            get
            {
                return _results;
            }
        }

        #endregion Properties

        private OlharMeninaBDEntities produtosEntities;
        private Exceptions exc = new Exceptions();

        public ProdutosViewModel()
        {
            produtosEntities = new OlharMeninaBDEntities();
            //LoadProdutos();
            DeleteCommand = new Command((s) => true, Delete);
            UpdateCommand = new Command((s) => true, Update);
            UpdateProdutoCommand = new Command((s) => true, UpdateProduto);
            AddProdutoCommand = new Command((s) => true, AddProduto);
        }

        #region Methods

        private void GetResults(string search)
        {
            if (_search == "*")
            {
                LoadProdutos();
                return;
            }
            if (lstProdutos != null)
                lstProdutos.Clear();

            lstProdutos = new ObservableCollection<Produtos>();
            _results.Clear();
            var ObjQuery = produtosEntities.Produtos.Where(x => x.NomeProduto.Contains(_search) || x.Marca.Contains(_search) || x.FK_NomeCategoria.Contains(_search)).ToList();
            foreach (var employee in ObjQuery)
            {
                _results.Add(employee.NomeProduto);
                lstProdutos.Add(employee);
            }
        }

        private void AddProduto(object obj)
        {
            Produtos.Codigo = produtosEntities.Clientes.Count();
            produtosEntities.Produtos.Add(Produtos);
            try
            {
                produtosEntities.SaveChanges();
                lstProdutos.Add(Produtos);
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                produtosEntities.Dispose();
                produtosEntities = new OlharMeninaBDEntities();
            }

            Produtos = new Produtos();
        }

        private void UpdateProduto(object obj) //Update cliente
        {
            //var ObjEmployee = produtosEntities.Produtos.Find(Produtos.Codigo);
            //SelectedProduto = obj as Produtos;
            //System.Windows.MessageBox.Show(SelectedProduto.Codigo.ToString());

            try
            {
                int num = 1;
                var uRow = produtosEntities.Produtos.Where(w => w.Codigo == num).FirstOrDefault();
                uRow.NomeProduto = Produtos.NomeProduto;
                uRow.Marca = Produtos.Marca;
                uRow.Descricao = Produtos.Descricao;
                uRow.Valor = Produtos.Valor;
                produtosEntities.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                produtosEntities.Dispose();
                produtosEntities = new OlharMeninaBDEntities();
            }
            SelectedProduto = new Produtos();
        }

        private void Update(object obj) //Update, recarrega
        {
            SelectedProduto = obj as Produtos;
            LoadProdutos();
        }

        private void Delete(object obj) //Delete
        {
            System.Windows.MessageBoxResult deletarConfirma = System.Windows.MessageBox.Show("Você tem certeza que quer deletar esse produto?", "Deletar?", System.Windows.MessageBoxButton.OKCancel);
            if (deletarConfirma == System.Windows.MessageBoxResult.Cancel)
            {
                return;
            }

            try
            {
                var cl = obj as Produtos;
                produtosEntities.Produtos.Remove(cl);
                produtosEntities.SaveChanges();
                lstProdutos.Remove(cl);
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                produtosEntities.Dispose();
                produtosEntities = new OlharMeninaBDEntities();
            }
        }

        private void LoadProdutos() //Read
        {
            lstProdutos = new ObservableCollection<Produtos>(produtosEntities.Produtos);
        }

        #endregion Methods

        #region Commands

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateProdutoCommand { get; set; }
        public ICommand AddProdutoCommand { get; set; }

        #endregion Commands
    }
}