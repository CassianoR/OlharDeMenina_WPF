using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
        }

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

        private void btnEditar_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }
}