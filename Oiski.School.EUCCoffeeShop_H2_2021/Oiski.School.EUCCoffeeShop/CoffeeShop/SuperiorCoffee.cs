using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.EUCCoffeeShop_H2_2021
{
    /// <summary>
    /// Represents a <see cref="Coffee"/> with extra specifications
    /// </summary>
    public class SuperiorCoffee : Coffee
    {
        public string ExtraDescription { get; set; }
    }
}