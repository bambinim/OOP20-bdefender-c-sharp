using System;
using System.Collections.Generic;
using Gtk;
using System.IO;
using System.Linq;

namespace OOP20bdefender.MatteoBambini.Map
{
    public class Map:IMap
    {
        private Gtk.Image mapImage;
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

        public Image MapImage
        {
            get { return this.mapImage; }
        }

        public Map(Gtk.Image mapImage, IList<Coordinates> path, IList<TowerBox> towerBoxes)
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
