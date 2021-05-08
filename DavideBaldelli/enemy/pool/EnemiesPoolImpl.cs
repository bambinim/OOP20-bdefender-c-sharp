using OOP20bdefender.DavideBaldelli.enemy.pool.interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.enemy.pool
{
    public class EnemiesPoolImpl : EnemyDamager, EnemyMover, EnemySpawner
    {
        private Dictionary<int, Enemy> enemies = new Dictionary<int, Enemy>();
        private int counter = 0;
        private MapInteractor mapInteractor;

        public EnemiesPoolImpl(MapInteractor mapInteractor)
        {
            this.mapInteractor = mapInteractor;
        }

        public void clearPool()
        {
            this.enemies.Clear();
        }

        public void addEnemy(Enemy enemy)
        {
            enemy.moveTo(this.mapInteractor.getSpawnPoint());
            enemy.setDirection(this.mapInteractor.getStartingDirection());
            this.enemies.Add(counter++, enemy);
        }

        public void applyDamageById(int id, double damage)
        {
            this.enemies[id].takeDamage(damage);
        }

        public Dictionary<int, Enemy> getEnemies()
        {
            return this.enemies;
        }

        public void moveEnemies(long speedDiv)
        {
            foreach (Enemy enemy in this.enemies.Values)
            {
                if (enemy.isAlive() && !enemy.isArrived())
                {
                    try
                    {
                        
                        enemy.moveTo(getNextValidPos(getNextPos(enemy.getDirection(), enemy.getPosition(), new Pair<Double, Double>(enemy.getSpeed() / speedDiv, enemy.getSpeed() / speedDiv)), enemy));
                    }
                    catch (EnemyReachedEndException ex)
                    {
                        enemy.setArrived(true);
                        enemy.doDamage();
                    }
                }
            }
        }

        private bool isAfterKeyPoint(Pair<Double, Double> pos, Pair<Double, Double> keyPoint, Pair<int, int> dir)
        {
            return ((pos.X - keyPoint.X) > 0 && pos.Y == keyPoint.Y ) || (pos.X == keyPoint.X && (pos.Y - keyPoint.Y) * dir.Y > 0);

        }

        private bool keyPointIsAfter(Pair<Double, Double> p1, Pair<Double, Double> p2, Pair<int, int> dir)
        {
            return (p1.X >= p2.X) && ((p1.Y - p2.Y) * dir.Y) >= 0;
        }

        private Pair<Double, Double> getNextPos(Pair<int, int> dir, Pair<Double, Double> currPos, Pair<Double, Double> distance)
        {
            double newX = currPos.X + (distance.X * dir.X);
            double newY = currPos.Y + (distance.Y * dir.Y);
            return new Pair<Double, Double>(newX, newY);
        }

        private Pair<Double, Double> getNextValidPos(Pair<Double, Double> nextPosSimple, Enemy enemy)
        {
            List<Pair<double, double>> keyPoints = new List<Pair<double, double>>(this.mapInteractor.getKeyPoints());
            Pair<int, int> dir = enemy.getDirection();
            Pair<Double, Double> currPos = enemy.getPosition();
            Pair<Double, Double> nxtPos = nextPosSimple;
            foreach (Pair<Double, Double> keyPoint in keyPoints)
            {
                
                if (keyPointIsAfter(keyPoint, currPos, dir) && isAfterKeyPoint(nxtPos, keyPoint, dir))
                {
                    Console.WriteLine("enemy changed dir at [" + currPos.X + ", " + currPos.Y + "]");
                    int nextXDir = dir.X == 0 ? 1 : 0;
                    int nextYDir = 0;
                    if (keyPoints.IndexOf(keyPoint) + 1 == keyPoints.Count())
                    {
                        throw new EnemyReachedEndException("Enemy reached end");
                    }
                    else
                    {
                        Double nextKeyPointY = keyPoints[keyPoints.IndexOf(keyPoint) + 1].Y;
                        if (!nextKeyPointY.Equals(keyPoint.Y))
                        {
                            nextYDir = nextKeyPointY > keyPoint.Y ? 1 : -1;
                        }
                        enemy.setDirection(new Pair<int, int>(nextXDir, nextYDir));
                        nxtPos = getNextPos(enemy.getDirection(), keyPoint, new Pair<Double, Double>(Math.Abs(nxtPos.Y - keyPoint.Y), Math.Abs(nxtPos.X - keyPoint.X)));
                    }
                    break;
                }
            }
            Console.WriteLine("moving enemy to [" + nxtPos.X + ", "+ nxtPos.Y +"]");
            return nxtPos;
        }


        class EnemyReachedEndException : Exception
        {
            public EnemyReachedEndException(string message)
        : base(message)
            {
            }
        }
    }

}
