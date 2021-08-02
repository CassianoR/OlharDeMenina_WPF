using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LojaOlharDeMenina_WPF.Model
{
    internal class ClientesDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        private string nome;
        private string cpf;
        private string endereco;
        private string telefone;
        private string datanasc;

        public int ID
        {
            get => id; set
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Nome
        {
            get => nome; set
            {
                nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }

        public string CPF
        {
            get => cpf; set
            {
                cpf = value;
                OnPropertyChanged(nameof(CPF));
            }
        }

        public string Endereco
        {
            get => endereco; set
            {
                endereco = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }

        public string Telefone
        {
            get => telefone; set
            {
                telefone = value;
                OnPropertyChanged(nameof(Telefone));
            }
        }

        public string DataNasc
        {
            get => datanasc; set
            {
                datanasc = value;
                OnPropertyChanged(nameof(DataNasc));
            }
        }
    }
}