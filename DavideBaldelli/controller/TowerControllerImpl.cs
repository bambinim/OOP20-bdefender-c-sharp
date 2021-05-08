using OOP20bdefender.DavideBaldelli.enemy.pool;
using OOP20bdefender.DavideBaldelli.tower;
using OOP20bdefender.DavideBaldelli.tower.interactor;
using OOP20bdefender.DavideBaldelli.tower.view;
using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP20bdefender.DavideBaldelli.controller
{
    class TowerControllerImpl : TowerController
    {
        public delegate TowerView GetTowerView(Tower tower);


        private GetTowerView getView;
        private EnemyDamager damager;
        private Dictionary<Tower, Thread> towersThreads = new Dictionary<Tower, Thread>(); 

        public TowerControllerImpl(GetTowerView getView, EnemyDamager damager)
        {
            this.damager = damager;
            this.getView = getView;
        }
        public Tower addTower(TowerData data, Pair<double, double> pos)
        {
            Tower tower = TowerFactory.GetDirectShootTower(data, new DirectTowerInteractorImpl(this.damager), pos);
            TowerView view = this.getView(tower);
            TowerThread t = new TowerThread(tower, view);
            Thread towerThread = new Thread(new ThreadStart(t.start));
            this.towersThreads.Add(tower, towerThread);
            towerThread.Start();
            return tower;
        }

        public void removeTower(Tower tower)
        {
            this.towersThreads[tower].Abort();
            this.towersThreads.Remove(tower);
        }

        public int upgradeTower(Tower tower)
        {
            return tower.upgradeLevel();
        }

        class TowerThread
        {
            private static long TEN_SECONDS = 10000;
            private TowerView view;
            private Tower tower;

            public TowerThread(Tower tower, TowerView view)
            {
                this.view = view;
                this.tower = tower;
            }

            public void start()
            {
                while (true)
                {
                    Thread.Sleep((int)(TEN_SECONDS / this.tower.getShootSpeed()));
                    Pair<Double, Double> shootTargetPos = tower.shoot();
                    if (shootTargetPos != null)
                    {
                        view.startShootAnimation(new Pair<Double, Double>(shootTargetPos.X, shootTargetPos.Y));
                    }
                }
            }

        }

    }
    
}
