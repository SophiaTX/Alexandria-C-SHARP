using System.Collections;
using System.Reflection;

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
			return SendRequest(MethodBase.GetCurrentMethod().Name.ToLower(), @params);
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
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		
		

		
    }
}