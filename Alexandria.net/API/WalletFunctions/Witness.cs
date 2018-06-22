using System;
using System.Collections;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Alexandria.net.Messaging.Responses.DTO;
using Alexandria.net.Settings;

namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    /// <para>
    /// Wallet Witness Functions
    /// </para>
    public class Witness : RpcConnection
    {   private readonly ILogger _logger;

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public Witness(IConfig config) :
            base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(LoggingType.Server, assemblyname);
        }

        /// <summary>
        /// Returns the list of witnesses producing blocks in the current round (21 Blocks)
        /// </summary>
        /// <returns>Returns json object combining list of active witnesses 
        /// </returns>
        public ActiveWitnessResponse GetActiveWitnesses()
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);  
                var result = SendRequest(reqname);
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
        /// <returns></returns>
        private string GetMinerQueue()
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);  
                return SendRequest(reqname);
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Returns information about the given witness.
        /// @param owner_account the name or id of the witness account owner, or the id of the witness
       /// @returns the information about the witness stored in the block chain
         
        /// </summary>
        /// <param name="ownerAccount">the name Or id Of the witness account owner, Or the id of the witness</param>
        /// <returns>the information about the witness stored In the block chain</returns>
        public GetWitnessResponse GetWitness(string ownerAccount)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);  
                var @params = new ArrayList {ownerAccount};
                var result= SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<GetWitnessResponse>(result);
                return contentdata;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
       /// Lists all witnesses registered in the blockchain.
       /// This returns a list of all account names that own witnesses, and the associated witness id,
      /// sorted by name.  This lists witnesses whether they are currently voted in or not.
       ///
       /// Use the \c lowerbound and limit parameters to page through the list.  To retrieve all witnesss,
       /// start by setting \c lowerbound to the empty string \c "", and then each iteration, pass
       /// the last witness name returned as the \c lowerbound for the next \c list_witnesss() call.
       ///
       /// @param lowerbound the name of the first witness to return.  If the named witness does not exist,
       ///                   the list will start at the witness that comes after \c lowerbound
       /// @param limit the maximum number of witnesss to return (max: 1000)
       /// @returns a list of witnesss mapping witness names to witness ids
       
        /// </summary>
        /// <param name="lowerbound">the name Of the first witness To Return.
        /// If the named witness does Not exist, the list will start at the witness thatcomes after 'lowerbound'</param>
        /// <param name="limit">the maximum number Of witnesss To return (max: 1000)</param>
        /// <returns>Returns a list Of witnesss mapping witness names To witness ids</returns>
        public ActiveWitnessResponse ListWitnesses(string lowerbound, uint limit)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);  
                var @params = new ArrayList {lowerbound, limit};
                var result= SendRequest(reqname, @params);
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
        /// Update a witness Object owned by the given account.
        /// </summary>
        /// <param name="witnessName">The name Of the witness's owner account.
        /// Also accepts the ID of the owner account Or the ID of the witness.</param>
        /// <param name="url">Same as for create_witness. The empty string makes it remain the same.</param>
        /// <param name="blockSigningKey">The New block signing public key. The empty string makes it remain the same.</param>
        /// <param name="props">The chain properties the witness Is voting On. </param>
        /// <returns></returns>
        public string UpdateWitness(string witnessName, string url, string blockSigningKey, JArray props)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);  
                var @params = new ArrayList {witnessName, url, blockSigningKey, props};
                return SendRequest(reqname, @params);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
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
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);  
                var @params = new ArrayList {voter, author, permlink, weight};
                return SendRequest(reqname, @params);
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
        public AccountResponse VoteForWitness(string accountToVoteWith, string witnessToVoteFor, bool approve)
        {
            var trans = new Transaction(Config);
            var key = new Key(Config);
            var pk = "5KGL7MNAfwCzQ8DAq7DXJsneXagka3KNcjgkRayJoeJUucSLkev";
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);      
                var @params = new ArrayList {accountToVoteWith, witnessToVoteFor, approve};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                BroadCastTransactionProcess newProcess = new BroadCastTransactionProcess(Config);
                
                var response = newProcess.StartBroadcasting(contentdata);
                
                return response == null ? null : contentdata;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }   
        }

    }
}