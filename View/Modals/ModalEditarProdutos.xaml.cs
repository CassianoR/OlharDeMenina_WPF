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
            tboxNome.Text = NomeProduto;
            tboxMarca.Text = Marca;
            cboxCategoria.Text = Categoria;
            tboxDescricao.Text = Descricao;
            tboxValor.Text = Valor.ToString();
            DataContext = new EditarProdutosViewModel(Codigo);
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

        private void tboxNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxMarca_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxDesc_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxValor_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxUnidadeMed_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void cboxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LiberaButton();
        }

        private void LiberaButton()
        {
            if (btnEditar != null)
            {
                if (tboxNome.Text == null || tboxMarca.Text == null || tboxDescricao.Text == null || tboxUnidade == null || tboxValor.Text == "0" || cboxCategoria.Text == null || tboxNome.Text == string.Empty || tboxMarca.Text == string.Empty || tboxDescricao.Text == string.Empty || tboxUnidade.Text == string.Empty || tboxValor.Text == string.Empty || cboxCategoria.Text == string.Empty)
                {
                    btnEditar.IsEnabled = false;
                }
                else
                {
                    btnEditar.IsEnabled = true;
                }
            }
        }
    }
}