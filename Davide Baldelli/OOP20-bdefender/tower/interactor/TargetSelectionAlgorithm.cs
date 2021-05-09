using System;

namespace OOP20bdefender.DavideBaldelli.tower.interactor
{
    interface TargetSelectionAlgorithm
    {
        int GetBestTargetId(EnemiesInteractor interactor, Double radius, Pair<Double, Double> pos);
    }
}
