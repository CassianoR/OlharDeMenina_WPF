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
    /// Interação lógica para ModalAdicionarFuncionario.xam
    /// </summary>
    public partial class ModalAdicionarFuncionario : UserControl
    {
        public ModalAdicionarFuncionario()
        {
            InitializeComponent();
        }
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //Se o cadastro foi concluído com sucesso, fechar o dialog
        }
    }
}
