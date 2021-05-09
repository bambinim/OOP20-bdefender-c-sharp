using OOP20bdefender.DavideBaldelli.tower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.controller
{
    interface TowerController
    {
        ITower addTower(TowerData data, Pair<Double, Double> pos);

        void removeTower(ITower tower);

        int upgradeTower(ITower tower);
    }
}
