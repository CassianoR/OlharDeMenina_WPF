using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace LojaOlharDeMenina_WPF.View.Modals
{
    /// <summary>
    /// Interação lógica para ModalEditarFuncionarios.xam
    /// </summary>
    public partial class ModalEditarFuncionarios : UserControl
    {
        public ModalEditarFuncionarios()
        {
            InitializeComponent();
            DataContext = new EditarFuncionariosViewModel(id);
        }

        public int id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Atividade { get; set; }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void LimparCampos()
        {
            tboxNome.Text = string.Empty;
            tboxEnde.Text = string.Empty;
            tboxTele.Text = string.Empty;
            tboxLogin.Text = string.Empty;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new EditarFuncionariosViewModel(id);
            LimparCampos();
            tboxNome.Text = Nome;
            tboxEnde.Text = Endereco;
            tboxTele.Text = Telefone;
            tboxLogin.Text = Email;
            cboxAtividade.SelectedItem = Atividade;
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

        private void tboxEndereco_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void tboxTele_TextChanged(object sender, TextChangedEventArgs e)
        {
            LiberaButton();
        }

        private void cboxAtividade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LiberaButton();
        }

        private void LiberaButton()
        {
            if (btnEditar != null)
            {
                if (tboxNome.Text == null || tboxLogin.Text == null || tboxSenha.Text == null || tboxEnde.Text == null || tboxTele.Text == null || cboxAtividade.SelectedIndex == -1 || tboxNome.Text == string.Empty || tboxLogin.Text == string.Empty || tboxSenha.Text == string.Empty || tboxEnde.Text == string.Empty || tboxTele.Text == string.Empty || tboxTele.Text == "(__) _____-____")
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