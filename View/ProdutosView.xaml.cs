using LojaOlharDeMenina_WPF.View.Dialogs;
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
        public Produtos()
        {
            InitializeComponent();
            DataContext = new ProdutosViewModel();
        }

        private void btnCadastrarProd_Click(object sender, RoutedEventArgs e)
        {
            AdicionarProdutosDialog acd = new AdicionarProdutosDialog();
            acd.ShowDialog();
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
    }
}