using LojaOlharDeMenina_WPF.View.Dialogs;
using LojaOlharDeMenina_WPF.View.Modal;
using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para Produtos.xam
    /// </summary>
    public partial class Produtos : UserControl
    {
        private ModalAdicionarProduto map = new ModalAdicionarProduto();
        private ModalEditarProdutos mep = new ModalEditarProdutos();
        public Produtos()
        {
            InitializeComponent();
            DataContext = new ProdutosViewModel();
        }

        private void btnCadastrarProd_Click(object sender, RoutedEventArgs e)
        {

            if (MainGrid.Children.Contains(map) == true)
            {
                map.Visibility = Visibility.Visible;
            }
            else
            {
                MainGrid.Children.Add(map);
            }
        }

        private void AbrirEditarDialog(object sender, RoutedEventArgs e)
        {
            if (MainGrid.Children.Contains(mep) == true)
            {
                map.Visibility = Visibility.Visible;
            }
            else
            {
                MainGrid.Children.Add(mep);
            }
        }
    }
}