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