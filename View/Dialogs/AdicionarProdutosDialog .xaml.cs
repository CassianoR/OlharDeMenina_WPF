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
using System.Windows.Shapes;

namespace LojaOlharDeMenina_WPF.View.Dialogs
{
    /// <summary>
    /// Lógica interna para AdicionarClientesDialog.xaml
    /// </summary>
    public partial class AdicionarProdutosDialog : Window
    {
        public AdicionarProdutosDialog()
        {
            InitializeComponent();
            DataContext = new ProdutosViewModel();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
