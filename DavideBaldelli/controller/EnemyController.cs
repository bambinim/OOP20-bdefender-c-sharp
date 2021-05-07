using OOP20bdefender.DavideBaldelli.enemy;
using OOP20bdefender.DavideBaldelli.enemy.pool;

namespace OOP20bdefender.DavideBaldelli.controller
{
    interface EnemyController
    {

        EnemyDamager getDamager();

        void stopMovingEnemies();

        void stopSpawnEnemies();

        void startGenerate(int intensity, int totEnemies, EnemyEvent onReachedEnd, EnemyEvent onDead);
    }
}
