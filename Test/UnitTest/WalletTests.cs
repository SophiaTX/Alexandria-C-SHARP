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
           var witness= _client.Witness.GetWitness("initminer");
           Console.WriteLine(witness);
        }

        [Fact]
        public void VoteForWitness()
        {
            _client.Witness.VoteForWitness("test101", "initminer", true, PrivateKey);
        }


        [Fact]
        public void UpdateWitness()
        {
            var feed1 = new List<PrizeFeedQuoteMessage>
            {
                new PrizeFeedQuoteMessage
                {
                    Currency = "USD",
                    PrizeFeedQuote = new PrizeFeedQuote {Base = "1 USD", Quote = "0.152063 SPHTX"}
                }
                
            };
            var feed2= new List<PrizeFeedQuoteMessage>
            {
                new PrizeFeedQuoteMessage
                {
                    Currency = "EUR",
                    PrizeFeedQuote = new PrizeFeedQuote {Base = "1 EUR", Quote = "0.154988 SPHTX"}
                }
                
            };

            var pricefeed=new List<List<PrizeFeedQuoteMessage>>{feed1,feed2};
            var result = _client.Witness.UpdateWitness("martyn", "http://www.testminer.com",
                "SPH6zDAKpmQFATYSFC57hMCcCXjbDwQgG8YwkxbLUokGyXwXAjhad", "0.0010 SPHTX",
                1024676, pricefeed, "5JYeZJMfYazRE3W9w6VAofBx9s9pUCpQzcqSpAiPTirfKVb1XMM");
            Console.WriteLine(result);
        }

        #endregion

        #region Transaction Methods

        [Fact]
        public void GetFeedHistory()
        {
            var result=_client.Transaction.GetFeedHistory("SPHTX");
            Console.WriteLine(result);
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
        public void GetOpsInBlock()
        {
            var trx=_client.Transaction.GetOpsInBlock(1983, true);
            Console.WriteLine(trx);
        }

        

        [Fact]
        public void GetTransaction()
        {
            var trx=_client.Transaction.GetTransaction("4895dec7aa4b08837eeb2d8cc1cc33ae10f6acfa");
            Console.WriteLine(trx.Result.Operations);
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
            var Value=_client.Key.GetTransactionDigest("{ \"ref_block_num\": 2161, \"ref_block_prefix\": 855038757, \"expiration\": \"2018-07-30T16:27:18\", \"operations\": [ [ \"account_create\", { \"fee\": \"0.000000 SPHTX\", \"creator\": \"initminer\", \"name_seed\": \"test45747477ww1245565768910\", \"owner\": { \"weight_threshold\": 1, \"account_auths\": [], \"key_auths\": [ [ \"SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK\", 1 ] ] }, \"active\": { \"weight_threshold\": 1, \"account_auths\": [], \"key_auths\": [ [ \"SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK\", 1 ] ] }, \"memo_key\": \"SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK\", \"json_metadata\": \"{}\" } ] ], \"extensions\": [], \"signatures\": [] }",
                "4f402f175fc41ab3cdd3fd2eacaf0124150a4a84854bebfb5e2f8c55696fd8d4", new byte[64]);
            Console.WriteLine(Value);
        }

        [Fact]
        public void GetPublicKey()
        {
            _client.Key.GetPublicKey("5JPwY3bwFgfsGtxMeLkLqXzUrQDMAsqSyAZDnMBkg7PDDRhQgaV", new byte[53]);

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
            _client.Key.SignDigest("d139b5e917536aa3951916752df88d5cb28b27a27d266ad4bc1c920f1524187d", "5JPwY3bwFgfsGtxMeLkLqXzUrQDMAsqSyAZDnMBkg7PDDRhQgaV", new byte[130]);

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
           var result= _client.Account.CreateAccount("sanjiv27", "{}",
                "SPH6zDAKpmQFATYSFC57hMCcCXjbDwQgG8YwkxbLUokGyXwXAjhad",
                "SPH6zDAKpmQFATYSFC57hMCcCXjbDwQgG8YwkxbLUokGyXwXAjhad",
                "SPH6zDAKpmQFATYSFC57hMCcCXjbDwQgG8YwkxbLUokGyXwXAjhad","initminer","5JKHcAHiZnPVMzzeSGrWcRPhkjFZsPy2Pf36CVaz8W2WmMP4L1z");
            Console.WriteLine(result);
        }
        
        [Fact]
        public void GetAccount()
        {
            var result=_client.Account.GetAccount("sanjiv");
            Console.WriteLine(result);
        }

        [Fact]
        public void DeleteAccount()
        {
            _client.Account.DeleteAccount("sanjiv12345678910", PrivateKey);

        }
        [Fact]
        public void update_account()
        {
            var result=_client.Account.UpdateAccount("sanjiv", "{}",
                "SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK",
                "SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK",
                "SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK",
                "5KUbCiBJac8omkwgftfkp8hUCgh5k2H3mgoqMDN7bfzDLLEK2i8");
            Console.WriteLine(result);
        }
        [Fact]
        public void GetAccountHistory()
        {
            var result=_client.Account.GetAccountHistory("nXhMW8wWUL4d5eRFLNLzCfKvX7X", 10,9);
            Console.WriteLine(result);           
        }
        [Fact]
        public void GetAccountNameFromSeed()
        {
            var result=_client.Account.GetAccountNameFromSeed("sanjiv12345");
            Console.WriteLine(result);       
        }
        [Fact]
        public void GetVestingBalance()
        {
            var result=_client.Account.GetVestingBalance("sanjiv");
            Console.WriteLine(result);       
        }
        [Fact]
        public void GetAccountBalance()
        {
            var result=_client.Account.GetAccountBalance("sanjiv");
            Console.WriteLine(result);       
        }
        [Fact]
        public void AccountExists()
        {
            var result=_client.Account.AccountExists("rumGMWVHCxedjhSHMBQYk3o9LVD");
            Console.WriteLine(result);       
        }
        [Fact]
        public void GetActiveAuthority()
        {
            var result=_client.Account.GetActiveAuthority("2hPgEeeuitiNeM8bCCQWTKx9u6wx");
            Console.WriteLine(result);       
        }
        [Fact]
        public void GetMemoKey()
        {
            var result=_client.Account.GetMemoKey("2hPgEeeuitiNeM8bCCQWTKx9u6wx");
            Console.WriteLine(result);       
        }
        [Fact]
        public void GetOwnerAuthority()
        {
            var result=_client.Account.GetOwnerAuthority("2hPgEeeuitiNeM8bCCQWTKx9u6wx");
            Console.WriteLine(result);       
        }
        [Fact]
        public void CreateSimpleMultisigAuthority()
        {
            var pubkeys = new List<string> {"SPH5o2V32evStYJwAgewNmsvtk7n178CygWmwdEVR6uyThATBwVwi"};
            var result=_client.Account.CreateSimpleMultisigAuthority(pubkeys,4);
            Console.WriteLine(result);       
        }
        [Fact]
        public void CreateSimpleManagedAuthority()
        {
            var result=_client.Account.CreateSimpleManagedAuthority("SPH5o2V32evStYJwAgewNmsvtk7n178CygWmwdEVR6uyThATBwVwi");
            Console.WriteLine(result);       
        }
        [Fact]
        public void CreateSimpleAuthority()
        {
            var pubkeys = new List<string> {"SPH5o2V32evStYJwAgewNmsvtk7n178CygWmwdEVR6uyThATBwVwi"};
            var result=_client.Account.CreateSimpleMultiManagedAuthority(pubkeys,5);
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
            
            _client.Asset.Transfer("rumGMWVHCxedjhSHMBQYk3o9LVD", "2hPgEeeuitiNeM8bCCQWTKx9u6wx", "250000.00 SPHTX",
                "Hello-test","5JKHcAHiZnPVMzzeSGrWcRPhkjFZsPy2Pf36CVaz8W2WmMP4L1w");

        }

        [Fact]
        public void TransferToVesting()
        {
            _client.Asset.TransferToVesting("initminer", "martyn", "250000.000 SPHTX", "5JKHcAHiZnPVMzzeSGrWcRPhkjFZsPy2Pf36CVaz8W2WmMP4L1w");

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
                Recipients = new List<string> {"45fR5HHoV2XA7NyvKdc3CK4WrixE"},
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
                Recipients = new List<string> {"45fR5HHoV2XA7NyvKdc3CK4WrixE"},
                Sender = "45fR5HHoV2XA7NyvKdc3CK4WrixE",
                DocumentChars = "2ZJ8RsXVNcNEoWPr6U5XYcjJeEfuz8cZbUNKxi6UQcgpxch5K1rRqagDHTv3C9vZLDJpSD9WYss6VHAWWvWVNCtCNkadKEcvaSV9SecRUnFeomX9HDTvhTXLW6BAAvuLRBMFLo1" //"[\"" + $"{test}" + "\"]"
            };
            
            var result = _client.Data.SendBinary(data);
            Console.WriteLine(result);
        }
        
        
        [Fact]
        public void Receive()
        {
            var result = _client.Data.Receive(1,"45fR5HHoV2XA7NyvKdc3CK4WrixE",SearchType.ByRecipient,"2018-06-22T13:39:34",10);
            Console.WriteLine(result.Result);
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

