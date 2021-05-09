using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsOOP.DanielGuariglia
{
    public interface IStatisticsReader
    {
        int GetHigherstRoundEver();
        MapType GetMostPlayedMap();
        long GetTotTimePlayed();
        void Reload();
    }
}
