using System.Collections;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.API
{
    public partial class Wallet // Witness
    {
        /// <summary>
        /// Returns the list Of witnesses producing blocks In the current round (21 Blocks)
        /// </summary>
        /// <returns></returns>
        public JArray get_active_witnesses()
        {
            return call_api_array(MethodBase.GetCurrentMethod().Name);
        }
        
        //Returns the queue Of pow miners waiting To produce blocks.
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JArray get_miner_queue()
        {
            return call_api_array(MethodBase.GetCurrentMethod().Name);
        }
        
        //    Returns information about the given witness.
        //
        //    Parameters:
        //        owner_account: the name Or id Of the witness account owner, Or the id of the witness 
        //
        //    Returns
        //        the information about the witness stored In the block chain
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerAccount"></param>
        /// <returns></returns>
        public JObject get_witness(string ownerAccount)
        {
            var @params = new ArrayList {ownerAccount};
            return call_api(MethodBase.GetCurrentMethod().Name, @params);
        }
        
        //    Lists all witnesses registered In the blockchain. This returns a list Of
        //    all account names that own witnesses, And the associated witness id, sorted
        //    by name. This lists witnesses whether they are currently voted In Or Not.
        //
        //    Use the 'lowerbound' and limit parameters to page through the list. To
        //    retrieve all witnesss, start by setting 'lowerbound' to the empty string
        //    '""', and then each iteration, pass the last witness name returned as the
        //    'lowerbound' for the next 'list_witnesss()' call.
        //
        //    Parameters:
        //         lowerbound: the name Of the first witness To Return. If the named
        //        witness does Not exist, the list will start at the witness that
        //        comes after 'lowerbound' (type: const string &)
        //         limit: the maximum number Of witnesss To return (max: 1000) 
        //
        //    Returns
        //        a list Of witnesss mapping witness names To witness ids
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowerbound"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public JArray list_witnesses(string lowerbound, uint limit)
        {
            var @params = new ArrayList {lowerbound, limit};
            return call_api_array(MethodBase.GetCurrentMethod().Name, @params);
        }
        
        /// <summary>
        /// Update a witness Object owned by the given account.
        /// </summary>
        /// <param name="witnessName">The name Of the witness's owner account.Also accepts the ID of the owner account Or the ID of the witness.</param>
        /// <param name="url">Same as for create_witness. The empty string makes it remain the same.</param>
        /// <param name="blockSigningKey">The New block signing public key. The empty string makes it remain the same.</param>
        /// <param name="props">The chain properties the witness Is voting On. </param>
        /// <param name="broadcast">true if you wish to broadcast the transaction.</param>
        /// <returns></returns>
        public JObject update_witness(string witnessName, string url, string blockSigningKey, JArray props,
            bool broadcast = true)
        {
            var @params = new ArrayList {witnessName, url, blockSigningKey, props, broadcast};
            return call_api(MethodBase.GetCurrentMethod().Name, @params);
        }
        
        /// <summary>
        /// Vote on a comment to be paid Sophia
        /// </summary>
        /// <param name="voter">The account voting</param>
        /// <param name="author">The author Of the comment To be voted On</param>
        /// <param name="permlink">The permlink Of the comment To be voted On. (author, permlink) Is a unique pair</param>
        /// <param name="weight">The weight [-100,100] Of the vote</param>
        /// <param name="broadcast">true if you wish to broadcast the transaction</param>
        /// <returns></returns>
        public JObject Vote(string voter, string author, string permlink, short weight, bool broadcast = true)
        {
            var @params = new ArrayList {voter, author, permlink, weight, broadcast};
            return call_api(MethodBase.GetCurrentMethod().Name, @params);
        }

        /// <summary>
        /// Vote for a witness to become a block producer. By default an account has not voted positively Or negatively for a witness.
        /// The account can either vote for with positively votes Or against with negative votes.
        /// The vote will remain until updated With another vote. Vote strength Is determined by the accounts vesting shares.
        /// </summary>
        /// <param name="accountToVoteWith">The account voting For a witness</param>
        /// <param name="witnessToVoteFor">The witness that Is being voted For</param>
        /// <param name="approve">true if the account Is voting for the account to be able to be a block produce</param>
        /// <param name="broadcast">true if you wish to broadcast the transaction </param>
        /// <returns></returns>
        public JObject vote_for_witness(string accountToVoteWith, string witnessToVoteFor, bool approve,
            bool broadcast = true)
        {
            var @params = new ArrayList {accountToVoteWith, witnessToVoteFor, approve, broadcast};
            return call_api(MethodBase.GetCurrentMethod().Name, @params);
        }

    }
}