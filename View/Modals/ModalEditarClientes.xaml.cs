using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace LojaOlharDeMenina_WPF.View.Modals
{
    /// <summary>
    /// Interação lógica para ModalEditarClientes.xam
    /// </summary>
    public partial class ModalEditarClientes : UserControl
    {
        public ModalEditarClientes()
        {
            InitializeComponent();
            DataContext = new EditarClientesViewModel(id);
        }

        public int id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void LimparCampos()
        {
            tboxNome.Text = string.Empty;
            tboxEnde.Text = string.Empty;
            tboxTelefone.Text = string.Empty;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new EditarClientesViewModel(id);
            LimparCampos();
            tboxNome.Text = Nome;
            tboxEnde.Text = Endereco;
            tboxTelefone.Text = Telefone;
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
            if (btnEditar != null)
            {
                if (tboxNome.Text == null || tboxCPF.Text == null || tboxEnde.Text == null || tboxTelefone.Text == null || tboxData.Text == null || tboxNome.Text == string.Empty || tboxCPF.Text == string.Empty || tboxEnde.Text == string.Empty || tboxTelefone.Text == string.Empty || tboxData.Text == string.Empty || tboxTelefone.Text == "(__) _____-____" || tboxCPF.Text == "___.___.___-__" || tboxData.Text == "__/__/____")
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