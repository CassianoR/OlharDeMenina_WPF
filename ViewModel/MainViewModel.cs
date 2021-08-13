using LojaOlharDeMenina_WPF.Core;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class MainViewModel : ObservableObject
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

        public bool isEnabled { get; set; }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;
            IdentificaViewCommand = new Command((s) => true, BuscaView);
        }

        public MainViewModel(bool cargo)
        {
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;
            IdentificaViewCommand = new Command((s) => true, BuscaView);
            isEnabled = cargo;
        }

        public ICommand IdentificaViewCommand { get; set; }

        private void BuscaView(object obj) => CurrentView = obj;
    }
}