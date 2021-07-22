﻿using LojaOlharDeMenina_WPF.Core;
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
        private Exceptions exc = new Exceptions();

        #region INotifyPropertyChanged Methods

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion INotifyPropertyChanged Methods

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

        public FuncionariosViewModel()
        {
            funcionariosEntities = new OlharMeninaBDEntities();
            LoadFuncionario();
            CurrentEmployee = new FuncionariosDTO();
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
                Message = exceptionMessage;
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

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateFuncionarioCommand { get; set; }
        public ICommand AddFuncionarioCommand { get; set; }
    }
}