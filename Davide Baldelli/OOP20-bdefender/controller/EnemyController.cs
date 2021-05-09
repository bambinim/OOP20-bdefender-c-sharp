using OOP20bdefender.DavideBaldelli.enemy;
using OOP20bdefender.DavideBaldelli.enemy.pool;

namespace OOP20bdefender.DavideBaldelli.controller
{
    interface EnemyController
    {

        EnemyDamager GetDamager();

        void StopMovingEnemies();

        void StopSpawnEnemies();

        void StartGenerate(int intensity, int totEnemies, EnemyEvent onReachedEnd, EnemyEvent onDead);
    }
}
