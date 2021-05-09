using System;
using System.Collections.Generic;

namespace OOP20bdefender.DavideBaldelli.enemy.pool.interactors
{
    public interface MapInteractor
    {
            
        List<Pair<Double, Double>> GetKeyPoints();

        Pair<int, int> GetStartingDirection();

        Pair<Double, Double> GetSpawnPoint();

    }
}
