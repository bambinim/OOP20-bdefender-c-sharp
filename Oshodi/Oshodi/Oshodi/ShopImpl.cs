using System;

public class ShopImpl : Shop
{
    private Wallet Wallet;
    private TowerInfo TowerInfo = new TowerInfo();
    private TowerType TowerToBuy = null;
    private ITower TowerToUp = null;
   
    public ShopImpl(Wallet Wallet)
    {
        this.Wallet = Wallet;
    }

    //buy the tower selected in TowerToBuy
    public void BuyTower()
    {
        if (this.TowerToBuy != null)
        {
            if (this.IsTowerBuyable(TowerToBuy))
            {
                Wallet.SubctractMoney(TowerToBuy.Price);
                this.TowerToBuy = null;
            };
        }
    }

    // buy the Upgrade selected in TowerToUpg
    public void BuyUpgrade()
    {
        int UpgPrice = 0;
        if (this.TowerToUp != null) {
            
             UpgPrice = this.GetUpgPrice();
            
            if (Wallet.AreMoneyEnough(UpgPrice)) 
            {
                Wallet.SubctractMoney(UpgPrice);
                this.TowerToUp.UpgradeTower();
                this.TowerToUp = null;
            }
        }
            }

    public ITower GetTowerToUpg()
    {
        throw new NotImplementedException();
    }

    public Wallet GetWallet()
    {
        return this.Wallet;
    }

    //check if money are enough to buy  the param Tower
    public bool IsTowerBuyable(TowerType Tower)
    {
        return this.Wallet.AreMoneyEnough(Tower.Price);
    }

    //set the next tower that has to be bought
    public void SetTowerToBuy( TowerType Tower)
    {
        this.TowerToBuy = Tower;
    }

    //set the next tower that has to be upgraded
    public void SetTowerToUpg(ITower Tower)
    {
        this.TowerToUp = Tower;
    }

    //from a Object of type Tower return its Type
    private TowerType FindTowerType(ITower Tower) {
      foreach(TowerType TwType in TowerInfo.Towers.Values)
        {
            
            if (TwType.Id.Equals(Tower.GetTowerTypeId()))
            {
                return TwType;
            }

        }
        throw new InvalidOperationException();
    }

    //return the price of the upgrade for the specific tyoe
    private int GetUpgPrice() {
       return this.FindTowerType(this.TowerToUp).UpgCost;
    }

}
