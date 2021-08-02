using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using Microsoft.AspNet.Identity;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class FuncionariosViewModel : ObservableObject
    {
        private Exceptions exc = new Exceptions();

        #region Properties

        private ObservableCollection<Funcionarios> _lstFuncionarios;

        public ObservableCollection<Funcionarios> lstFuncionarios
        {
            get { return _lstFuncionarios; }
            set
            {
                _lstFuncionarios = value;
                OnPropertyChanged(nameof(lstFuncionarios));
            }
        }

        private Funcionarios _selectedFuncionario;

        public Funcionarios SelectedFuncionario
        {
            get { return _selectedFuncionario; }
            set
            {
                _selectedFuncionario = value;
                OnPropertyChanged(nameof(SelectedFuncionario));
            }
        }

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

        private OlharMeninaBDEntities funcionariosEntities;

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private FuncionariosDTO currentEmployee;

        public FuncionariosDTO CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private string _search;

        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                if (value.Length > 2 || value == "*")
                    GetResults(_search);

                if (value == null || value == string.Empty)
                    if (lstFuncionarios != null)
                        lstFuncionarios.Clear();
            }
        }

        private readonly ObservableCollection<string> _results = new ObservableCollection<string>();

        public ObservableCollection<string> Results
        {
            get
            {
                return _results;
            }
        }

        #endregion Properties

        private readonly IPasswordHasher _passwordHasher;

        public FuncionariosViewModel()
        {
            _passwordHasher = new PasswordHasher();
            funcionariosEntities = new OlharMeninaBDEntities();
            //LoadFuncionario();
            CurrentEmployee = new FuncionariosDTO();
            DeleteCommand = new Command((s) => true, Delete);
            UpdateCommand = new Command((s) => true, Update);
            UpdateFuncionarioCommand = new Command((s) => true, UpdateFuncionario);
            AddFuncionarioCommand = new Command((s) => true, AddFuncionario);
        }

        private Hash _hash;

        #region Methods

        private void GetResults(string search)
        {
            if (_search == "*")
            {
                LoadFuncionario();
                return;
            }
            if (lstFuncionarios != null)
                lstFuncionarios.Clear();

            lstFuncionarios = new ObservableCollection<Funcionarios>();
            _results.Clear();
            var ObjQuery = funcionariosEntities.Funcionarios.Where(x => x.Nome.Contains(_search) || x.CPF.Contains(_search) || x.Telefone.Contains(_search)).ToList();
            foreach (var funcionario in ObjQuery)
            {
                _results.Add(funcionario.Nome);
                lstFuncionarios.Add(funcionario);
            }
        }

        private void AddFuncionario(object obj)
        {
            _hash = new Hash();
            funcionariosEntities = new OlharMeninaBDEntities();
            LoadFuncionario();
            Funcionarios.ID = funcionariosEntities.Funcionarios.Count();
            Funcionarios.Cargo = "Funcionário";
            Funcionarios.Senha = _hash.Encrypt("1234");
            Funcionarios.LoginFuncionario = "teste3@gmail.com";
            funcionariosEntities.Funcionarios.Add(Funcionarios);
            try
            {
                funcionariosEntities.SaveChanges();
                lstFuncionarios.Add(Funcionarios);
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                funcionariosEntities.Dispose();
                funcionariosEntities = new OlharMeninaBDEntities();
            }
            Funcionarios = new Funcionarios();
        }

        private void UpdateFuncionario(object obj) //Update funcionario
        {
            funcionariosEntities = new OlharMeninaBDEntities();
            SelectedFuncionario = obj as Funcionarios;
            funcionariosEntities.Funcionarios.Attach(Funcionarios);
            try
            {
                funcionariosEntities.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                funcionariosEntities.Dispose();
            }
            SelectedFuncionario = new Funcionarios();
        }

        private void Update(object obj) //Update, recarrega
        {
            SelectedFuncionario = obj as Funcionarios;
            LoadFuncionario();
        }

        private void Delete(object obj) //Delete
        {
            System.Windows.MessageBoxResult deletarConfirma = System.Windows.MessageBox.Show("Você tem certeza que quer deletar esse funcionário?", "Deletar?", System.Windows.MessageBoxButton.OKCancel);
            if (deletarConfirma == System.Windows.MessageBoxResult.Cancel)
            {
                return;
            }
            var fu = obj as Funcionarios;
            funcionariosEntities.Funcionarios.Remove(fu);
            try
            {
                funcionariosEntities.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                funcionariosEntities.Dispose();
                funcionariosEntities = new OlharMeninaBDEntities();
            }
            lstFuncionarios.Remove(fu);
        }

        private void LoadFuncionario() //Read
        {
            lstFuncionarios = new ObservableCollection<Funcionarios>(funcionariosEntities.Funcionarios);
        }

        #endregion Methods

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateFuncionarioCommand { get; set; }
        public ICommand AddFuncionarioCommand { get; set; }
    }
}