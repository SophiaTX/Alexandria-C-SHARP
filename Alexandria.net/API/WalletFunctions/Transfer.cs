using System.Collections;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.API.WalletFunctions
{
    public partial class Wallet //Transfer
    {
        //    Transfer funds from one account To another. STEEM And SBD can be
		//    transferred.
		//
		//    Parameters:
		//         from: The account the funds are coming from 
		//        to: The account the funds are going To 
		//        amount: The funds being transferred. i.e. "100.000 STEEM" 
		//        memo: A memo For the transactionm, encrypted With the To account's
		//        Public memo key 
		//        broadcast: true if you wish to broadcast the transaction (type: bool)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <param name="amount"></param>
		/// <param name="memo"></param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string Transfer(string from, string to, decimal amount, string memo, bool broadcast = true)
		{
			var @params = new ArrayList {@from, to, amount, memo, broadcast};
			return call_api(MethodBase.GetCurrentMethod().Name, @params);
		}

		//    Transfer STEEM into a vesting fund represented by vesting shares (VESTS).
		//    VESTS are required To vesting For a minimum Of one coin year And can be
		//    withdrawn once a week over a two year withdraw period. VESTS are Protected
		//    against dilution up until 90% Of STEEM Is vesting.
		//
		//    Parameters:
		//         from: The account the STEEM Is coming from 
		//        to: The account getting the VESTS 
		//        amount: The amount Of STEEM To vest i.e. "100.00 STEEM" 
		//        broadcast: true if you wish to broadcast the transaction (type: bool)

		/// <summary>
		/// 
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <param name="amount"></param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string transfer_to_vesting(string from, string to, decimal amount, bool broadcast = true)
		{
			var @params = new ArrayList {@from, to, amount, broadcast};
			return call_api(MethodBase.GetCurrentMethod().Name, @params);
		}

		// Transfers into savings happen immediately, transfers from savings take 72 hours
		//
		/// <summary>
		/// 
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <param name="amount"></param>
		/// <param name="memo"></param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string transfer_to_savings(string from, string to, string amount, string memo, bool broadcast = false)
		{
			var @params = new ArrayList {@from, to, amount, broadcast};
			return call_api(MethodBase.GetCurrentMethod().Name, @params);
		}


		// @param request_id - an unique ID assigned by from account, the id is used to cancel the operation and can be reused after the transfer completes
		//
		/// <summary>
		/// 
		/// </summary>
		/// <param name="from"></param>
		/// <param name="requestId"></param>
		/// <param name="to"></param>
		/// <param name="amount"></param>
		/// <param name="memo"></param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string transfer_from_savings(string from, uint requestId, string to, string amount, string memo,
			bool broadcast = false)
		{
			var @params = new ArrayList {@from, requestId, to, amount, memo, broadcast};
			return call_api(MethodBase.GetCurrentMethod().Name, @params);
		}

		// @param request_id the id used in transfer_from_savings
		// @param from the account that initiated the transfer
		//
		/// <summary>
		/// 
		/// </summary>
		/// <param name="from"></param>
		/// <param name="requestId"></param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string cancel_transfer_from_savings(string from, uint requestId, bool broadcast = false)
		{
			var @params = new ArrayList {@from, requestId, broadcast};
			return call_api(MethodBase.GetCurrentMethod().Name, @params);
		}
    }
}