using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LojaOlharDeMenina_WPF.Model
{
    internal class EstoqueDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        private int numlote;
        private int totalprodutoslote;
        private string frete;
        private string fornecedor;
        private string datacompra;
        private string precolote;
        private int quantidadeestoque;
        private string validade;
        private int fk_codigoproduto;

        public int ID
        {
            get => id; set
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public int NumLote
        {
            get => numlote; set
            {
                numlote = value;
                OnPropertyChanged(nameof(NumLote));
            }
        }

        public int TotalProdutosLote
        {
            get => totalprodutoslote; set
            {
                totalprodutoslote = value;
                OnPropertyChanged(nameof(TotalProdutosLote));
            }
        }

        public string Frete
        {
            get => frete; set
            {
                frete = value;
                OnPropertyChanged(nameof(Frete));
            }
        }

        public string Fornecedor
        {
            get => fornecedor; set
            {
                fornecedor = value;
                OnPropertyChanged(nameof(Fornecedor));
            }
        }

        public string DataCompra
        {
            get => datacompra; set
            {
                datacompra = value;
                OnPropertyChanged(nameof(DataCompra));
            }
        }

        public string PrecoLote
        {
            get => precolote; set
            {
                precolote = value;
                OnPropertyChanged(nameof(PrecoLote));
            }
        }

        public int QuantidadeEstoque
        {
            get => quantidadeestoque; set
            {
                quantidadeestoque = value;
                OnPropertyChanged(nameof(QuantidadeEstoque));
            }
        }

        public string Validade
        {
            get => validade; set
            {
                validade = value;
                OnPropertyChanged(nameof(Validade));
            }
        }

        public int FK_CodigoProduto
        {
            get => fk_codigoproduto; set
            {
                fk_codigoproduto = value;
                OnPropertyChanged(nameof(FK_CodigoProduto));
            }
        }

        public virtual Produtos Produtos { get; set; }
    }
}