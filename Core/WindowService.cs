using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LojaOlharDeMenina_WPF.View;

namespace LojaOlharDeMenina_WPF.Core
{
    interface IWindowService
    {
        void showWindow();
    }
    
    class WindowService : IWindowService
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
