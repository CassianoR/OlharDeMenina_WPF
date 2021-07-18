using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class FuncionariosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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

        public FuncionariosViewModel()
        {
            funcionariosEntities = new OlharMeninaBDEntities();
            LoadFuncionario();
            DeleteCommand = new Command((s) => true, Delete);
            UpdateCommand = new Command((s) => true, Update);
            UpdateFuncionarioCommand = new Command((s) => true, UpdateFuncionario);
            AddFuncionarioCommand = new Command((s) => true, AddFuncionario);
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

        private void AddFuncionario(object obj)
        {
            funcionariosEntities = new OlharMeninaBDEntities();
            Funcionarios.ID = funcionariosEntities.Funcionarios.Count();
            Funcionarios.Cargo = "Funcionário";
            Funcionarios.Senha = Encrypt("1234");
            Funcionarios.LoginFuncionario = "teste2@gmail.com";
            funcionariosEntities.Funcionarios.Add(Funcionarios);
            try
            {
                funcionariosEntities.SaveChanges();
                lstFuncionarios.Add(Funcionarios);
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("\n", errorMessages);
                var exceptionMessage = string.Concat(fullErrorMessage);
                System.Windows.MessageBox.Show(exceptionMessage, ex.EntityValidationErrors.ToString());
                funcionariosEntities.Dispose();
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
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("\n", errorMessages);
                var exceptionMessage = string.Concat(fullErrorMessage);
                System.Windows.MessageBox.Show(exceptionMessage, ex.EntityValidationErrors.ToString());
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
            funcionariosEntities = new OlharMeninaBDEntities();
            var fu = obj as Funcionarios;
            funcionariosEntities.Funcionarios.Remove(fu);
            try
            {
                funcionariosEntities.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("\n", errorMessages);
                var exceptionMessage = string.Concat(fullErrorMessage);
                System.Windows.MessageBox.Show(exceptionMessage, ex.EntityValidationErrors.ToString());
                funcionariosEntities.Dispose();
            }
            lstFuncionarios.Remove(fu);
        }

        private void LoadFuncionario() //Read
        {
            lstFuncionarios = new ObservableCollection<Funcionarios>(funcionariosEntities.Funcionarios);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateFuncionarioCommand { get; set; }
        public ICommand AddFuncionarioCommand { get; set; }
    }
}