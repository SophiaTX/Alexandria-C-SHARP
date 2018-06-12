using System;
using System.Collections;
using Alexandria.net.Core;
using Xunit;


namespace UnitTest
{
    public class WalletTests : BaseTest
    {
        private const string transaction =
            "{ \"ref_block_num\": 287,\"ref_block_prefix\": 3535709865,\"expiration\": \"2018-06-01T07:42:27\",\"operations\": [[\"account_create\",{\"fee\": \"0.000030 SPHTX\",\"creator\": \"initminer\",\"new_account_name\": \"matus\",\"owner\": {\"weight_threshold\": 1,\"account_auths\": [],\"key_auths\": [[\"STM5WcWH1RAUd2sJK4eNJxomZuf6RAjs1s6CB4sfkQcHaaS3JY66f\",1 ]]},\"active\": {\"weight_threshold\": 1,\"account_auths\": [],\"key_auths\": [[\"STM8JCyWEwLUypREhAadUxKVWSzTyhUvNW8XiYppnZN31sBpMXUt8\",1]]},\"memo_key\": \"STM5sSw5xWuEYQf1EUoCsD6uUHuGgA6orAC4var1Kka28BL2j3wiL\",\"json_metadata\": \"{}\"}]],\"extensions\": [],\"signatures\": [],\"transaction_id\": \"560f5b91130e4048dbc6a6d4b2d1e0093b412a83\",\"block_num\": 0,\"transaction_num\": 0}";

        byte[] key = new byte[52];
        byte[] digest = new byte[52];
        byte[] sign = new byte[52];
        byte[] signedDigest = new byte[52];
        
        
//        [Fact]
//        public void CreateAccount()
//        {
//            _client.Wallet.create_account("creator","Account_name","{}",true);
//        }
//        [Fact]
//        public void CreateAccountWithKets()
//        {
//            _client.Wallet.create_account_with_keys("creator","newname","jsonMeta","owner","active","posting","memo",true);
//        }
//        [Fact]
//        public void CreateOrder()
//        {
//            _client.Wallet.create_order("owner",1120134,1000,999,true,90,true);
//        }
//        [Fact]
//        public void CancelOrder()
//        {
//            _client.Wallet.cancel_order("owner",1120133,true);
//        }
//
//       
        
//        [Fact]
//        public void VoteForWitness()
//        {
//            _client.Wallet.vote_for_witness("AccountWith","AccountFor",true,true);
//        }
        [Fact]
        public void ChangeRecoveryAccount()
        {
            _client.Wallet.change_recovery_account("initminer","temp",true); //{"id":0,"error":{"code":1,"message":"0 exception: unspecified\nmissing required owner authority:Missing Owner Authority initminer\n    {\"error\":\"missing required owner authority:Missing Owner Authority initminer\",\"data\":{\"id\":6,\"error\":{\"code\":-32000,\"message\":\"missing required owner authority:Missing Owner Authority initminer\",\"data\":{\"code\":3020000,\"name\":\"tx_missing_owner_auth\",\"message\":\"missing required owner authority\",\"stack\":[{\"context\":{\"level\":\"error\",\"file\":\"transaction_util.hpp\",\"line\":52,\"method\":\"verify_authority\",\"hostname\":\"\",\"timestamp\":\"2018-06-12T15:32:45\"},\"format\":\"Missing Owner Authority ${id}\",\"data\":{\"id\":\"initminer\",\"auth\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM8Xg6cEbqPCY8jrWFccgbCq5Fjw1okivwwmLDDgqQCQeAk7jedu\",1]]}}},{\"context\":{\"level\":\"warn\",\"file\":\"transaction_util.hpp\",\"line\":60,\"method\":\"verify_authority\",\"hostname\":\"\",\"timestamp\":\"2018-06-12T15:32:45\"},\"format\":\"\",\"data\":{\"auth_containers\":[[\"change_recovery_account\",{\"account_to_recover\":\"initminer\",\"new_recovery_account\":\"temp\",\"extensions\":[]}]],\"sigs\":[]}},{\"context\":{\"level\":\"warn\",\"file\":\"transaction.cpp\",\"line\":169,\"method\":\"verify_authority\",\"hostname\":\"\",\"timestamp\":\"2018-06-12T15:32:45\"},\"format\":\"\",\"data\":{\"*this\":{\"ref_block_num\":19667,\"ref_block_prefix\":141500550,\"expiration\":\"2018-06-12T15:33:15\",\"operations\":[[\"change_recovery_account\",{\"account_to_recover\":\"initminer\",\"new_recovery_account\":\"temp\",\"extensions\":[]}]],\"extensions\":[],\"signatures\":[]}}},{\"context\":{\"level\":\"warn\",\"file\":\"database.cpp\",\"line\":2112,\"method\":\"_apply_transaction\",\"hostname\":\"\",\"timestamp\":\"2018-06-12T15:32:45\"},\"format\":\"\",\"data\":{\"trx\":{\"ref_block_num\":19667,\"ref_block_prefix\":141500550,\"expiration\":\"2018-06-12T15:33:15\",\"operations\":[[\"change_recovery_account\",{\"account_to_recover\":\"initminer\",\"new_recovery_account\":\"temp\",\"extensions\":[]}]],\"extensions\":[],\"signatures\":[]}}},{\"context\":{\"level\":\"warn\",\"file\":\"database.cpp\",\"line\":654,\"method\":\"push_transaction\",\"hostname\":\"\",\"timestamp\":\"2018-06-12T15:32:45\"},\"format\":\"\",\"data\":{\"trx\":{\"ref_block_num\":19667,\"ref_block_prefix\":141500550,\"expiration\":\"2018-06-12T15:33:15\",\"operations\":[[\"change_recovery_account\",{\"account_to_recover\":\"initminer\",\"new_recovery_account\":\"temp\",\"extensions\":[]}]],\"extensions\":[],\"signatures\":[]}}}]}}}}\n    state.cpp:38 handle_reply\n\n    {\"call.method\":\"change_recovery_account\",\"call.params\":[\"initminer\",\"temp\",true]}\n    websocket_api.cpp:138 on_message","data":{"code":0,"name":"exception","message":"unspecified","stack":[{"context":{"level":"error","file":"state.cpp","line":38,"method":"handle_reply","hostname":"","timestamp":"2018-06-12T15:32:45"},"format":"${error}","data":{"error":"missing required owner authority:Missing Owner Authority initminer","data":{"id":6,"error":{"code":-32000,"message":"missing required owner authority:Missing Owner Authority initminer","data":{"code":3020000,"name":"tx_missing_owner_auth","message":"missing required owner authority","stack":[{"context":{"level":"error","file":"transaction_util.hpp","line":52,"method":"verify_authority","hostname":"","timestamp":"2018-06-12T15:32:45"},"format":"Missing Owner Authority ${id}","data":{"id":"initminer","auth":{"weight_threshold":1,"account_auths":[],"key_auths":[["STM8Xg6cEbqPCY8jrWFccgbCq5Fjw1okivwwmLDDgqQCQeAk7jedu",1]]}}},{"context":{"level":"warn","file":"transaction_util.hpp","line":60,"method":"verify_authority","hostname":"","timestamp":"2018-06-12T15:32:45"},"format":"","data":{"auth_containers":[["change_recovery_account",{"account_to_recover":"initminer","new_recovery_account":"temp","extensions":[]}]],"sigs":[]}},{"context":{"level":"warn","file":"transaction.cpp","line":169,"method":"verify_authority","hostname":"","timestamp":"2018-06-12T15:32:45"},"format":"","data":{"*this":{"ref_block_num":19667,"ref_block_prefix":141500550,"expiration":"2018-06-12T15:33:15","operations":[["change_recovery_account",{"account_to_recover":"initminer","new_recovery_account":"temp","extensions":[]}]],"extensions":[],"signatures":[]}}},{"context":{"level":"warn","file":"database.cpp","line":2112,"method":"_apply_transaction","hostname":"","timestamp":"2018-06-12T15:32:45"},"format":"","data":{"trx":{"ref_block_num":19667,"ref_block_prefix":141500550,"expiration":"2018-06-12T15:33:15","operations":[["change_recovery_account",{"account_to_recover":"initminer","new_recovery_account":"temp","extensions":[]}]],"extensions":[],"signatures":[]}}},{"context":{"level":"warn","file":"database.cpp","line":654,"method":"push_transaction","hostname":"","timestamp":"2018-06-12T15:32:45"},"format":"","data":{"trx":{"ref_block_num":19667,"ref_block_prefix":141500550,"expiration":"2018-06-12T15:33:15","operations":[["change_recovery_account",{"account_to_recover":"initminer","new_recovery_account":"temp","extensions":[]}]],"extensions":[],"signatures":[]}}}]}}}}},{"context":{"level":"warn","file":"websocket_api.cpp","line":138,"method":"on_message","hostname":"","timestamp":"2018-06-12T15:32:45"},"format":"","data":{"call.method":"change_recovery_account","call.params":["initminer","temp",true]}}]}}}
        }
        [Fact]
        public void WithdrawVesting()
        {
            _client.Wallet.withdraw_vesting("initminer",10,true); //add some shares for vesting test
        }
        
        [Fact]
        public void GetHistory()
        {
            _client.Wallet.get_account_history("initminer",10000000,1000);
        }
        [Fact]
        public void GetActiveWitness()
        {
            _client.Wallet.get_active_witnesses();
        }
        
        [Fact]
        public void GetFeedHistory()
        {
            _client.Wallet.get_feed_history();
        }
        [Fact]
        public void IsLockedFunc()
        {
            _client.Wallet.is_locked();
        }

        [Fact]
        public void LockAccount()
        {
            if (!_client.Wallet.is_locked())
            {
                var result = _client.Wallet.Lock();
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Already locked!");
            }
        }

        [Fact]
        public void GetInfo()
        {
            var result = _client.Wallet.info();
            Console.WriteLine(result);
        }

        [Fact]
        public void GetAbout()
        {
            _client.Wallet.About();
        }

        [Fact]
        public void ListAccounts()
        {
            var result = _client.Wallet.list_accounts();
            Console.WriteLine(result);
        }

        [Fact]
        public void GetBlock()
        {
            var result = _client.Wallet.get_block(16116);
            Console.WriteLine(result);
        }        
        [Fact]
        public void GetHelp()
        {
            var result = _client.Wallet.help();
            Console.WriteLine(result);
        }
        
        [Fact]
        public void UnLockAccount()
        {
            if (_client.Wallet.is_locked())
            {
                var param = new ArrayList {"abcde"};
                var result = _client.Wallet.unlock(param);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Already unlocked!");
            }
        }
        
        [Fact]
        public void GeneratePrivateKey()
        {          
            
            _client.Wallet.generate_private_key_c(key);
           
             
        }
        [Fact]
        public void GetTransactionDigest()
        {           
           _client.Wallet.get_transaction_digest_c(transaction,digest);
           
            
        }
        [Fact]
        public void SignedDigest()
        {           
            _client.Wallet.sign_digest_c(digest.ToString(),key.ToString(),sign);
            
            
        }
        [Fact]
        public void AddSignature()
        {           
            _client.Wallet.add_signature_c(transaction,sign.ToString(),signedDigest);
            
        }
    }
}