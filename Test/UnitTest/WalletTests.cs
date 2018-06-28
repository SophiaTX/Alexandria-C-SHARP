using System;
using System.Collections.Generic;
using System.Data;
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
            _client.Wallet.Witness.GetActiveWitnesses();
        }

        [Fact]
        public void ListWitnesses()
        {
            _client.Wallet.Witness.ListWitnesses("initminer", 10);
        }

        [Fact]
        public void GetWitness()
        {
            _client.Wallet.Witness.GetWitness("initminer");
        }

        [Fact]
        public void VoteForWitness()
        {
            _client.Wallet.Witness.VoteForWitness("test101", "initminer", true, PrivateKey);
        }
        [Fact]
        public void update_witness()
        {
            
            _client.Wallet.Witness.UpdateWitness("test101", "http://www.testminer.com", PublicKey, "SPHTX",1,PrivateKey);
        
        }
        #endregion

        #region Transaction Methods

        [Fact]
        public void GetFeedHistory()
        {
            _client.Wallet.Transaction.GetFeedHistory();
        }

        [Fact]
        public void GetAbout()
        {
            _client.Wallet.Transaction.About();
        }

        [Fact]
        public void Help()
        {
            _client.Wallet.Transaction.Help();
        }

        [Fact]
        public void Info()
        {
            _client.Wallet.Transaction.Info();
        }

        [Fact]
        public void GetBlock()
        {
            _client.Wallet.Transaction.GetBlock(1983);

        }

        [Fact]
        public void get_ops_in_block()
        {
            _client.Wallet.Transaction.GetOpsInBlock(1983, true);
        }

        

        [Fact]
        public void GetTransaction()
        {
            _client.Wallet.Transaction.GetTransaction("2095fecb2a679dd8a1cee16472c4c5fe9edcc01d");

        }

        [Fact]
        public void set_voting_proxy()
        {
            _client.Wallet.Account.SetVotingProxy("test101", "test103", PrivateKey);

        }

        #endregion

        #region Key Methods

        [Fact]
        public void GeneratePrivateKey()
        {
            _client.Wallet.Key.GeneratePrivateKey(new byte[51], new byte[53]);
        }

        [Fact]
        public void GetTransactionDigest()
        {
            _client.Wallet.Key.GetTransactionDigest(Transaction, ChainId, new byte[64]);

        }

        [Fact]
        public void GetPublicKey()
        {
            _client.Wallet.Key.GetPublicKey("5KGL7MNAfwCzQ8DAq7DXJsneXagka3KNcjgkRayJoeJUucSLkev", new byte[53]);

        }

        [Fact]
        public void GenerateKeyPairFromBrainKey()
        {
            _client.Wallet.Key.GenerateKeyPairFromBrainKey(Brain, new byte[51], new byte[53]);

        }

        [Fact]
        public void VerifySignaturet()
        {
            _client.Wallet.Key.VerifySignature(Digest, PublicKey, Sign);

        }

        [Fact]
        public void SignedDigest()
        {
            _client.Wallet.Key.SignDigest(Digest, PrivateKey, new byte[130]);

        }

        [Fact]
        public void EncryptMemo()
        {
            _client.Wallet.Key.EncryptMemo("{Hello:World}", PrivateKey, PublicKey2, new byte[1024]);

        }
        [Fact]
        public void DecryptMemo()
        {
            _client.Wallet.Key.DecryptMemo("2ZJ8RsXVNcNEoWPr6U5XYcjJeEfuz8cZbUNKxi6UQcgpxch5K1rRqagDHTv3C9vZLDJpSD9WYss6VHAWWvWVNCtCNkadKEcvaSV9SecRUnFeomX9HDTvhTXLW6BAAvuLRBMFLo1", PrivateKey2, PublicKey, new byte[1024]);

        }
        [Fact]
        public void AddSignature()
        {
            _client.Wallet.Key.AddSignature(Transaction, Sign, new byte[Transaction.Length + 200]);

        }

        [Fact]
        public void SuggestBrainKey()
        {
            _client.Wallet.Key.SuggestBrainKey();

        }

        [Fact]
        public void NormalizeBrainKey()
        {
            _client.Wallet.Key.NormalizeBrainKey(Brain);

        }

        #endregion

        #region Account Methods

        [Fact]
        public void CreateAccount()
        {
           var result= _client.Wallet.Account.CreateAccount("test116", "{}",
                "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz",
                "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz",
                "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz");
            Console.WriteLine(result);
        }
        
        [Fact]
        public void GetAccount()
        {
            var result=_client.Wallet.Account.GetAccount("test110");
            Console.WriteLine(result);
        }

        [Fact]
        public void DeleteAccount()
        {
            _client.Wallet.Account.DeleteAccount("test106", PrivateKey);

        }

        [Fact]
        public void update_account()
        {
            var result=_client.Wallet.Account.UpdateAccount("test110", "{}",
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
            _client.Wallet.Asset.WithdrawVesting("test101", "10.000000 VESTS", PrivateKey);
        }
        [Fact]
        public void Transfer()
        {
            _client.Wallet.Asset.Transfer("test101", "test110", "10.000 SPHTX",
                "SPH6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz", PrivateKey);

        }

        [Fact]
        public void TransferToVesting()
        {
            _client.Wallet.Asset.TransferToVesting("test101", "test101", "100.000 SPHTX", PrivateKey);

        }

        #endregion

        #region Data Methods

        [Fact]
        public void Send()
        {
            var test = "this is some text that i would like to send";
           
            var data = new SenderData
            {
                AppId = 1,
                PrivateKey = PrivateKey,
                Recipients = new List<string> {"test101"},
                Sender = "test103",
                Document = test//"[\"" + $"{test}" + "\"]"
            };
            var result = _client.Wallet.Data.Send(data);
            Console.WriteLine(result);
        }

//        [Fact]
//        public void SendBinary()
//        {
//            
//            var result = _client.Wallet.Data.MakeCustomBinaryOperation(4,"test101",Recipients,"2ZJ8RsXVNcNEoWPr6U5XYcjJeEfuz8cZbUNKxi6UQcgpxch5K1rRqagDHTv3C9vZLDJpSD9WYss6VHAWWvWVNCtCNmWD1BT7R2zQg98nKq5pMJt7Y2y2Ks6MqT6KLqFnBtL2P1E",PrivateKey);
//            Console.WriteLine(result);
//        }
//
//        
//        [Fact]
//        public void Receive()
//        {
//            var result = _client.Wallet.Data.GetReceivedDocuments(4,"by_sender","test101","2018-06-22T13:39:34",10);
//            Console.WriteLine(result);
//        }

        #endregion

        #region Application Methods

        [Fact]
        public void CreateApplication()
        {
            _client.Wallet.Application.CreateApplication("test101","BoxGame5","http://boxgame.com","genre: Adventure, requirements: Mac OS Sierra",1,PrivateKey);

        }
        [Fact]
        public void UpdateApplication()
        {
            _client.Wallet.Application.UpdateApplication("test101","BoxGame","test106","http://boxGamers.com","Genre:Action",1,PrivateKey);

        }

        [Fact]
        public void DeleteApplication()
        {
            _client.Wallet.Application.DeleteApplication("test101","BoxGame",PrivateKey);

        }

        [Fact]
        public void BuyApplication()
        {
            _client.Wallet.Application.BuyApplication("test110",4,PrivateKey);

        }

        [Fact]
        public void CancelApplicationBuying()
        {
            _client.Wallet.Application.CancelApplicationBuying("test101","test110",4,PrivateKey);

        }

        [Fact]
        public void GetApplicationBuyings()
        {
            _client.Wallet.Application.GetApplicationBuyings("test110","by_buyer",10);

        }
        [Fact]
        public void GetApplications()
        {
            List<string> Names=new List<string>{"BoxGame5","BoxGame4"};
            _client.Wallet.Application.GetApplications(Names);

        }


        #endregion
    }
}

