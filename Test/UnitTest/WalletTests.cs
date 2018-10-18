using System;
using System.Collections.Generic;
using System.Threading;
using Alexandria.net.Enums;
using Alexandria.net.Events;
using Alexandria.net.Messaging.Receiver;
using Xunit;

namespace UnitTest
{
    public class WalletTests : BaseTest
    {
        #region Member Variables

        private const string Transaction =
            "{ \"ref_block_num\": 34958, \"ref_block_prefix\": 4183758935, \"expiration\": \"2018-08-21T07:57:48\", \"operations\": [ [ \"account_create\", { \"fee\": \"0.000000 SPHTX\", \"creator\": \"initminer\", \"name_seed\": \"test45747477ww124556576891010234789107\", \"owner\": { \"weight_threshold\": 1, \"account_auths\": [], \"key_auths\": [ [ \"SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK\", 1 ] ] }, \"active\": { \"weight_threshold\": 1, \"account_auths\": [], \"key_auths\": [ [ \"SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK\", 1 ] ] }, \"memo_key\": \"SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK\", \"json_metadata\": \"{}\" } ] ], \"extensions\": [], \"signatures\": [] }";
        private const string Digest = "fe7ee427286c25eb48a39218f4415fd64f59b25aac2978a8a534b542cf8059c9";

        private const string Sign =
            "1f7d9cb0bf47d052a35b2f8534e46b0197abc636c0627e9f5ef54fedbd5c5b1d1318ae0983a7281633da849045a267b6f4acbb178d2533ce6d9807f8074f2b6099";
        //-----client1
        private const string PrivateKey = "5K14hP7ziUNqZbp75o4oW885259T1SbCinZskXhz3XnA2ymR1Wz";
        private const string PublicKey = "SPH6zDAKpmQFATYSFC57hMCcCXjbDwQgG8YwkxbLUokGyXwXAjhad";
        
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
            Client.Witness.GetActiveWitnesses();
        }

        [Fact]
        public void ListWitnesses()
        {
            Client.Witness.ListWitnesses("initminer", 10);
        }

        [Fact]
        public void GetWitness()
        {
           var witness= Client.Witness.GetWitness("initminer");
           Console.WriteLine(witness);
        }

        [Fact]
        public void VoteForWitness()
        {
            Client.Witness.VoteForWitness("test101", "initminer", true, PrivateKey);
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
            var result = Client.Witness.UpdateWitness("martyn", "http://www.testminer.com",
                "SPH6zDAKpmQFATYSFC57hMCcCXjbDwQgG8YwkxbLUokGyXwXAjhad", "0.0010 SPHTX",
                1024676, pricefeed, "5JYeZJMfYazRE3W9w6VAofBx9s9pUCpQzcqSpAiPTirfKVb1XMM");
            Console.WriteLine(result);
        }

        #endregion

        #region Transaction Methods

        [Fact]
        public void GetFeedHistory()
        {
            var result=Client.Transaction.GetFeedHistory("SPHTX");
            Console.WriteLine(result);
        }

        [Fact]
        public void About()
        {
            var result=Client.Transaction.About();
            Console.WriteLine(result);
        }

        [Fact]
        public void Help()
        {
            Client.Transaction.Help();
        }

        [Fact]
        public void Info()
        {
            Client.Transaction.Info();
        }

        [Fact]
        public void GetBlock()
        {
            Client.Transaction.GetBlock(1983);

        }

        [Fact]
        public void GetOpsInBlock()
        {
            var trx=Client.Transaction.GetOpsInBlock(1983, true);
            Console.WriteLine(trx);
        }

        

        [Fact]
        public void GetTransaction()
        {
            var trx=Client.Transaction.GetTransaction("4895dec7aa4b08837eeb2d8cc1cc33ae10f6acfa");
            Console.WriteLine(trx.Result.Operations);
        }

        [Fact]
        public void set_voting_proxy()
        {
            Client.Account.SetVotingProxy("test101", "test103", PrivateKey);

        }

        #endregion
    
        #region Key Methods

        [Fact]
        public void GeneratePrivateKey()
        {
           var result= Client.Key.GeneratePrivateKey(new byte[51], new byte[53]);
           Console.WriteLine(result);
        }
        [Fact]
        public void GetTransactionDigest()
        {
            var value=Client.Key.GetTransactionDigest("{\"ref_block_num\":1780,\"ref_block_prefix\":247711471,\"expiration\":\"2018-08-22T11:51:39\",\"operations\":[[\"account_create\",{\"fee\":\"0.000000 SPHTX\",\"creator\":\"initminer\",\"name_seed\":\"test45747477ww124556576891010234789107\",\"owner\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK\",1]]},\"active\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK\",1]]},\"memo_key\":\"SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK\",\"json_metadata\":\"{}\"}]],\"extensions\":[],\"signatures\":[\"200c7a0b41d02e20218d3b919fee80e107da5de10eb84fbfb9ba9ba07fb4bca25a493073d6684cc066e4810eb60606ba166cf858559c7fc303c5ca46dfcfc65e0a\"]}","66423e7baa1f62570784e17cb78d48329e78faa43075cc9d847c434b4bfe2dfb", new byte[64]);
            Console.WriteLine(value);
        }
        [Fact]
        public void GetPublicKey()
        {
            var result =Client.Key.GetPublicKey("5K14hP7ziUNqZbp75o4oW885259T1SbCinZskXhz3XnA2ymR1Wz", new byte[53]);
            Console.WriteLine(result);
        }
        [Fact]
        public void GenerateKeyPairFromBrainKey()
        {
            Client.Key.GenerateKeyPairFromBrainKey(Brain, new byte[51], new byte[53]);
        }
        [Fact]
        public void VerifySignaturet()
        {
            var value=Client.Key.VerifySignature("d3a58bca45a00d2a7c5b01090000000000000000065350485458000009696e69746d696e6572267465737434353734373437377777313234353536353736383931303130323334373839313037010000000001033a559a0a3fda201f1a126551b8edcd69a227efbd8b4eb184dab6ea8c75b68ea30100010000000001033a559a0a3fda201f1a126551b8edcd69a227efbd8b4eb184dab6ea8c75b68ea30100033a559a0a3fda201f1a126551b8edcd69a227efbd8b4eb184dab6ea8c75b68ea3027b7d00", "SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK", "201968e85c9573fd56c915ce52bf227b068496d6fc1036ab652d40d625dee81e7216694f78c80bb6246456df823ede8ff5c643eee8e28b1bb3177be71134172b5a");
            Console.WriteLine(value);
        }
        [Fact]
        public void SignedDigest()
        {
            Client.Key.SignDigest("d139b5e917536aa3951916752df88d5cb28b27a27d266ad4bc1c920f1524187d", "5JPwY3bwFgfsGtxMeLkLqXzUrQDMAsqSyAZDnMBkg7PDDRhQgaV", new byte[130]);
        }
        [Fact]
        public void EncryptMemo()
        {
            Client.Key.EncryptMemo("{Hello:World}", PrivateKey, PublicKey2, new byte[1024]);
        }
        [Fact]
        public void DecryptMemo()
        {
            Client.Key.DecryptMemo("G3KK7mhkR7G99gGWC5fiGu1ie7xBJSdgdpXgTDe7GAmQG", PrivateKey2, PublicKey, new byte[1024]);
        }
        [Fact]
        public void EncodeBase64()
        {
            Client.Key.EncodeBase64("{Hello:World}", new byte[1024]);
        }
        [Fact]
        public void DecodeBase64()
        {
            string code = "e0hlbGxvOldvcmxkfQ==";
            Client.Key.DecodeBase64(code, new byte[code.Length+100]);
        }
        [Fact]
        public void AddSignature()
        {
            var value=Client.Key.AddSignature(Transaction, "1f038c20c460b74676002e1e73f863f8498fd5abdb92aebc6a7af25e03c16bbf001ca01e0abe2f4e23b5740ec080ccea8051e5c370ec36fd8c0cdbcbebcdcdcb7e", new byte[Transaction.Length + 200]);
            Console.WriteLine(value);
        }
        [Fact]
        public void SuggestBrainKey()
        {
            var result=Client.Key.SuggestBrainKey();
            Console.WriteLine(result);
        }
        [Fact]
        public void NormalizeBrainKey()
        {
            Client.Key.NormalizeBrainKey(Brain);
        }

        #endregion

        #region Account Methods

        [Fact]
        public void CreateAccount()
        {
           var result= Client.Account.CreateAccount("test457457474889", "{}",
                "SPH6zDAKpmQFATYSFC57hMCcCXjbDwQgG8YwkxbLUokGyXwXAjhad",
                "SPH6zDAKpmQFATYSFC57hMCcCXjbDwQgG8YwkxbLUokGyXwXAjhad",
                "SPH6zDAKpmQFATYSFC57hMCcCXjbDwQgG8YwkxbLUokGyXwXAjhad","initminer","5JKHcAHiZnPVMzzeSGrWcRPhkjFZsPy2Pf36CVaz8W2WmMP4L1w");
            Console.WriteLine(result);
        }
        
        [Fact]
        public void GetAccount()
        {
            var result=Client.Account.GetAccount("sanjiv2781");
            Console.WriteLine(result);
        }

        [Fact]
        public void DeleteAccount()
        {
            var result=Client.Account.DeleteAccount("sanjiv12345678910", PrivateKey);
            Console.WriteLine(result);

        }
        [Fact]
        public void update_account()
        {
            var result=Client.Account.UpdateAccount("sanjiv", "{}",
                "SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK",
                "SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK",
                "SPH7GvbxZTntaqCnNSsuai1Dguejh23RKJHmu2uuR869BLbM3yWPK",
                "5KUbCiBJac8omkwgftfkp8hUCgh5k2H3mgoqMDN7bfzDLLEK2i8");
            Console.WriteLine(result);
        }
        [Fact]
        public void GetAccountHistory()
        {
            var result=Client.Account.GetAccountHistory("nXhMW8wWUL4d5eRFLNLzCfKvX7X", 10,1);
            Console.WriteLine(result);           
        }
        [Fact]
        public void GetAccountNameFromSeed()
        {
            var result=Client.Account.GetAccountNameFromSeed("sanjiv12345");
            Console.WriteLine(result);       
        }
        [Fact]
        public void GetVestingBalance()
        {
            var result=Client.Account.GetVestingBalance("sanjiv");
            Console.WriteLine(result);       
        }
        [Fact]
        public void GetAccountBalance()
        {
            var result=Client.Account.GetAccountBalance("yofVXV_6Rdaun-yWM7U1I0m8G0w");
            Console.WriteLine(result);       
        }
        [Fact]
        public void AccountExists()
        {
            var result=Client.Account.AccountExists("rumGMWVHCxedjhSHMBQYk3o9LVD");
            Console.WriteLine(result);       
        }
        [Fact]
        public void GetActiveAuthority()
        {
            var result=Client.Account.GetActiveAuthority("2hPgEeeuitiNeM8bCCQWTKx9u6wx");
            Console.WriteLine(result);       
        }
        [Fact]
        public void GetMemoKey()
        {
            var result=Client.Account.GetMemoKey("2hPgEeeuitiNeM8bCCQWTKx9u6wx");
            Console.WriteLine(result);       
        }
        [Fact]
        public void GetOwnerAuthority()
        {
            var result=Client.Account.GetOwnerAuthority("2hPgEeeuitiNeM8bCCQWTKx9u6wx");
            Console.WriteLine(result);       
        }
        [Fact]
        public void CreateSimpleMultisigAuthority()
        {
            var pubkeys = new List<string> {"SPH5o2V32evStYJwAgewNmsvtk7n178CygWmwdEVR6uyThATBwVwi"};
            var result=Client.Account.CreateSimpleMultisigAuthority(pubkeys,4);
            Console.WriteLine(result);       
        }
        [Fact]
        public void CreateSimpleManagedAuthority()
        {
            var result=Client.Account.CreateSimpleManagedAuthority("SPH5o2V32evStYJwAgewNmsvtk7n178CygWmwdEVR6uyThATBwVwi");
            Console.WriteLine(result);       
        }
        [Fact]
        public void CreateSimpleAuthority()
        {
            var pubkeys = new List<string> {"SPH5o2V32evStYJwAgewNmsvtk7n178CygWmwdEVR6uyThATBwVwi"};
            var result=Client.Account.CreateSimpleMultiManagedAuthority(pubkeys,5);
            Console.WriteLine(result);       
        }
        #endregion

        #region Asset Methods
        [Fact]
        public void WithdrawVesting()
        {
            Client.Asset.WithdrawVesting("test101", "10.000000 VESTS", PrivateKey);
        }
        [Fact]
        public void Transfer()
        {
            
            Client.Asset.Transfer("initminer", "2XyeasoZcbEzJDpTNIPPwjtwFwQA", "1000.00 SPHTX",
                "Hello-test","5JKHcAHiZnPVMzzeSGrWcRPhkjFZsPy2Pf36CVaz8W2WmMP4L1w");

        }

        [Fact]
        public void TransferToVesting()
        {
            Client.Asset.TransferToVesting("initminer", "martyn", "250000.000 SPHTX", "5JKHcAHiZnPVMzzeSGrWcRPhkjFZsPy2Pf36CVaz8W2WmMP4L1w");

        }

        #endregion

        #region Data Methods

        [Fact]
        public void TestListening()
        {
            Client.OnDataReceivedBlockChainEvent += ClientOnOnDataReceivedBlockChainEvent;
            Client.Data.StartListening(1234, "cranfield", SearchType.BySender, DateTime.UtcNow.AddDays(-10), 1);

            for (var index = 0; index < 50; index++)
            {
                Thread.Sleep(20000);
            }
            Console.WriteLine("test completed");
        }

        private void ClientOnOnDataReceivedBlockChainEvent(object sender, DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void SendJson()
        {
            var test = "{\"Name\":\"test: \",\"ClientId\":1,\"MessageIndex\":0}";
           
            var data = new JsonData
            {
                AppId = 20023,
                PrivateKey = "5HpSFkogryJQXNM4RtuvqDJtQEVDyTHwUS26bhLfhGuToifCRyx",
                Recipients = new List<string> {"K2F_dnhaRXbSMJLAsCe6FJhmOKU"},
                Sender = "yofVXV_6Rdaun-yWM7U1I0m8G0w",
                JsonDoc = test
            };

            var result = Client.Data.SendJson(data);
            Console.WriteLine(result);
        }

        [Fact]
        public void SendBinary()
        {
            var data = new BinaryData
            {
                AppId = 20009,
                PrivateKey ="5KUbCiBJac8omkwgftfkp8hUCgh5k2H3mgoqMDN7bfzDLLEK2i8",
                Recipients = new List<string> {"yofVXV_6Rdaun-yWM7U1I0m8G0w"},
                Sender = "sanjiv",
                BinaryDoc = "e0hlbGxvOldvcmxkfQ==" 
            };
            
            var result = Client.Data.SendBinary(data);
            Console.WriteLine(result);
        }
        
        [Fact]
        public void SendJsonAsync()
        {
            var test = "{\"ref_block_num\":16364,\"ref_block_prefix\":2217467278,\"expiration\":\"2018-06-20T15:24:06\",\"operations\":[[\"account_create\",{\"fee\":\"0.100000 SPHTX\",\"creator\":\"initminer\",\"new_account_name\":\"sanjiv9999\",\"owner\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",1]]},\"active\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",1]]},\"memo_key\":\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",\"json_metadata\":\"{}\"}]],\"extensions\":[],\"signatures\":[]}";

            
                var data = new JsonData
                {
                    AppId = 3,
                    PrivateKey = "5HpSFkogryJQXNM4RtuvqDJtQEVDyTHwUS26bhLfhGuToifCRyx",
                    Recipients = new List<string> {"45fR5HHoV2XA7NyvKdc3CK4WrixE"},
                    Sender = "yofVXV_6Rdaun-yWM7U1I0m8G0w",
                    JsonDoc = test
                };

                var result = Client.Data.SendJsonAsync(data);
                Console.WriteLine(result);
                       
        }

        [Fact]
        public void SendBinaryAsync()
        {
            var data = new BinaryData
            {
                AppId = 20023,
                PrivateKey = "5HpSFkogryJQXNM4RtuvqDJtQEVDyTHwUS26bhLfhGuToifCRyx",
                Recipients = new List<string> {"K2F_dnhaRXbSMJLAsCe6FJhmOKU"},
                Sender = "yofVXV_6Rdaun-yWM7U1I0m8G0w",
                BinaryDoc = "e0hlbGxvOldvcmxkfQ==" 
            };
            
            var result = Client.Data.SendBinaryAsync(data);
            Console.WriteLine(result);
        }


        [Fact]
        public void Receive()
        {
            var result = Client.Data.Receive(20023, "K2F_dnhaRXbSMJLAsCe6FJhmOKU", SearchType.ByRecipient,
                DateTime.UtcNow.AddDays(-10), 10);
            Console.WriteLine(result.ReceivedDocumentCollection.Documents);
            
        }

        #endregion

        #region Application Methods

        [Fact]
        public void CreateApplication()
        {
            var result=Client.Application.CreateApplication("yofVXV_6Rdaun-yWM7U1I0m8G0w","MyTVBox","http://boxgame.com","genre: Adventure, requirements: Mac OS Sierra",1,"5HpSFkogryJQXNM4RtuvqDJtQEVDyTHwUS26bhLfhGuToifCRyx");
            Console.WriteLine(result);
        }
        
        [Fact]
        public void UpdateApplication()
        {
            Client.Application.UpdateApplication("test101","BoxGame","test106","http://boxGamers.com","Genre:Action",1,PrivateKey);

        }

        [Fact]
        public void DeleteApplication()
        {
            Client.Application.DeleteApplication("test101","BoxGame",PrivateKey);

        }

        [Fact]
        public void BuyApplication()
        {
            Client.Application.BuyApplication("yofVXV_6Rdaun-yWM7U1I0m8G0w",4,"5HpSFkogryJQXNM4RtuvqDJtQEVDyTHwUS26bhLfhGuToifCRyx");

        }

        [Fact]
        public void CancelApplicationBuying()
        {
            Client.Application.CancelApplicationBuying("test101","test110",4,PrivateKey);

        }

        [Fact]
        public void GetApplicationBuyings()
        {
            var result=Client.Application.GetApplicationBuyings("4",SearchType.ByAppId,10);
            Console.WriteLine(result);

        }
        [Fact]
        public void GetApplications()
        {
            var names = new List<string>{"MyTVBox"};
            var result=Client.Application.GetApplications(names);
            Console.WriteLine(result);
        }


        #endregion

        #region Rpc Function

        [Fact]
        public void SignAndSendTransaction()
        {          
            var result=Client.Transaction.SignAndSendTransaction(Transaction,PrivateKey);
            Console.WriteLine(result);
        }


        #endregion
    }
}

