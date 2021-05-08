using System;
namespace OOP20_bdefender.MatteoBambini.Map
{
    public class TowerBox
    {
        private readonly Coordinates topLeftCoord;
        private string tower = null;

        public string Tower
        {
            get { return this.tower; }
            set { this.tower = value; }
        }

        public Coordinates TopLeftCoord
        {
            get { return this.topLeftCoord; }
        }

        public TowerBox(Coordinates topLeftCoord)
        {
            this.topLeftCoord = topLeftCoord;
        }

        public Coordinates GetCentralCoordinate()
        {
            return new Coordinates(this.topLeftCoord.X + 0.5, this.topLeftCoord.Y + 0.5);
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                TowerBox tmp = (TowerBox)obj;
                return tmp.TopLeftCoord.Equals(this.topLeftCoord) && tmp.Tower.Equals(this.tower);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.topLeftCoord.GetHashCode() + this.Tower.GetHashCode();
        }
    }
}
