using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LojaOlharDeMenina_WPF.Model
{
    internal class QuantidadeDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string nomecategoria;

        public string NomeCategoria
        {
            get => nomecategoria;
            set
            {
                nomecategoria = value;
                OnPropertyChanged(nameof(NomeCategoria));
            }
        }
    }
}