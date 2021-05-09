using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.enemy
{
    public interface IEnemy
    {

        Pair<Double, Double> GetPosition();

        void TakeDamage(Double damage);


        bool IsAlive();

  
        bool IsArrived();

        void SetArrived(bool arrived);

        void MoveTo(Pair<Double, Double> pos);

        double GetSpeed();

        Pair<int, int> GetDirection();

        void SetDirection(Pair<int, int> dir);

        void DoDamage();

        int GetTypeId();

        Double GetLife();
    }
}
