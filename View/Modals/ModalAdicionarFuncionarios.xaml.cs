using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View.Modals
{
    /// <summary>
    /// Interação lógica para ModalAdicionarFuncionarios.xam
    /// </summary>
    public partial class ModalAdicionarFuncionarios : UserControl
    {
        public ModalAdicionarFuncionarios()
        {
            InitializeComponent();
            DataContext = new FuncionariosViewModel();
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
            //Se o cadastro foi concluído com sucesso, fechar o dialog
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}