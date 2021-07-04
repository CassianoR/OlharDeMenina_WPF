using LojaOlharDeMenina_WPF.Model;
using System;
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

        private ObservableCollection<Produtos> _lstprodutos;

        public ObservableCollection<Produtos> lstProdutos
        {
            get { return _lstprodutos; }
            set
            {
                _lstprodutos = value;
                OnPropertyChanged(nameof(lstProdutos));
            }
        }

        private Produtos _selectedProduto;

        public Produtos SelectedProduto
        {
            get { return _selectedProduto; }
            set
            {
                _selectedProduto = value;
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
        private OlhardeMeninaBDEntities produtosEntities;

        public ProdutosViewModel()
        {
            produtosEntities = new OlhardeMeninaBDEntities();
            LoadProduto();
            DeleteCommand = new CommandProd((s) => true, Delete);
            UpdateCommand = new CommandProd((s) => true, Update);
            UpdateProdutoCommand = new CommandProd((s) => true, UpdateProduto);
            AddProdutoCommand = new CommandProd((s) => true, AddProduto);
        }

        private void AddProduto(object obj)
        {
            Produtos.Codigo = produtosEntities.Produtos.Count();
            produtosEntities.Produtos.Add(Produtos);
            produtosEntities.SaveChanges();
            lstProdutos.Add(Produtos);
            Produtos = new Produtos();
        }

            private void UpdateProduto(object obj) //Update cliente
            {
                produtosEntities.SaveChanges();
                SelectedProduto = new Produtos();
            }

            private void Update(object obj) //Update, recarrega
            {
                SelectedProduto = obj as Produtos;
                LoadProduto();
            }

            private void Delete(object obj) //Delete
            {
                var pro = obj as Produtos;
                produtosEntities.Produtos.Remove(pro);
                produtosEntities.SaveChanges();
                lstProdutos.Remove(pro);
            }

            private void LoadProduto() //Read
            {
                lstProdutos = new ObservableCollection<Produtos>(produtosEntities.Produtos);
            }

            public ICommand DeleteCommand { get; set; }
            public ICommand UpdateCommand { get; set; }
            public ICommand UpdateProdutoCommand { get; set; }
            public ICommand AddProdutoCommand { get; set; }
    }

        internal class CommandProd : ICommand
        {
            public CommandProd(Func<object, bool> methodCanExecute, Action<object> methodExecute)
            {
                MethodCanExecute = methodCanExecute;
                MethodExecute = methodExecute;
            }

            private Action<object> MethodExecute;
            private Func<object, bool> MethodCanExecute;

            public bool CanExecute(object parameter)
            {
                return MethodExecute != null && MethodCanExecute.Invoke(parameter);
            }

            public void Execute(object parameter)
            {
                MethodExecute(parameter);
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }
}