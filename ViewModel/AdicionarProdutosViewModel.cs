﻿using LojaOlharDeMenina_WPF.Core;
using LojaOlharDeMenina_WPF.Model;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.ViewModel
{
    public class AdicionarProdutosViewModel : ObservableObject
    {
        #region Properties

        private Produtos _produtos = new Produtos();

        public Produtos Produtos
        {
            get { return _produtos; }
            set
            {
                _produtos = value;
                OnPropertyChanged(nameof(Produtos));
            }
        }

        private string message;

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private OlharMeninaBDEntities produtosEntities;
        private Exceptions exc = new Exceptions();

        #endregion Properties

        #region Constructor

        public AdicionarProdutosViewModel()
        {
            produtosEntities = new OlharMeninaBDEntities();
            AddProdutoCommand = new Command((s) => true, AddProduto);
        }

        #endregion Constructor

        #region Methods

        private void AddProduto(object obj)
        {
            if (produtosEntities == null)
                produtosEntities = new OlharMeninaBDEntities();
            Produtos.Codigo = produtosEntities.Clientes.Count();
            produtosEntities.Produtos.Add(Produtos);
            try
            {
                produtosEntities.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = exc.concatenaExceptions(ex);
                Message = exceptionMessage;
                produtosEntities.Dispose();
                produtosEntities = new OlharMeninaBDEntities();
            }
        }

        #endregion Methods

        #region Commands

        public ICommand AddProdutoCommand { get; set; }

        #endregion Commands
    }
}