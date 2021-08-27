using LojaOlharDeMenina_WPF.View.Modals;
using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para Vendas.xam
    /// </summary>
    public partial class Vendas : UserControl
    {
        public Vendas()
        {
            InitializeComponent();
            DataContext = new VendasViewModel();
        }

        private ModalAdicionarVenda mav = new ModalAdicionarVenda();

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //AdicionarFuncionariosDialog acd = new AdicionarFuncionariosDialog();
            //acd.ShowDialog();
            stkPanelVendas.Effect = new BlurEffect();
            tboxVendasTitulo.Effect = new BlurEffect();
            if (MainGridVendas.Children.Contains(mav) == true)
            {
                mav.Visibility = Visibility.Visible;
            }
            else
            {
                MainGridVendas.Children.Add(mav);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void MainGridVendas_GotFocus(object sender, RoutedEventArgs e)
        {
            stkPanelVendas.Effect = null;
            tboxVendasTitulo.Effect = null;
        }

        private void btnadd_produto_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}