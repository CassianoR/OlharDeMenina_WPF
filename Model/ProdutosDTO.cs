using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LojaOlharDeMenina_WPF.Model
{
    class ProdutosDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int codigo;
        private string fk_nomecategoria;
        private string nomeproduto;
        private string unidademedida;
        private string marca;
        private string categoria;
        private string descricao;
        private decimal valor;

        public int Codigo
        {
            get => codigo;
            set
            {
                codigo = value;
                OnPropertyChanged(nameof(Codigo));
            }
        }
        public string FK_NomeCategoria
        {
            get => fk_nomecategoria;
            set
            {
                fk_nomecategoria = value;
                OnPropertyChanged(nameof(fk_nomecategoria));
            }
        }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string NomeProduto
        {
            get => nomeproduto;
            set
            {
                nomeproduto = value;
                OnPropertyChanged(nameof(NomeProduto));
            }
        }

        [Required(ErrorMessage = "O campo Unidade de medida é obrigatório.")]
        public string UnidadeMedida
        {
            get => unidademedida;
            set
            {
                unidademedida = value;
                OnPropertyChanged(nameof(UnidadeMedida));
            }
        }
        [Required]
        public string Marca
        {
            get => marca;
            set
            {
                marca = value;
                OnPropertyChanged(nameof(Marca));
            }
        }
        public string Categoria
        {
            get => categoria;
            set
            {
                categoria = value;
                OnPropertyChanged(nameof(Categoria));
            }
        }
        [Required]
        public string Descricao
        {
            get => descricao;
            set
            {
                descricao = value;
                OnPropertyChanged(nameof(Descricao));
            }
        }

        [Required]
        [RegularExpression(@"/^\d*\.?\d*$/", ErrorMessage = "O campo Valor precisa estar no formato correto. (00.0)")]
        public decimal Valor
        {
            get => valor;
            set
            {
                valor = value;
                OnPropertyChanged(nameof(Valor));
            }
        }
    }
}
