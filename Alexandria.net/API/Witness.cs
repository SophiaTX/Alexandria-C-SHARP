using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Messaging;
using Alexandria.net.Messaging.Receiver;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.API
{
    /// <inheritdoc />
    /// <para>
    /// Sophia Blockchain Witness functions
    /// </para>
    public class Witness : RpcConnection
    {
        #region Member Variables
        private readonly ILogger _logger;
        #endregion
        
        #region Constructor
        /// <inheritdoc />
        /// <summary>
        /// Witness constructor
        /// </summary>
        /// <param name="config">the Configuration parameters for the endpoint and ports</param>
        public Witness(IConfig config) :
            base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(config, assemblyname);
        }
        #endregion
        
        #region Methods

        /// <summary>
        /// Returns the list of witnesses producing blocks in the current round (21 Blocks)
        /// </summary>
        /// <returns>Returns json object combining list of active witnesses</returns>
        public ActiveWitnessResponse GetActiveWitnesses()
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            var @params = new object();
            var result = SendRequestToDaemon(reqname,@params);
            var contentdata = JsonConvert.DeserializeObject<ActiveWitnessResponse>(result);
            return contentdata;
        }

        /// <summary>
        /// Returns information about the given witness.
        /// </summary>
        /// <param name="ownerAccount">the name Or id Of the witness account owner, Or the id of the witness</param>
        /// <returns>the information about the witness stored In the block chain</returns>
        public GetWitnessResponse GetWitness(string ownerAccount)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, ownerAccount);
            //var @params = new ArrayList {ownerAccount};
            var result = SendRequestToDaemon(reqname, @params);
            var contentdata = JsonConvert.DeserializeObject<GetWitnessResponse>(result);
            return contentdata;
        }

        /// <summary>
        /// Lists all witnesses registered in the blockchain.
        /// This returns a list of all account names that own witnesses, and the associated witness id,
        /// sorted by name.  This lists witnesses whether they are currently voted in or not.
        /// </summary>
        /// <param name="lowerbound">the name Of the first witness To Return.
        /// If the named witness does Not exist, the list will start at the witness thatcomes after 'lowerbound'</param>
        /// <param name="limit">the maximum number Of witnesss To return (max: 1000)</param>
        /// <returns>Returns a list of witnesss mapping witness names To witness ids</returns>
        public ActiveWitnessResponse ListWitnesses(string lowerbound, uint limit)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, lowerbound, limit);
            //var @params = new ArrayList {lowerbound, limit};
            var result = SendRequestToDaemon(reqname, @params);
            var contentdata = JsonConvert.DeserializeObject<ActiveWitnessResponse>(result);
            return contentdata;
        }


        /// <summary>
        /// Vote on a comment to be paid Sophia
        /// </summary>
        /// <param name="voter">The account voting</param>
        /// <param name="author">The author Of the comment To be voted On</param>
        /// <param name="permlink">The permlink Of the comment To be voted On. (author, permlink) Is a unique pair</param>
        /// <param name="weight">The weight [-100,100] Of the vote</param>
        /// <returns>the vote response data</returns>
        public string Vote(string voter, string author, string permlink, short weight)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, voter, author, permlink, weight);
            //var @params = new ArrayList {voter, author, permlink, weight};
            return SendRequestToDaemon(reqname, @params);
        }

        /// <summary>
        /// Vote for a witness to become a block producer. By default an account has not voted positively Or negatively for a witness.
        /// The account can either vote for with positively votes Or against with negative votes.
        /// The vote will remain until updated With another vote. Vote strength Is determined by the accounts vesting shares.
        /// </summary>
        /// <param name="accountToVoteWith">The account voting For a witness</param>
        /// <param name="witnessToVoteFor">The witness that Is being voted For</param>
        /// <param name="approve">true if the account Is voting for the account to be able to be a block produce</param>
        /// <param name="privateKey"></param>
        /// <returns>the transacxtion response data</returns>
        public TransactionResponse VoteForWitness(string accountToVoteWith, string witnessToVoteFor, bool approve,
            string privateKey)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountToVoteWith, witnessToVoteFor,
                approve);
            //var @params = new ArrayList {accountToVoteWith, witnessToVoteFor, approve};
            var result = SendRequestToDaemon(reqname, @params);
            var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);

            var response = StartBroadcasting(contentdata.Result, privateKey);
            return response;
        }

        /// <summary>
        /// Update an account to witness.Requires 250,000 vested SPHTX before updating.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <param name="descriptionUrl">A URL containing some information about the witness.  The empty string makes it remain the same.</param>
        /// <param name="blockSigningKey">The new block signing public key.  The empty string disables block production.</param>
        /// <param name="accountCreationPrice"></param>
        /// <param name="maxBlockSizeLimit"></param>
        /// <param name="priceFeed"></param>
        /// <param name="privateKey"></param>
        /// <returns>Returns true if success or false for failed try</returns>
        public TransactionResponse UpdateWitness(string accountName, string descriptionUrl, string blockSigningKey,
            string accountCreationPrice, int maxBlockSizeLimit, List<List<PrizeFeedQuoteMessage>> priceFeed,
            string privateKey)
        {
            var pros = new ChainProperties
            {
                AccountCreationFee = accountCreationPrice,
                MaximumBlockSize = maxBlockSizeLimit,
                PriceFeeds = priceFeed
            };

            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountName, descriptionUrl,
                blockSigningKey, pros);
            //var @params = new ArrayList {accountName, descriptionUrl, blockSigningKey, pros};
            var result = SendRequestToDaemon(reqname, @params, typeof(PrizeFeedQuoteMessage));
            var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);

            var response = StartBroadcasting(contentdata.Result, privateKey);
            return response;
        }

        #endregion
    }
}