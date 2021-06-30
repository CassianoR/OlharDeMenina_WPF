﻿using LojaOlharDeMenina_WPF.ViewModel;
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else if (WindowState == WindowState.Normal)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

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
    }
}