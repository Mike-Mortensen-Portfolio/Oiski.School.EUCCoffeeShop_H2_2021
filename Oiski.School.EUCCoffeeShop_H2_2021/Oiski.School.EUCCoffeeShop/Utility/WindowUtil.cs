using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.EUCCoffeeShop_H2_2021.Utility
{
    public static class WindowUtil
    {
        public static List<IMyWindow> Windows { get; } = new List<IMyWindow> ();

        public static T CreateAndOpenWindow<T> ( string _title ) where T : IMyWindow, new()
        {
            T window = new T ();
            window.Title = _title;
            window.Show ();

            return window;
        }

        public static void OpenWindow ( IMyWindow _window )
        {
            _window.Show ();
        }

        public static void CloseWindow ( IMyWindow _window )
        {
            _window.Close ();
        }

        public static void Visibility (IMyWindow _window, bool _visible )
        {
            _window.Visible = _visible;
        }

        public static T CreateAndSwitchWindow<T> ( IMyWindow _windowToClose, string _title ) where T : IMyWindow, new()
        {
            T window = CreateAndOpenWindow<T> (_title);

            CloseWindow (_windowToClose);

            return window;
        }

        public static void SwitchWindow ( IMyWindow _windowToClose, IMyWindow _windowToOpen )
        {
            _windowToOpen.Show ();

            _windowToClose.Close ();
        }
    }
}
