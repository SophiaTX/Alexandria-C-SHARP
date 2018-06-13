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

        private string digest="560f5b91130e4048dbc6a6d4b2d1e0093b412a83a529c36d7066";
        private string sign="1f05e0a0ad257dd3f93fb01cacf8da5da2e1a632d6da4f1eb35506a3e5a854f8ff1ff42e725f0caac288226e29b7138bd02a3389b3fb4aab4b92cd9f3f0773e96";
        private string key="5KfQMLDj6QkiGV515xb42GzB6PqS4aGGefBYxZwWvuazsW1AYrj";
           
        
        [Fact]
        public void CreateOrder()
        {
            _client.Wallet.create_order("STM72M7oitApSdU1fp4wPWNYgBrtxkUq7yK2xAgzxrNEkKkoPKN2u",1120134,1000,999,true,90,true);
            //{"id":0,"error":{"code":1,"message":"10 assert_exception: Assert Exception\nitr != _by_name.end(): no method with name 'create_order'\n    {\"name\":\"create_order\",\"api\":{\"about\":2,\"change_recovery_account\":49,\"create_account\":27,\"create_account_with_keys\":28,\"decrypt_memo\":52,\"escrow_approve\":40,\"escrow_dispute\":41,\"escrow_release\":42,\"escrow_transfer\":39,\"get_account\":21,\"get_account_history\":25,\"get_active_witnesses\":56,\"get_block\":22,\"get_encrypted_memo\":51,\"get_feed_history\":24,\"get_ops_in_block\":23,\"get_owner_history\":50,\"get_private_key\":13,\"get_private_key_from_password\":14,\"get_prototype_operation\":53,\"get_state\":26,\"get_transaction\":57,\"get_witness\":20,\"gethelp\":1,\"help\":0,\"import_key\":10,\"info\":16,\"is_locked\":4,\"is_new\":3,\"list_accounts\":18,\"list_keys\":12,\"list_my_accounts\":17,\"list_witnesses\":19,\"load_wallet_file\":8,\"lock\":5,\"normalize_brain_key\":15,\"publish_feed\":45,\"recover_account\":48,\"request_account_recovery\":47,\"save_wallet_file\":9,\"serialize_transaction\":54,\"set_password\":7,\"set_transaction_expiration\":46,\"set_voting_proxy\":36,\"sign_transaction\":55,\"suggest_brain_key\":11,\"transfer\":38,\"transfer_to_vesting\":43,\"unlock\":6,\"update_account\":29,\"update_account_auth_account\":31,\"update_account_auth_key\":30,\"update_account_auth_threshold\":32,\"update_account_memo_key\":34,\"update_account_meta\":33,\"update_witness\":35,\"vote_for_witness\":37,\"withdraw_vesting\":44}}\n    api_connection.hpp:109 call\n\n    {\"call.method\":\"create_order\",\"call.params\":[\"STM72M7oitApSdU1fp4wPWNYgBrtxkUq7yK2xAgzxrNEkKkoPKN2u\",1120134,\"1000.00000000000000000\",\"999.00000000000000000\",true,90,true]}\n    websocket_api.cpp:138 on_message","data":{"code":10,"name":"assert_exception","message":"Assert Exception","stack":[{"context":{"level":"error","file":"api_connection.hpp","line":109,"method":"call","hostname":"","timestamp":"2018-06-13T07:42:13"},"format":"itr != _by_name.end(): no method with name '${name}'","data":{"name":"create_order","api":{"about":2,"change_recovery_account":49,"create_account":27,"create_account_with_keys":28,"decrypt_memo":52,"escrow_approve":40,"escrow_dispute":41,"escrow_release":42,"escrow_transfer":39,"get_account":21,"get_account_history":25,"get_active_witnesses":56,"get_block":22,"get_encrypted_memo":51,"get_feed_history":24,"get_ops_in_block":23,"get_owner_history":50,"get_private_key":13,"get_private_key_from_password":14,"get_prototype_operation":53,"get_state":26,"get_transaction":57,"get_witness":20,"gethelp":1,"help":0,"import_key":10,"info":16,"is_locked":4,"is_new":3,"list_accounts":18,"list_keys":12,"list_my_accounts":17,"list_witnesses":19,"load_wallet_file":8,"lock":5,"normalize_brain_key":15,"publish_feed":45,"recover_account":48,"request_account_recovery":47,"save_wallet_file":9,"serialize_transaction":54,"set_password":7,"set_transaction_expiration":46,"set_voting_proxy":36,"sign_transaction":55,"suggest_brain_key":11,"transfer":38,"transfer_to_vesting":43,"unlock":6,"update_account":29,"update_account_auth_account":31,"update_account_auth_key":30,"update_account_auth_threshold":32,"update_account_memo_key":34,"update_account_meta":33,"update_witness":35,"vote_for_witness":37,"withdraw_vesting":44}}},{"context":{"level":"warn","file":"websocket_api.cpp","line":138,"method":"on_message","hostname":"","timestamp":"2018-06-13T07:42:13"},"format":"","data":{"call.method":"create_order","call.params":["STM72M7oitApSdU1fp4wPWNYgBrtxkUq7yK2xAgzxrNEkKkoPKN2u",1120134,"1000.00000000000000000","999.00000000000000000",true,90,true]}}]}}}
        }
        
        [Fact]
        public void CancelOrder()
        {
            _client.Wallet.cancel_order("STM72M7oitApSdU1fp4wPWNYgBrtxkUq7yK2xAgzxrNEkKkoPKN2u",1120133,true);
            //{"id":0,"error":{"code":1,"message":"10 assert_exception: Assert Exception\nitr != _by_name.end(): no method with name 'cancel_order'\n    {\"name\":\"cancel_order\",\"api\":{\"about\":2,\"change_recovery_account\":49,\"create_account\":27,\"create_account_with_keys\":28,\"decrypt_memo\":52,\"escrow_approve\":40,\"escrow_dispute\":41,\"escrow_release\":42,\"escrow_transfer\":39,\"get_account\":21,\"get_account_history\":25,\"get_active_witnesses\":56,\"get_block\":22,\"get_encrypted_memo\":51,\"get_feed_history\":24,\"get_ops_in_block\":23,\"get_owner_history\":50,\"get_private_key\":13,\"get_private_key_from_password\":14,\"get_prototype_operation\":53,\"get_state\":26,\"get_transaction\":57,\"get_witness\":20,\"gethelp\":1,\"help\":0,\"import_key\":10,\"info\":16,\"is_locked\":4,\"is_new\":3,\"list_accounts\":18,\"list_keys\":12,\"list_my_accounts\":17,\"list_witnesses\":19,\"load_wallet_file\":8,\"lock\":5,\"normalize_brain_key\":15,\"publish_feed\":45,\"recover_account\":48,\"request_account_recovery\":47,\"save_wallet_file\":9,\"serialize_transaction\":54,\"set_password\":7,\"set_transaction_expiration\":46,\"set_voting_proxy\":36,\"sign_transaction\":55,\"suggest_brain_key\":11,\"transfer\":38,\"transfer_to_vesting\":43,\"unlock\":6,\"update_account\":29,\"update_account_auth_account\":31,\"update_account_auth_key\":30,\"update_account_auth_threshold\":32,\"update_account_memo_key\":34,\"update_account_meta\":33,\"update_witness\":35,\"vote_for_witness\":37,\"withdraw_vesting\":44}}\n    api_connection.hpp:109 call\n\n    {\"call.method\":\"cancel_order\",\"call.params\":[\"STM72M7oitApSdU1fp4wPWNYgBrtxkUq7yK2xAgzxrNEkKkoPKN2u\",1120133,true]}\n    websocket_api.cpp:138 on_message","data":{"code":10,"name":"assert_exception","message":"Assert Exception","stack":[{"context":{"level":"error","file":"api_connection.hpp","line":109,"method":"call","hostname":"","timestamp":"2018-06-13T07:46:34"},"format":"itr != _by_name.end(): no method with name '${name}'","data":{"name":"cancel_order","api":{"about":2,"change_recovery_account":49,"create_account":27,"create_account_with_keys":28,"decrypt_memo":52,"escrow_approve":40,"escrow_dispute":41,"escrow_release":42,"escrow_transfer":39,"get_account":21,"get_account_history":25,"get_active_witnesses":56,"get_block":22,"get_encrypted_memo":51,"get_feed_history":24,"get_ops_in_block":23,"get_owner_history":50,"get_private_key":13,"get_private_key_from_password":14,"get_prototype_operation":53,"get_state":26,"get_transaction":57,"get_witness":20,"gethelp":1,"help":0,"import_key":10,"info":16,"is_locked":4,"is_new":3,"list_accounts":18,"list_keys":12,"list_my_accounts":17,"list_witnesses":19,"load_wallet_file":8,"lock":5,"normalize_brain_key":15,"publish_feed":45,"recover_account":48,"request_account_recovery":47,"save_wallet_file":9,"serialize_transaction":54,"set_password":7,"set_transaction_expiration":46,"set_voting_proxy":36,"sign_transaction":55,"suggest_brain_key":11,"transfer":38,"transfer_to_vesting":43,"unlock":6,"update_account":29,"update_account_auth_account":31,"update_account_auth_key":30,"update_account_auth_threshold":32,"update_account_memo_key":34,"update_account_meta":33,"update_witness":35,"vote_for_witness":37,"withdraw_vesting":44}}},{"context":{"level":"warn","file":"websocket_api.cpp","line":138,"method":"on_message","hostname":"","timestamp":"2018-06-13T07:46:34"},"format":"","data":{"call.method":"cancel_order","call.params":["STM72M7oitApSdU1fp4wPWNYgBrtxkUq7yK2xAgzxrNEkKkoPKN2u",1120133,true]}}]}}}
        }
        [Fact]
        public void SuggestBrainKey()
        {
            _client.Wallet.suggest_brain_key();
        }
        
        [Fact]
        public void NormalizeBrainKey()
        {
            _client.Wallet.normalize_brain_key("");
        }
        [Fact]
        public void GetPrivateKeyFromPassword()
        {
            _client.Wallet.get_private_key_from_password("initminer","witness","abcde");
        }
        [Fact]
        public void isNew()
        {
            _client.Wallet.is_new();
        }
        
        [Fact]
        public void VoteForWitness()
        {
            _client.Wallet.vote_for_witness("initminer","temp",true,true); //{"id":0,"error":{"code":1,"message":"0 exception: unspecified\nmissing required active authority:Missing Active Authority initminer\n    {\"error\":\"missing required active authority:Missing Active Authority initminer\",\"data\":{\"id\":3,\"error\":{\"code\":-32000,\"message\":\"missing required active authority:Missing Active Authority initminer\",\"data\":{\"code\":3010000,\"name\":\"tx_missing_active_auth\",\"message\":\"missing required active authority\",\"stack\":[{\"context\":{\"level\":\"error\",\"file\":\"transaction_util.hpp\",\"line\":45,\"method\":\"verify_authority\",\"hostname\":\"\",\"timestamp\":\"2018-06-13T07:04:09\"},\"format\":\"Missing Active Authority ${id}\",\"data\":{\"id\":\"initminer\",\"auth\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM8Xg6cEbqPCY8jrWFccgbCq5Fjw1okivwwmLDDgqQCQeAk7jedu\",1]]},\"owner\":{\"weight_threshold\":1,\"account_auths\":[],\"key_auths\":[[\"STM8Xg6cEbqPCY8jrWFccgbCq5Fjw1okivwwmLDDgqQCQeAk7jedu\",1]]}}},{\"context\":{\"level\":\"warn\",\"file\":\"transaction_util.hpp\",\"line\":60,\"method\":\"verify_authority\",\"hostname\":\"\",\"timestamp\":\"2018-06-13T07:04:09\"},\"format\":\"\",\"data\":{\"auth_containers\":[[\"account_witness_vote\",{\"account\":\"initminer\",\"witness\":\"temp\",\"approve\":true}]],\"sigs\":[]}},{\"context\":{\"level\":\"warn\",\"file\":\"transaction.cpp\",\"line\":169,\"method\":\"verify_authority\",\"hostname\":\"\",\"timestamp\":\"2018-06-13T07:04:09\"},\"format\":\"\",\"data\":{\"*this\":{\"ref_block_num\":19802,\"ref_block_prefix\":746503726,\"expiration\":\"2018-06-13T07:04:39\",\"operations\":[[\"account_witness_vote\",{\"account\":\"initminer\",\"witness\":\"temp\",\"approve\":true}]],\"extensions\":[],\"signatures\":[]}}},{\"context\":{\"level\":\"warn\",\"file\":\"database.cpp\",\"line\":2112,\"method\":\"_apply_transaction\",\"hostname\":\"\",\"timestamp\":\"2018-06-13T07:04:09\"},\"format\":\"\",\"data\":{\"trx\":{\"ref_block_num\":19802,\"ref_block_prefix\":746503726,\"expiration\":\"2018-06-13T07:04:39\",\"operations\":[[\"account_witness_vote\",{\"account\":\"initminer\",\"witness\":\"temp\",\"approve\":true}]],\"extensions\":[],\"signatures\":[]}}},{\"context\":{\"level\":\"warn\",\"file\":\"database.cpp\",\"line\":654,\"method\":\"push_transaction\",\"hostname\":\"\",\"timestamp\":\"2018-06-13T07:04:09\"},\"format\":\"\",\"data\":{\"trx\":{\"ref_block_num\":19802,\"ref_block_prefix\":746503726,\"expiration\":\"2018-06-13T07:04:39\",\"operations\":[[\"account_witness_vote\",{\"account\":\"initminer\",\"witness\":\"temp\",\"approve\":true}]],\"extensions\":[],\"signatures\":[]}}}]}}}}\n    state.cpp:38 handle_reply\n\n    {\"voting_account\":\"initminer\",\"witness_to_vote_for\":\"temp\",\"approve\":true,\"broadcast\":true}\n    wallet.cpp:1455 vote_for_witness\n\n    {\"call.method\":\"vote_for_witness\",\"call.params\":[\"initminer\",\"temp\",true,true]}\n    websocket_api.cpp:138 on_message","data":{"code":0,"name":"exception","message":"unspecified","stack":[{"context":{"level":"error","file":"state.cpp","line":38,"method":"handle_reply","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"${error}","data":{"error":"missing required active authority:Missing Active Authority initminer","data":{"id":3,"error":{"code":-32000,"message":"missing required active authority:Missing Active Authority initminer","data":{"code":3010000,"name":"tx_missing_active_auth","message":"missing required active authority","stack":[{"context":{"level":"error","file":"transaction_util.hpp","line":45,"method":"verify_authority","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"Missing Active Authority ${id}","data":{"id":"initminer","auth":{"weight_threshold":1,"account_auths":[],"key_auths":[["STM8Xg6cEbqPCY8jrWFccgbCq5Fjw1okivwwmLDDgqQCQeAk7jedu",1]]},"owner":{"weight_threshold":1,"account_auths":[],"key_auths":[["STM8Xg6cEbqPCY8jrWFccgbCq5Fjw1okivwwmLDDgqQCQeAk7jedu",1]]}}},{"context":{"level":"warn","file":"transaction_util.hpp","line":60,"method":"verify_authority","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"auth_containers":[["account_witness_vote",{"account":"initminer","witness":"temp","approve":true}]],"sigs":[]}},{"context":{"level":"warn","file":"transaction.cpp","line":169,"method":"verify_authority","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"*this":{"ref_block_num":19802,"ref_block_prefix":746503726,"expiration":"2018-06-13T07:04:39","operations":[["account_witness_vote",{"account":"initminer","witness":"temp","approve":true}]],"extensions":[],"signatures":[]}}},{"context":{"level":"warn","file":"database.cpp","line":2112,"method":"_apply_transaction","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"trx":{"ref_block_num":19802,"ref_block_prefix":746503726,"expiration":"2018-06-13T07:04:39","operations":[["account_witness_vote",{"account":"initminer","witness":"temp","approve":true}]],"extensions":[],"signatures":[]}}},{"context":{"level":"warn","file":"database.cpp","line":654,"method":"push_transaction","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"trx":{"ref_block_num":19802,"ref_block_prefix":746503726,"expiration":"2018-06-13T07:04:39","operations":[["account_witness_vote",{"account":"initminer","witness":"temp","approve":true}]],"extensions":[],"signatures":[]}}}]}}}}},{"context":{"level":"warn","file":"wallet.cpp","line":1455,"method":"vote_for_witness","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"voting_account":"initminer","witness_to_vote_for":"temp","approve":true,"broadcast":true}},{"context":{"level":"warn","file":"websocket_api.cpp","line":138,"method":"on_message","hostname":"","timestamp":"2018-06-13T07:04:09"},"format":"","data":{"call.method":"vote_for_witness","call.params":["initminer","temp",true,true]}}]}}}
        }
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
            
            _client.Wallet.generate_private_key_c(new byte[52]);
           
             
        }
        [Fact]
        public void GetTransactionDigest()
        {           
           _client.Wallet.get_transaction_digest_c(transaction,new byte[62]);
           
            
        }
        [Fact]
        public void SignedDigest()
        {           
            _client.Wallet.sign_digest_c(digest,key,new byte[130]);
            
            
        }
        [Fact]
        public void AddSignature()
        {           
            _client.Wallet.add_signature_c(transaction,sign,new byte[transaction.Length+200]);
            
        }

        
    }
}