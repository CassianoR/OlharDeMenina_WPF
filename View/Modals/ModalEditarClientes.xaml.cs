using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LimparCampos()
        {
            tboxNome.Text = string.Empty;
            tboxEnde.Text = string.Empty;
            mtboxTele.Text = string.Empty;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new EditarClientesViewModel(id);
            LimparCampos();
            tboxNome.Text = Nome;
            tboxEnde.Text = Endereco;
            mtboxTele.Text = Telefone;
        }
    }
}