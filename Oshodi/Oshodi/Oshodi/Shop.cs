using System;

public interface Shop
{
    public bool IsTowerBuyable(TowerType Tower);
    public void BuyTower();
    public void BuyUpgrade();
    public Wallet GetWallet();
    public void SetTowerToBuy(TowerType Tower);
    public ITower GetTowerToUpg();
    public void SetTowerToUpg(ITower Tower);



}
