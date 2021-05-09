using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.enemy
{
    delegate void EnemyEvent(IEnemy enemy);

    class EnemiesFactory
    {
        public static IEnemy GetEnemy(EnemyData data, EnemyEvent onEnemyArrived, EnemyEvent onDeath)
        {
            return new Enemy(data, onEnemyArrived, onDeath);
        }

        private class Enemy : IEnemy
        {
            private EnemyEvent onEnemyArrived;
            private EnemyEvent onDeath;
            private Pair<Double, Double> pos = new Pair<double, double>(0, 0);
            private double life;
            private Pair<int, int> direction = new Pair<int, int>(0, 0);
            private bool arrived = false;
            private EnemyData data;
            public Enemy(EnemyData data, EnemyEvent onDamage, EnemyEvent onDeath)
            {
                this.onEnemyArrived = onDamage;
                this.onDeath = onDeath;
                this.data = data;
                this.life = data.life;
            }
            public void DoDamage()
            {
                onEnemyArrived(this);
            }

            public Pair<int, int> GetDirection()
            {
                return this.direction;
            }

            public double GetLife()
            {
                return this.life;
            }

            public Pair<double, double> GetPosition()
            {
                return this.pos;
            }

            public double GetSpeed()
            {
                return data.speed;
            }

            public int GetTypeId()
            {
                return data.id;
            }

            public bool IsAlive()
            {
                return life > 0;
            }

            public bool IsArrived()
            {
                return this.arrived;
            }

            public void MoveTo(Pair<double, double> pos)
            {
                this.pos = pos;
            }

            public void SetArrived(bool arrived)
            {
                this.arrived = arrived;
            }

            public void SetDirection(Pair<int, int> dir)
            {
                this.direction = dir;
            }

            public void TakeDamage(double damage)
            {
                this.life -= damage;
                if (life <= 0)
                {
                    this.onDeath(this);
                }
            }
        }
    }
}
