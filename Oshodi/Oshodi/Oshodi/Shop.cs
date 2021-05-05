using System;

public interface Shop
{
	public bool IsTowerBuyable(TowerType Tower);
	public void BuyTower();
	public void BuyUpgrade();
	public Wallet GetWallet();
	
	public void setTowerToBuy(TowerType Tower);

	public ITower getTowerToUpg();
	public void setTowerToUpg(ITower Tower);

	




}
