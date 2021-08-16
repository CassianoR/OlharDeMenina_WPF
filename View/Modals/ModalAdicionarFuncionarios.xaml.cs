using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View.Modals
{
    /// <summary>
    /// Interação lógica para ModalAdicionarFuncionarios.xam
    /// </summary>
    public partial class ModalAdicionarFuncionarios : UserControl
    {
        public ModalAdicionarFuncionarios()
        {
            InitializeComponent();
            DataContext = new AdicionarFuncionariosViewModel();
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

        private void tboxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxSenha_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxCargo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxEndereco_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxTele_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void LiberaButton()
        {
            if (btnCadastrar != null)
            {
                if (tboxNome.Text == null || tboxCPF.Text == null || tboxLogin.Text == null || tboxSenha.Text == null || tboxCargo.SelectedIndex == -1 || tboxEndereco.Text == null || tboxTele.Text == null || tboxNome.Text == string.Empty || tboxCPF.Text == string.Empty || tboxLogin.Text == string.Empty || tboxSenha.Text == string.Empty || tboxEndereco.Text == string.Empty || tboxTele.Text == string.Empty)
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