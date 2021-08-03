using LojaOlharDeMenina_WPF.ViewModel;
using LojaOlharDeMenina_WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaOlharDeMenina_WPF.View.Modals;

namespace LojaOlharDeMenina_WPF.Core.Funcionarios
{
    public class EditarCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            //var viewModel = parameter as FuncionariosViewModel;
            //return viewModel != null && viewModel.FuncionarioSelecionado != null;
            return true;
        }

        public override void Execute(object parameter)
        {
            var viewModel = (FuncionariosViewModel)parameter;
            var cloneFuncionario = (Model.Funcionarios)viewModel.FuncionarioSelecionado.Clone();

            viewModel.FuncionarioSelecionado.Nome = cloneFuncionario.Nome;
            viewModel.FuncionarioSelecionado.Endereco = cloneFuncionario.Endereco;
            viewModel.FuncionarioSelecionado.Telefone = cloneFuncionario.Telefone;
        }
    }
}