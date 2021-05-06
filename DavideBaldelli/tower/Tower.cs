using System;

namespace OOP20bdefender.DavideBaldelli.tower
{
    interface Tower
    {
        Pair<Double, Double> shoot();

        int upgradeLevel();

        int getLevel();

        long getShootSpeed();

        int getTowerTypeId();

        Pair<Double, Double> getPosition();

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
