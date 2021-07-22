using LojaOlharDeMenina_WPF.View.Dialogs;
using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows.Controls;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para Funcionarios.xam
    /// </summary>
    public partial class Funcionarios : UserControl
    {
        public Funcionarios()
        {
            InitializeComponent();
            DataContext = new FuncionariosViewModel();
        }

        private void btnCadastrar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AdicionarFuncionariosDialog acd = new AdicionarFuncionariosDialog();
            acd.ShowDialog();
        }
    }
}