﻿using System.Windows.Controls;
using LojaOlharDeMenina_WPF.ViewModel;
namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para Produtos.xam
    /// </summary>
    public partial class Produtos : UserControl
    {
        public Produtos()
        {
            InitializeComponent();
            DataContext = new ProdutosViewModel();
        }

        private void btnCadastrar_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}