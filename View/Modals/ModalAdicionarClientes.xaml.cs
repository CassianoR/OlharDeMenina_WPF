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

namespace LojaOlharDeMenina_WPF.View.Modals
{
    /// <summary>
    /// Interação lógica para ModalAdicionarClientes.xam
    /// </summary>
    public partial class ModalAdicionarClientes : UserControl
    {
        public ModalAdicionarClientes()
        {
            InitializeComponent();
            DataContext = new ClientesViewModel();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
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

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
