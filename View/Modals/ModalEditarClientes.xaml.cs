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
            DataContext = new ClientesViewModel();
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
            LimparCampos();
            tboxNome.Text = Nome;
            tboxEnde.Text = Endereco;
            mtboxTele.Text = Telefone;
        }

    }
}
