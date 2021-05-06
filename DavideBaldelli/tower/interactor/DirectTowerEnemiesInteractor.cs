using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.tower.interactor
{
    interface DirectTowerEnemiesInteractor : EnemiesInteractor
    {
        void applyDamageById(int id, double damage);
    }
}
