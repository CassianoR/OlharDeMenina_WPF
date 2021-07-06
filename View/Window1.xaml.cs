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
            if (Adm == false) 
            {
                rbFunc.Visibility = Visibility.Hidden;
                rbProd.Visibility = Visibility.Hidden;
            }
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
    }
}