using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Validation;
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
            try 
            { 
                produtosEntities.SaveChanges();
                lstProdutos.Add(Produtos);
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("\n", errorMessages);
                var exceptionMessage = string.Concat(fullErrorMessage);
                //System.Windows.MessageBox.Show(exceptionMessage, ex.EntityValidationErrors.ToString());
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
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("\n", errorMessages);
                var exceptionMessage = string.Concat(fullErrorMessage);
                //System.Windows.MessageBox.Show(exceptionMessage, ex.EntityValidationErrors.ToString());
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
            var cl = obj as Produtos;
            produtosEntities.Produtos.Remove(cl);
            try
            {
                produtosEntities.SaveChanges();
                lstProdutos.Remove(cl);
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("\n", errorMessages);
                var exceptionMessage = string.Concat(fullErrorMessage);
                //System.Windows.MessageBox.Show(exceptionMessage, ex.EntityValidationErrors.ToString());
                Message = exceptionMessage;
                produtosEntities.Dispose();
                produtosEntities = new OlharMeninaBDEntities();
            }

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