using Oiski.School.EUCCoffeeShop_H2_2021.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Oiski.School.EUCCoffeeShop_H2_2021.Events
{
    /// <summary>
    /// Defines a model button functionality
    /// </summary>
    public class WindowViewModel
    {
        /// <summary>
        /// Open a WPF Window
        /// </summary>
        public static ICommand OpenWindow { get; private set; }
        /// <summary>
        /// Close a WPF Window
        /// </summary>
        public static ICommand CloseWindow { get; private set; }
        /// <summary>
        /// Close application
        /// </summary>
        public static ICommand Close { get; private set; }

        /// <summary>
        /// Initializes a new instance of type <see cref="WindowViewModel"/>
        /// </summary>
        public WindowViewModel ()
        {
            OpenWindow = new Command (OpenNewWindow);
            CloseWindow = new Command (CloseOldWindow);
            Close = new Command (CloseApplication);
        }

        /// <summary>
        /// OPen a new WPF <see cref="Window"/>
        /// </summary>
        /// <param name="_sender"></param>
        public void OpenNewWindow ( object _sender )
        {
            if ( _sender != null )
            {
                ( ( Window ) _sender ).Show ();
            }
        }

        /// <summary>
        /// Close a WPF <see cref="Window"/>
        /// </summary>
        /// <param name="_sender"></param>
        public void CloseOldWindow ( object _sender )
        {
            if ( _sender != null )
            {
                ( ( Window ) _sender ).Close ();
            }
        }

        /// <summary>
        /// Close the application
        /// </summary>
        /// <param name="_sender"></param>
        public void CloseApplication ( object _sender )
        {
            Environment.Exit (0);
        }
    }
}
