using LojaOlharDeMenina_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            DataContext = new ProdutosViewModel();
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

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            //Window.GetWindow(this).Close();
            //this.Visibility = Visibility.Collapsed;
            this.Visibility = Visibility.Collapsed;
        }

        private void tboxNome_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxMarca_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxDesc_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxValor_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxUnidadeMed_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void LiberaButton()
        {
            if (tboxNome.Text == null || tboxMarca.Text == null || tboxDesc.Text == null || tboxUnidadeMed.Text == null || tboxValor.Text == "00.00" || cboxCategoria.Text == null)
            {
                btnCadastrar.IsEnabled = false;
                btnCadastrar.Opacity = 0.5;
            }
            else
            {
                btnCadastrar.IsEnabled = true;
                btnCadastrar.Opacity = 1;
            }
        }
    }
}
