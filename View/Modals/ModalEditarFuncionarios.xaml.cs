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
            DataContext = new FuncionariosViewModel();
        }

        public int id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

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
            mtboxTele.Text = string.Empty;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LimparCampos();
            tboxNome.Text = Nome;
            tboxEnde.Text = Endereco;
            mtboxTele.Text = Telefone;
        }

        private void btnEditar_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }
}