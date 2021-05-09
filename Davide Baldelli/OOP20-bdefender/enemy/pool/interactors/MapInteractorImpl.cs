using OOP20bdefender.DavideBaldelli.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP20bdefender.DavideBaldelli.enemy.pool.interactors
{
    class MapInteractorImpl : MapInteractor
    {
        private IMap map;
        public MapInteractorImpl(IMap map)
        {
            this.map = map;
        }
        public List<Pair<double, double>> GetKeyPoints()
        {
            List<Pair<double, double>> keyPoints = new List<Pair<double, double>>();
            for(int i = 0; i < map.Path.Count; i++)
            {
                keyPoints.Add(new Pair<double, double>(map.Path[i].X, map.Path[i].Y));
            }
            return keyPoints;
        }

        public Pair<double, double> GetSpawnPoint()
        {
            return map.Path[0];
        }

        public Pair<int, int> GetStartingDirection()
        {
            int initialX = map.Path[0].X == map.Path[1].X ? 1 : 0;
            int initialY = map.Path[0].Y  == map.Path[1].Y ? 1 : 0;
            return new Pair<int, int>(initialX, initialY);
        }
    }
}
