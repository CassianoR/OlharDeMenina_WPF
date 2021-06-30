using LojaOlharDeMenina_WPF.Model;
using LojaOlharDeMenina_WPF.View;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                System.Windows.Application.Current.Shutdown();
        }

        private Conexao objCon = new Conexao();
        private Window1 f = new Window1();
        private string cargo;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblErro.Content = "";
            try
            {
                if (txtNome.Text != "" && pb.Password.ToString() != "")
                {
                    SqlCommand objCmd = new SqlCommand("select ID, Cargo, Nome, Senha from funcionarios WHERE Nome = @nome AND Senha = @senha", objCon.Conectar());
                    objCmd.Parameters.Clear();
                    objCmd.Parameters.AddWithValue("nome", txtNome.Text);
                    objCmd.Parameters.AddWithValue("senha", pb.Password.ToString());
                    SqlDataReader dr;
                    dr = objCmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        cargo = dr.GetString(1);
                        if (cargo == "Administrador")
                        {
                            f.Adm = true;
                        }
                        else
                        {
                            f.Adm = false;
                        }
                        f.idFunc = dr.GetInt32(0).ToString();
                        f.username = dr.GetString(2);
                        f.password = dr.GetInt32(3).ToString();
                        f.Show();
                        Close();
                        objCon.Close();
                    }
                    else
                    {
                        lblErro.Content = "Usuário ou senha incorretos.";
                        objCon.Close();
                    }
                }
                else
                {
                    lblErro.Content = "Campos de texto não podem estar vazios.";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro de conexão: " + ex);
            }
        }
    }
}