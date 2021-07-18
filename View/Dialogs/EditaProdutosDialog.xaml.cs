using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View.Dialogs
{
    /// <summary>
    /// Lógica interna para EditaProdutosDialog.xaml
    /// </summary>
    public partial class EditaProdutosDialog : Window
    {
        public EditaProdutosDialog()
        {
            InitializeComponent();
            DataContext = new ProdutosViewModel();
        }

        public int Codigo { get; set; }
        public string NomeProduto { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProdCodigo.Content = Codigo;
            ProdNome.Text = NomeProduto;
            ProdMarca.Text = Marca;
            ProdCategoria.Text = Categoria;
            ProdDescricao.Text = Descricao;
            ProdValor.Text = Valor.ToString();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }
    }
}