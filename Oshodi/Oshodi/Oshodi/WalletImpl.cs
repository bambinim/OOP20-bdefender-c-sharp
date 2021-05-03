using System;

public class WalletImpl : Wallet
{
    const int NEG_LIMIT = -1;
    private int UserMoney;

    public WalletImpl(int InitAmount) {
        this.UserMoney = InitAmount;
    }

    public void AddMoney(int value)
    {
        this.UserMoney = this.UserMoney + value;
    }

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
