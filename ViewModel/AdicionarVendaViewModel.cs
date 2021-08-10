

using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    class AdicionarVendaViewModel : ObservableObject
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

        private DateTime _Timer = DateTime.Now;

        public DateTime Time
        {
            get
            {
                return _Timer;
            }
            set
            {
                _Timer = value;
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


        private OlharMeninaBDEntities vendasEntities;
        private Exceptions exc = new Exceptions();

        #endregion

        #region Constructor

        public AdicionarVendaViewModel()
        {
            vendasEntities = new OlharMeninaBDEntities();
            AddVendaCommand = new Command((s) => true, AddVenda);
            
        }
        #endregion

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

       


        #endregion

        #region Commands

        public ICommand AddVendaCommand { get; set; }

        #endregion
    }
}
