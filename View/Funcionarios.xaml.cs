﻿using LojaOlharDeMenina_WPF.View.Dialogs;
using LojaOlharDeMenina_WPF.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para Funcionarios.xam
    /// </summary>
    public partial class Funcionarios : UserControl
    {
        public Funcionarios()
        {
            InitializeComponent();
            DataContext = new FuncionariosViewModel();
            for (int i = 0; i < 20; i++)
            {
                TestData.Add(new TestClass { MyProperty = GetRandomText(), MyProperty2 = GetRandomText(), MyProperty3 = GetRandomText() });
            }
        }

        //private void OnMouseEnter(object sender, MouseEventArgs e)
        //{
        //    DataGridRow row = sender as DataGridRow;
        //    DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
        //    for (int i = 0; i < datagrid_funcionario.Columns.Count; ++i)
        //    {
        //        DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(i) as DataGridCell;
        //        if (cell != null)
        //            cell.IsEditing = true;
        //    }
        //}

        //private void OnMouseLeave(object sender, MouseEventArgs e)
        //{
        //    DataGridRow row = sender as DataGridRow;
        //    DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
        //    for (int i = 0; i < datagrid_funcionario.Columns.Count; ++i)
        //    {
        //        DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(i) as DataGridCell;
        //        if (cell != null)
        //        {
        //            if (cell.IsEditing)
        //            {
        //                //dGrid.CommitEdit(DataGridEditingUnit.Cell, true);
        //                cell.IsEditing = false;
        //            }
        //        }
        //    }
        //}

        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private string GetRandomText()
        {
            return System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName());
        }

        private ObservableCollection<TestClass> _testData = new ObservableCollection<TestClass>();

        public ObservableCollection<TestClass> TestData
        {
            get { return _testData; }
            set { _testData = value; }
        }

        private void btnCadastrar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AdicionarFuncionariosDialog acd = new AdicionarFuncionariosDialog();
            acd.ShowDialog();
        }

        public class TestClassCli
        {
            public string MyProperty { get; set; }
            public string MyProperty2 { get; set; }
            public string MyProperty3 { get; set; }
        }

        public static class DataGridTextSearchCli
        {
            public static readonly DependencyProperty SearchValueProperty =
                DependencyProperty.RegisterAttached("SearchValue", typeof(string), typeof(DataGridTextSearch),
                    new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));

            public static string GetSearchValue(DependencyObject obj)
            {
                return (string)obj.GetValue(SearchValueProperty);
            }

            public static void SetSearchValue(DependencyObject obj, string value)
            {
                obj.SetValue(SearchValueProperty, value);
            }

            public static readonly DependencyProperty IsTextMatchProperty =
                DependencyProperty.RegisterAttached("IsTextMatch", typeof(bool), typeof(DataGridTextSearch), new UIPropertyMetadata(false));

            public static bool GetIsTextMatch(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsTextMatchProperty);
            }

            public static void SetIsTextMatch(DependencyObject obj, bool value)
            {
                obj.SetValue(IsTextMatchProperty, value);
            }
        }

        public class SearchValueConverterCli : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                string cellText = values[0] == null ? string.Empty : values[0].ToString();
                string searchText = values[1] as string;

                if (!string.IsNullOrEmpty(searchText) && !string.IsNullOrEmpty(cellText))
                {
                    return cellText.ToLower().StartsWith(searchText.ToLower());
                }
                return false;
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox.Text.Length > 2)
            {
                //using (var contexto = new DbContext())
                //{
                //    var resultado = contexto.Funcionarios
                //                             .Where(m => EF.Functions.Like(m, "%sender%"))
                //                             .ToList();
                //    foreach (var func in resultado)
                //    {
                //        datagrid_funcionario.ItemsSource = func;
                //    }
                //}
            }
        }
    }
}