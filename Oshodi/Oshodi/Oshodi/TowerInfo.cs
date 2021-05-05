using System;
using System.Collections.Generic;

public class TowerInfo {
	public static Dictionary<string, TowerType> Towers { get; private set; }
    public TowerInfo() {
		Towers.Add("Fire Arrow", new TowerType("Fire Arrow", 0, 200, 50, 13, 7, 8));
		Towers.Add("Fire Ball", new TowerType("Fire Ball", 2, 100, 30, 20, 7, 5));
		Towers.Add("Thunder Bolt", new TowerType("Thunder Bolt", 120, 0, 45, 10, 8, 6));
		Towers.Add("Rock", new TowerType("Rock", 3, 50, 55, 30, 5, 5));
	}

}