using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View.Modals
{
    /// <summary>
    /// Interação lógica para ModalAdicionarVenda.xam
    /// </summary>
    public partial class ModalAdicionarVenda : UserControl
    {
        public ModalAdicionarVenda()
        {
            InitializeComponent();
            DataContext = new AdicionarVendaViewModel();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            //this.DragMove();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            
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