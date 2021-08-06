using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View.Modals
{
    /// <summary>
    /// Interação lógica para ModalEditaProdutos.xam
    /// </summary>
    public partial class ModalEditarProdutos : UserControl
    {
        public ModalEditarProdutos()
        {
            InitializeComponent();
            DataContext = new EditarProdutosViewModel(Codigo);
        }

        public int Codigo { get; set; }
        public string NomeProduto { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string UnidadeMedida { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProdCodigo.Text = Codigo.ToString();
            ProdNome.Text = NomeProduto;
            ProdMarca.Text = Marca;
            ProdCategoria.Text = Categoria;
            ProdDescricao.Text = Descricao;
            ProdValor.Text = Valor.ToString();
            DataContext = new EditarProdutosViewModel(Codigo);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            //this.DragMove();
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Visibility = Visibility.Collapsed;
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}