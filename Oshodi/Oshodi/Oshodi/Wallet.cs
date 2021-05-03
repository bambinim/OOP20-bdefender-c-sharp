using System;

public interface Wallet
{
	public void SubctractMoney(int value);
	public void AddMoney(int value);
	public bool AreMoneyEnough(int value);
	public int GetMoney();

}
