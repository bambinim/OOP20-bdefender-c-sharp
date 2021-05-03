using System;
using System.Collections.Generic;
namespace OOP20bdefender.MatteoBambini.Map
{
    public interface IMap
    {
        IList<Coordinates> Path { get; }
        IList<TowerBox> TowerBoxes { get; }
        IList<TowerBox> GetEmptyTowerBoxes();
        IList<TowerBox> GetOccupiedTowerBoxes();
        Gtk.Image MapImage { get; }
    }
}
