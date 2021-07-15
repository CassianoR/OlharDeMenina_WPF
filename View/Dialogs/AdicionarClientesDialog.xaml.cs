using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View.Dialogs
{
    /// <summary>
    /// Lógica interna para AdicionarClientesDialog.xaml
    /// </summary>
    public partial class AdicionarClientesDialog : Window
    {
        public AdicionarClientesDialog()
        {
            InitializeComponent();
            DataContext = new ClientesViewModel();
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
            this.Close();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}