using System;
using System.Collections.Generic;
using Alexandria.net.Core;
using Alexandria.net.Messaging.Receiver;
using Alexandria.net.Messaging.Responses;
using Newtonsoft.Json;
using Xunit;

namespace UnitTest
{
    public class ArkTree
    {
        private readonly SophiaClient
            _client = new SophiaClient("195.48.9.208", 8095, 8096);

        private const string PublicKey = "SPH59weyKqJJvECS6EG4t2qbd5LbnZDcsLq5Eq2CxWv9peUeN2cwp";
        private const string PrivateKey = "5Kb3xDUMJ6QoDGEq3gsXU9KRQDDvLBXqaT3P8bp1jPcfctAvagZ";

        private const string PrivateKey2 = "5HqnQB5R8Yfaq4mALL33kkBGFuSv2kMPxGsjFygHPhk8EqunmXZ";
        private const string PublicKey2 = "SPH6eJ4GcGtay4qvZ7eebXaLkGcXsMhq3WC1GgyQbTLbEd6EVisSm";

        [Fact]
        public bool Test()
        {
            
            //generate keys
//            var keyResponse =  _client.Wallet.Key.GeneratePrivateKey(new byte[51], new byte[53]);
//            if(keyResponse == null) return false;
//
//            //create account
//            var transresponse = _client.Wallet.Account.CreateAccount("marc1", "{}",PublicKey,
//                PublicKey, PublicKey);
//            if (transresponse == null) return false;
//            
//            transresponse = _client.Wallet.Account.CreateAccount("sean1", "{}", PublicKey,
//                PublicKey, PublicKey);
//            if (transresponse == null) return false;
//            
            //get account details
//            var accountresponse = _client.Wallet.Account.GetAccount("marc1");
//            if (accountresponse == null) return false;

//            var transresponse = _client.Wallet.Account.UpdateAccount("marc1", "{}", PublicKey2, PublicKey,
//                PublicKey, PrivateKey);
//            if (transresponse == null) return false;

//            //update to account
//            accountresponse = _client.Wallet.Account.GetAccount("marc1");
//            if (accountresponse == null) return false;

            var loaner = new Person
            {
                Name = "Martyn",
                LoanDate = DateTime.UtcNow,
                ReturnDate = DateTime.UtcNow.AddDays(14),
                LoanedBook = new Book {Title = "Blockchain for dummies"}
            };

            var json = JsonConvert.SerializeObject(loaner);

            var data = new SenderData
            {
                AppId = 23,
                PrivateKey = PrivateKey,
                Recipients = new List<string> {"sean"},
                Sender = "marc1",
                Document = json
            };
            var transresponse = _client.Data.Send(data);

            if (transresponse == null) return false;

            var blockresponse = _client.Transaction.GetBlock((uint)transresponse.Result.BlockNum);
            if (blockresponse == null) return false;

            loaner.Blockdata = blockresponse;
            //data to be persisted somwhere

            _client.Transaction.GetTransaction(loaner.Blockdata.Result.BlockId);
            Console.WriteLine(blockresponse.Result);
            return true;
        }
    }

    public class Book
    {
        public string  Title { get; set; }
       
    }

    public class Person
    {
        public string Name { get; set; }
        public Book LoanedBook { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public BlockResponse Blockdata { get; set; }
    }
}