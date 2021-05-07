﻿using System;
using System.Collections.Generic;

namespace OOP20bdefender.DavideBaldelli.enemy.pool.interactors
{
    interface MapInteractor
    {
            
        List<Pair<Double, Double>> getKeyPoints();

        Pair<int, int> getStartingDirection();

        Pair<Double, Double> getSpawnPoint();

    }
}