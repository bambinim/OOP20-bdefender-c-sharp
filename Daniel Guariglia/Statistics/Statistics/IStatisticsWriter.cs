using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsOOP.DanielGuariglia
{
    public interface IStatisticsWriter
    {
        void GameStarted(MapType map);
        void GameFinished(int round);
        void SaveStatistics();
        void ResetAllStatistics();

    }
}
