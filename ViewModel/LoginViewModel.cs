using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

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

        private readonly IPasswordHasher _passwordHasher;

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
            _passwordHasher = new PasswordHasher();
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
                    string hashedPassword = _passwordHasher.HashPassword(Password);
                    var count1 = funcionariosEntities.Funcionarios
                                .Where(o => o.Nome == Username.ToString())
                                .Count();
                    var count2 = funcionariosEntities.Funcionarios
                                .Where(o => o.Senha == hashedPassword)
                                .Count();
                    if (count1 != 1 && count2 != 1)
                    {
                        Message = "Usuário ou senha incorretos";
                        estaAutenticado = false;
                        return;
                    }
                    else
                    {
                        //Fazer lógica de abrir a MainWindow aqui, talvez seja preciso fazer um sistema de navegação
                        Message = "Login efetuado com sucesso!";
                        estaAutenticado = true;
                        return;
                    }
                }
            }
            catch (Exception)
            {
                throw;
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

        public RelayCommand LoginCommand { get; private set; }
    }
}