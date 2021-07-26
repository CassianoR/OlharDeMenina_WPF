using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        public string username { get; set; }
        public string password { get; set; }
        public string idFunc { get; set; }
        public bool Adm { get; set; }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void rbMenu_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeViewModel();
        }

        private void rbVendas_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new VendasViewModel();
        }

        private void rbFunc_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new FuncionariosViewModel();
        }

        private void rbCli_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ClientesViewModel();
        }

        private void rbProd_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ProdutosViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeViewModel();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_contacts.Visibility = Visibility.Collapsed;
                tt_messages.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_messages.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            contentControl.Opacity = 1;
            nav_pnl.Background.Opacity = 0.394;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            contentControl.Opacity = 0.3;
            nav_pnl.Background.Opacity = 0.7;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnClientes_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new ClientesViewModel();
        }

        private void btnHome_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new HomeViewModel();
        }

        private void btnFuncionarios_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new FuncionariosViewModel();
        }

        private void btnProdutos_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new ProdutosViewModel();
        }
    }
}