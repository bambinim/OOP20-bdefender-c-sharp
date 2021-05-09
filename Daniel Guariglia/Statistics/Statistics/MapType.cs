using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsOOP.DanielGuariglia
{
    public class MapType
    {
        public static readonly MapType COUNTRYSIDE = new MapType("CountrySide", 0);
        public static readonly MapType ICEPLAIN = new MapType("IcePlain", 1);

        public static IEnumerable<MapType> Values
        {
            get
            {
                yield return COUNTRYSIDE;
                yield return ICEPLAIN;
            }
        }

        public string Name { get; private set; }
        public int Id { get; private set; }

        MapType(string name, int id) =>
            (Name, Id) = (name, id);
    }
}

