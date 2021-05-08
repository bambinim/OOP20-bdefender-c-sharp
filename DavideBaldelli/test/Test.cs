using OOP20bdefender.DavideBaldelli.controller;
using OOP20bdefender.DavideBaldelli.tower;
using OOP20bdefender.DavideBaldelli.tower.view;
using OOP20bdefender.MatteoBambini.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.test
{
    class Test
    {
        public static void Main(string []args)
        {
            MapTest map = new MapTest();
            EnemyController enemyController = new EnemyControllerImpl(map, t => { });
            enemyController.startGenerate(6, 1, e => Console.WriteLine("An enemy as reached the end"), e => Console.WriteLine("An Enemy as died"));

            TowerController towerController = new TowerControllerImpl(t => new TowerViewImpl(), enemyController.getDamager());
            towerController.addTower(TowerData.FIRE_BALL, new Pair<double, double>(9, 11));
        }

        class MapTest : IMap
        {
            public IList<Coordinates> Path { 
                get {
                    List<Coordinates> coordinates = new List<Coordinates>();
                    coordinates.Add(new Coordinates(0, 9));
                    coordinates.Add(new Coordinates(7, 9));
                    coordinates.Add(new Coordinates(7, 18));
                    coordinates.Add(new Coordinates(14, 18));
                    coordinates.Add(new Coordinates(14, 3));
                    return coordinates; 
                } 
            }

            public IList<TowerBox> TowerBoxes => throw new NotImplementedException();

            public Gtk.Image MapImage => throw new NotImplementedException();

            public IList<TowerBox> GetEmptyTowerBoxes()
            {
                throw new NotImplementedException();
            }

            public IList<TowerBox> GetOccupiedTowerBoxes()
            {
                throw new NotImplementedException();
            }
        }

        class TowerViewImpl : TowerView
        {
            public void startShootAnimation(Pair<double, double> target)
            {
                Console.WriteLine("shooting animation..");
            }
        }
    }
}
