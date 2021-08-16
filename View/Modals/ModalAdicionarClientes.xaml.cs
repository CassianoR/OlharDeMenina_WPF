using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View.Modals
{
    /// <summary>
    /// Interação lógica para ModalAdicionarClientes.xam
    /// </summary>
    public partial class ModalAdicionarClientes : UserControl
    {
        public ModalAdicionarClientes()
        {
            InitializeComponent();
            DataContext = new AdicionarClientesViewModel();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
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

        private void tboxCPF_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxEnde_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxTelefone_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxData_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void LiberaButton()
        {
            if (btnCadastrar != null)
            {
                if (tboxNome.Text == null || tboxCPF.Text == null || tboxEnde.Text == null || tboxTelefone.Text == null || tboxData.Text == null || tboxNome.Text == string.Empty || tboxCPF.Text == string.Empty || tboxEnde.Text == string.Empty || tboxTelefone.Text == string.Empty || tboxData.Text == string.Empty || tboxTelefone.Text == "(__) _____-____" || tboxCPF.Text == "___.___.___-__" || tboxData.Text == "__/__/____")
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