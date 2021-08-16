using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class EditarProdutosViewModel : ObservableObject
    {
        #region Properties

        private ObservableCollection<Categoria> _lstCategoria;

        public ObservableCollection<Categoria> lstCategoria
        {
            get { return _lstCategoria; }
            set
            {
                _lstCategoria = value;
                OnPropertyChanged(nameof(lstCategoria));
            }
        }

        private Produtos _produtos = new Produtos();

        public bool buttonenablebool = false;
        public double buttonopacidadedouble = 0.5;

        public Produtos Produtos
        {
            get { return _produtos; }
            set
            {
                _produtos = value;
                OnPropertyChanged(nameof(Produtos));
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

        private Produtos _selectedProduto = new Produtos();

        public Produtos SelectedProduto
        {
            get { return _selectedProduto; }
            set
            {
                _selectedProduto = value;
                OnPropertyChanged(nameof(SelectedProduto));
            }
        }

        private OlharMeninaBDEntities produtosEntities;
        private Exceptions exc = new Exceptions();
        private int _codigo;

        #endregion Properties

        #region Constructor

        public EditarProdutosViewModel(int codigo)
        {
            _codigo = codigo;
            produtosEntities = new OlharMeninaBDEntities();
            EditProdutoCommand = new Command((s) => true, EditProduto);
            LoadProdutos();
        }

        #endregion Constructor

        #region Methods


        private void ButtonAtivado()
        {
            if (Produtos.NomeProduto.ToString() == null || Produtos.Marca.ToString() == null || Produtos.Descricao.ToString() == null || Produtos.UnidadeMedida == null || Produtos.Valor.ToString() == "00.00" || Produtos.Categoria == null)
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
            if (Produtos.NomeProduto == null || Produtos.Marca == null || Produtos.Descricao == null || Produtos.UnidadeMedida == null || Produtos.Valor.ToString() == "00.00" || Produtos.Categoria == null)
            {
                buttonopacidadedouble = 0.5;
            }
            else
            {
                buttonopacidadedouble = 1;
            }
        }

        private void EditProduto(object obj)
        {
            try
            {
                var uRow = produtosEntities.Produtos.Where(w => w.Codigo == _codigo).FirstOrDefault();
                uRow.NomeProduto = Produtos.NomeProduto;
                uRow.Marca = Produtos.Marca;
                uRow.Descricao = Produtos.Descricao;
                uRow.Valor = Produtos.Valor;
                produtosEntities.SaveChanges();
                Produtos = new Produtos();
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
            var lista = await produtosEntities.Categoria.ToListAsync();
            lstCategoria = new ObservableCollection<Categoria>(lista);
        }

        #endregion Methods

        #region Commands

        public ICommand EditProdutoCommand { get; set; }

        #endregion Commands
    }
}