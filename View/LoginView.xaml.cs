using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class Login : Window
    {
        private LoginViewModel _loginViewModel = new LoginViewModel();

        public Login()
        {
            InitializeComponent();
            //DataContext = LoginViewModel();
            this.DataContext = _loginViewModel;
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                System.Windows.Application.Current.Shutdown();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}