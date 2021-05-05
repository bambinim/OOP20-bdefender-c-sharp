using System;
using Xunit;


namespace TestOshodi
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            const int INIT_AMOUNT = 300;
            Wallet Wallet = new WalletImpl(INIT_AMOUNT);
            Shop Shop = new ShopImpl(Wallet);

            Assert.True(true);

            
        }
    }
}
