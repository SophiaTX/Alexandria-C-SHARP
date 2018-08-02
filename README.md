# Alexandria 
Alexandria.NET library for SophiaTX blockchain

Table of Contents
=================

- [Install](#install)
- [Create Connection](#create-connection)
- [Library Functions](#library-functions)
    - [Details](#details)
    - [Keys](#keys)
    - [Cryptography](#cryptography)
    - [Accounts](#accounts)
    - [Transactions](#transactions)
    - [Witnesses](#witnesses)
    - [Votes](#votes)
    - [Applications](#applications)


Install
=================

- Get the Library (Alexandria 1.0.2) as a nuget package from nuget.org

- https://www.nuget.org/packages/Alexandria.net/1.0.2 (Latest stable version)

- Add the nuget package into the project (using Nuget Package Manager)

- Rebuild the project and use the below mentioned functions to get connected with SophiaTX Blockchain


Create Connection
=================

```c#
 protected readonly SophiaClient _client = new SophiaClient(IpAddress, DemonPort, WalletPort); 
```

Library Functions
=================


Details
==================
Get Feed History
```c#
_client.Transaction.GetFeedHistory(CurrencySymbol);

```
Get details about the Blockchain
```c#
_client.Transaction.About();
```
Get a list of functions and How-To available on the sophia blockchain
```c#
_client.Transaction.Help();
```      
Get recent transaction and block information on the blockchain
```c#
_client.Transaction.Info();
```
Get block infromation using blockId
```c#
_client.Transaction.GetBlock(blockNumber);
```
Get operations from a block 
```c#
_client.Transaction.GetOpsInBlock(blockNumber, onlyVirtual);
```
Get Transaction details            
```c#
var trx=_client.Transaction.GetTransaction(transactionId);
```     
       
Keys
=================
Generate Private Key and Public Key pair
```c#
_client.Key.GeneratePrivateKey(new byte[51], new byte[53]);
```          
Get public key using private key
```c#
_client.Key.GetPublicKey(privateKey, new byte[53]);
```

Cryptography
====================
Encrypt Memo with private key and receiver's public key for sending secure data across the blockchain
```c#
_client.Key.EncryptMemo(memo, PrivateKey, PublicKey2, new byte[1024]);
```
Decrypt the received using private key and sender's public key
```c#
_client.Key.DecryptMemo(encryptedMemo, PrivateKey2, PublicKey, new byte[1024]);
```
Send JSON data to list of recepients
```c#
var test = "{\"new_book_name\":\"test9999\"}";
           
var data = new SenderData
            {
                AppId = 2,
                PrivateKey = PrivateKey,
                Recipients = new List<string> {accountName1, acocuntName2},
                Sender = accountName,
                Document = test
            };
            
_client.Data.Send(data);
```
Send plain text to list of recepients
```c#
var data = new SenderData
            {
                AppId = 2,
                PrivateKey = PrivateKey,
                Recipients = new List<string> {accountName1, acocuntName2},
                Sender = accountName,
                DocumentChars = memo
            };
            
_client.Data.SendBinary(data);
```   
List recieved documents, sorted depending on the search type, start(ISOTimeStamp)    
```c#
_client.Data.Receive(AppID, accountName, SearchType, start, numberOfEntries);
```

Accounts
====================
Create account using private key. Same public key can be used for all three keys required to create accoun. 

Seed, can be any unique value string (have atleast 3 digits and no special characters ($, £, #, etc.)) for genrating new account name.   

Creator, is an account with enough balance to pay for account creation.

```c#
_client.Account.CreateAccount(seed, jsonData, ownerKey, activeKey, memoKey, creator, creatorPrivateKey);
```
Get account details
```c#
_client.Account.GetAccount(accountName);
```
Delete account
```c#
_client.Account.DeleteAccount(accountName, PrivateKey);
```
Update account keys and JSON details
```c#
_client.Account.UpdateAccount(accountName, jsonData, ownerKey, activeKey, memoKey, privateKey);
```
Get account history
```c#
_client.Account.GetAccountHistory(accountName, from, limit);
```
Get account name from seed (used to create account)
```c#
_client.Account.GetAccountNameFromSeed(accountName);
```

Get account vesting balance
```c#
_client.Account.GetVestingBalance(accountName);
```
Get account balance
```c#
_client.Account.GetAccountBalance(accountName);
```
Check if account still exists
```c#
_client.Account.AccountExists(accountName);
```
Get account authority key
```c#
_client.Account.GetActiveAuthority(accountName);
```

Get account memo key
```c#
_client.Account.GetMemoKey(accountName);
```

Get account owner key
```c#
_client.Account.GetOwnerAuthority(accountName);
```
Create simple multi-signature authority
```c#
var pubkeys = new List<string> {publicKey1, publicKey2};
_client.Account.CreateSimpleMultisigAuthority(pubkeys, requiredSignatures);
```
Create simple managing authority
```c#
_client.Account.CreateSimpleManagedAuthority(managingAccountName);
```
Create simple multi-signature managing authority
```c#
var pubkeys = new List<string> {publicKey1, publicKey2};
_client.Account.CreateSimpleMultiManagedAuthority(pubkeys, requiredSignatures);
```

Transactions
==================
Transfer amount (argument in the format "250000.00 SPHTX") from one to other account 
```c#
_client.Asset.Transfer(accountName, beneficiaryAccountName, amount, memo, privateKey);
```
Withdraw amount (argument in the format "250000.00 SPHTX") vesting account balance
```c#
_client.Asset.WithdrawVesting(acocuntName, ammount, PrivateKey);
```
Transfer amount to vesting account 
```c#
_client.Asset.TransferToVesting(accountName, beneficiaryAccountName, amount, privateKey);
```
Witnesses
=================

Get Active Witnesses  
```c#
_client.Witness.GetActiveWitnesses();
```

Get List of all witnesses
```c#
_client.Witness.ListWitnesses(witnessName, numberOfEntries);
```

Get details of a witness      
```c#
_client.Witness.GetWitness(witnessName);
```
Become a witness, price feed example can be as 
```c#
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

_client.Witness.UpdateWitness(accountName, url, blockSigningKey, accountCreationFee, minimumBlockSize, pricefeed, privateKey);
```

Votes
====================
Set voting proxy
```c#
_client.Account.SetVotingProxy(accountName, proxyAccountName, PrivateKey);
```
Vote for a witness         
```c#
_client.Witness.VoteForWitness(accountName, witnessName, voteType, privateKey);
``` 

Applications
==================
Create application (the price parameter that specifies billing for the app (1 or 0))
```c#
_client.Application.CreateApplication(accountName, applicationName, URL, jsonData, priceParam, PrivateKey);
```
Update application
```c#
_client.Application.UpdateApplication(accountName, applicationName, URL, jsonData, priceParam, PrivateKey);
```
Delete application
```c#
_client.Application.DeleteApplication(accountName, applicationName, PrivateKey);
```
Buy Application
```c#
_client.Application.BuyApplication(accountName, appId, PrivateKey);
```
Cancel Application purchase 
```c#
_client.Application.CancelApplicationBuying(sellerAccountName, buyerAccountName, appId, PrivateKey);
```
Get a list of all bought application and sorting is done depending on search type (bySeller or byBuyer)
```c#
_client.Application.GetApplicationBuyings(accountName, SearchType, numberOfEntries);
```
Get details of list of applications
```c#
var names = new List<string>{applicationName1, applicationName2};
_client.Application.GetApplications(names);
```      
