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
        private Dictionary<int, IEnemy> enemies = new Dictionary<int, IEnemy>();
        private int counter = 0;
        private MapInteractor mapInteractor;

        public EnemiesPoolImpl(MapInteractor mapInteractor)
        {
            this.mapInteractor = mapInteractor;
        }

        public void ClearPool()
        {
            this.enemies.Clear();
        }

        public void AddEnemy(IEnemy enemy)
        {
            enemy.MoveTo(this.mapInteractor.GetSpawnPoint());
            enemy.SetDirection(this.mapInteractor.GetStartingDirection());
            this.enemies.Add(counter++, enemy);
        }

        public void ApplyDamageById(int id, double damage)
        {
            this.enemies[id].TakeDamage(damage);
        }

        public Dictionary<int, IEnemy> GetEnemies()
        {
            return this.enemies;
        }

        public void MoveEnemies(long speedDiv)
        {
            foreach (IEnemy enemy in this.enemies.Values)
            {
                if (enemy.IsAlive() && !enemy.IsArrived())
                {
                    try
                    {
                        
                        enemy.MoveTo(GetNextValidPos(GetNextPos(enemy.GetDirection(), enemy.GetPosition(), new Pair<Double, Double>(enemy.GetSpeed() / speedDiv, enemy.GetSpeed() / speedDiv)), enemy));
                    }
                    catch (EnemyReachedEndException ex)
                    {
                        enemy.SetArrived(true);
                        enemy.DoDamage();
                    }
                }
            }
        }

        private bool IsAfterKeyPoint(Pair<Double, Double> pos, Pair<Double, Double> keyPoint, Pair<int, int> dir)
        {
            return ((pos.X - keyPoint.X) > 0 && pos.Y == keyPoint.Y ) || (pos.X == keyPoint.X && (pos.Y - keyPoint.Y) * dir.Y > 0);

        }

        private bool KeyPointIsAfter(Pair<Double, Double> p1, Pair<Double, Double> p2, Pair<int, int> dir)
        {
            return (p1.X >= p2.X) && ((p1.Y - p2.Y) * dir.Y) >= 0;
        }

        private Pair<Double, Double> GetNextPos(Pair<int, int> dir, Pair<Double, Double> currPos, Pair<Double, Double> distance)
        {
            double newX = currPos.X + (distance.X * dir.X);
            double newY = currPos.Y + (distance.Y * dir.Y);
            return new Pair<Double, Double>(newX, newY);
        }

        private Pair<Double, Double> GetNextValidPos(Pair<Double, Double> nextPosSimple, IEnemy enemy)
        {
            List<Pair<double, double>> keyPoints = new List<Pair<double, double>>(this.mapInteractor.GetKeyPoints());
            Pair<int, int> dir = enemy.GetDirection();
            Pair<Double, Double> currPos = enemy.GetPosition();
            Pair<Double, Double> nxtPos = nextPosSimple;
            foreach (Pair<Double, Double> keyPoint in keyPoints)
            {
                
                if (KeyPointIsAfter(keyPoint, currPos, dir) && IsAfterKeyPoint(nxtPos, keyPoint, dir))
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
                        enemy.SetDirection(new Pair<int, int>(nextXDir, nextYDir));
                        nxtPos = GetNextPos(enemy.GetDirection(), keyPoint, new Pair<Double, Double>(Math.Abs(nxtPos.Y - keyPoint.Y), Math.Abs(nxtPos.X - keyPoint.X)));
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
