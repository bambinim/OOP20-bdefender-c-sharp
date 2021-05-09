using System;
using Xunit;


namespace TestOshodi
{
    public class Test
    {
        [Fact]
        public void Test1()
        {
            const int INIT_AMOUNT = 300;
            int TowerId = 0;
            Wallet Wallet = new WalletImpl(INIT_AMOUNT);
            Shop Shop = new ShopImpl(Wallet);
            ITower Tower = new TowerTest(TowerId); //creating a Fire Arrow Tower
            TowerInfo TowerInfo = new TowerInfo();
            Shop.BuyTower();
            //if TowerToBuy wasn't specified nothing should happen
            Assert.Equal(INIT_AMOUNT, Shop.GetWallet().GetMoney());
            //set as Tower to buy a Fire Arrow Tower
            Shop.SetTowerToBuy(TowerInfo.Towers[TowerName.FireArrow]);
            Shop.BuyTower();
            //INIT_AMOUNT - Fire Arrow Price (200)
            Assert.Equal(100, Shop.GetWallet().GetMoney());
            //buy FireArrow for the second time
            Shop.BuyTower();
            //nothing should happen because no tower to buy was specified
            Shop.BuyTower();
            Assert.Equal(100, Shop.GetWallet().GetMoney());
            Shop.SetTowerToBuy(TowerInfo.Towers[TowerName.ThunderBolt]);
            //no enough money, purchase should not be possible
            Shop.BuyTower();
            Assert.False(-20 == Shop.GetWallet().GetMoney());
            
            //UPGRADE
            Shop.SetTowerToUpg(Tower);
            Shop.BuyUpgrade();
            //UserMoney (100) - Upg Cost (50);
            Assert.Equal(50, Shop.GetWallet().GetMoney());
            //if TowerToUp wasn't specified nothing should happen
            Shop.BuyUpgrade();
            Assert.False(0 == Shop.GetWallet().GetMoney());
          
            Shop.SetTowerToUpg(Tower);
            Shop.BuyUpgrade();
            Assert.Equal(0, Shop.GetWallet().GetMoney());
            //can't buy if money is 0
            Shop.SetTowerToUpg(Tower);
            Shop.BuyUpgrade();
            Assert.False(-50 == Shop.GetWallet().GetMoney());






        }

        

        
    }

    //implemented to test
    class TowerTest : ITower
    {
        int Id;

        public TowerTest(int Id) 
        {
            this.Id = Id;
        }

        public int GetTowerTypeId()
        {
            return this.Id;
        }


        public void UpgradeTower()
        {
            Console.WriteLine("UPGRADE");
        }

    }
}
