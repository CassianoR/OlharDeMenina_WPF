﻿using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class ClientesViewModel : INotifyPropertyChanged
    {
        private Exceptions exc = new Exceptions();

        #region INotifyPropertyChanged Methods

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion INotifyPropertyChanged Methods

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private ObservableCollection<Clientes> _lstClientes;

        public ObservableCollection<Clientes> lstClientes
        {
            get { return _lstClientes; }
            set
            {
                _lstClientes = value;
                OnPropertyChanged(nameof(lstClientes));
            }
        }

        private Clientes _selectedCliente;

        public Clientes SelectedCliente
        {
            get { return _selectedCliente; }
            set
            {
                _selectedCliente = value;
                OnPropertyChanged(nameof(SelectedCliente));
            }
        }

        private Clientes _clientes = new Clientes();

        public Clientes Clientes
        {
            get { return _clientes; }
            set
            {
                _clientes = value;
                OnPropertyChanged(nameof(Clientes));
            }
        }

        //Mudei o entities aqui, agora está belezinha com o banco novo bb's

        private OlharMeninaBDEntities clientesEntities;

        public ClientesViewModel()
        {
            clientesEntities = new OlharMeninaBDEntities();
            LoadCliente();
            DeleteCommand = new Command((s) => true, Delete);
            UpdateCommand = new Command((s) => true, Update);
            UpdateClienteCommand = new Command((s) => true, UpdateCliente);
            AddClienteCommand = new Command((s) => true, AddCliente);
        }

        private void AddCliente(object obj)
        {
            clientesEntities = new OlharMeninaBDEntities();
            Clientes.ID = clientesEntities.Clientes.Count();
            clientesEntities.Clientes.Add(Clientes);
            try
            {
                clientesEntities.SaveChanges();
                lstClientes.Add(Clientes);
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                clientesEntities.Dispose();
            }
            Clientes = new Clientes();
        }

        private void UpdateCliente(object obj) //Update cliente
        {
            SelectedCliente = obj as Clientes;
            clientesEntities.Clientes.Attach(Clientes);
            try
            {
                clientesEntities.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                clientesEntities.Dispose();
            }
            SelectedCliente = new Clientes();
        }

        private void Update(object obj) //Update, recarrega
        {
            SelectedCliente = obj as Clientes;
            LoadCliente();
        }

        private void Delete(object obj) //Delete
        {
            System.Windows.MessageBoxResult deletarConfirma = System.Windows.MessageBox.Show("Você tem certeza que quer deletar esse cliente?", "Deletar?", System.Windows.MessageBoxButton.OKCancel);
            if (deletarConfirma == System.Windows.MessageBoxResult.Cancel)
            {
                return;
            }
            var cl = obj as Clientes;
            clientesEntities.Clientes.Remove(cl);
            try
            {
                clientesEntities.SaveChanges();
                lstClientes.Remove(cl);
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                clientesEntities.Dispose();
            }
        }

        private void LoadCliente() //Read
        {
            lstClientes = new ObservableCollection<Clientes>(clientesEntities.Clientes);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateClienteCommand { get; set; }
        public ICommand AddClienteCommand { get; set; }
    }
}