using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.enemy.pool
{
    interface EnemyPool 
    {
        Dictionary<int, Enemy> getEnemies();
    }
}
