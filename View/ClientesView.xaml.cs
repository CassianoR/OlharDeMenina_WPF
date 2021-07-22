using LojaOlharDeMenina_WPF.View.Dialogs;
using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para Cliente.xam
    /// </summary>
    public partial class Clientes : UserControl
    {
        public Clientes()
        {
            InitializeComponent();
            DataContext = new ClientesViewModel();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            AdicionarClientesDialog acd = new AdicionarClientesDialog();
            acd.ShowDialog();
        }
    }
}