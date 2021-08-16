using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

        private OlharMeninaBDEntities produtosEntities;
        private Exceptions exc = new Exceptions();

        #endregion Properties

        #region Constructor

        public ProdutosViewModel()
        {
            produtosEntities = new OlharMeninaBDEntities();
            //LoadProdutos();
            DeleteCommand = new Command((s) => true, Delete);
            UpdateCommand = new Command((s) => true, Update);
        }

        #endregion Constructor

        #region Methods

        private async void GetResults(string search)
        {
            if (search == "*")
            {
                LoadProdutos();
                return;
            }
            lstProdutos = new ObservableCollection<Produtos>();
            produtosEntities = new OlharMeninaBDEntities();
            var ObjQuery = await produtosEntities.Produtos.Where(x => x.NomeProduto.Contains(search) || x.Marca.Contains(search) || x.FK_NomeCategoria.Contains(search)).ToListAsync();
            foreach (var produto in ObjQuery)
            {
                lstProdutos.Add(produto);
            }
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

        private async void LoadProdutos() //Read
        {
            produtosEntities = new OlharMeninaBDEntities();
            var lista = await produtosEntities.Produtos.ToListAsync();
            lstProdutos = new ObservableCollection<Produtos>(lista);
        }

        #endregion Methods

        #region Commands

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        #endregion Commands
    }
}