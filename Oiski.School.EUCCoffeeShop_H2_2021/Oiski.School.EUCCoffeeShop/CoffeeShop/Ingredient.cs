using Oiski.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.EUCCoffeeShop_H2_2021.CoffeeShop
{
    /// <summary>
    /// Represents an <see cref="Ingredient"/> for a <see cref="Coffee"/>
    /// </summary>
    public class Ingredient : IMyRepositoryEntity<int, string>
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="Ingredient"/>
        /// </summary>
        public Ingredient ()
        {
            ID = ingredientCount++;
        }

        /// <summary>
        /// Initialize a new instance of type <see cref="Ingredient"/> where the name is set to <paramref name="_name"/>
        /// </summary>
        /// <param name="_name"></param>
        public Ingredient ( string _name ) : this ()
        {
            Name = _name;
        }

        private static int ingredientCount = 0;

        public string Name { get; set; }
        public bool InStock
        {
            get
            {
                return Stock > 0;
            }
        }
        public int Stock { get; set; }
        public int ID { get; private set; }

        /// <summary>
        /// Build the <see cref="Ingredient"/> based on <paramref name="_data"/>
        /// </summary>
        /// <param name="_data"></param>
        public void BuildEntity ( string _data )
        {
            string[] data = _data.Split (',');

            if ( int.TryParse (data[ 0 ].Replace ("Ingredient", string.Empty), out int _id) && int.TryParse (data[ 1 ], out int _stock) )
            {
                Name = data[ 2 ];
                ID = _id;
                Stock = _stock;

                return;
            }

            throw new FormatException ($"One or more fields couldn't be retrieved from: {_data}");
        }

        /// <summary>
        /// Save the current state of the <see cref="Ingredient"/>
        /// </summary>
        /// <returns></returns>
        public string SaveEntity ()
        {
            return $"Ingredient{ID},{Stock},{Name}";
        }
    }
}
