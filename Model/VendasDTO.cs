using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LojaOlharDeMenina_WPF.Model
{
    internal class VendasDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int codigo;
        private int fk_idfuncionario;
        private int fk_idcliente;
        private int fk_codigoproduto;
        private decimal valor;
        private string metodopagamento;
        private string datahora;
        private int quantidadevendida;

        public int CodigoVendas
        {
            get => codigo; set
            {
                codigo = value;
                OnPropertyChanged(nameof(CodigoVendas));
            }
        }

        public int FK_IDFuncionario
        {
            get => fk_idfuncionario; set
            {
                fk_idfuncionario = value;
                OnPropertyChanged(nameof(FK_IDFuncionario));
            }
        }

        public int FK_IDCliente
        {
            get => fk_idcliente; set
            {
                fk_idcliente = value;
                OnPropertyChanged(nameof(FK_IDCliente));
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

        public decimal Valor
        {
            get => valor; set
            {
                valor = value;
                OnPropertyChanged(nameof(Valor));
            }
        }

        public string MetodoPagamento
        {
            get => metodopagamento; set
            {
                metodopagamento = value;
                OnPropertyChanged(nameof(MetodoPagamento));
            }
        }

        public string DataHora
        {
            get => datahora; set
            {
                datahora = value;
                OnPropertyChanged(nameof(DataHora));
            }
        }

        public int QuantidadeVendida
        {
            get => quantidadevendida; set
            {
                quantidadevendida = value;
                OnPropertyChanged(nameof(QuantidadeVendida));
            }
        }

        public virtual Funcionarios Clientes { get; set; }
        public virtual Funcionarios Funcionarios { get; set; }
        public virtual Produtos Produtos { get; set; }
    }
}