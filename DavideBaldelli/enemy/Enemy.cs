using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.enemy
{
    public interface Enemy
    {

        Pair<Double, Double> getPosition();

        void takeDamage(Double damage);


        bool isAlive();

  
        bool isArrived();

        void setArrived(bool arrived);

        void moveTo(Pair<Double, Double> pos);

        double getSpeed();

        Pair<int, int> getDirection();

        void setDirection(Pair<int, int> dir);

        void doDamage();

        int getTypeId();

        Double getLife();
    }
}
