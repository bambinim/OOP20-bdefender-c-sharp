using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOP20_bdefender.MatteoBambini.Map
{
    public class Map:IMap
    {
        private byte[] mapImage;
        private IList<Coordinates> path;
        private IList<TowerBox> towerBoxes;

        public IList<Coordinates> Path
        {
            get { return this.path; }
        }

        public IList<TowerBox> TowerBoxes
        {
            get { return this.towerBoxes; }
        }

        public byte[] MapImage
        {
            get { return this.mapImage; }
        }

        public Map(byte[] mapImage, IList<Coordinates> path, IList<TowerBox> towerBoxes)
        {
            this.mapImage = mapImage;
            this.path = path;
            this.towerBoxes = towerBoxes;
        }

        public IList<TowerBox> GetEmptyTowerBoxes()
        {
            return Enumerable.AsEnumerable<TowerBox>(this.towerBoxes).Where<TowerBox>((el) => el.Tower == null).ToList<TowerBox>();
        }

        public IList<TowerBox> GetOccupiedTowerBoxes()
        {
            return Enumerable.AsEnumerable<TowerBox>(this.towerBoxes).Where<TowerBox>((el) => el.Tower != null).ToList<TowerBox>();
        }
    }
}
