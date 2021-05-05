using System;

public class ShopImpl : Shop
{
    private Wallet Wallet;
   
    private TowerType TowerToBuy = null;
    private ITower TowerToUp = null;
   
	public ShopImpl(Wallet Wallet)
	{
        this.Wallet = Wallet;
	}

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

    public void BuyUpgrade()
    {
        if (this.TowerToUp != null) {
            int UpgPrice = this.GetUpgPrice();
            if (Wallet.AreMoneyEnough(UpgPrice)) 
            {
                Wallet.SubctractMoney(UpgPrice);
                this.TowerToUp.upgradeTower();
            }
        }
            }

    public ITower getTowerToUpg()
    {
        throw new NotImplementedException();
    }

    public Wallet GetWallet()
    {
        return this.Wallet;
    }

    public bool IsTowerBuyable(TowerType Tower)
    {
        return this.Wallet.AreMoneyEnough(Tower.Price);
    }

    public void setTowerToBuy(TowerType Tower)
    {
        this.TowerToBuy = Tower;
    }

    public void setTowerToUpg(ITower Tower)
    {
        this.TowerToUp = Tower;
    }

    private TowerType FindTowerType(ITower Tower) {
      foreach(TowerType TwType in TowerInfo.Towers.Values)
        {
            if (TwType.Name.Equals(Tower.getName()))
            {
                return TwType;
            }

        }
        throw new InvalidOperationException();
    }

    private int GetUpgPrice() {
       return this.FindTowerType(this.TowerToUp).Price;
    }
}
