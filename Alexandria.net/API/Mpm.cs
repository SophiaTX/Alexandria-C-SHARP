using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mime;
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

using System.Data.SqlClient;
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
        /// Get Account name registered on the blockchain
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
            var operationalList=new List<Dictionary<string, GroupMeta>>();
            var gOb=new GroupObject
            {
                Admin=adminName,
                CurrentGroupName = groupName,
                Description = description,
                Members = membersArray,
                GroupName = groupName,
                GroupKey = groupKey
            };
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

                operationalList.Add(new Dictionary<string, GroupMeta>
                {
                    {
                        member.Result.account[0].Name, messageMeta
                    }

                });
            }

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                UserID = "sa",
                Password = "<YourStrong!Passw0rd>",
                InitialCatalog = "master"
            };
            Console.Write("connecting to SQL server...");
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                String sql; //= "DROP DATABASE IF EXISTS [MpmDB]; CREATE DATABASE [MpmDB]";
//                using (SqlCommand command = new SqlCommand(sql, connection))
//                {
//                    command.ExecuteNonQuery();
//                    Console.WriteLine("Done.");
//                }
                // Create a Table and insert some sample data
                
                StringBuilder sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                sb.Append("IF EXISTS(Select * from Groups) Begin ");
                sb.Append("INSERT INTO Groups (Admin, CurrentGroupName, Description, Members, GroupName, GroupKey, CurrentSeq) VALUES ");
                sb.Append("(N'"+adminName+"', N'"+groupName+"', N'"+description+"', N'"+membersArray+"', N'"+groupName+"', N'"+groupKey+"', N'"+0+"') End ELSE Begin ");
                sb.Append("CREATE TABLE Groups ( ");
                sb.Append(" Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");
                sb.Append(" Admin NVARCHAR(50), ");
                sb.Append(" CurrentGroupName NVARCHAR(50), ");
                sb.Append(" Description NVARCHAR(50), ");
                sb.Append(" Members TEXT,");
                sb.Append(" GroupName NVARCHAR(50), ");
                sb.Append(" GroupKey NVARCHAR(50), ");
                sb.Append(" CurrentSeq NVARCHAR(50) ");
                sb.Append("); ");
                sb.Append("INSERT INTO Groups (Admin, CurrentGroupName, Description, Members, GroupName, GroupKey, CurrentSeq) VALUES ");
                
                sb.Append("(N'"+adminName+"', N'"+groupName+"', N'"+description+"', N'"+membersArray+"', N'"+groupName+"', N'"+groupKey+"', N'"+0+"') End");
                
                sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done.");
                }
            }
            ret.operation_payloads=operationalList;
            ret.group_name = groupName;
            return ret;
        }
        
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