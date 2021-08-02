using LojaOlharDeMenina_WPF.Core;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public HomeViewModel HomeVM { get; set; }
        public FuncionariosViewModel FuncionariosVM { get; set; }
        public VendasViewModel VendasVM { get; set; }
        public ProdutosViewModel ProdutosVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;
            IdentificaViewCommand = new Command((s) => true, BuscaView);
        }

        public ICommand IdentificaViewCommand { get; set; }

        private void BuscaView(object obj) => CurrentView = obj;
    }
}