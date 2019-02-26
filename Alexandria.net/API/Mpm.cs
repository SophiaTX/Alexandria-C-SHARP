using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
//using System.Security.Cryptography.Algorithms;
using Alexandria.net.Communication;
using Alexandria.net.Input;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Params;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;
using AccountResponse = Alexandria.net.Messaging.Responses.AccountResponse;


namespace Alexandria.net.API
{
   
    /// <summary>
    /// 
    /// </summary>
    public class Mpm: RpcConnection
    {
        private readonly ILogger _logger;
        private IConfig Config { get; }
        #region Constructor
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        /// <param name="wallet"></param>
        public Mpm(IConfig config) : base(config)
        {   
            Config = config;
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(config, assemblyname);
        }
        

        #endregion


        #region PublicMethods

        //suggestGroupName
        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public string SuggestGroupName(string description)
        {
           
           
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
           
            byte[] randomBytes = new byte[21];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            string seed = description + randomBytes;
            byte[] seedByte = Encoding.ASCII.GetBytes(seed);
            
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(seedByte);
                return Convert.ToBase64String(hash);
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CreateRandomKey()
        {
//            fc::sha256::encoder sha_enc;
//            for(int i=0; i<4; i++) {
//                fc::sha256 sha_entropy = fc::ecc::private_key::generate().get_secret();
//                sha_enc.write( sha_entropy.data(), sha_entropy.data_size());
//            }
//            fc::sha256 result_key = sha_enc.result();
//            vector<char> ret(result_key.data(), result_key.data() + result_key.data_size());
//            return ret;
            
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
           
            byte[] randomBytes = new byte[21];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(randomBytes);
                return Convert.ToBase64String(hash);
            }
            
        }

         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="op"></param>
        public GroupMeta EncodeAndPack(string privateKey,string publicKey, GroupOp op)
        {
//                        
              MessageWrapper messageContent=new MessageWrapper
              {
                  type=MessageWrapper.message_type.group_operation,
                  operation_data = op
              };
            var key=new Key(Config);
            string encodedMessages=key.EncryptMemo(op.ToString(), privateKey, publicKey, new byte[1024]);;
            GroupMeta messageMeta =new GroupMeta
            {
               data = encodedMessages
            };
            return messageMeta;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public GetAccountResponse GetAccount(string adminName)
        {
            var account=new Account(Config);
            var result=account.GetAccount(adminName);
            return result;
        }
        
//        public object GetGroup(string groupName)
//        {
//            
//        }

        /// <summary>
        /// Create Group for a closed group conversations
        /// </summary>
        /// <param name="adminName"></param>
        /// <param name="privateKey"></param>
        /// <param name="description"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        public CreateGroupReturn CreateGroup(string adminName, string privateKey, string description, string[] members)
        {
            CreateGroupReturn ret=new CreateGroupReturn();
            var key=new Key(Config);
            var admin = GetAccount(adminName);
            string groupName = SuggestGroupName(description);
            string groupKey = CreateRandomKey();
            string[] membersArray = members;
            var list= new List<string>();
            var operational_list=new List<Dictionary<string, GroupMeta>>();
            foreach (string s in membersArray)
            {
                var member = GetAccount(s);
                var gOp = new GroupOp
                {
                    type = "add",
                    description = description,
                    new_group_name = groupName,
                    senders_pubkey = admin.Result.account[0].MemoKey
                };
                list.Add(admin.Result.account[0].Name);
                gOp.user_list = list.ToArray();

                var encryptedKey =
                    key.EncryptMemo(groupKey, privateKey, member.Result.account[0].MemoKey, new byte[1024]);
                gOp.new_key = new Dictionary<string, string>
                {
                    {member.Result.account[0].MemoKey, encryptedKey}
                };

                var messageMeta = EncodeAndPack(privateKey,member.Result.account[0].MemoKey,gOp);
                messageMeta.recipient = member.Result.account[0].MemoKey;
                messageMeta.sender = admin.Result.account[0].Name;
                
                 operational_list.Add(new Dictionary<string, GroupMeta>
                 {
                     {
                         member.Result.account[0].Name,messageMeta
                     }

                 });
                
            }
            ret.operation_payloads=operational_list;
            ret.group_name = groupName;
            return ret;

        }
//        
//        public object AddGroupParticipants(string groupName, string privateKey, string admin, string [] newMembers)
//        {
//            
//        }
//        public object DeleteGroupParticipants(string groupName, string privateKey, string admin, string [] deleteMembers)
//        {
//            
//        }
//        public object UpdateGroup(string groupName, string privateKey, string description, string admin)
//        {
//            
//        }
//        public object DisbandGroup(string groupName, string privateKey, string admin)
//        {
//            
//        }
//        public object sendGroupMessages(string groupName, string privateKey, string sender, string data)
//        {
//            
//        }
        #endregion
    }
}