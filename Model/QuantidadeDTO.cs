using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LojaOlharDeMenina_WPF.Model
{
    class QuantidadeDTO:INotifyPropertyChanged
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
