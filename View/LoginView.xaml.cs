using LojaOlharDeMenina_WPF.View;
using LojaOlharDeMenina_WPF.ViewModel;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            //DataContext = LoginViewModel();
            //this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                System.Windows.Application.Current.Shutdown();
        }

        //private Conexao objCon = new Conexao();
        private Window1 f = new Window1();

        //private string cargo;

        //private static string Encrypt(string value)
        //{
        //    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        //    {
        //        UTF8Encoding utf8 = new UTF8Encoding();
        //        byte[] data = md5.ComputeHash(utf8.GetBytes(value));
        //        return Convert.ToBase64String(data);
        //    }
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //lblErro.Content = "";
            //try
            //{
            //    if (txtNome.Text != "" && pb.Password.ToString() != "")
            //    {
            //        SqlCommand objCmd = new SqlCommand("select ID, Cargo, Nome, Senha from funcionarios WHERE Nome = @nome AND Senha = @senha", objCon.Conectar());
            //        objCmd.Parameters.Clear();
            //        objCmd.Parameters.AddWithValue("nome", txtNome.Text);
            //        objCmd.Parameters.AddWithValue("senha", Encrypt(pb.Password.ToString()));
            //        SqlDataReader dr;
            //        dr = objCmd.ExecuteReader();
            //        dr.Read();
            //        if (dr.HasRows)
            //        {
            //            cargo = dr.GetString(1);
            //            if (cargo == "Administrador")
            //            {
            //                f.Adm = true;
            //            }
            //            else
            //            {
            //                f.Adm = false;
            //            }
            //            f.idFunc = dr.GetInt32(0).ToString();
            //            f.username = dr.GetString(2);
            //            f.password = dr.GetString(3);
            //            f.Show();
            //            Close();
            //            objCon.Close();
            //        }
            //        else
            //        {
            //            lblErro.Content = "Usuário ou senha incorretos.";
            //            objCon.Close();
            //        }
            //    }
            //    else
            //    {
            //        lblErro.Content = "Campos de texto não podem estar vazios.";
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    System.Windows.MessageBox.Show("Erro de conexão: " + ex);
            //}
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    lblErro.Content = "";
            //    try
            //    {
            //        if (txtNome.Text != "" && pb.Password.ToString() != "")
            //        {
            //            SqlCommand objCmd = new SqlCommand("select ID, Cargo, Nome, Senha from funcionarios WHERE Nome = @nome AND Senha = @senha", objCon.Conectar());
            //            objCmd.Parameters.Clear();
            //            objCmd.Parameters.AddWithValue("nome", txtNome.Text);
            //            objCmd.Parameters.AddWithValue("senha", Encrypt(pb.Password.ToString()));
            //            SqlDataReader dr;
            //            dr = objCmd.ExecuteReader();
            //            dr.Read();
            //            if (dr.HasRows)
            //            {
            //                cargo = dr.GetString(1);
            //                if (cargo == "Administrador")
            //                {
            //                    f.Adm = true;
            //                }
            //                else
            //                {
            //                    f.Adm = false;
            //                }
            //                f.idFunc = dr.GetInt32(0).ToString();
            //                f.username = dr.GetString(2);
            //                f.password = dr.GetString(3);
            //                f.Show();
            //                Close();
            //                objCon.Close();
            //            }
            //            else
            //            {
            //                lblErro.Content = "Usuário ou senha incorretos.";
            //                objCon.Close();
            //            }
            //        }
            //        else
            //        {
            //            lblErro.Content = "Campos de texto não podem estar vazios.";
            //        }
            //    }
            //    catch (SqlException ex)
            //    {
            //        System.Windows.MessageBox.Show("Erro de conexão: " + ex);
            //    }
            //}
        }
    }
}