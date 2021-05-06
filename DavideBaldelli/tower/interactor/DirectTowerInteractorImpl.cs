using OOP20bdefender.DavideBaldelli.enemy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP20bdefender.DavideBaldelli.tower.interactor
{
    class DirectTowerInteractorImpl : DirectTowerEnemiesInteractor
    {
        private EnemyDamager damager;

        public DirectTowerInteractorImpl(EnemyDamager damager)
        {
            this.damager = damager;
        }

        public void applyDamageById(int id, double damage)
        {
            this.damager.applyDamageById(id, damage);
        }

        public Dictionary<int, Pair<double, double>> getEnemiesInZone(double radius, Pair<double, double> center)
        {
            return this.damager.getEnemies()
                .Where(e => e.Value.isAlive())
                .Where(e => Math.Sqrt(Math.Pow(center.X - e.Value.getPosition().X, 2) + Math.Pow(center.Y - e.Value.getPosition().Y, 2)) <= radius)
                .ToDictionary(e => e.Key,  e => e.Value.getPosition());
        }

        public Pair<double, double> getEnemyPosById(int id)
        {
            return this.damager.getEnemies()[id].getPosition();
        }
    }
}
