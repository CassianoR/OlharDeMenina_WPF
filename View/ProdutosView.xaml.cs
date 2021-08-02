using LojaOlharDeMenina_WPF.View.Dialogs;
using LojaOlharDeMenina_WPF.View.Modal;
using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

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
<<<<<<< HEAD

            if (MainGrid.Children.Contains(map) == true)
            {
                map.Visibility = Visibility.Visible;
            }
            else
            {
                MainGrid.Children.Add(map);
            }
=======
            //AdicionarProdutosDialog acd = new AdicionarProdutosDialog();
            //acd.ShowDialog();
            stkPanel.Effect = new BlurEffect();
            tboxTitulo.Effect = new BlurEffect();
            btnCadastrarProd.Effect = new BlurEffect();
            btnRecarregar.Effect = new BlurEffect();

            MainGrid.Children.Add(new ModalAdicionarProduto());
>>>>>>> ba09893d6b90f575b47abdf74eaf1f1dd1cb0b4e
        }

        private void AbrirEditarDialog(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            if (MainGrid.Children.Contains(mep) == true)
            {
                map.Visibility = Visibility.Visible;
            }
            else
            {
                MainGrid.Children.Add(mep);
            }
=======
            EditaProdutosDialog epd = new EditaProdutosDialog();
            ProdutosViewModel pvm = new ProdutosViewModel();
            //pvm.Produtos = (Model.Produtos)datagrid_produto.SelectedItem;
            epd.Codigo = pvm.Produtos.Codigo;
            epd.NomeProduto = pvm.Produtos.NomeProduto;
            epd.Marca = pvm.Produtos.Marca;
            epd.Descricao = pvm.Produtos.Descricao;
            epd.Valor = pvm.Produtos.Valor;
            epd.ShowDialog();
>>>>>>> ba09893d6b90f575b47abdf74eaf1f1dd1cb0b4e
        }

        private void MainGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            stkPanel.Effect = null;
            tboxTitulo.Effect = null;
            btnCadastrarProd.Effect = null;
            btnRecarregar.Effect = null;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //datagrid_produto.Visibility = Visibility.Hidden;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (datagrid_produto.Items.Count > 0)
            //    datagrid_produto.Visibility = Visibility.Visible;
            //else
            //    datagrid_produto.Visibility = Visibility.Hidden;

            //if (SearchBox.Text.Length <= 2)
            //{
            //    if (SearchBox.Text != "*")
            //        datagrid_produto.Visibility = Visibility.Hidden;
            //    else
            //        datagrid_produto.Visibility = Visibility.Visible;
            //}
            //else
            //    datagrid_produto.Visibility = Visibility.Visible;
        }
    }
}