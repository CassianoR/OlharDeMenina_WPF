using LojaOlharDeMenina_WPF.View.Dialogs;
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

        private void btnCadastrarProd_Click(object sender, RoutedEventArgs e)
        {
            //AdicionarProdutosDialog acd = new AdicionarProdutosDialog();
            //acd.ShowDialog();
            stkPanel.Effect = new BlurEffect();
            tboxTitulo.Effect = new BlurEffect();
            btnCadastrarProd.Effect = new BlurEffect();
            btnRecarregar.Effect = new BlurEffect();

            MainGrid.Children.Add(new ModalAdicionarProduto());
        }

        private void AbrirEditarDialog(object sender, RoutedEventArgs e)
        {
            EditaProdutosDialog epd = new EditaProdutosDialog();
            ProdutosViewModel pvm = new ProdutosViewModel();
            pvm.Produtos = (Model.Produtos)datagrid_produto.SelectedItem;
            epd.Codigo = pvm.Produtos.Codigo;
            epd.NomeProduto = pvm.Produtos.NomeProduto;
            epd.Marca = pvm.Produtos.Marca;
            epd.Descricao = pvm.Produtos.Descricao;
            epd.Valor = pvm.Produtos.Valor;
            epd.ShowDialog();
        }

        private void MainGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            stkPanel.Effect = null;
            tboxTitulo.Effect = null;
            btnCadastrarProd.Effect = null;
            btnRecarregar.Effect = null;
        }
    }
}