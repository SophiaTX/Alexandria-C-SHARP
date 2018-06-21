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
        public void GetBlock()
        {
            _client.Wallet.Transaction.GetBlock(8198);
            
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
            _client.Wallet.Key.GetPublicKey("5KGL7MNAfwCzQ8DAq7DXJsneXagka3KNcjgkRayJoeJUucSLkev",new byte[63]);
             
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
            _client.Wallet.Account.CreateAccount("test102", "{}",
                "STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz",
                "STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz",
                "STM6vh1vH3DTzFj2NUpZgpXfNACxUGsXThSpwVLXh9KaYAnJtrUpz");
           
            
        }
        [Fact]
        public void GetAccount()
        {
            var response = _client.Wallet.Account.GetAccount("test101");

            Assert.Equal(response.result.name, "test101");

        }
        
        
//        [Fact]
//        public void DeleteAccount()
//        {
//           var response =  _client.Wallet.Account.DeleteAccount("test101");
//            Console.WriteLine(response);
//
//        }
//        [Fact]
//        public void update_account()
//        {
//            _client.Wallet.Account.updateAccount("sanjiv",7888,"active","memo");
//
//        }
//        [Fact]
//        public void VoteForWitness()
//        {
//            _client.Wallet.Witness.Vote("initminer","temp",true); //{"id":0,"error":{"code":1,"message":"0 exception: unspecified\nmissing required active authority:Missing Active Authority initminer\n    {\"error\":\"missing required active authority:Missing Active Authority initminer\",\"data\":{\"id\":3,\"error\":{\"code\":-32000,\"message\":\"missing required active authority:Missing Active Authority initminer\",\"data\":{\"code\":3010000,\"name\":\"tx_missing_active_auth\",\"message\":\"missing required active authority\",\"stack\":[{\"context\":{\"level\":\"error\",\"file\":\"transaction_util.hpp\",\"line\":45,\"method\":\"verify_authority\",\"hostname\":\"\",\"timestamp\":\"2018-06-13T07:04:09\"},\"format\":\"Missing Active Authority ${id}\",\"data\":{\"id\":\"initminer\",\"auth\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM8Xg6cEbqPCY8jrWFccgbCq5Fjw1okivwwmLDDgqQCQeAk7jedu\",1]]},\"owner\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM8Xg6cEbqPCY8jrWFccgbCq5Fjw1okivwwmLDDgqQCQeAk7jedu\",1]]}}},{\"context\":{\"level\":\"warn\",\"file\":\"transaction_util.hpp\",\"line\":60,\"method\":\"verify_authority\",\"hostname\":\"\",\"timestamp\":\"2018-06-13T07:04:09\"},\"format\":\"\",\"data\":{\"auth_containers\":[[\"account_witness_vote\",{\"account\":\"initminer\",\"witness\":\"temp\",\"approve\":true}]],\"sigs\":[]}},{\"context\":{\"level\":\"warn\",\"file\":\"transaction.cpp\",\"line\":169,\"method\":\"verify_authority\",\"hostname\":\"\",\"timestamp\":\"2018-06-13T07:04:09\"},\"format\":\"\",\"data\":{\"*this\":{\"ref_block_num\":19802,\"ref_block_prefix\":746503726,\"expiration\":\"2018-06-13T07:04:39\",\"operations\":[[\"account_witness_vote\",{\"account\":\"initminer\",\"witness\":\"temp\",\"approve\":true}]],\"extensions\":[],\"signatures\":[]}}},{\"context\":{\"level\":\"warn\",\"file\":\"database.cpp\",\"line\":2112,\"method\":\"_apply_transaction\",\"hostname\":\"\",\"timestamp\":\"2018-06-13T07:04:09\"},\"format\":\"\",\"data\":{\"trx\":{\"ref_block_num\":19802,\"ref_block_prefix\":746503726,\"expiration\":\"2018-06-13T07:04:39\",\"operations\":[[\"account_witness_vote\",{\"account\":\"initminer\",\"witness\":\"temp\",\"approve\":true}]],\"extensions\":[],\"signatures\":[]}}},{\"context\":{\"level\":\"warn\",\"file\":\"database.cpp\",\"line\":654,\"method\":\"push_transaction\",\"hostname\":\"\",\"timestamp\":\"2018-06-13T07:04:09\"},\"format\":\"\",\"data\":{\"trx\":{\"ref_block_num\":19802,\"ref_block_prefix\":746503726,\"expiration\":\"2018-06-13T07:04:39\",\"operations\":[[\"account_witness_vote\",{\"account\":\"initminer\",\"witness\":\"temp\",\"approve\":true}]],\"extensions\":[],\"signatures\":[]}}}]}}}}\n    state.cpp:38 handle_reply\n\n    {\"voting_account\":\"initminer\",\"witness_to_vote_for\":\"temp\",\"approve\":true,\"broadcast\":true}\n    wallet.cpp:1455 vote_for_witness\n\n    {\"call.method\":\"vote_for_witness\",\"call.params\":[\"initminer\",\"temp\",true,true]}\n    websocket_api.cpp:138 on_message","data":{"code":0,"name":"exception","message":"unspecified","stack":[{"context":{"level":"error","file":"state.cpp","line":38,"method":"handle_reply","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"${error}","data":{"error":"missing required active authority:Missing Active Authority initminer","data":{"id":3,"error":{"code":-32000,"message":"missing required active authority:Missing Active Authority initminer","data":{"code":3010000,"name":"tx_missing_active_auth","message":"missing required active authority","stack":[{"context":{"level":"error","file":"transaction_util.hpp","line":45,"method":"verify_authority","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"Missing Active Authority ${id}","data":{"id":"initminer","auth":{"weight_threshold":1,"account_auths":[],"key_auths":[["STM8Xg6cEbqPCY8jrWFccgbCq5Fjw1okivwwmLDDgqQCQeAk7jedu",1]]},"owner":{"weight_threshold":1,"account_auths":[],"key_auths":[["STM8Xg6cEbqPCY8jrWFccgbCq5Fjw1okivwwmLDDgqQCQeAk7jedu",1]]}}},{"context":{"level":"warn","file":"transaction_util.hpp","line":60,"method":"verify_authority","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"auth_containers":[["account_witness_vote",{"account":"initminer","witness":"temp","approve":true}]],"sigs":[]}},{"context":{"level":"warn","file":"transaction.cpp","line":169,"method":"verify_authority","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"*this":{"ref_block_num":19802,"ref_block_prefix":746503726,"expiration":"2018-06-13T07:04:39","operations":[["account_witness_vote",{"account":"initminer","witness":"temp","approve":true}]],"extensions":[],"signatures":[]}}},{"context":{"level":"warn","file":"database.cpp","line":2112,"method":"_apply_transaction","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"trx":{"ref_block_num":19802,"ref_block_prefix":746503726,"expiration":"2018-06-13T07:04:39","operations":[["account_witness_vote",{"account":"initminer","witness":"temp","approve":true}]],"extensions":[],"signatures":[]}}},{"context":{"level":"warn","file":"database.cpp","line":654,"method":"push_transaction","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"trx":{"ref_block_num":19802,"ref_block_prefix":746503726,"expiration":"2018-06-13T07:04:39","operations":[["account_witness_vote",{"account":"initminer","witness":"temp","approve":true}]],"extensions":[],"signatures":[]}}}]}}}}},{"context":{"level":"warn","file":"wallet.cpp","line":1455,"method":"vote_for_witness","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"voting_account":"initminer","witness_to_vote_for":"temp","approve":true,"broadcast":true}},{"context":{"level":"warn","file":"websocket_api.cpp","line":138,"method":"on_message","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"call.method":"vote_for_witness","call.params":["initminer","temp",true,true]}}]}}}
//        }
        
//        [Fact]
//        public void WithdrawVesting()
//        {
//            _client.Wallet.Transaction.withdraw_vesting("initminer",10); //add some shares for vesting test
//        }
        
        
        
//        [Fact]
//        public void GetAccountBalance()
//        {
//            _client.Wallet.Account.GetAccount("sanjiv");
//        }
        
//        [Fact]
//        public void CreateSimpleAuthority()
//        {
//            //_client.Wallet.Account.createSimpleAuthority();
//        }

        

        //----------LocalFunctions
        
        
        //---------Transaction

        
        
//        [Fact]
//        public void get_transaction()
//        {
//            //_client.Wallet.Transaction.broadcast_transaction(_signedTransaction);
//
//        }
        
//        [Fact]
//        public void serialize_transaction()
//        {
//            _client.Wallet.Account.WithdrawVestings("sanjiv",67557);
//
//        }
        //--------operations
//        [Fact]
//        public void get_prototype_operation()
//        {
//            _client.Wallet.Account.WithdrawVestings("sanjiv",67557);
//
//        }
//        [Fact]
//        public void get_ops_in_block()
//        {
//            _client.Wallet.Transaction.get_ops_in_block();
//
//        }
        //----------keys
        
        
       //---------Accounts
//        
        
//        [Fact]
//        public void update_witness()
//        {
//           // _client.Wallet.Account.updateAccount("sanjiv",7888,"active","memo");
//
//        }
//        [Fact]
//        
//        public void set_voting_proxy()
//        {
//            _client.Wallet.Transaction.set_voting_proxy("sanjiv","proxy");
//
//        }
//        [Fact]
//        public void Transfer()
//        {
//            _client.Wallet.Asset.Transfer("from","to","memo",1233,"symbol");
//
//        }
//        [Fact]
//        public void transfer_to_vesting()
//        {
//            _client.Wallet.Account.transfer_to_vesting();
//
//        }
        //[Fact]
        /*public void withdrawVestings()
        {
            _client.Wallet.Account.withdrawVestings("sanjiv",67557);

        }
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

///// wallet api
//(help)(gethelp)
//(about)
//
///// key api
//(suggest_brain_key)
//(normalize_brain_key)
//
///// query api
//(info)
//(list_witnesses)
//(get_witness)
//(get_account)
//(get_block)
//(get_ops_in_block)
//(get_feed_history)

//
///// transaction api
//(create_account)
//(update_account)
//(delete_account)
//(update_witness)
//(set_voting_proxy)
//(vote_for_witness)
//(transfer)
////        (escrow_transfer)
////        (escrow_approve)
////        (escrow_dispute)
////        (escrow_release)
//(transfer_to_vesting)
//(withdraw_vesting)
////        (request_account_recovery)
////        (recover_account)
////        (change_recovery_account)
//(create_application)
//(update_application)
//(delete_application)
//(buy_application)
//(cancel_application_buying)
//(get_application_buyings)
//
///// helper api
//(get_prototype_operation)
//(serialize_transaction)
//(broadcast_transaction)
//(create_transaction)
//(get_digest)
//
//(get_active_witnesses)
//(get_transaction)
//
//(send_custom_json_document)
//(send_custom_binary_document)
//(get_received_documents)
