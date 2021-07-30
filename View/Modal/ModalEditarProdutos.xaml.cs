using LojaOlharDeMenina_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LojaOlharDeMenina_WPF.View.Modal
{
    /// <summary>
    /// Interação lógica para ModalEditarProdutos.xam
    /// </summary>
    public partial class ModalEditarProdutos : UserControl
    {
        public ModalEditarProdutos()
        {
            InitializeComponent();
            DataContext = new ProdutosViewModel();
        }

        public int Codigo { get; set; }
        public string NomeProduto { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProdCodigo.Text = Codigo.ToString();
            ProdNome.Text = NomeProduto;
            ProdMarca.Text = Marca;
            ProdCategoria.SelectedItem = Categoria;
            ProdDescricao.Text = Descricao;
            ProdValor.Text = Valor.ToString();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            //this.DragMove();
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Visibility = Visibility.Collapsed;
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
