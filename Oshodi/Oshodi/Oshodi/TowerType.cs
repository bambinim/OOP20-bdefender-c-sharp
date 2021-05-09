using System;

public class TowerType
{
    //infomation about tower 
    public string Name { get; private set; }
    public int Id { get; private set; }
    public int Price { get; private set; }
    public int UpgCost { get; private set; }
    public int Damage { get; private set; }
    public int RangeRadius { get; private set; }
    public int ShootSpeed { get; private set; }


    public TowerType(string Name, int Id, int Price, int UpgCost, int Damage, int RangeRadius, int ShootSpeed)
    {
        this.Name = Name;
        this.Id = Id;
        this.Price = Price;
        this.UpgCost = UpgCost;
        this.Damage = Damage;
        this.RangeRadius = RangeRadius;
        this.ShootSpeed = ShootSpeed;
    }


}
