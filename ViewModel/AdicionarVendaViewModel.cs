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

        private ObservableCollection<Funcionarios> lstfuncionarios;

        public ObservableCollection<Funcionarios> lstFuncionarios
        {
            get
            {
                return lstfuncionarios;
            }
            set
            {
                lstfuncionarios = value;
                OnPropertyChanged(nameof(lstFuncionarios));
            }
        }
        private ObservableCollection<Clientes> lstclientes;

        public ObservableCollection<Clientes> lstClientes
        {
            get
            {
                return lstclientes;
            }
            set
            {
                lstclientes = value;
                OnPropertyChanged(nameof(lstClientes));
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
        }

        #endregion Constructor

        #region Methods

        private void AddVenda(object obj)
        {
            if (vendaEntities == null)
                vendaEntities = new OlharMeninaBDEntities();
            Venda.CodigoVendas = vendaEntities.Venda.Count();
            vendaEntities.Venda.Add(Venda);

            //Funcionalidade para inserção de cpf e email e retornar ID para o banco
            //var cpfcliente = clientesEntities.Clientes.Where(o => o.CPF == cpfCliente.ToString())
            // .Select(o => o.ID).FirstOrDefault();

            Funcionarios funcionarios = new Funcionarios();
            Clientes clientes = new Clientes();

            clientes.CPF = cpfCliente;

            funcionarios.LoginFuncionario = emailFuncionario;

            vendaEntities.Funcionarios.Add(funcionarios);
            vendaEntities.Clientes.Add(clientes);

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

        private async void LoadVendas()
        {
            vendaEntities = new OlharMeninaBDEntities();
            var listaf = await vendaEntities.Funcionarios.ToListAsync();
            var listac = await vendaEntities.Clientes.ToListAsync();
            lstFuncionarios = new ObservableCollection<Funcionarios>(listaf);
            lstClientes = new ObservableCollection<Clientes>(listac);
        }

        #endregion Methods

        #region Commands

        public ICommand AddVendaCommand { get; set; }

        #endregion Commands
    }
}