using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.EUCCoffeeShop_H2_2021.Utility
{
    public interface IMyWindow
    {
        string Title { get; set; }
        bool Visible { get; set; }

        void Show ();
        void Close ();
    }
}
