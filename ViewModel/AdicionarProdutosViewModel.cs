using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class AdicionarProdutosViewModel : ObservableObject
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

        private OlharMeninaBDEntities produtosEntities;
        private Exceptions exc = new Exceptions();

        #endregion Properties

        #region Constructor

        public AdicionarProdutosViewModel()
        {
            produtosEntities = new OlharMeninaBDEntities();
            AddProdutoCommand = new Command((s) => true, AddProduto);
            LoadProdutos();
        }

        #endregion Constructor

        #region Methods

        private void AddProduto(object obj)
        {
            if (produtosEntities == null)
                produtosEntities = new OlharMeninaBDEntities();
            Produtos.Codigo = produtosEntities.Clientes.Count();
            System.Console.Write(Produtos.Valor);
            var count = produtosEntities.Categoria
                                .Where(o => o.NomeCategoria == Produtos.FK_NomeCategoria)
                                .Count();
            if (count != 1)
            {
                System.Windows.MessageBoxResult criarConfirma = System.Windows.MessageBox.Show("Não existe uma categoria com esse nome. Deseja criá-la?", "Criar nova categoria?", System.Windows.MessageBoxButton.OKCancel);
                if (criarConfirma == System.Windows.MessageBoxResult.Cancel)
                {
                    return;
                }
                Categoria categoria = new Categoria();
                categoria.NomeCategoria = Produtos.FK_NomeCategoria;
                produtosEntities.Categoria.Add(categoria);
            }
            produtosEntities.Produtos.Add(Produtos);
            try
            {
                produtosEntities.SaveChanges();
                Produtos = new Produtos();
                Message = "Cadastrado com sucesso!";
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

        public ICommand AddProdutoCommand { get; set; }

        #endregion Commands
    }
}