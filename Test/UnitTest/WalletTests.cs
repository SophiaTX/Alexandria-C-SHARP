using System;
using System.Collections.Generic;
using Alexandria.net.Enums;
using Alexandria.net.Messaging.Receiver;
using Xunit;


namespace UnitTest
{
    public class WalletTests : BaseTest
    {
        #region Member Variables

        private const string Transaction =
            "{\"ref_block_num\":16364,\"ref_block_prefix\":2217467278,\"expiration\":\"2018-06-20T15:24:06\",\"operations\":[[\"account_create\",{\"fee\":\"0.100000 SPHTX\",\"creator\":\"initminer\",\"new_account_name\":\"sanjiv9999\",\"owner\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",1]]},\"active\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",1]]},\"memo_key\":\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",\"json_metadata\":\"{}\"}]],\"extensions\":[],\"signatures\":[]}";

        private const string Digest = "fe7ee427286c25eb48a39218f4415fd64f59b25aac2978a8a534b542cf8059c9";

        private const string Sign =
            "1f7d9cb0bf47d052a35b2f8534e46b0197abc636c0627e9f5ef54fedbd5c5b1d1318ae0983a7281633da849045a267b6f4acbb178d2533ce6d9807f8074f2b6099";
        //-----client1
        private const string PrivateKey = "5KGL7MNAfwCzQ8DAq7DXJsneXagka3KNcjgkRayJoeJUucSLkev";
        private const string PublicKey = "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz";
        
        //-----client2
        private const string PrivateKey2 = "5HqnQB5R8Yfaq4mALL33kkBGFuSv2kMPxGsjFygHPhk8EqunmXZ";
        private const string PublicKey2 = "SPH6eJ4GcGtay4qvZ7eebXaLkGcXsMhq3WC1GgyQbTLbEd6EVisSm";
        
        private const string ChainId = "00000000000000000000000000000000";

        private const string Brain =
            "DERRIDE BASCULE NIMBUS DOXA BURL AURALLY OER GOSSIPY BEHALE PINKER INVOKER YAULD HOYLE POTTY TITE WHUD";

        #endregion

        #region Witness Methods

        [Fact]
        public void GetActiveWitness()
        {
            _client.Witness.GetActiveWitnesses();
        }

        [Fact]
        public void ListWitnesses()
        {
            _client.Witness.ListWitnesses("initminer", 10);
        }

        [Fact]
        public void GetWitness()
        {
            _client.Witness.GetWitness("initminer");
        }

        [Fact]
        public void VoteForWitness()
        {
            _client.Witness.VoteForWitness("test101", "initminer", true, PrivateKey);
        }
        [Fact]
        public void update_witness()
        {
            int amount;
            string symbol;
         //  var price=new object(){amount=1,symbol="SPHTX"};
            
            var pricefeed = new List<object> {};

            //var pricefeedtuple=new Tuple<AssetType>(pricefeed);
            var result=_client.Witness.UpdateWitness("test101", "http://www.testminer.com", PublicKey, "10.000 SPHTX",900,pricefeed,PrivateKey);
            Console.WriteLine(result);
        }
        #endregion

        #region Transaction Methods

        [Fact]
        public void GetFeedHistory()
        {
            //var feedSymbol = new AssetType {Symbol = "SPT1"};
            _client.Transaction.GetFeedHistory("SPHTX");
        }

        [Fact]
        public void GetAbout()
        {
            _client.Transaction.About();
        }

        [Fact]
        public void Help()
        {
            _client.Transaction.Help();
        }

        [Fact]
        public void Info()
        {
            _client.Transaction.Info();
        }

        [Fact]
        public void GetBlock()
        {
            _client.Transaction.GetBlock(1983);

        }

        [Fact]
        public void get_ops_in_block()
        {
            _client.Transaction.GetOpsInBlock(1983, true);
        }

        

        [Fact]
        public void GetTransaction()
        {
            _client.Transaction.GetTransaction("2095fecb2a679dd8a1cee16472c4c5fe9edcc01d");

        }

        [Fact]
        public void set_voting_proxy()
        {
            _client.Account.SetVotingProxy("test101", "test103", PrivateKey);

        }

        #endregion

        #region Key Methods

        [Fact]
        public void GeneratePrivateKey()
        {
           var result= _client.Key.GeneratePrivateKey(new byte[51], new byte[53]);
           Console.WriteLine(result);
        }

        [Fact]
        public void GetTransactionDigest()
        {
            _client.Key.GetTransactionDigest(Transaction, ChainId, new byte[64]);

        }

        [Fact]
        public void GetPublicKey()
        {
            _client.Key.GetPublicKey("5KGL7MNAfwCzQ8DAq7DXJsneXagka3KNcjgkRayJoeJUucSLkev", new byte[53]);

        }

        [Fact]
        public void GenerateKeyPairFromBrainKey()
        {
            _client.Key.GenerateKeyPairFromBrainKey(Brain, new byte[51], new byte[53]);

        }

        [Fact]
        public void VerifySignaturet()
        {
            _client.Key.VerifySignature(Digest, PublicKey, Sign);

        }

        [Fact]
        public void SignedDigest()
        {
            _client.Key.SignDigest(Digest, PrivateKey, new byte[130]);

        }

        [Fact]
        public void EncryptMemo()
        {
            _client.Key.EncryptMemo("{Hello:World}", PrivateKey, PublicKey2, new byte[1024]);

        }
        [Fact]
        public void DecryptMemo()
        {
            _client.Key.DecryptMemo("2ZJ8RsXVNcNEoWPr6U5XYcjJeEfuz8cZbUNKxi6UQcgpxch5K1rRqagDHTv3C9vZLDJpSD9WYss6VHAWWvWVNCtCNkadKEcvaSV9SecRUnFeomX9HDTvhTXLW6BAAvuLRBMFLo1", PrivateKey2, PublicKey, new byte[1024]);

        }
        [Fact]
        public void AddSignature()
        {
            _client.Key.AddSignature(Transaction, Sign, new byte[Transaction.Length + 200]);

        }

        [Fact]
        public void SuggestBrainKey()
        {
            var result=_client.Key.SuggestBrainKey();
            Console.WriteLine(result);
        }

        [Fact]
        public void NormalizeBrainKey()
        {
            _client.Key.NormalizeBrainKey(Brain);

        }

        #endregion

        #region Account Methods

        [Fact]
        public void CreateAccount()
        {
           var result= _client.Account.CreateAccount("martyn6", "{}",
                "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz",
                "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz",
                "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz");
            Console.WriteLine(result);
        }
        
        [Fact]
        public void GetAccount()
        {
            var result=_client.Account.GetAccount("martyn");
            Console.WriteLine(result);
        }

        [Fact]
        public void DeleteAccount()
        {
            _client.Account.DeleteAccount("test106", PrivateKey);

        }

        [Fact]
        public void update_account()
        {
            var result=_client.Account.UpdateAccount("test110", "{}",
                "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz",
                "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz",
                "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz", PrivateKey);
            Console.WriteLine(result);
        }

        

        #endregion

        #region Asset Methods
        [Fact]
        public void WithdrawVesting()
        {
            _client.Asset.WithdrawVesting("test101", "10.000000 VESTS", PrivateKey);
        }
        [Fact]
        public void Transfer()
        {
            
            _client.Asset.Transfer("test101", "test110", "10.000 SPHTX",
                "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz", PrivateKey);

        }

        [Fact]
        public void TransferToVesting()
        {
            _client.Asset.TransferToVesting("test101", "test101", "100.000 SPHTX", PrivateKey);

        }

        #endregion

        #region Data Methods

        [Fact]
        public void Send()
        {
            var test = "{\"ref_block_num\":16364,\"ref_block_prefix\":2217467278,\"expiration\":\"2018-06-20T15:24:06\",\"operations\":[[\"account_create\",{\"fee\":\"0.100000 SPHTX\",\"creator\":\"initminer\",\"new_account_name\":\"sanjiv9999\",\"owner\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",1]]},\"active\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",1]]},\"memo_key\":\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",\"json_metadata\":\"{}\"}]],\"extensions\":[],\"signatures\":[]}";
            
           
            var data = new SenderData
            {
                AppId = 2,
                PrivateKey = PrivateKey,
                Recipients = new List<string> {"2hPgEeeuitiNeM8bCCQWTKx9u6wx"},
                Sender = "rumGMWVHCxedjhSHMBQYk3o9LVD",
                Document = test//"[\"" + $"{test}" + "\"]"
            };
            var result = _client.Data.Send(data);
            Console.WriteLine(result);
        }

        [Fact]
        public void SendBinary()
        {
            var data = new SenderData
            {
                AppId = 2,
                PrivateKey = PrivateKey,
                Recipients = new List<string> {"test101"},
                Sender = "test110",
                DocumentChars = "2ZJ8RsXVNcNEoWPr6U5XYcjJeEfuz8cZbUNKxi6UQcgpxch5K1rRqagDHTv3C9vZLDJpSD9WYss6VHAWWvWVNCtCNkadKEcvaSV9SecRUnFeomX9HDTvhTXLW6BAAvuLRBMFLo1" //"[\"" + $"{test}" + "\"]"
            };
            
            var result = _client.Data.SendBinary(data);
            Console.WriteLine(result);
        }
        
        
        [Fact]
        public void Receive()
        {
            var result = _client.Data.Receive(2,"test110",SearchType.BySender,"2018-06-22T13:39:34",10);
            Console.WriteLine(result);
        }

        #endregion

        #region Application Methods

        [Fact]
        public void CreateApplication()
        {
            _client.Application.CreateApplication("test101","BoxGame5","http://boxgame.com","genre: Adventure, requirements: Mac OS Sierra",1,PrivateKey);

        }
        [Fact]
        public void UpdateApplication()
        {
            _client.Application.UpdateApplication("test101","BoxGame","test106","http://boxGamers.com","Genre:Action",1,PrivateKey);

        }

        [Fact]
        public void DeleteApplication()
        {
            _client.Application.DeleteApplication("test101","BoxGame",PrivateKey);

        }

        [Fact]
        public void BuyApplication()
        {
            _client.Application.BuyApplication("test110",4,PrivateKey);

        }

        [Fact]
        public void CancelApplicationBuying()
        {
            _client.Application.CancelApplicationBuying("test101","test110",4,PrivateKey);

        }

        [Fact]
        public void GetApplicationBuyings()
        {
            _client.Application.GetApplicationBuyings("test110",SearchType.ByBuyer,10);

        }
        [Fact]
        public void GetApplications()
        {
            var names = new List<string>{"BoxGame5","BoxGame4"};
            _client.Application.GetApplications(names);
        }


        #endregion
    }
}

