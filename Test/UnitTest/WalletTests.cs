using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;


namespace UnitTest
{
    public class WalletTests : BaseTest
    {
        private const string Transaction =
        "{\"ref_block_num\":16364,\"ref_block_prefix\":2217467278,\"expiration\":\"2018-06-20T15:24:06\",\"operations\":[[\"account_create\",{\"fee\":\"0.100000 SPHTX\",\"creator\":\"initminer\",\"new_account_name\":\"sanjiv9999\",\"owner\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",1]]},\"active\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",1]]},\"memo_key\":\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",\"json_metadata\":\"{}\"}]],\"extensions\":[],\"signatures\":[]}";
        private readonly string _digest="fe7ee427286c25eb48a39218f4415fd64f59b25aac2978a8a534b542cf8059c9";
        private readonly string _sign="1f7d9cb0bf47d052a35b2f8534e46b0197abc636c0627e9f5ef54fedbd5c5b1d1318ae0983a7281633da849045a267b6f4acbb178d2533ce6d9807f8074f2b6099";
        private readonly string _private_key=/*"5JEhygBY1VAeCrGyLtUin59CVMgrkaTDMH85p4jkEKmNzK7dwvn";//*/"5JPwY3bwFgfsGtxMeLkLqXzUrQDMAsqSyAZDnMBkg7PDDRhQgaV";
        private readonly string _public_key = /*"8Scq8njrvjHRqh5jV7DR6C6n3KTiFtQVk4tcHs8uYLNA1mUH97";//*/"8Xg6cEbqPCY8jrWFccgbCq5Fjw1okivwwmLDDgqQCQeAgWn8Fr";
        //private readonly string _signedTransaction =  "{\"ref_block_num\":53889,\"ref_block_prefix\":3757496330,\"expiration\":\"2018-06-19T15:57:27\",\"operations\":[[\"account_create\",{\"fee\":\"0.100000 SPHTX\",\"creator\":\"initminer\",\"new_account_name\":\"sanjiv\",\"owner\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",1]]},\"active\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",1]]},\"memo_key\":\"STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz\",\"json_metadata\":\"{}\"}]],\"extensions\":[],\"signatures\":[\"1f6c5326bc2f3ed482ad72ecae706c627754427eda292b9a100d192a884bb4f3072ddd188773ed5ba4afab36863d74a80abdcdde50adcaaa5fe6754558e3c078f0\"]}";
        private readonly string _chainID="00000000000000000000000000000000";
        private readonly string _Brain = "DERRIDE BASCULE NIMBUS DOXA BURL AURALLY OER GOSSIPY BEHALE PINKER INVOKER YAULD HOYLE POTTY TITE WHUD";
        private readonly string _memo = "JL6LMz5u6hk2tAHRergn9Esnyg8gXAnPRhbLUszRW4pqoBjf8BynbfzXWjGzyehZKvdM5w3FSrN4kUfQyPeYqmCGivdMkU7TjKaU";
        [Fact]
        public void GetActiveWitness()
        {
            _client.Wallet.Witness.GetActiveWitnesses();
        }
        [Fact]
        public void ListWitnesses()
        {
            _client.Wallet.Witness.ListWitnesses("initminer",10);
        }

        [Fact]
        public void GetWitness()
        {
            _client.Wallet.Witness.GetWitness("initminer");
        }
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
            _client.Wallet.Transaction.GetOpsInBlock(1983,true);
        }
        [Fact]
        public void GeneratePrivateKey()
        {                     
            _client.Wallet.Key.GeneratePrivateKey(new byte[51],new byte[53]);      
        }
        [Fact]
        public void GetTransactionDigest()
        {           
            _client.Wallet.Key.GetTransactionDigest(Transaction,_chainID,new byte[64]);
             
        }[Fact]
        public void GetPublicKey()
        {           
            _client.Wallet.Key.GetPublicKey("5KGL7MNAfwCzQ8DAq7DXJsneXagka3KNcjgkRayJoeJUucSLkev",new byte[53]);
             
        }[Fact]
        public void GenerateKeyPairFromBrainKey()
        {           
            _client.Wallet.Key.GenerateKeyPairFromBrainKey(_Brain,new byte[51],new byte[53]);
             
        }[Fact]
        public void VerifySignaturet()
        {           
            _client.Wallet.Key.VeriFySignature(_digest,_public_key,_sign);
             
        }
        [Fact]
        public void SignedDigest()
        {           
            _client.Wallet.Key.SignDigest(_digest,_private_key,new byte[130]);
            
        }[Fact]
        public void EncryptMemo()
        {           
            _client.Wallet.Key.EncryptMemo("Hello World",_private_key,_public_key,new byte[100]);
             
        }
           // [Fact]
           //        public void DecryptMemo()
           //        {           
           //            _client.Wallet.Key.DecryptMemo(_memo,_private_key,_public_key,new byte[100]);
           //             
           //        }
        [Fact]
        public void AddSignature()
        {           
            _client.Wallet.Key.AddSignature(Transaction,_sign,new byte[Transaction.Length+200]);
            
        }
        [Fact]
        public void SuggestBrainKey()
        {
            _client.Wallet.Key.SuggestBrainKey();

        }

        [Fact]
        public void NormalizeBrainKey()
        {
            _client.Wallet.Key.NormalizeBrainKey(_Brain);

        }
        [Fact]
        public void CreateAccount()
        {
            _client.Wallet.Account.CreateAccount("test108", "{}",
                "STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz",
                "STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz",
                "STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz");
           
            
        }
        [Fact]
        public void GetAccount()
        {
            _client.Wallet.Account.GetAccount("test106");

        }
        
        [Fact]
        public void DeleteAccount()
        {
           _client.Wallet.Account.DeleteAccount("test102");

        }
        [Fact]
        public void update_account()
        {
            _client.Wallet.Account.UpdateAccount("test101","{}","STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz","STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz","STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz");

        }
        [Fact]
        public void VoteForWitness()
        {
            _client.Wallet.Witness.VoteForWitness("test101","initminer",true);
        }
        
        [Fact]
        public void WithdrawVesting()
        {
            _client.Wallet.Transaction.WithdrawVesting("test106","10.000000 VESTS"); 
        }
        
        
        [Fact]
        public void GetTransaction()
        {
            _client.Wallet.Transaction.GetTransaction("2095fecb2a679dd8a1cee16472c4c5fe9edcc01d");

        }
                      
        [Fact]
        public void update_witness()
        {
           _client.Wallet.Account.UpdateWitness("test101","url","blockkey","pros");

        }
        [Fact]
        
        public void set_voting_proxy()
        {
            _client.Wallet.Transaction.SetVotingProxy("test101","test103");

        }
        [Fact]
        public void Transfer()
        {
            _client.Wallet.Asset.Transfer("test106","test101","100.000 STEEM","STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz");

        }
        [Fact]
        public void TransferToVesting()
        {
            _client.Wallet.Asset.TransferToVesting("test106","test101","100.000 STEEM");

        }
       
        /*
       //--------Application
        [Fact]
        public void create_application()
        {
            _client.Wallet.Account.withdrawVestings("sanjiv",67557);

        }
        [Fact]
        public void update_application()
        {
            _client.Wallet.Account.withdrawVestings("sanjiv",67557);

        }
        [Fact]
        public void delete_application()
        {
            _client.Wallet.Account.withdrawVestings("sanjiv",67557);

        }
        [Fact]
        public void buy_application()
        {
            _client.Wallet.Account.withdrawVestings("sanjiv",67557);

        }
        [Fact]
        public void cancel_application_buying()
        {
            _client.Wallet.Account.withdrawVestings("sanjiv",67557);

        }
        [Fact]
        public void get_application_buyings()
        {
            _client.Wallet.Account.withdrawVestings("sanjiv",67557);

        }
        //----------custom_api
        [Fact]
        public void send_custom_json_document()
        {
            _client.Wallet.Account.withdrawVestings("sanjiv",67557);

        }
        [Fact]
        public void send_custom_binary_document()
        {
            _client.Wallet.Account.withdrawVestings("sanjiv",67557);

        }
        [Fact]
        public void get_received_documents()
        {
            _client.Wallet.Account.withdrawVestings("sanjiv",67557);

        }*/
        
        
    }
}

