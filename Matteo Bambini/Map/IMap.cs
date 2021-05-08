using System;
using System.Collections.Generic;
namespace OOP20_bdefender.MatteoBambini.Map
{
    public interface IMap
    {
        IList<Coordinates> Path { get; }
        IList<TowerBox> TowerBoxes { get; }
        IList<TowerBox> GetEmptyTowerBoxes();
        IList<TowerBox> GetOccupiedTowerBoxes();
        byte[] MapImage { get; }
    }
}
