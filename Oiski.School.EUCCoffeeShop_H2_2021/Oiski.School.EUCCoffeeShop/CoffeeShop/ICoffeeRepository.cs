using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.EUCCoffeeShop_H2_2021
{
    /// <summary>
    /// Represents a simulated database link
    /// </summary>
    public interface ICoffeeRepository
    {
        /// <summary>
        /// Remove a <see cref="Coffee"/> from the database
        /// </summary>
        /// <param name="_coffee"></param>
        void DeleteCoffee ( Coffee _coffee );
        /// <summary>
        /// Get a random coffee
        /// </summary>
        /// <returns>A randomely chosen instance of a <see cref="Coffee"/></returns>
        Coffee GetACoffee ();
        /// <summary>
        /// Find a <see cref="Coffee"/> based on its <paramref name="_id"/>
        /// </summary>
        /// <param name="_id"></param>
        /// <returns>The found <see cref="Coffee"/>; Otherwise if no <see cref="Coffee"/> was found, <see langword="null"/></returns>
        Coffee GetCoffeeByID ( int _id );
        /// <summary>
        /// Get all <see cref="Coffee"/> <see langword="objects"/> in the database
        /// </summary>
        /// <returns>A collection of <see cref="Coffee"/> <see langword="objects"/></returns>
        List<Coffee> GetCoffees ();
        /// <summary>
        /// Update a <see cref="Coffee"/> entry in the database
        /// </summary>
        /// <param name="_coffee"></param>
        void UpdateCoffee ( Coffee _coffee );
        /// <summary>
        /// Build the database
        /// </summary>
        void LoadCoffees ();
    }
}