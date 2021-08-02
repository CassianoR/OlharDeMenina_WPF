using LojaOlharDeMenina_WPF.View.Dialogs;
using LojaOlharDeMenina_WPF.View.Modals;
using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

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

        private ModalAdicionarClientes mac = new ModalAdicionarClientes();

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //AdicionarClientesDialog acd = new AdicionarClientesDialog();
            //acd.ShowDialog();

            stkClientesPanel.Effect = new BlurEffect();
            tboxClienteTitulo.Effect = new BlurEffect();
            btnCadastrar.Effect = new BlurEffect();
            btnRecarregar.Effect = new BlurEffect();

            if (MainGrid.Children.Contains(mac) == true)
            {
                mac.Visibility = Visibility.Visible;
            }
            else
            {
                MainGrid.Children.Add(mac);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //datagrid_cliente.Visibility = Visibility.Hidden;
        }

        private void MainGridClientes_GotFocus(object sender, RoutedEventArgs e)
        {
            stkClientesPanel.Effect = null;
            tboxClienteTitulo.Effect = null;
            btnCadastrar.Effect = null;
            btnRecarregar.Effect = null;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (datagrid_cliente.Items.Count > 0)
            //    datagrid_cliente.Visibility = Visibility.Visible;
            //else
            //    datagrid_cliente.Visibility = Visibility.Hidden;

            //if (SearchBox.Text.Length <= 2)
            //{
            //    if (SearchBox.Text != "*")
            //        datagrid_cliente.Visibility = Visibility.Hidden;
            //    else
            //        datagrid_cliente.Visibility = Visibility.Visible;
            //}
            //else
            //    datagrid_cliente.Visibility = Visibility.Visible;
        }
    }
}