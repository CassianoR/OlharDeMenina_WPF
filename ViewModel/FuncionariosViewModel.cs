using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class FuncionariosViewModel : ObservableObject
    {
        #region Properties

        private Exceptions exc = new Exceptions();

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

        /// <summary>
        /// TO-DO: Colocar a propriedade Message e as demais que se remetem na BaseViewModel
        /// </summary>
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
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

        private Hash _hash;

        #endregion Properties

        #region Constructor

        public FuncionariosViewModel()
        {
            funcionariosEntities = new OlharMeninaBDEntities();
            //LoadFuncionario();
            DeleteCommand = new Command((s) => true, Delete);
            UpdateCommand = new Command((s) => true, Update);
        }

        #endregion Constructor

        #region Methods

        private async void GetResults(string search)
        {
            if (search == "*")
            {
                LoadFuncionario();
                return;
            }
            funcionariosEntities = new OlharMeninaBDEntities();
            lstFuncionarios = new ObservableCollection<Funcionarios>();
            var ObjQuery = await funcionariosEntities.Funcionarios.Where(x => x.Nome.Contains(search) || x.CPF.Contains(search) || x.Telefone.Contains(search)).ToListAsync();
            foreach (var funcionario in ObjQuery)
            {
                lstFuncionarios.Add(funcionario);
            }
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

        private async void LoadFuncionario() //Read
        {
            funcionariosEntities = new OlharMeninaBDEntities();
            var lista = await funcionariosEntities.Funcionarios.ToListAsync();
            lstFuncionarios = new ObservableCollection<Funcionarios>(lista);
        }

        #endregion Methods

        #region Commands

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        #endregion Commands
    }
}