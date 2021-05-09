using System;
using System.Collections.Generic;

//name of the tower
  public enum TowerName { 
        FireArrow,
        FireBall,
        ThunderBolt,
        Rock
    }

public class TowerInfo {
    //associate TowerName and Data 
    public static Dictionary<TowerName, TowerType> Towers { get; private set; } = new Dictionary<TowerName, TowerType>();
    public static int Counter = 0;
  
    public TowerInfo() {
        //initialize the dictionary only the first time
        if (TowerInfo.Counter == 0)
        {
            Towers.Add(TowerName.FireArrow, new TowerType("Fire Arrow", 0, 200, 50, 13, 7, 8));
            Towers.Add(TowerName.FireBall, new TowerType("Fire Ball", 2, 100, 30, 20, 7, 5));
            Towers.Add(TowerName.ThunderBolt, new TowerType("Thunder Bolt", 1, 120, 45, 10, 8, 6));
            Towers.Add(TowerName.Rock, new TowerType("Rock", 3, 50, 55, 30, 5, 5));
            TowerInfo.Counter++;
        }
    }

}