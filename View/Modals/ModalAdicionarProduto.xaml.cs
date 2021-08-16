using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para ModalAdicionarProduto.xam
    /// </summary>
    public partial class ModalAdicionarProduto : UserControl
    {
        public ModalAdicionarProduto()
        {
            InitializeComponent();
            DataContext = new AdicionarProdutosViewModel();
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

        private void LiberaButton()
        {
            if (btnCadastrar != null)
            {
                if (tboxNome.Text == null || tboxMarca.Text == null || tboxDesc.Text == null || tboxUnidadeMed == null || tboxValor.Text == "0" || cboxCategoria.Text == null || tboxNome.Text == string.Empty || tboxMarca.Text == string.Empty || tboxDesc.Text == string.Empty || tboxUnidadeMed.Text == string.Empty || tboxValor.Text == string.Empty || cboxCategoria.Text == string.Empty)
                {
                    btnCadastrar.IsEnabled = false;
                }
                else
                {
                    btnCadastrar.IsEnabled = true;
                }
            }
        }
    }
}