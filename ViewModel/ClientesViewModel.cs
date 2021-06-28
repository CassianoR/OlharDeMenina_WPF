using LojaOlharDeMenina_WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class ClientesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
            set { _selectedCliente = value;
                OnPropertyChanged(nameof(SelectedCliente));
            }
        }


        private Clientes _clientes = new Clientes();

        public Clientes Clientes
        {
            get { return _clientes; }
            set { _clientes = value;
                OnPropertyChanged(nameof(Clientes));
            }
        }
        

        olharmeninabdEntities1 clientesEntities;
        public ClientesViewModel()
        {
            clientesEntities = new olharmeninabdEntities1();
            LoadCliente();
            DeleteCommand = new Command((s) => true, Delete);
            UpdateCommand = new Command((s) => true, Update);
            UpdateClienteCommand = new Command((s) => true, UpdateCliente);
            AddClienteCommand = new Command((s) => true, AddCliente);
        }

        private void AddCliente(object obj)
        {
            Clientes.ID = clientesEntities.Clientes.Count();
            clientesEntities.Clientes.Add(Clientes);
            clientesEntities.SaveChanges();
            lstClientes.Add(Clientes);
            Clientes = new Clientes();

        }

        private void UpdateCliente(object obj) //Update cliente
        {
            clientesEntities.SaveChanges();
            SelectedCliente = new Clientes();
        }

        private void Update(object obj) //Update, recarrega
        {
            SelectedCliente = obj as Clientes;
        }

        private void Delete(object obj) //Delete
        {
            var cl = obj as Clientes;
            clientesEntities.Clientes.Remove(cl);
            clientesEntities.SaveChanges();
            lstClientes.Remove(cl); 
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

    class Command : ICommand
    {
        public Command(Func<object, bool> methodCanExecute, Action<object> methodExecute)
        {
            MethodCanExecute = methodCanExecute;
            MethodExecute = methodExecute;
        }
        Action<object> MethodExecute;
        Func<object, bool> MethodCanExecute;

        public bool CanExecute(object parameter)
        {
            return MethodExecute != null && MethodCanExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            MethodExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}
