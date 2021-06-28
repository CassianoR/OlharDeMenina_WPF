using LojaOlharDeMenina_WPF.Core;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public HomeViewModel HomeVM { get; set; }
        public FuncionariosViewModel FuncVM { get; set; }
        public VendasViewModel VendasVM { get; set; }
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
        }
    }
}