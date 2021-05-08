using OOP20bdefender.DavideBaldelli.enemy;
using OOP20bdefender.DavideBaldelli.enemy.pool;
using OOP20bdefender.DavideBaldelli.enemy.pool.interactors;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using OOP20bdefender.DavideBaldelli.map;

namespace OOP20bdefender.DavideBaldelli.controller
{
    delegate void GraphicMover(List<Enemy> enemies);
    class EnemyControllerImpl : EnemyController
    {
        private EnemiesPoolImpl pool;
        private Thread moverThread;
        private Thread spawnerThread;

        public EnemyControllerImpl(IMap map, GraphicMover gMover)
        {
            this.pool = new EnemiesPoolImpl(new MapInteractorImpl(map));
            MoverThread mover = new MoverThread((EnemyMover)this.pool, gMover);
            this.moverThread = new Thread(new ThreadStart(mover.startMoving));
            this.moverThread.Start();
        }

        public EnemyDamager getDamager()
        {
            return (EnemyDamager)this.pool;
        }

        public void startGenerate(int intensity, int totEnemies, EnemyEvent onReachedEnd, EnemyEvent onDead)
        {
            this.pool.clearPool();
            SpawnerThread spawner = new SpawnerThread((EnemySpawner)this.pool, intensity, totEnemies, onReachedEnd, onDead);
            this.spawnerThread = new Thread(new ThreadStart(spawner.startGenerate));
            this.spawnerThread.Start();         
        }

        public void stopMovingEnemies()
        {
            this.spawnerThread.Abort();
        }

        public void stopSpawnEnemies()
        {
            if(spawnerThread != null)
            {
                this.spawnerThread.Abort();
            }
        }

        class SpawnerThread
        {
            private static long TEN_SEC = 10000;
            private EnemySpawner spawner;
            private int intensity;
            private int totEnemies;
            private EnemyEvent onReachedEnd;
            private EnemyEvent onDead;
            public SpawnerThread(EnemySpawner spawner, int intensity, int totEnemies, EnemyEvent onReachedEnd, EnemyEvent onDead)
            {
                this.spawner = spawner;
                this.intensity = intensity;
                this.totEnemies = totEnemies;
                this.onReachedEnd = onReachedEnd;
                this.onDead = onDead;
            }

            public void startGenerate()
            {               
                for (int i = 0; i < this.totEnemies; i++)
                {
                    Thread.Sleep((int)(TEN_SEC / this.intensity));
                    spawner.addEnemy(getEnemyByType(new Random().Next(0, 2)));
                }
            }

            private Enemy getEnemyByType(int enemyCod)
            {
                switch (enemyCod)
                {
                    case 0:
                        return EnemiesFactory.GetEnemy(EnemyData.AXE_OGRE, this.onReachedEnd, this.onDead);
                    case 1:
                        return EnemiesFactory.GetEnemy(EnemyData.SWORD_OGRE, this.onReachedEnd, this.onDead);
                    default:
                        return null;
                }
            }
        }

        class MoverThread
        {
            private EnemyMover mover;
            private GraphicMover gMover;
            private static long SPEED_DIV = 10;
            private static long TEN_SEC = 10000;

            public MoverThread(EnemyMover mover, GraphicMover gMover)
            {
                this.mover = mover;
                this.gMover = gMover;
            }

            public void startMoving()
            {
                while (true)
                {
                    Thread.Sleep((int)(TEN_SEC / SPEED_DIV));
                    this.mover.moveEnemies(SPEED_DIV);
                    this.gMover(mover.getEnemies().Where(e => e.Value.isAlive() && !e.Value.isArrived()).Select(e => e.Value).ToList());
                }
            }
        }
    }

}
