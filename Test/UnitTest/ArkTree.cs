using Xunit;

namespace UnitTest
{
    public class ArkTree : BaseTest
    {
        [Fact]
        public void Test()
        {
            var key =  _client.Wallet.Key.GeneratePrivateKey(new byte[51], new byte[53]);

            //var reponse = _client.Wallet.Account.CreateAccount("initminer", "Martyn", "{}", key, key, key);
            //if(reponse == null) return false;

            //_client.Wallet.
        }
    }
}