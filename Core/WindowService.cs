using LojaOlharDeMenina_WPF.View;
using System.Windows;

namespace LojaOlharDeMenina_WPF.Core
{
    internal interface IWindowService
    {
        void showWindow(object cargo);
    }

    internal class WindowService : IWindowService
    {
        public WindowService()
        {
            
        }
        public void showWindow(object cargo)
        {
            if (cargo.ToString() == "Administrador")
            {
                Window1 window = new Window1();
                window._cargo = true;
                window.Show();
            }
            else
            {
                Window1 window = new Window1();
                window._cargo = false;
                window.Show();
            }
        }

        public void CloseWindow(Window login)
        {
            login.Close();
        }
    }
}