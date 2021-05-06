using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.enemy
{
    delegate void EnemyEvent(Enemy enemy);

    class EnemiesFactory
    {
        static Enemy GetEnemy(EnemyData data, EnemyEvent onEnemyArrived, EnemyEvent onDeath)
        {
            return new CustomEnemy(data, onEnemyArrived, onDeath);
        }

        private class CustomEnemy : Enemy
        {
            private EnemyEvent onEnemyArrived;
            private EnemyEvent onDeath;
            private Pair<Double, Double> pos = new Pair<double, double>(0, 0);
            private double life;
            private Pair<int, int> direction = new Pair<int, int>(0, 0);
            private bool arrived = false;
            private EnemyData data;
            public CustomEnemy(EnemyData data, EnemyEvent onDamage, EnemyEvent onDeath)
            {
                this.onEnemyArrived = onDamage;
                this.onDeath = onDeath;
                this.data = data;
                this.life = data.life;
            }
            public void doDamage()
            {
                onEnemyArrived(this);
            }

            public Pair<int, int> getDirection()
            {
                return this.direction;
            }

            public double getLife()
            {
                return this.life;
            }

            public Pair<double, double> getPosition()
            {
                return this.pos;
            }

            public double getSpeed()
            {
                return data.speed;
            }

            public int getTypeId()
            {
                return data.id;
            }

            public bool isAlive()
            {
                return life > 0;
            }

            public bool isArrived()
            {
                return this.arrived;
            }

            public void moveTo(Pair<double, double> pos)
            {
                this.pos = pos;
            }

            public void setArrived(bool arrived)
            {
                this.arrived = arrived;
            }

            public void setDirection(Pair<int, int> dir)
            {
                this.direction = dir;
            }

            public void takeDamage(double damage)
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
