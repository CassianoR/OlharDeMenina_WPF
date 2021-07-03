using LojaOlharDeMenina_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace LojaOlharDeMenina_WPF.View
{
    /// <summary>
    /// Interação lógica para Cliente.xam
    /// </summary>
    public partial class Cliente : UserControl
    {
        public Cliente()
        {
            InitializeComponent();
            DataContext = new ClientesViewModel();
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
            for (int i = 0; i < datagrid_cliente.Columns.Count; ++i)
            {
                DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(i) as DataGridCell;
                if (cell != null)
                    cell.IsEditing = true;
            }
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
            for (int i = 0; i < datagrid_cliente.Columns.Count; ++i)
            {
                DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(i) as DataGridCell;
                if (cell != null)
                {
                    if (cell.IsEditing)
                    {
                        //dGrid.CommitEdit(DataGridEditingUnit.Cell, true);
                        cell.IsEditing = false;
                    }
                }
            }
        }

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
    }
}