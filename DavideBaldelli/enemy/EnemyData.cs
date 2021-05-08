using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.enemy
{
    struct EnemyData
    {
        public static EnemyData AXE_OGRE = new EnemyData(4, 20, 30, 1);
        public static EnemyData SWORD_OGRE = new EnemyData(3, 30, 35, 0);
        public double damage { get; }
        public double speed { get; }
        public double life { get; }
        public int id { get; }

        public EnemyData(double damage, double speed, double life, int id)
        {
            this.damage = damage;
            this.speed = speed;
            this.life = life;
            this.id = id;
        }
    }
}
