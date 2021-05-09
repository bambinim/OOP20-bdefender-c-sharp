using OOP20bdefender.DavideBaldelli.enemy.pool;
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

        public void ApplyDamageById(int id, double damage)
        {
            this.damager.ApplyDamageById(id, damage);
        }

        public Dictionary<int, Pair<double, double>> GetEnemiesInZone(double radius, Pair<double, double> center)
        {
            return this.damager.GetEnemies()
                .Where(e => e.Value.IsAlive() && !e.Value.IsArrived())
                .Where(e => Math.Sqrt(Math.Pow(center.X - e.Value.GetPosition().X, 2) + Math.Pow(center.Y - e.Value.GetPosition().Y, 2)) <= radius)
                .ToDictionary(e => e.Key,  e => e.Value.GetPosition());
        }

        public Pair<double, double> GetEnemyPosById(int id)
        {
            return this.damager.GetEnemies()[id].GetPosition();
        }
    }
}
