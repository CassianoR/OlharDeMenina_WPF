using LojaOlharDeMenina_WPF.View.Modals;
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
        public Produtos()
        {
            InitializeComponent();
            DataContext = new ProdutosViewModel();
        }

        private ModalAdicionarProduto map = new ModalAdicionarProduto();

        private void btnCadastrarProd_Click(object sender, RoutedEventArgs e)
        {
            //AdicionarProdutosDialog acd = new AdicionarProdutosDialog();
            //acd.ShowDialog();
            stkPanel.Effect = new BlurEffect();
            tboxTitulo.Effect = new BlurEffect();
            btnCadastrarProd.Effect = new BlurEffect();
            btnRecarregar.Effect = new BlurEffect();

            if (MainGrid.Children.Contains(map) == true)
            {
                map.Visibility = Visibility.Visible;
            }
            else
            {
                MainGrid.Children.Add(map);
            }
        }

        private ModalEditarProdutos mep = new ModalEditarProdutos();

        private void AbrirEditarDialog(object sender, RoutedEventArgs e)
        {
            //EditaProdutosDialog epd = new EditaProdutosDialog();
            //ProdutosViewModel pvm = new ProdutosViewModel();
            //pvm.Produtos = (Model.Produtos)datagrid_produto.SelectedItem;
            //mep.Codigo = pvm.Produtos.Codigo;
            //mep.NomeProduto = pvm.Produtos.NomeProduto;
            //mep.Marca = pvm.Produtos.Marca;
            //mep.Descricao = pvm.Produtos.Descricao;
            //mep.Valor = pvm.Produtos.Valor;
            //mep.UnidadeMedida = pvm.Produtos.UnidadeMedida;
            dynamic row = datagrid_produto.SelectedItem;
            mep.Codigo = row.Codigo;
            mep.NomeProduto = row.NomeProduto;
            mep.Marca = row.Marca;
            mep.Descricao = row.Descricao;
            mep.Valor = row.Valor;
            mep.UnidadeMedida = row.UnidadeMedida;
            if (MainGrid.Children.Contains(mep))
            {
                mep.Visibility = Visibility.Visible;
            }
            else
            {
                MainGrid.Children.Add(mep);
            }
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