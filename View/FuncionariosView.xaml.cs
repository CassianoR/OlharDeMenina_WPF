using LojaOlharDeMenina_WPF.View.Dialogs;
using LojaOlharDeMenina_WPF.View.Modal;
using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para Funcionarios.xam
    /// </summary>
    public partial class Funcionarios : UserControl
    {
        private ModalAdicionarFuncionario maf = new ModalAdicionarFuncionario();
        public Funcionarios()
        {
            InitializeComponent();
            DataContext = new FuncionariosViewModel();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (MainGrid.Children.Contains(maf) == true)
            {
                maf.Visibility = System.Windows.Visibility.Visible;
            }
            //erro do caralho
            else
            {
                MainGrid.Children.Add(maf);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //datagrid_funcionario.Visibility = Visibility.Hidden;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (datagrid_funcionario.Items.Count > 0)
            //    datagrid_funcionario.Visibility = Visibility.Visible;
            //else
            //    datagrid_funcionario.Visibility = Visibility.Hidden;

            //if (SearchBox.Text.Length <= 2)
            //{
            //    if (SearchBox.Text != "*")
            //        datagrid_funcionario.Visibility = Visibility.Hidden;
            //    else
            //        datagrid_funcionario.Visibility = Visibility.Visible;
            //}
            //else
            //    datagrid_funcionario.Visibility = Visibility.Visible;
        }
    }
}