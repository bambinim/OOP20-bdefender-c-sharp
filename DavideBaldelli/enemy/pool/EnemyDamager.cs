
using System.Collections.Generic;


namespace OOP20bdefender.DavideBaldelli.enemy
{
    interface EnemyDamager
    {
        Dictionary<int, Enemy> getEnemies();
        void applyDamageById(int id, double damage);
    }
}
