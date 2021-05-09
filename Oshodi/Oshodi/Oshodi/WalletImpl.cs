using System;

public class WalletImpl : Wallet
{
    const int NEG_LIMIT = -1;
    private int UserMoney = 0;
    //Set the initial amount of money
    public WalletImpl(int InitAmount) {
        this.UserMoney = InitAmount;
    }

    public void AddMoney(int value)
    {
        this.UserMoney = this.UserMoney + value;
    }

    //check if there are enough money to do something
    public bool AreMoneyEnough(int value)
    {
        return this.UserMoney - value > NEG_LIMIT;
    }

    public int GetMoney()
    {
        return this.UserMoney;
    }

    public void SubctractMoney(int value)
    {
        if (AreMoneyEnough(value))
        {
            this.UserMoney = this.UserMoney - value;

        }
    }
}
