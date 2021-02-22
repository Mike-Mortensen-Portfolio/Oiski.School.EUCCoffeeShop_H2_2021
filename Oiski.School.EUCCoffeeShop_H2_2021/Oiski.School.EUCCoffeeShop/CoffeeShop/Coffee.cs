using Oiski.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.EUCCoffeeShop_H2_2021.CoffeeShop
{
    /// <summary>
    /// Represents a Coffee
    /// </summary>
    public class Coffee : IMyRepositoryEntity<int, string>
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="Coffee"/>
        /// </summary>
        public Coffee ()
        {
            ID = coffeeCount++;
            Ingredients = new List<Ingredient> ();
        }

        private static int coffeeCount = 0;

        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// The collection of <see cref="Ingredient"/> <see langword="objects"/> that makes up the recipe
        /// </summary>
        public List<Ingredient> Ingredients { get; private set; }
        /// <summary>
        /// Returns the collection of <see cref="Ingredient"/> <see langword="objects"/> as a <see langword="string"/>
        /// </summary>
        public string GetIngredientsAsString
        {
            get
            {
                string ings = string.Empty;

                foreach ( Ingredient item in Ingredients )
                {
                    ings += $"{item.Name}{Environment.NewLine}";
                }

                return ings;
            }
        }
        public int ID { get; private set; }

        /// <summary>
        /// Build the <see cref="Coffee"/> <see langword="object"/> based on a formatted string (<i><strong>Note: </strong>"ID[id],[Name],[Description],[Ingredients]"</i>)
        /// </summary>
        /// <param name="_data"></param>
        public void BuildEntity ( string _data )
        {
            string[] data = _data.Split (',');

            if ( int.TryParse (data[ 0 ].Replace ("ID", string.Empty), out int _id) && data.Length >= 3 )
            {
                ID = _id;
                Name = data[ 1 ];
                Description = data[ 2 ];

                Ingredients = new List<Ingredient> ();
                for ( int i = 3; i < data.Length; i += 3 )
                {
                    Ingredient ing = new Ingredient ();

                    string ingredientString = $"{data[ i ]},{data[ i + 1 ]},{data[ i + 2 ]}";
                    ing.BuildEntity (ingredientString);

                    Ingredients.Add (ing);
                }

                return;
            }

            throw new FormatException ($"One or more fields couldn't be retrieved from: {_data}");
        }

        /// <summary>
        /// Saved the current state of the <see cref="Cofffe"/> <see langword="object"/> to a coma seperated string format
        /// </summary>
        /// <returns></returns>
        public string SaveEntity ()
        {
            string ingredients = string.Empty;

            for ( int i = 0; i < Ingredients.Count; i++ )
            {
                ingredients += $"{Ingredients[ i ].SaveEntity ()}";

                if ( i != Ingredients.Count - 1 )
                {
                    ingredients += ",";
                }
            }

            return $"ID{ID},{Name},{Description},{ingredients}";
        }
    }
}
