using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace LojaOlharDeMenina_WPF.View.Modals
{
    /// <summary>
    /// Interação lógica para ModalAdicionarVenda.xam
    /// </summary>
    public partial class ModalAdicionarVenda : UserControl
    {
        public ModalAdicionarVenda()
        {
            InitializeComponent();
            DataContext = new AdicionarVendaViewModel();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
