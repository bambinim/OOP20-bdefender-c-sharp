using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.map
{
    interface IMap
    {
        IList<Pair<Double, Double>> Path { get; }
    }
}
