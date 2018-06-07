using System;
using System.Net.WebSockets;
using Xunit;
using Alexandria.net.Core;
namespace TestAlexandria
{
    public class UnitTest1
    {
        private Wallet newWallet = new Wallet();
        [Fact]
        public void Test1()
        {
            bool val=newWallet.generate_private_key_c("HelloWorld");
            
            Console.WriteLine(val);
        }
    }
}