using System;
using System.Collections;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Mapping;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Alexandria.net.Messaging.Responses.DTO;

namespace Alexandria.net.API.WalletFunctions
{
    public class Witness : RpcConnection
    {   private readonly ILogger _logger;
        /// <summary>
        /// Connects Witness with default values, the runtime values inherited from base class
        /// </summary>
        /// <param name="hostname">string hostname = "127.0.0.1"</param>
        /// <param name="port">ushort port = 8091</param>
        /// <param name="api">string api = "/rpc"</param>
        /// <param name="version">string version = "2.0"</param>
        public Witness(string hostname = "127.0.0.1", ushort port = 8091, string api = "/rpc", string version = "2.0") :
            base(hostname, port, api, version)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(loggingType.server, assemblyname);
        }

        /// <summary>
        /// Returns the list Of witnesses producing blocks In the current round 
        /// </summary>
        /// <returns>Returns json object combining list of active witnesses 
        /// </returns>
        public ActiveWitnessResponse get_active_witnesses()
        {
            try
            {
                var result = SendRequest(MethodBase.GetCurrentMethod().Name);
                var contentdata = JsonConvert.DeserializeObject<ActiveWitnessResponse>(result);
                return contentdata;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Returns the queue Of pow miners waiting To produce blocks.
        /// </summary>
        /// <returns>...</returns>
        public string get_miner_queue()
        {
            try
            {
                return SendRequest(MethodBase.GetCurrentMethod().Name);
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Returns information about the given witness.
        /// </summary>
        /// <param name="ownerAccount">the name Or id Of the witness account owner, Or the id of the witness</param>
        /// <returns>the information about the witness stored In the block chain</returns>
        public string get_witness(string ownerAccount)
        {
            try
            {
                var @params = new ArrayList {ownerAccount};
                return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Lists all witnesses registered In the blockchain. This returns a list Of
        /// all account names that own witnesses, And the associated witness id, sorted
        /// by name. This lists witnesses whether they are currently voted In Or Not.
        /// Use the 'lowerbound' and limit parameters to page through the list. To
        /// retrieve all witnesss, start by setting 'lowerbound' to the empty string
        /// '""', and then each iteration, pass the last witness name returned as the
        /// 'lowerbound' for the next 'list_witnesss()' call.
        /// </summary>
        /// <param name="lowerbound">the name Of the first witness To Return.
        /// If the named witness does Not exist, the list will start at the witness thatcomes after 'lowerbound'</param>
        /// <param name="limit">the maximum number Of witnesss To return (max: 1000)</param>
        /// <returns>Returns a list Of witnesss mapping witness names To witness ids</returns>
        public string list_witnesses(string lowerbound, uint limit)
        {
            try
            {
                var @params = new ArrayList {lowerbound, limit};
                return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Update a witness Object owned by the given account.
        /// </summary>
        /// <param name="witnessName">The name Of the witness's owner account.
        /// Also accepts the ID of the owner account Or the ID of the witness.</param>
        /// <param name="url">Same as for create_witness. The empty string makes it remain the same.</param>
        /// <param name="blockSigningKey">The New block signing public key. The empty string makes it remain the same.</param>
        /// <param name="props">The chain properties the witness Is voting On. </param>
        /// <returns></returns>
        public string update_witness(string witnessName, string url, string blockSigningKey, JArray props)
        {
            try
            {
                var @params = new ArrayList {witnessName, url, blockSigningKey, props};
                return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            }
            catch(Exception ex)
            {
                
                throw;
            }
           
        }

        /// <summary>
        /// Vote on a comment to be paid Sophia
        /// </summary>
        /// <param name="voter">The account voting</param>
        /// <param name="author">The author Of the comment To be voted On</param>
        /// <param name="permlink">The permlink Of the comment To be voted On. (author, permlink) Is a unique pair</param>
        /// <param name="weight">The weight [-100,100] Of the vote</param>
        /// <returns></returns>
        public string Vote(string voter, string author, string permlink, short weight)
        {
            try
            {
                var @params = new ArrayList {voter, author, permlink, weight};
                return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
           
        }

        /// <summary>
        /// Vote for a witness to become a block producer. By default an account has not voted positively Or negatively for a witness.
        /// The account can either vote for with positively votes Or against with negative votes.
        /// The vote will remain until updated With another vote. Vote strength Is determined by the accounts vesting shares.
        /// </summary>
        /// <param name="accountToVoteWith">The account voting For a witness</param>
        /// <param name="witnessToVoteFor">The witness that Is being voted For</param>
        /// <param name="approve">true if the account Is voting for the account to be able to be a block produce</param>
        /// <returns></returns>
        public ActiveWitnessResponse Vote(string accountToVoteWith, string witnessToVoteFor, bool approve)
        {
<<<<<<< HEAD
            var reqname = _cSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            var @params = new ArrayList {accountToVoteWith, witnessToVoteFor, approve};
            var result = SendRequest(reqname, @params);
            var contentdata = JsonConvert.DeserializeObject<ActiveWitnessResponse>(result);
            return contentdata;
        }
=======
            try
            {
                var reqname = _cSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            
                var @params = new ArrayList {accountToVoteWith, witnessToVoteFor, approve};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<ActiveWitnessResponse>(result);
                return contentdata;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
            
        }
        
        /// <summary>
        /// C#toCPP object generated to map the method names according to C# naming conventions
        /// </summary>
        private CSharpToCPP _cSharpToCpp = new CSharpToCPP();
>>>>>>> 77b65a5ef8f1b972701c625c4cf00746cb880c0e
    }
}