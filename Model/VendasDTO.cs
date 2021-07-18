using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LojaOlharDeMenina_WPF.Model
{
    class VendasDTO : INotifyPropertyChanged
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
        private DateTime datahora;
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
                OnPropertyChanged(nameof(fk_idfuncionario));
            }
        }
        public int FK_IDCliente
        {
            get => fk_idcliente; set
            {
                fk_idcliente = value;
                OnPropertyChanged(nameof(fk_idcliente));
            }

        }

        public int FK_CodigoProduto
        {
            get => fk_codigoproduto; set
            {
                fk_codigoproduto = value;
                OnPropertyChanged(nameof(fk_codigoproduto));
            }
        }

        public decimal Valor
        {
            get => valor ; set
            {
                valor = value;
                OnPropertyChanged(nameof(valor));
            }
        }


        public string MetodoPagamento
        {
            get => metodopagamento; set
            {
                metodopagamento = value;
                OnPropertyChanged(nameof(metodopagamento));
            }
        }

        public System.DateTime DataHora
        {
            get => datahora; set
            {
                datahora = value;
                OnPropertyChanged(nameof(datahora));
            }
        }

        public int QuantidadeVendida
        {
            get => quantidadevendida; set
            {
                quantidadevendida = value;
                OnPropertyChanged(nameof(quantidadevendida));
            }
        }




        public virtual Clientes Clientes { get; set; }
        public virtual Funcionarios Funcionarios { get; set; }
        public virtual Produtos Produtos { get; set; }
    }
}
