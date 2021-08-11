using LojaOlharDeMenina_WPF.View.Modals;
using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

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

        private ModalAdicionarFuncionarios maf = new ModalAdicionarFuncionarios();
        private ModalEditarFuncionarios mef = new ModalEditarFuncionarios();

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //AdicionarFuncionariosDialog acd = new AdicionarFuncionariosDialog();
            //acd.ShowDialog();
            stkPanelFuncionarios.Effect = new BlurEffect();
            tboxFuncionarioTitulo.Effect = new BlurEffect();
            btnCadastrar.Effect = new BlurEffect();
            btnRecarregar.Effect = new BlurEffect();
            if (MainGrid.Children.Contains(maf) == true)
            {
                maf.Visibility = Visibility.Visible;
            }
            else
            {
                MainGrid.Children.Add(maf);
            }
        }

        private void LimpaCampos()
        {
            if (mef.id != -1 || mef.Nome != string.Empty || mef.Endereco != string.Empty || mef.Telefone != string.Empty)
            {
                mef.id = -1;
                mef.Nome = string.Empty;
                mef.Endereco = string.Empty;
                mef.Telefone = string.Empty;
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            LimpaCampos();
            dynamic row = datagrid_funcionario.SelectedItem;
            mef.id = row.ID;
            mef.Nome = row.Nome;
            mef.Telefone = row.Telefone;
            mef.Endereco = row.Endereco;
            mef.Email = row.LoginFuncionario;
            mef.Atividade = row.Atividade;
            stkPanelFuncionarios.Effect = new BlurEffect();
            tboxFuncionarioTitulo.Effect = new BlurEffect();
            btnCadastrar.Effect = new BlurEffect();
            btnRecarregar.Effect = new BlurEffect();
            if (MainGrid.Children.Contains(mef) == true)
            {
                mef.Visibility = Visibility.Visible;
            }
            else
            {
                MainGrid.Children.Add(mef);
            }
            (this.MainGrid).Children.Remove(this);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //datagrid_funcionario.Visibility = Visibility.Hidden;
        }

        private void MainGridFuncionarios_GotFocus(object sender, RoutedEventArgs e)
        {
            stkPanelFuncionarios.Effect = null;
            tboxFuncionarioTitulo.Effect = null;
            btnCadastrar.Effect = null;
            btnRecarregar.Effect = null;
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