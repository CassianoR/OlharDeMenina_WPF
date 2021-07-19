using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View.Dialogs
{
    /// <summary>
    /// Lógica interna para AdicionarClientesDialog.xaml
    /// </summary>
    public partial class AdicionarProdutosDialog : Window
    {
        private int cont;

        public AdicionarProdutosDialog()
        {
            InitializeComponent();
            DataContext = new ProdutosViewModel();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            btnCadastrar.IsEnabled = false;
            btnCadastrar.Opacity = 0.5;
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

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tboxNome_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (tboxNome.Text.Length > 2)
            {
                cont = 1;
                LiberaButton(cont);
            }
        }

        private void tboxMarca_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (tboxMarca.Text.Length > 3)
            {
                cont = 2;
                LiberaButton(cont);
            }
        }

        private void tboxDesc_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (tboxDesc.Text.Length > 5)
            {
                cont = 3;
                LiberaButton(cont);
            }
        }

        private void tboxValor_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (tboxValor.Text != "00.00")
            {
                cont = 4;
                LiberaButton(cont);
            }
        }

        private void tboxUnidadeMed_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (tboxUnidadeMed.Text != null)
            {
                cont = 5;
                LiberaButton(cont);
            }
        }

        private void LiberaButton(int value)
        {
            if (value == 5)
            {
                btnCadastrar.IsEnabled = true;
                btnCadastrar.Opacity = 1;
            }
        }

        
    }
}