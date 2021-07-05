using LojaOlharDeMenina_WPF.View.Dialogs;
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
        }

        private void btnAdicionar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AdicionarFuncionariosDialog acd = new AdicionarFuncionariosDialog();
            acd.ShowDialog();
        }
    }
}