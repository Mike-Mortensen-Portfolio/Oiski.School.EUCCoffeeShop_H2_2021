using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.EUCCoffeeShop_H2_2021
{
    /// <summary>
    /// Represents a simulated database link
    /// </summary>
    class CoffeeRepository : ICoffeeRepository
    {
        private static CoffeeRepository link;
        public static CoffeeRepository Link
        {
            get
            {
                if ( link == null )
                {
                    link = new CoffeeRepository ();
                }

                return link;
            }
        }
        private List<Coffee> coffees;

        /// <summary>
        /// Remove a <see cref="Coffee"/> from the database
        /// </summary>
        /// <param name="_coffee"></param>
        public void DeleteCoffee ( Coffee _coffee )
        {
            Coffee coffee = GetCoffeeByID (_coffee.ID);
            coffees.Remove (coffee);
        }

        /// <summary>
        /// Get a random coffee
        /// </summary>
        /// <returns>A randomely chosen instance of a <see cref="Coffee"/></returns>
        public Coffee GetACoffee ()
        {
            return coffees[ new Random ().Next (0, coffees.Count) ];
        }

        /// <summary>
        /// Find a <see cref="Coffee"/> based on its <paramref name="_id"/>
        /// </summary>
        /// <param name="_id"></param>
        /// <returns>The found <see cref="Coffee"/>; Otherwise if no <see cref="Coffee"/> was found, <see langword="null"/></returns>
        public Coffee GetCoffeeByID ( int _id )
        {
            return coffees.Find (coff => coff.ID == _id);
        }

        /// <summary>
        /// Get all <see cref="Coffee"/> <see langword="objects"/> in the database
        /// </summary>
        /// <returns>A collection of <see cref="Coffee"/> <see langword="objects"/></returns>
        public List<Coffee> GetCoffees ()
        {
            return coffees;
        }

        /// <summary>
        /// Update a <see cref="Coffee"/> entry in the database
        /// </summary>
        /// <param name="_coffee"></param>
        public void UpdateCoffee ( Coffee _coffee )
        {
            coffees[ coffees.IndexOf (GetCoffeeByID (_coffee.ID)) ] = _coffee;
        }

        /// <summary>
        /// Build the database
        /// </summary>
        public void LoadCoffees ()
        {
            coffees = new List<Coffee> ()
            {
                new Coffee ()
                {
                    ID = 1,
                    Name = "Gill's home-made latte",
                    Description = "Simply the best lattes in the world, with a little bit of hazelnut syrup!",
                    ImageID = 1,
                    AmountInStock=10,
                    InStock = true,
                    FirstAddedToStockDate = new DateTime(2014,1,3),
                    OriginCountry = Country.Ethiopia,
                    Price = 12
                },
                new Coffee ()
                {
                    ID = 2,
                    Name = "Espresso",
                    Description = "Espresso is a strong black coffee made by forcing steam through dark-roast aromatic coffee beans at high pressure in an espresso machine. A perfectly brewed espresso will have a thick, golden-brown crema (foam) on the surface. If the crema is good, the sugar you add will float on the surface for a couple of seconds before slowly sinking to the bottom.",
                    ImageID = 2,
                    InStock = true,
                    AmountInStock=100,
                    FirstAddedToStockDate = new DateTime(2015,10,3),
                    OriginCountry = Country.Colombia,
                    Price = 12
                },
                new Coffee ()
                {
                    ID = 3,
                    Name = "Capuccino coffee",
                    Description = "This hugely popular coffee drink has become a staple that even the most common of corner coffee shops carries (or at least a version of it). A true cappuccino is a combination of equal parts espresso, steamed milk and milk froth. This luxurious drink, if made properly, can double as a dessert with its complex flavors and richness.",
                    ImageID = 3,
                    InStock = true,
                    AmountInStock=0,
                    FirstAddedToStockDate = new DateTime(2014,5,5),
                    OriginCountry = Country.Ecuador,
                    Price = 12
                },
                new Coffee ()
                {
                    ID = 4,
                    Name = "Americano",
                    Description = "An Americano is a single shot of espresso added to a cup of hot water. The name is thought to have originated as a bit of an insult to Americans, who had to dilute their espresso when it first gained popularity on this side of the pond. Many coffee houses have perfected it, however, and the result has become a creamy, rich espresso-based coffee that you can sip and savor before jumping on your Vespa and heading to the soccer field.",
                    ImageID = 4,
                    InStock = true,
                    AmountInStock=200,
                    FirstAddedToStockDate = new DateTime(2013,9,9),
                    OriginCountry = Country.India,
                    Price = 14
                },
                new Coffee ()
                {
                    ID = 5,
                    Name = "Caffe Latte",
                    Description = "A caffe latte is a single shot of espresso to three parts of steamed milk.",
                    ImageID = 5,
                    InStock = true,
                    AmountInStock=0,
                    FirstAddedToStockDate = new DateTime(2013,9,9),
                    OriginCountry = Country.India,
                    Price = 9
                },
                new Coffee ()
                {
                    ID = 6,
                    Name = "Cafe au Lait",
                    Description = "This traditional French drink is similar to a caffe latte except that it is made with brewed coffee instead of espresso, in a 1:1 ratio with steamed milk. It is considered a weaker form of caffe latte.",
                    ImageID = 6,
                    InStock = false,
                    AmountInStock=8,
                    FirstAddedToStockDate = new DateTime(2013,9,9),
                    OriginCountry = Country.India,
                    Price = 11
                },
                new Coffee ()
                {
                    ID = 7,
                    Name = "Cafe Mocha",
                    Description = "This is a cappuccino or a caffe latte with chocolate syrup or powder added. There can be wide variations in exactly how this is prepared, so ask your coffee house how they do it before you order.",
                    ImageID = 7,
                    InStock = true,
                    AmountInStock=1000,
                    FirstAddedToStockDate = new DateTime(2013,9,9),
                    OriginCountry = Country.Ethiopia,
                    Price = 10
                },
                new Coffee ()
                {
                    ID = 8,
                    Name = "Caramel Macchiato",
                    Description = "This is another variation that is prepared in a number of ways by different coffee houses. The most common method is combining espresso, caramel and foamed milk, though some use steamed milk. Often, vanilla is added to provide extra flavor.",
                    ImageID = 8,
                    InStock = true,
                    AmountInStock=200,
                    FirstAddedToStockDate = new DateTime(2013,9,9),
                    OriginCountry = Country.Honduras,
                    Price = 11
                }
            };
        }
    }
}
