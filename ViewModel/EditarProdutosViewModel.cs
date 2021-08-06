using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class EditarProdutosViewModel : ObservableObject
    {
        #region Properties

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
        }

        #endregion Constructor

        #region Methods

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
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                produtosEntities.Dispose();
                produtosEntities = new OlharMeninaBDEntities();
            }
        }

        #endregion Methods

        #region Commands

        public ICommand EditProdutoCommand { get; set; }

        #endregion Commands
    }
}