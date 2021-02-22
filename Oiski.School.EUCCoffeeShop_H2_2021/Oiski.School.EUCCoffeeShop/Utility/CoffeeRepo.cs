using Oiski.Common.Files;
using Oiski.Common.Repository;
using Oiski.School.EUCCoffeeShop_H2_2021.CoffeeShop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.EUCCoffeeShop_H2_2021.Utility
{
    public class CoffeeRepo : IMyRepository<Coffee, string>
    {
        private CoffeeRepo ()
        {
            file = new FileHandler (filePath);
        }

        private static CoffeeRepo link = null;
        private readonly FileHandler file;

        public static CoffeeRepo Link
        {
            get
            {
                if ( link == null )
                {
                    link = new CoffeeRepo ();
                }

                return link;
            }
        }

        public static readonly string filePath = $"{Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location)}\\Coffees.csv";

        public bool DeleteData<IDType> ( IMyRepositoryEntity<IDType, string> _entity )
        {
            if ( GetDataByIdentifier (_entity.ID) != null )
            {
                file.DeleteLine (file.GetLineNumber (file.FindLine (_entity.ID.ToString ())));
                return true;
            }

            return false;
        }

        public Coffee GetDataByIdentifier<IDType> ( IDType _id )
        {
            string data = file.FindLine ($"ID{Common.Generics.Converter.CastGeneric<IDType, int> (_id)}");

            if ( data != null )
            {
                Coffee cof = new Coffee ();
                ( ( IMyRepositoryEntity<int, string> ) cof ).BuildEntity (data);
                return cof;
            }

            return null;
        }

        public IEnumerable<Coffee> GetEnumerable ()
        {
            List<Coffee> coffees = new List<Coffee> ();

            foreach ( string data in file.ReadLines () )
            {
                if ( !string.IsNullOrEmpty (data) )
                {
                    IMyRepositoryEntity<int, string> cof = new Coffee ();
                    cof.BuildEntity (data);

                    coffees.Add (cof as Coffee);
                }
            }

            return coffees;
        }

        public bool InsertData<IDType> ( IMyRepositoryEntity<IDType, string> _data )
        {
            if ( GetDataByIdentifier (_data.ID) == null )
            {
                file.WriteLine (_data.SaveEntity (), true);

                return true;
            }

            return false;
        }

        public bool UpdateData<IDType> ( IMyRepositoryEntity<IDType, string> _data )
        {
            if ( !string.IsNullOrWhiteSpace (file.FindLine ($"ID{_data.ID}")) )
            {
                file.UpdateLine (_data.SaveEntity (), file.GetLineNumber (file.FindLine ($"ID{Common.Generics.Converter.CastGeneric<IDType, int> (_data.ID)}")));
                return true;
            }

            return false;
        }
    }
}
