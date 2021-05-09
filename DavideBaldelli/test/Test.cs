using OOP20bdefender.DavideBaldelli.controller;
using OOP20bdefender.DavideBaldelli.map;
using OOP20bdefender.DavideBaldelli.tower;
using OOP20bdefender.DavideBaldelli.tower.view;
using System;
using System.Collections.Generic;

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
            public IList<Pair<double, double>> Path
            {
                get
                {
                    List<Pair<Double, Double>> coordinates = new List<Pair<Double, Double>>();
                    coordinates.Add(new Pair<Double, Double>(0, 9));
                    coordinates.Add(new Pair<Double, Double>(7, 9));
                    coordinates.Add(new Pair<Double, Double>(7, 18));
                    coordinates.Add(new Pair<Double, Double>(14, 18));
                    coordinates.Add(new Pair<Double, Double>(14, 3));
                    return coordinates;
                }
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
