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

        private OlharMeninaBDEntities funcionariosEntities;
        private ObservableCollection<Funcionarios> _lstFunc;
        private Hash _hash;
        private WindowService windowService;

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

        private string _user;

        public string User
        {
            get { return _user; }
            set
            {
                if (value == null || value == string.Empty)
                    buttonIsEnabled = false;
                else
                    contador++;
                _user = value;
                OnPropertyChanged(nameof(User));
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

        private string _cargo;

        public string Cargo
        {
            get { return _cargo; }
            set
            {
                _cargo = value;
                OnPropertyChanged(nameof(Cargo));
            }
        }

        private int contador;

        private Funcionarios _funcionarios = new Funcionarios();

        public Funcionarios Funcionarios
        {
            get { return _funcionarios; }
            set
            {
                _funcionarios = value;
                OnPropertyChanged(nameof(Funcionarios));
            }
        }

        private Exceptions exc = new Exceptions();

        #endregion Properties

        public LoginViewModel()
        {
            _passwordHasher = new PasswordHasher();
            funcionariosEntities = new OlharMeninaBDEntities();
            LoadFuncionario();
            LoginCommand = new RelayCommand(DoLogin, CanLogin => true);
            ChecaAdmin();
        }

        private void ChecaAdmin()
        {
            var count = funcionariosEntities.Funcionarios
                                .Where(o => o.LoginFuncionario == "admin").Count();
            if (count == 0)
            {
                Funcionarios.ID = funcionariosEntities.Funcionarios.Count();
                _hash = new Hash();
                var senha = _hash.Encrypt("1234");
                Funcionarios.Cargo = "Administrador";
                Funcionarios.LoginFuncionario = "admin";
                Funcionarios.Nome = "ADMIN";
                Funcionarios.Telefone = "0";
                Funcionarios.CPF = "000.000.000-00";
                Funcionarios.Senha = senha;
                Funcionarios.Atividade = "Ativo";
                Funcionarios.Endereco = "Olhar de Menina";
                funcionariosEntities.Funcionarios.Add(Funcionarios);
                try
                {
                    funcionariosEntities.SaveChanges();
                    Funcionarios = new Funcionarios();
                }
                catch (DbEntityValidationException ex)
                {
                    string exceptionMessage = exc.concatenaExceptions(ex);
                    Message = exceptionMessage;
                    funcionariosEntities.Dispose();
                    funcionariosEntities = new OlharMeninaBDEntities();
                }
            }
        }

        #region Methods

        private void DoLogin(object obj)
        {
            _hash = new Hash();
            windowService = new WindowService();
            Message = "Tentando fazer login...";
            try
            {
                if (!String.IsNullOrEmpty(User) && !String.IsNullOrEmpty(Password))
                {
                    var senha = _hash.Encrypt(Password.ToString());
                    var count = funcionariosEntities.Funcionarios
                                .Where(o => o.LoginFuncionario == User.ToString())
                                .Where(o => o.Senha == senha)
                                .Count();
                    if (count != 1)
                    {
                        Message = "Usuário ou senha incorretos";
                        User = string.Empty;
                        Password = string.Empty;
                    }
                    else
                    {
                        var nomecargo = funcionariosEntities.Funcionarios.Where(o => o.LoginFuncionario == User.ToString())
                                                    .Where(o => o.Senha == senha)
                                                    .Select(o => o.Cargo).FirstOrDefault();
                        Message = "Login efetuado com sucesso!";
                        windowService.showWindow(nomecargo.ToString());
                        App.Current.MainWindow.Close();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                Message = ex.ToString();
            }
            contador = 0;
        }

        private void LoadFuncionario()
        {
            lstFunc = new ObservableCollection<Funcionarios>(funcionariosEntities.Funcionarios);
        }

        #endregion Methods

        public RelayCommand LoginCommand { get; set; }
    }
}