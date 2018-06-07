using System;
using Alexandria.net.Core;
namespace Test
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Wallet newWallet= new Wallet();
            byte[] buf = new byte[52];
            bool val=newWallet.generate_private_key_c(buf);
            Console.WriteLine(System.Text.Encoding.ASCII.GetString(buf));
            Console.WriteLine(val);

            
            
        }
    }
}