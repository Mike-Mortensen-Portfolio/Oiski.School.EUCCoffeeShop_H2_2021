using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.EUCCoffeeShop_H2_2021
{
    /// <summary>
    /// Represents a <see cref="Coffee"/>
    /// </summary>
    public class Coffee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public Country OriginCountry { get; set; }

        public bool InStock { get; set; }

        public int AmountInStock { get; set; }

        public DateTime FirstAddedToStockDate { get; set; }

        public int ImageID { get; set; }
    }
}