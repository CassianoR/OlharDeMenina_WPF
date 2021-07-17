using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel

{
    public class ProdutosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

        private OlharMeninaBDEntities produtosEntities;

        public ProdutosViewModel()
        {
            produtosEntities = new OlharMeninaBDEntities();
            LoadProdutos();
            DeleteCommand = new Command((s) => true, Delete);
            UpdateCommand = new Command((s) => true, Update);
            UpdateProdutoCommand = new Command((s) => true, UpdateProduto); 
            AddProdutoCommand = new Command((s) => true, AddProduto);
        }

        private void AddProduto(object obj)
        {
            Produtos.Codigo = produtosEntities.Clientes.Count();
            produtosEntities.Produtos.Add(Produtos);
            produtosEntities.SaveChanges();
            lstProdutos.Add(Produtos);
            Produtos = new Produtos();
        }

        private void UpdateProduto(object obj) //Update cliente
        {
            int num = 1;
            var uRow = produtosEntities.Produtos.Where(w => w.Codigo == num).FirstOrDefault();
            uRow.NomeProduto = Produtos.NomeProduto;
            uRow.Marca = Produtos.Marca;
            uRow.Categoria = Produtos.Categoria;
            uRow.Descricao = Produtos.Descricao;
            uRow.Valor = Produtos.Valor;
            produtosEntities.SaveChanges();
            SelectedProduto = new Produtos();
        }

        private void Update(object obj) //Update, recarrega
        {
            SelectedProduto = obj as Produtos;
            LoadProdutos();
        }

        private void Delete(object obj) //Delete
        {
            var cl = obj as Produtos;
            produtosEntities.Produtos.Remove(cl);
            produtosEntities.SaveChanges();
            lstProdutos.Remove(cl);
        }

        private void LoadProdutos() //Read
        {
            lstProdutos = new ObservableCollection<Produtos>(produtosEntities.Produtos);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateProdutoCommand { get; set; }
        public ICommand AddProdutoCommand { get; set; }
    }
}