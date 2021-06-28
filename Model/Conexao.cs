
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace LojaOlharDeMenina_WPF.Model
{
    internal class Conexao
    {
        private static SqlConnection databaseConnection = null;

        public SqlConnection getDBConnection()
        {
            if (databaseConnection == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
                databaseConnection = new SqlConnection(connectionString);
            }
            return databaseConnection;
        }

        public SqlConnection Conectar()
        {
            getDBConnection();
            if (databaseConnection.State != System.Data.ConnectionState.Open)
            {
                databaseConnection.Open();
            }
            return databaseConnection;
        }

        public void Desconectar()
        {
            //Verifica se o estado da conexão é aberto, então fecho.
            if (databaseConnection.State == System.Data.ConnectionState.Open)
            {
                databaseConnection.Close();
            }
        }

        ///
        public bool Open()
        {
            try
            {
                databaseConnection.Open();
                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro de conexão: " + er.Message);
            }
            return false;
        }

        public void Close()
        {
            databaseConnection.Close();
            databaseConnection.Dispose();
        }
    }
}