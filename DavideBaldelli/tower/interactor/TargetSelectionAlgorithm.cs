using System;

namespace OOP20bdefender.DavideBaldelli.tower.interactor
{
    interface TargetSelectionAlgorithm
    {
        int getBestTargetId(EnemiesInteractor interactor, Double radius, Pair<Double, Double> pos);
    }
}
