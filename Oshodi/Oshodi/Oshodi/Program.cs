using System;

namespace Oshodi
{
    class Program
    {
        static void Main(string[] args)
        {
            Wallet wallet = new WalletImpl(300);
            wallet.AddMoney(300);
            wallet.SubctractMoney(4000);
            Console.WriteLine("" + wallet.GetMoney());
            
        }
    }
}
