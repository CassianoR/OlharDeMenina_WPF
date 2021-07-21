using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Methods

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion INotifyPropertyChanged Methods

        private ObservableCollection<Funcionarios> _lstFunc;

        public ObservableCollection<Funcionarios> lstFunc
        {
            get { return _lstFunc; }
            set
            {
                _lstFunc = value;
                OnPropertyChanged(nameof(_lstFunc));
            }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private bool _estaAutenticado;

        public bool estaAutenticado
        {
            get { return _estaAutenticado; }
            set
            {
                if (value != _estaAutenticado)
                {
                    _estaAutenticado = value;
                    OnPropertyChanged("estaAutenticado");
                }
            }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private OlharMeninaBDEntities funcionariosEntities;

        public LoginViewModel()
        {
            funcionariosEntities = new OlharMeninaBDEntities();
            LoadFuncionario();
            LoginCommand = new RelayCommand(DoLogin, CanLogin);
        }

        private void DoLogin(object obj)
        {
            try
            {
                if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
                {
                    var count1 = funcionariosEntities.Funcionarios
                                .Where(o => o.Nome == Username.ToString())
                                .Count();
                    var count2 = funcionariosEntities.Funcionarios
                                .Where(o => o.Senha == Encrypt(Password.ToString()))
                                .Count();
                    if (count1 != 1 && count2 != 1)
                    {
                        Message = "Usuário ou senha incorretos";
                        estaAutenticado = false;
                        podeLogin = false;
                        return;
                    }
                    else
                    {
                        //Fazer lógica de abrir a MainWindow aqui, talvez seja preciso fazer um sistema de navegação
                        Message = "Login efetuado com sucesso!";
                        estaAutenticado = true;
                        podeLogin = true;
                        return;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool _podeLogin;

        public bool podeLogin
        {
            get
            {
                return this._podeLogin;
            }

            set
            {
                this._podeLogin = value;
                OnPropertyChanged(nameof(podeLogin));
            }
        }

        public bool CanLogin()
        {
            if (Username == null || Password == null)
                return false;

            return true;
        }

        private void LoadFuncionario()
        {
            lstFunc = new ObservableCollection<Funcionarios>(funcionariosEntities.Funcionarios);
        }

        private static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        public RelayCommand LoginCommand { get; private set; }
    }
}