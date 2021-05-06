using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.tower
{
    public struct TowerData
    {
        static TowerData FIRE_ARROW = new TowerData("Fire Arrow", 0, 200, 50, 13, 7, 8);
        static TowerData FIRE_BALL = new TowerData("Fire Ball", 1, 100, 30, 20, 7, 5);

        String name { get; }
        public int id { get; }
        int price { get; }
        int upgCost { get; }
        public Double damage { get; }
        public Double rangeRadius { get; }
        public long shootSpeed { get; }

        public TowerData(string name, int id, int price, int upgCost, double damage, double rangeRadius, long shootSpeed)
        {
            this.name = name;
            this.id = id;
            this.price = price;
            this.upgCost = upgCost;
            this.damage = damage;
            this.rangeRadius = rangeRadius;
            this.shootSpeed = shootSpeed;
        }
    }
}
