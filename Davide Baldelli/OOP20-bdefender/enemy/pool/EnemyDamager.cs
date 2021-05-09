using System.Collections.Generic;


namespace OOP20bdefender.DavideBaldelli.enemy.pool
{
    interface EnemyDamager : EnemyPool
    {
        void ApplyDamageById(int id, double damage);
    }
}
