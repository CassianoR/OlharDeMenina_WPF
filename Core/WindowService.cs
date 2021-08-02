using LojaOlharDeMenina_WPF.View;
using System.Windows;

namespace LojaOlharDeMenina_WPF.Core
{
    internal interface IWindowService
    {
        void showWindow();
    }

    internal class WindowService : IWindowService
    {
        public void showWindow()
        {
            Window1 window = new Window1();
            window.Show();
        }

        public void CloseWindow(Window login)
        {
            login.Close();
        }
    }
}