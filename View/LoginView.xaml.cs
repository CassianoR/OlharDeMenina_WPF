﻿using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class Login : Window
    {
        private readonly LoginViewModel _loginViewModel;

        public Login()
        {
            InitializeComponent();
            //DataContext = LoginViewModel();
            _loginViewModel = DataContext as LoginViewModel;
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