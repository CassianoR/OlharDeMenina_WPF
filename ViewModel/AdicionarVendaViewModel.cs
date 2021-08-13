using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    internal class AdicionarVendaViewModel : ObservableObject
    {
        #region Properties

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

        private decimal valorAntes;

        public decimal ValorAntes
        {
            get
            {
                return valorAntes;
            }
            set
            {
                valorAntes = value;
                OnPropertyChanged(nameof(ValorAntes));
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

        private OlharMeninaBDEntities vendasEntities;
        private Exceptions exc = new Exceptions();

        #endregion Properties

        #region Constructor

        public AdicionarVendaViewModel()
        {
            vendasEntities = new OlharMeninaBDEntities();
            AddVendaCommand = new Command((s) => true, AddVenda);
        }

        #endregion Constructor

        #region Methods

        private void AddVenda(object obj)
        {
            if (vendasEntities == null)
                vendasEntities = new OlharMeninaBDEntities();
            Venda.CodigoVendas = vendasEntities.Clientes.Count();
            vendasEntities.Venda.Add(Venda);
            try
            {
                vendasEntities.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                vendasEntities.Dispose();
                vendasEntities = new OlharMeninaBDEntities();
            }
        }

        //private void DescontoMetodo (object obj)
        //{
        //    if (Desconto != null)
        //    {
        //        Venda.Valor = valorAntes - desconto;
        //    }
        //}

        #endregion Methods

        #region Commands

        public ICommand AddVendaCommand { get; set; }

        #endregion Commands
    }
}