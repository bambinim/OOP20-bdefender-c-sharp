using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.tower.interactor
{
    interface EnemiesInteractor
    {
        Dictionary<int, Pair<Double, Double>> GetEnemiesInZone(double radius, Pair<Double, Double> center);
        Pair<Double, Double> GetEnemyPosById(int id);
    }
}
