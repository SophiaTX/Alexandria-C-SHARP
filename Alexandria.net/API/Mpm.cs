using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;


namespace Alexandria.net.API
{
   
    /// <inheritdoc />
    /// <summary>
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
        /// Suggest a group name for current messgae exchange
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        private string SuggestGroupName(string description)
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
        /// Create random key for next key exchange
        /// </summary>
        /// <returns></returns>
        private string CreateRandomKey()
        {
//            fc::sha256::encoder sha_enc;
//            for(int i=0; i<4; i++) {
//                fc::sha256 sha_entropy = fc::ecc::private_key::generate().get_secret();
//                sha_enc.write( sha_entropy.data(), sha_entropy.data_size());
//            }
//            fc::sha256 result_key = sha_enc.result();
//            vector<char> ret(result_key.data(), result_key.data() + result_key.data_size());
//            return ret;
            
//            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
//           
//            byte[] randomBytes = new byte[21];
//            rngCryptoServiceProvider.GetBytes(randomBytes);
//            using (SHA1Managed sha1 = new SHA1Managed())
//            {
//                var hash = sha1.ComputeHash(randomBytes);
//                return Convert.ToBase64String(hash);
//            }
            var key=new Key(Config);
            return key.GeneratePrivateKey(new byte[50], new byte[53]).PublicKey;


        }


        /// <summary>
        /// Encode a message and create a bundle of object
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="op"></param>
        /// <param name="privateKey"></param>
        private GroupMeta EncodeAndPack(string privateKey,string publicKey, GroupOp op)
        {                       
              MessageWrapper messageContent=new MessageWrapper
              {
                  type=MessageWrapper.message_type.group_operation,
                  operation_data = op
              };
            var key=new Key(Config);
            var encodedMessages=key.EncryptMemo(messageContent.ToString(), privateKey, publicKey, new byte[1024]);;
            var messageMeta =new GroupMeta
            {
               data = encodedMessages
            };
            return messageMeta;
        }
        private string EncodeMessage(string privateKey,string publicKey, MessageWrapper op)
        {                       
            var key=new Key(Config);
            string encodedMessage=key.EncryptMemo(op.ToString(), privateKey, publicKey, new byte[1024]);;
            
            return encodedMessage.Trim('\u0000');
        }
        /// <summary>
        /// Get Account name registered on the block chain
        /// </summary>
        /// <param name="adminName"></param>
        /// <returns></returns>
        private GetAccountResponse GetAccount(string adminName)
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
            var ret=new CreateGroupReturn();
            var key=new Key(Config);
            var admin = GetAccount(adminName);
            var groupName = SuggestGroupName(description);
            var groupKey = CreateRandomKey();
            var membersArray = members;
            var list= new List<string>();
            var operationalList=new List<Dictionary<string, GroupMeta>>();
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
                gOp.user_list = list.Union(membersArray).ToArray();

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
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                string sql; //= "DROP DATABASE IF EXISTS [MpmDB]; CREATE DATABASE [MpmDB]";
//                using (SqlCommand command = new SqlCommand(sql, connection))
//                {
//                    command.ExecuteNonQuery();
//                    Console.WriteLine("Done.");
//                }
                // Create a Table and insert some sample data
                Console.WriteLine(membersArray);
                var sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                sb.Append("IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Groups') Begin ");
                sb.Append($"INSERT INTO Groups (Admin, CurrentGroupName, Description, Members, GroupName, GroupKey, CurrentSeq) VALUES ");
                sb.Append("(N'"+adminName+"', N'"+groupName+"', N'"+description+"', N'"+JsonConvert.SerializeObject(membersArray)+"', N'"+groupName+"', N'"+groupKey+"', N'"+0+"') End ELSE Begin ");
                sb.Append($"CREATE TABLE Groups ( ");
                sb.Append(" Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");
                sb.Append(" Admin NVARCHAR(50), ");
                sb.Append(" CurrentGroupName NVARCHAR(50), ");
                sb.Append(" Description NVARCHAR(50), ");
                sb.Append(" Members TEXT,");
                sb.Append(" GroupName NVARCHAR(50), ");
                sb.Append(" GroupKey NVARCHAR(max), ");
                sb.Append(" CurrentSeq NVARCHAR(50) ");
                sb.Append("); ");
                sb.Append($"INSERT INTO Groups (Admin, CurrentGroupName, Description, Members, GroupName, GroupKey, CurrentSeq) VALUES ");
                
                sb.Append("(N'"+adminName+"', N'"+groupName+"', N'"+description+"', N'"+JsonConvert.SerializeObject(membersArray)+"', N'"+groupName+"', N'"+groupKey+"', N'"+0+"') End");
                
                sql = sb.ToString();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done.");
                }
            }
            ret.operation_payloads=operationalList;
            ret.group_name = groupName;
            return ret;
        }
        
        /// <summary>
        /// Add participants to the group
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="privateKey"></param>
        /// <param name="adminName"></param>
        /// <param name="newMembers"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CreateGroupReturn AddGroupParticipants(string groupName, string privateKey, string adminName, string [] newMembers)
        {
            var ret = new CreateGroupReturn();
            var key = new Key(Config);
            string description = null;
            string[] members = null;
            string Admin = null;
            string GroupKey = null;
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                UserID = "sa",
                Password = "<YourStrong!Passw0rd>",
                InitialCatalog = "master"
            };
            Console.Write("connecting to SQL server...");
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                var sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                sb.Append(
                    "IF EXISTS(Select * from Groups) Begin Select Description,Members,CurrentGroupName,Admin,GroupKey from Groups where Groups.GroupName = '" +
                    groupName + "' End ; ");

                var sql = sb.ToString();
                using (var command = new SqlCommand(sql, connection))
                {
                    var item = command.ExecuteReader();
                    while (item.Read())
                    {
                        description = item[0].ToString();
                        members = item[1].ToString().Replace("\"", "").Trim('[').Trim(']').Split(',');
                        Admin = item[3].ToString();
                        GroupKey = item[4].ToString();
                    }

                    Console.WriteLine("Done.");
                }
            }

            if (adminName == Admin)
            {
                var admin = GetAccount(adminName);
                var newGroupName = SuggestGroupName(description);
                var newGroupKey = CreateRandomKey();

                if (members != null)
                {
                    var membersArray = members.Union(newMembers).ToArray();

                    var operationalList = new List<Dictionary<string, GroupMeta>>();
                        
                    foreach (string s in membersArray)
                    {
                        var member = GetAccount(s);
                        var gOp = new GroupOp
                        {
                            type = "add",
                            description = description,
                            new_group_name = newGroupName, 
                            user_list = membersArray,
                            senders_pubkey = admin.Result.account[0].MemoKey
                                
                        };

                        var encryptedKey1 =
                            key.EncryptMemo(newGroupKey, privateKey, member.Result.account[0].MemoKey, new byte[1024]);
                        gOp.new_key = new Dictionary<string, string>
                        {
                            {member.Result.account[0].MemoKey, encryptedKey1}
                        };
                            
                        var messageMeta1 = EncodeAndPack(privateKey, member.Result.account[0].MemoKey, gOp);
                        messageMeta1.recipient = member.Result.account[0].MemoKey;
                        messageMeta1.sender = admin.Result.account[0].Name;

                        operationalList.Add(new Dictionary<string, GroupMeta>
                        {
                            {
                                member.Result.account[0].Name, messageMeta1
                            }

                        });
                    }
                        
                    var gOpUpdate = new GroupOp
                    {
                        type = "update",
                        description = description,
                        new_group_name = groupName, 
                        user_list = membersArray,
                        senders_pubkey = admin.Result.account[0].MemoKey
                                
                    };
                    var encryptedKey2 =
                        key.EncryptMemo(newGroupKey, privateKey, GroupKey, new byte[1024]);
                    gOpUpdate.new_key = new Dictionary<string, string>
                    {
                        {GroupKey, encryptedKey2}
                    };
                        

                    using (var connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        Console.WriteLine("Done");
                        string sql; 
                        // Create a Table and insert some sample data
                        Console.WriteLine(membersArray);
                        var sb = new StringBuilder();
                        sb.Append("USE MpmDB; ");
                        sb.Append("IF EXISTS(Select * from Groups) Begin ");
                        sb.Append(
                            $"UPDATE Groups SET CurrentGroupName = N'" + newGroupName+ "', Members = N'" +
                            JsonConvert.SerializeObject(membersArray) + "', GroupKey =N'" +newGroupKey+"' WHERE GroupName = N'" +groupName+ "' END ");
                            
                        sql = sb.ToString();
                        using (var command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Done.");
                        }
                    }
                    var messageMeta2 = EncodeAndPack(privateKey, GroupKey, gOpUpdate);
                    operationalList.Add(new Dictionary<string, GroupMeta>
                    {
                        {
                            newGroupName, messageMeta2
                        }

                    });
                        

                    ret.operation_payloads = operationalList;
                }
                else
                {
                    ret.operation_payloads = null;
                }
                ret.group_name = newGroupName;
            }
            else
            {
                throw new Exception("You are not the group admin");
            }

            
            return ret;
        }
        /// <summary>
        /// Delete a participant from the group
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="privateKey"></param>
        /// <param name="adminName"></param>
        /// <param name="deleteMembers"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CreateGroupReturn DeleteGroupParticipants(string groupName, string privateKey, string adminName, string [] deleteMembers)
        {
            var ret = new CreateGroupReturn();
            var key = new Key(Config);
            string description = null;
            string[] members = null;
            string Admin = null;
            string GroupKey = null;
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                UserID = "sa",
                Password = "<YourStrong!Passw0rd>",
                InitialCatalog = "master"
            };
            Console.Write("connecting to SQL server...");
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                var sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                sb.Append(
                    "IF EXISTS(Select * from Groups) Begin Select Description,Members,CurrentGroupName,Admin,GroupKey from Groups where Groups.GroupName = '" +
                    groupName + "' End ; ");

                var sql = sb.ToString();
                using (var command = new SqlCommand(sql, connection))
                {
                    var item = command.ExecuteReader();
                    while (item.Read())
                    {
                        description = item[0].ToString();
                        members = item[1].ToString().Replace("\"", "").Trim('[').Trim(']').Split(',');
                        Admin = item[3].ToString();
                        GroupKey = item[4].ToString();
                    }

                    Console.WriteLine("Done.");
                }
            }

            if (adminName == Admin)
            {
                var admin = GetAccount(adminName);
                var newGroupName = SuggestGroupName(description);
                var newGroupKey = CreateRandomKey();

                if (members != null)
                {
                    var membersArray = members.Except(deleteMembers).ToArray();
                    
                    var operationalList = new List<Dictionary<string, GroupMeta>>();
                        
                    foreach (string s in membersArray)
                    {
                        var member = GetAccount(s);
                        var gOp = new GroupOp
                        {
                            type = "add",
                            description = description,
                            new_group_name = newGroupName, 
                            user_list = membersArray,
                            senders_pubkey = admin.Result.account[0].MemoKey
                                
                        };

                        var encryptedKey1 =
                            key.EncryptMemo(newGroupKey, privateKey, member.Result.account[0].MemoKey, new byte[1024]);
                        gOp.new_key = new Dictionary<string, string>
                        {
                            {member.Result.account[0].MemoKey, encryptedKey1}
                        };
                            
                        var messageMeta1 = EncodeAndPack(privateKey, member.Result.account[0].MemoKey, gOp);
                        messageMeta1.recipient = member.Result.account[0].MemoKey;
                        messageMeta1.sender = admin.Result.account[0].Name;

                        operationalList.Add(new Dictionary<string, GroupMeta>
                        {
                            {
                                member.Result.account[0].Name, messageMeta1
                            }

                        });
                    }
                        
                    var gOpUpdate = new GroupOp
                    {
                        type = "update",
                        description = description,
                        new_group_name = groupName, 
                        user_list = membersArray,
                        senders_pubkey = admin.Result.account[0].MemoKey
                                
                    };
                    var encryptedKey2 =
                        key.EncryptMemo(newGroupKey, privateKey, GroupKey, new byte[1024]);
                    gOpUpdate.new_key = new Dictionary<string, string>
                    {
                        {GroupKey, encryptedKey2}
                    };
                        

                    using (var connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        Console.WriteLine("Done");
                        string sql; 
                        // Create a Table and insert some sample data
                        Console.WriteLine(membersArray);
                        var sb = new StringBuilder();
                        sb.Append("USE MpmDB; ");
                        sb.Append("IF EXISTS(Select * from Groups) Begin ");
                        sb.Append(
                            $"UPDATE Groups SET CurrentGroupName = N'" + newGroupName+ "', Members = N'" +
                            JsonConvert.SerializeObject(membersArray) + "', GroupKey =N'" +newGroupKey+"' WHERE GroupName = N'" +groupName+ "' END ");
                            
                        sql = sb.ToString();
                        using (var command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Done.");
                        }
                    }
                    var messageMeta2 = EncodeAndPack(privateKey, GroupKey, gOpUpdate);
                    operationalList.Add(new Dictionary<string, GroupMeta>
                    {
                        {
                            newGroupName, messageMeta2
                        }

                    });
                        

                    ret.operation_payloads = operationalList;
                }
                else
                {
                    ret.operation_payloads = null;
                }
                ret.group_name = newGroupName;
            }
            else
            {
                throw new Exception("You are not the group admin");
            }

           
            return ret;
            
        }
        /// <summary>
        /// Change group description
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="privateKey"></param>
        /// <param name="description"></param>
        /// <param name="adminName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CreateGroupReturn UpdateGroup(string groupName, string privateKey, string description, string adminName)
        {
            var ret = new CreateGroupReturn();
            var key = new Key(Config);
            string[] members = null;
            string Admin = null;
            string GroupKey = null;
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                UserID = "sa",
                Password = "<YourStrong!Passw0rd>",
                InitialCatalog = "master"
            };
            Console.Write("connecting to SQL server...");
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                var sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                sb.Append(
                    "IF EXISTS(Select * from Groups) Begin Select GroupName,Members,CurrentGroupName,Admin,GroupKey from Groups where Groups.GroupName = '" +
                    groupName + "' End ; ");

                var sql = sb.ToString();
                using (var command = new SqlCommand(sql, connection))
                {
                    var item = command.ExecuteReader();
                    while (item.Read())
                    {
                        members = item[1].ToString().Replace("\"", "").Trim('[').Trim(']').Split(',');
                        Admin = item[3].ToString();
                        GroupKey = item[4].ToString();
                    }

                    Console.WriteLine("Done.");
                }
            }

            if (adminName == Admin)
            {
                var admin = GetAccount(adminName);
                var newGroupName = SuggestGroupName(description);
                var newGroupKey = CreateRandomKey();

                    var operationalList = new List<Dictionary<string, GroupMeta>>();
                        
                    
                        
                    var gOpUpdate = new GroupOp
                    {
                        type = "update",
                        description = description,
                        new_group_name = groupName, 
                        user_list = members,
                        senders_pubkey = admin.Result.account[0].MemoKey
                                
                    };
                    var encryptedKey2 =
                        key.EncryptMemo(newGroupKey, privateKey, GroupKey, new byte[1024]);
                    gOpUpdate.new_key = new Dictionary<string, string>
                    {
                        {GroupKey, encryptedKey2}
                    };
                        

                    using (var connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        Console.WriteLine("Done");
                        string sql; 
                        // Create a Table and insert some sample data
                        Console.WriteLine(members);
                        var sb = new StringBuilder();
                        sb.Append("USE MpmDB; ");
                        sb.Append("IF EXISTS(Select * from Groups) Begin ");
                        sb.Append(
                            $"UPDATE Groups SET CurrentGroupName = N'" + newGroupName+ "', Description = N'" +
                            description + "', GroupKey =N'" +newGroupKey+"' WHERE GroupName = N'" +groupName+ "' END ");
                            
                        sql = sb.ToString();
                        using (var command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Done.");
                        }
                    }
                    var messageMeta2 = EncodeAndPack(privateKey, GroupKey, gOpUpdate);
                    messageMeta2.recipient = admin.Result.account[0].MemoKey;
                    messageMeta2.sender = admin.Result.account[0].Name;

                    operationalList.Add(new Dictionary<string, GroupMeta>
                    {
                        {
                            newGroupName, messageMeta2
                        }

                    });
                        

                    ret.operation_payloads = operationalList;
                
                
                ret.group_name = newGroupName;
            }
            else
            {
                throw new Exception("You are not the group admin");
            }

            
            return ret;
        }
        /// <summary>
        /// Disband a group by changing the group name and group key for future security
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="privateKey"></param>
        /// <param name="adminName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CreateGroupReturn DisbandGroup(string groupName, string privateKey, string adminName)
        {
             var ret = new CreateGroupReturn();
            var key = new Key(Config);
            string[] members = null;
            string Admin = null;
            string GroupKey = null;
            string description = null;
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                UserID = "sa",
                Password = "<YourStrong!Passw0rd>",
                InitialCatalog = "master"
            };
            Console.Write("connecting to SQL server...");
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                var sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                sb.Append(
                    "IF EXISTS(Select * from Groups) Begin Select GroupName,Members,CurrentGroupName,Admin,GroupKey from Groups where Groups.GroupName = '" +
                    groupName + "' End ; ");

                var sql = sb.ToString();
                using (var command = new SqlCommand(sql, connection))
                {
                    var item = command.ExecuteReader();
                    while (item.Read())
                    {
                        description = item[0].ToString();
                        members = item[1].ToString().Replace("\"", "").Trim('[').Trim(']').Split(',');
                        Admin = item[3].ToString();
                        GroupKey = item[4].ToString();
                    }

                    Console.WriteLine("Done.");
                }
            }

            if (adminName == Admin)
            {
                var admin = GetAccount(adminName);
                var newGroupName = SuggestGroupName(description);
                var newGroupKey = CreateRandomKey();
               
                    var operationalList = new List<Dictionary<string, GroupMeta>>();
                        
                    
                        
                    var gOpUpdate = new GroupOp
                    {
                        type = "disband",
                        description = description,
                        new_group_name = groupName, 
                        user_list = members,
                        senders_pubkey = admin.Result.account[0].MemoKey
                                
                    };
                    var encryptedKey2 =
                        key.EncryptMemo(newGroupKey, privateKey, GroupKey, new byte[1024]);
                    gOpUpdate.new_key = new Dictionary<string, string>
                    {
                        {GroupKey, encryptedKey2}
                    };
                        

                    using (var connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        Console.WriteLine("Done");
                        string sql; 
                        // Create a Table and insert some sample data
                        Console.WriteLine(members);
                        var sb = new StringBuilder();
                        sb.Append("USE MpmDB; ");
                        sb.Append("IF EXISTS(Select * from Groups) Begin ");
                        sb.Append(
                            $"UPDATE Groups SET CurrentGroupName = N'" + newGroupName+ "', GroupKey =N'" +newGroupKey+"' WHERE GroupName = N'" +groupName+ "' END ");
                            
                        sql = sb.ToString();
                        using (var command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Done.");
                        }
                    }
                    var messageMeta2 = EncodeAndPack(privateKey, GroupKey, gOpUpdate);
                    messageMeta2.recipient = admin.Result.account[0].MemoKey;
                    messageMeta2.sender = admin.Result.account[0].Name;

                    operationalList.Add(new Dictionary<string, GroupMeta>
                    {
                        {
                            newGroupName, messageMeta2
                        }

                    });
                        

                    ret.operation_payloads = operationalList;
                
                
                ret.group_name = newGroupName;
            }
            else
            {
                throw new Exception("You are not the group admin");
            }

            
            return ret;
        }
        /// <summary>
        /// Send encrypted group messages
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="privateKey"></param>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public CreateGroupReturn SendGroupMessages(string groupName, string privateKey, string sender, string data)
        {
            var ret = new CreateGroupReturn();
            string[] members = null;
            string Admin = null;
            string GroupKey = null;
            string description = null;
            string newGroupName = null;
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                UserID = "sa",
                Password = "<YourStrong!Passw0rd>",
                InitialCatalog = "master"
            };
            Console.Write("connecting to SQL server...");
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                var sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                sb.Append(
                    "IF EXISTS(Select * from Groups) Begin Select GroupName,Members,CurrentGroupName,Admin,GroupKey from Groups where Groups.GroupName = '" +
                    groupName + "' End ; ");

                var sql = sb.ToString();
                using (var command = new SqlCommand(sql, connection))
                {
                    var item = command.ExecuteReader();
                    while (item.Read())
                    {
                        newGroupName = item[2].ToString();
                        members = item[1].ToString().Replace("\"", "").Trim('[').Trim(']').Split(',');
                        Admin = item[3].ToString();
                        GroupKey = item[4].ToString();
                    }

                    Console.WriteLine("Done.");
                }
            }
                var admin = GetAccount(sender);
                
                
                    var operationalList = new List<Dictionary<string, GroupMeta>>();

                    var message = new MessageWrapper()
                    {
                        message_data = data,
                        type = MessageWrapper.message_type.message
                        
                    };
                    
                    var encodedMessage = EncodeMessage(privateKey, GroupKey, message);
                    var messageMeta2 = new GroupMeta
                    {
                        recipient = admin.Result.account[0].MemoKey, sender = admin.Result.account[0].Name,data = encodedMessage
                    };

                    operationalList.Add(new Dictionary<string, GroupMeta>
                    {
                        {
                            newGroupName, messageMeta2
                        }

                    });
                        

                    ret.operation_payloads = operationalList;
                
                
                ret.group_name = newGroupName;
                
                using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                string sql; //= "DROP DATABASE IF EXISTS [MpmDB]; CREATE DATABASE [MpmDB]";
//                using (SqlCommand command = new SqlCommand(sql, connection))
//                {
//                    command.ExecuteNonQuery();
//                    Console.WriteLine("Done.");
//                }
                // Create a Table and insert some sample data
               
                var sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                sb.Append("IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Messages') Begin ");
                sb.Append($"INSERT INTO Messages (GroupName, OperationPayloads) VALUES ");
                sb.Append("(N'"+newGroupName+"', N'"+ JsonConvert.SerializeObject(messageMeta2)+"') End ELSE Begin ");
                sb.Append($"CREATE TABLE Messages ( ");
                sb.Append(" Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");
                sb.Append(" GroupName NVARCHAR(50), ");
                sb.Append(" OperationPayloads TEXT ");
                sb.Append("); ");
                sb.Append($"INSERT INTO Messages (GroupName, OperationPayloads) VALUES ");
                
                sb.Append("(N'"+newGroupName+"', N'"+ JsonConvert.SerializeObject(messageMeta2)+"') End");
                
                sql = sb.ToString();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done.");
                }
            }
            
            return ret;
            
        }

        /// <summary>
        /// Get details of a group
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public GetGroupResponse GetGroup(string groupName)
        {
            var getGroupResponse = new GetGroupResponse();
            
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                UserID = "sa",
                Password = "<YourStrong!Passw0rd>",
                InitialCatalog = "master"
            };
            Console.Write("connecting to SQL server...");
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                var sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                sb.Append(
                    "IF EXISTS(Select * from Groups) Begin Select GroupName,Members,CurrentGroupName,Admin,GroupKey,Description,CurrentSeq from Groups where Groups.GroupName = '" +
                    groupName + "' End ; ");

                var sql = sb.ToString();
                using (var command = new SqlCommand(sql, connection))
                {
                    var item = command.ExecuteReader();
                    while (item.Read())
                    {
                        getGroupResponse.GroupName=item[0].ToString();
                        getGroupResponse.CurrentGroupName = item[2].ToString();
                        getGroupResponse.Members = item[1].ToString().Replace("\"", "").Trim('[').Trim(']').Split(',');
                        getGroupResponse.Admin = item[3].ToString();
                        getGroupResponse.GroupKey = item[4].ToString();
                        getGroupResponse.Description=item[5].ToString();
                        getGroupResponse.CurrentSeq=item[6].ToString();
                    }

                    Console.WriteLine("Done.");
                }
            }

            return getGroupResponse;

        }
        /// <summary>
        /// Get name of the group depending on the current name
        /// </summary>
        /// <param name="currentGroupName"></param>
        /// <returns></returns>
        public string GetGroupName(string currentGroupName)
        {
            string getGroupNameResponse =null;
            
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                UserID = "sa",
                Password = "<YourStrong!Passw0rd>",
                InitialCatalog = "master"
            };
            Console.Write("connecting to SQL server...");
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                var sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                sb.Append(
                    "IF EXISTS(Select * from Groups) Begin Select GroupName from Groups where Groups.CurrentGroupName = '" +
                    currentGroupName + "' End ; ");

                var sql = sb.ToString();
                using (var command = new SqlCommand(sql, connection))
                {
                    var item = command.ExecuteReader();
                    while (item.Read())
                    {
                       
                        getGroupNameResponse = item[0].ToString();
                        
                    }

                    Console.WriteLine("Done.");
                }
            }

            return getGroupNameResponse;
        }
        /// <summary>
        /// List all the groups 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public object ListMyGroups(string start,uint count)
        {

            var listMyGroupsResponse = new List<GetGroupResponse>();
            
            
            if (count >= 1000) return JsonConvert.SerializeObject("Count should be less than 1000"); 
            
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                UserID = "sa",
                Password = "<YourStrong!Passw0rd>",
                InitialCatalog = "master"
            };
            Console.Write("connecting to SQL server...");
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                var sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                
                sb.Append(
                    "IF EXISTS(Select * from Groups) Begin Select * from Groups where Groups.Id in " +
                    "(SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY Id ASC) AS rownumber FROM Groups) AS foo WHERE rownumber >= (Select min(Id) from Groups where GroupName= '" + start + "'))  End ; ");

                var sql = sb.ToString();
                
                    using (var command = new SqlCommand(sql, connection))
                    {
                        var item = command.ExecuteReader();
                        while (item.Read())
                        {
                            
                            listMyGroupsResponse.Add(new GetGroupResponse{
                                
                                GroupName = item["GroupName"].ToString(),
                                GroupKey = item["GroupKey"].ToString(),
                                Description = item["Description"].ToString(),
                                Members = item["Members"].ToString().Replace("\"", "").Trim('[').Trim(']').Split(','),
                                Admin = item["Admin"].ToString(),
                                CurrentGroupName = item["CurrentGroupName"].ToString(),
                                CurrentSeq = item["CurrentSeq"].ToString(),
                                
                            });

                        
                        
                        Console.WriteLine("Done.");
                    }
                }

            }

            return listMyGroupsResponse;
        }
        /// <summary>
        /// List all the messages belongs to a user
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public object ListMyMessages(string groupName,string start,uint count)
        {
            
            var listMyMessagesResponse = new List<GetMessagesResponse>();
            
            
            if (count >= 1000) return JsonConvert.SerializeObject("Count should be less than 1000"); 
            
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                UserID = "sa",
                Password = "<YourStrong!Passw0rd>",
                InitialCatalog = "master"
            };
            Console.Write("connecting to SQL server...");
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done");
                var sb = new StringBuilder();
                sb.Append("USE MpmDB; ");
                
                sb.Append(
                    "IF EXISTS(Select * from Messages) Begin Select * from Messages where Messages.Id in " +
                    "(SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY Id ASC) AS rownumber FROM Messages) AS foo WHERE rownumber >= (Select min(Id) from Messages where GroupName= '" + groupName + "'))  End ; ");

                var sql = sb.ToString();
                
                    using (var command = new SqlCommand(sql, connection))
                    {
                        var item = command.ExecuteReader();
                        while (item.Read())
                        {
                            var payloads = JsonConvert.DeserializeObject<GroupMeta>(item["OperationPayloads"].ToString());
                            
                            if(payloads.sender==start){
                            listMyMessagesResponse.Add(new GetMessagesResponse{
                                
                                GroupName = item["GroupName"].ToString(),
                                OperationPayloads = JsonConvert.DeserializeObject<GroupMeta>(item["OperationPayloads"].ToString())
                                
                            });
                            }
                        
                        Console.WriteLine("Done.");
                    }
                }

            }

            return listMyMessagesResponse;
        }
        #endregion
    }
}