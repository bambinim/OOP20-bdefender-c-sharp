using System.Collections.Generic;


namespace OOP20bdefender.DavideBaldelli.enemy.pool
{
    interface EnemyDamager : EnemyPool
    {
        void applyDamageById(int id, double damage);
    }
}
