using System;
using System.Collections;
using System.Collections.Generic;
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

        #region Constructor
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        /// <param name="wallet"></param>
        public Mpm(IConfig config) : base(config)
        {
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
        public GroupMeta EncodeAndPack(string key,GroupOp op)
        {
//                        
              MessageWrapper messageContent=new MessageWrapper
              {
                  type=MessageWrapper.message_type.group_operation,
                  operation_data = op
              };

            string encodedMessages=null;
            GroupMeta messageMeta =new GroupMeta
            {
               data = encodedMessages
            };
            return messageMeta;
        }

//        public CreateGroupReturn CreateGroup(string adminName, string privateKey, string description, string[] members)
//        {
//            CreateGroupReturn ret;
//            var admin = getAccount(adminName);
//
//        }

        private object getAccount(string adminName)
        {
            var account=new Account(new Config());
            var result=account.GetAccount(adminName);
            return result;
        }

        #endregion
    }
}