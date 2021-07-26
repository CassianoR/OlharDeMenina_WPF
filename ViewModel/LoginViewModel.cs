using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        #region Properties

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

        private bool _buttonIsEnabled;

        public bool buttonIsEnabled
        {
            get { return _buttonIsEnabled; }
            set
            {
                _buttonIsEnabled = value;
                OnPropertyChanged(nameof(buttonIsEnabled));
            }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                if (value == null || value == string.Empty)
                    buttonIsEnabled = false;
                else
                    contador++;
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (value == null || value == string.Empty)
                    buttonIsEnabled = false;
                else
                {
                    if (contador >= 1)
                        buttonIsEnabled = true;
                }
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private int contador;

        #endregion Properties

        private OlharMeninaBDEntities funcionariosEntities;

        public LoginViewModel()
        {
            _passwordHasher = new PasswordHasher();
            funcionariosEntities = new OlharMeninaBDEntities();
            LoadFuncionario();
            LoginCommand = new RelayCommand(DoLogin, CanLogin => true);
        }

        private Hash _hash;

        #region Methods

        private void DoLogin(object obj)
        {
            _hash = new Hash();
            Message = "Tentando fazer login...";
            try
            {
                if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
                {
                    //string hashedPassword = _passwordHasher.HashPassword(Password);
                    //PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(hashedPassword, funcionariosEntities.Funcionarios.Find(Password).Senha);
                    //if (passwordResult != PasswordVerificationResult.Success)
                    //{
                    //    System.Windows.MessageBox.Show("Test");
                    //}
                    //string senha = _hash.Encrypt(Password.ToString());
                    var senha = _hash.Encrypt(Password.ToString());
                    var count = funcionariosEntities.Funcionarios
                                .Where(o => o.Nome == Username.ToString())
                                .Where(o => o.Senha == senha)
                                .Count();
                    if (count != 1)
                    {
                        Message = "Usuário ou senha incorretos";
                        Username = string.Empty;
                        Password = string.Empty;
                    }
                    else
                    {
                        //Fazer lógica de abrir a MainWindow aqui, talvez seja preciso fazer um sistema de navegação
                        Message = "Login efetuado com sucesso!";
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                Message = ex.ToString();
            }
            contador = 0;
        }

        public bool CanLogin()
        {
            if (Username == null || Password == null)
            {
                Message = "Campos de textos não podem ser vazios.";
                return false;
            }

            return true;
        }

        private void LoadFuncionario()
        {
            lstFunc = new ObservableCollection<Funcionarios>(funcionariosEntities.Funcionarios);
        }

        #endregion Methods

        public RelayCommand LoginCommand { get; set; }
    }
}