using System;

namespace OOP20bdefender.DavideBaldelli.tower
{
    interface ITower
    {
        Pair<Double, Double> shoot();

        int UpgradeLevel();

        int GetLevel();

        long GetShootSpeed();

        int GetTowerTypeId();

        Pair<Double, Double> GetPosition();

    }

    class NoEnemiesAroundException : Exception
    {
        public NoEnemiesAroundException() {}

        public NoEnemiesAroundException(string message)
        : base(message)
        {
        }
    }

}
