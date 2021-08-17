using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    internal class AdicionarVendaViewModel : ObservableObject
    {
        #region Properties

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

        private Venda _venda = new Venda();

        public Venda Venda
        {
            get { return _venda; }
            set
            {
                _venda = value;
                OnPropertyChanged(nameof(Venda));
            }
        }

        private decimal desconto;

        public decimal Desconto
        {
            get
            {
                return desconto;
            }
            set
            {
                desconto = value;
                OnPropertyChanged(nameof(Desconto));
            }
        }

        private string message;

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private DateTime timer = DateTime.Now;

        public DateTime Timer
        {
            get
            {
                return timer;
            }
            set
            {
                timer = value;
            }
        }

        private string cpfCliente;

        public string CpfCliente
        {
            get
            {
                return cpfCliente;
            }
            set
            {
                cpfCliente = value;
                OnPropertyChanged(nameof(CpfCliente));
            }
        }

        private string emailFuncionario;

        public string EmailFuncionario
        {
            get
            {
                return emailFuncionario;
            }
            set
            {
                emailFuncionario = value;
                OnPropertyChanged(nameof(EmailFuncionario));
            }
        }

        private OlharMeninaBDEntities vendaEntities;
        private Exceptions exc = new Exceptions();

        #endregion Properties

        #region Constructor

        public AdicionarVendaViewModel()
        {
            vendaEntities = new OlharMeninaBDEntities();
            AddVendaCommand = new Command((s) => true, AddVenda);
            LoadVendas();
            Load();
        }

        #endregion Constructor

        #region Methods

        private void AddVenda(object obj)
        {
            if (vendaEntities == null)
                vendaEntities = new OlharMeninaBDEntities();
            if (emailFuncionario != null && cpfCliente != null)
            {
                Venda.CodigoVendas = vendaEntities.Venda.Count();
                vendaEntities.Venda.Add(Venda);

                var cpfcliente = vendaEntities.Clientes.Where(o => o.CPF == cpfCliente.ToString())
                                                   .Select(o => o.ID).FirstOrDefault();

                var emailFunc = vendaEntities.Funcionarios.Where(o => o.LoginFuncionario == emailFuncionario.ToString())
                                                             .Select(o => o.ID).FirstOrDefault();
                if (emailFunc != 0)
                {
                    Venda.FK_IDFuncionario = emailFunc;
                }
                if (cpfcliente != 0)
                {
                    Venda.FK_IDCliente = cpfcliente;
                }

                if (Desconto != 0)
                {
                    Venda.Valor = Venda.Valor - 00;
                    Venda.Valor = Venda.Valor - Desconto;
                }
                try
                {
                    vendaEntities.SaveChanges();
                    Venda = new Venda();
                }
                catch (DbEntityValidationException ex)
                {
                    string exceptionMessage = exc.concatenaExceptions(ex);
                    Message = exceptionMessage;
                    vendaEntities.Dispose();
                    vendaEntities = new OlharMeninaBDEntities();
                }
            }
            else
            {
                if (emailFuncionario == null)
                {
                    Message = "Email Inválido";
                }
                if (cpfCliente == null)
                {
                    Message = "CPF Inválido";
                }
            }
        }

        private void LoadVendas()
        {
            vendaEntities = new OlharMeninaBDEntities();
        }

        private async void Load() //Read
        {
            vendaEntities = new OlharMeninaBDEntities();

            var listaClientes = await vendaEntities.Clientes.ToListAsync();
            lstClientes = new ObservableCollection<Clientes>(listaClientes);

            var listaFuncionarios = await vendaEntities.Funcionarios.ToListAsync();
            lstFuncionarios = new ObservableCollection<Funcionarios>(listaFuncionarios);
        }

        #endregion Methods

        #region Commands

        public ICommand AddVendaCommand { get; set; }

        #endregion Commands
    }
}