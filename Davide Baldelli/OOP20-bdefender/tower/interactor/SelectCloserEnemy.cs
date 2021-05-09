using System;
using System.Collections.Generic;

namespace OOP20bdefender.DavideBaldelli.tower.interactor
{
    class SelectCloserEnemy : TargetSelectionAlgorithm
    {
        public int GetBestTargetId(EnemiesInteractor interactor, double radius, Pair<double, double> pos)
        {
            Dictionary<int, Pair<Double, Double>> enemiesInRange = interactor.GetEnemiesInZone(radius, pos);

            if (enemiesInRange.Count == 0)
            {
                throw new NoEnemiesAroundException("no enemies around..");
            }

            Pair<int, Double> closerEnemy = new Pair<int, Double>(0, radius + 1);

            foreach (var enemy in enemiesInRange)
            {
                double distance = Math.Sqrt(Math.Pow(enemy.Value.X - pos.X, 2) + Math.Pow(enemy.Value.Y - pos.Y, 2));
                if (distance <= closerEnemy.Y)
                {
                    closerEnemy = new Pair<int, Double>(enemy.Key, distance);
                }
            }

            return closerEnemy.X;
        }
    }
}
