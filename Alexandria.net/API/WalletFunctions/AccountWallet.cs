using System.Collections;
using System.Reflection;
using Alexandria.net.Messaging.Responses.DTO;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    public partial class Wallet // account
    {
	    #region Methods
	    
       
	    /// <summary>
	    /// Returns information about the given account.
	    /// </summary>
	    /// <param name="accountName">the name Of the account To provide information about </param>
	    /// <returns>the Public account data stored In the blockchain</returns>
	    public string get_account(string accountName)
	    {
		    var @params = new ArrayList {accountName};

		    return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
	    }

	    /// <summary>
	    /// Account operations have sequence numbers from 0 To N where N Is the most recent operation.
	    /// This method returns operations In the range [from-limit,from]
	    /// </summary>
	    /// <param name="account">account whose history will be returned </param>
	    /// <param name="from">the absolute sequence number, -1 means most recent, limit Is the number Of operations before from. </param>
	    /// <param name="limit">the maximum number of items that can be queried (0 to 1000], must be less than from</param>
	    /// <returns></returns>
	    public AccountHistoryResponse get_account_history(string account, uint from, uint limit)
	    {
		    var @params = new ArrayList {account, @from, limit};
		    var result= SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		    var contentdata = JsonConvert.DeserializeObject<AccountHistoryResponse>(result);
		    return contentdata;
	    }

	    /// <summary>
	    /// Lists all accounts registered In the blockchain. This returns a list Of all account names And their account ids, sorted by account name.
	    /// Use the 'lowerbound' and limit parameters to page through the list. To retrieve all accounts, start by setting 'lowerbound' to the
	    /// empty string '""', and then each iteration, pass the last account name returned as the 'lowerbound' for the next 'list_accounts()' call.
	    /// </summary>
	    /// <param name="lowerbound">the name Of the first account To Return. If the named account does Not exist, the list will start at the account that comes after 'lowerbound' </param>
	    /// <param name="limit">the maximum number Of accounts To return (max: 1000) </param>
	    /// <returns>a list Of accounts mapping account names To account ids</returns>
	    private ListAccountsResponse list_accounts(string lowerbound = "", uint limit = 1000)
	    {
		    var @params = new ArrayList {lowerbound, limit};
		    var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		    
		    var contentdata = JsonConvert.DeserializeObject<ListAccountsResponse>(result);
		    return contentdata;
	    }

	   
	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="accountToRecover"></param>
	    /// <param name="recentAuthority"></param>
	    /// <param name="newAuthority"></param>
	    /// <param name="broadcast">true if you wish to broadcast the transaction.</param>
	    /// <returns></returns>
	    public string recover_account(string accountToRecover, Hashtable recentAuthority, Hashtable newAuthority,
		    bool broadcast = true)
	    {
		    var @params = new ArrayList {accountToRecover, recentAuthority, newAuthority, broadcast};
		    return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
	    }

	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="recoveryAccount"></param>
	    /// <param name="accountToRecover"></param>
	    /// <param name="newAuthority"></param>
	    /// <param name="broadcast">true if you wish to broadcast the transaction.</param>
	    /// <returns></returns>
	    public string request_account_recovery(string recoveryAccount, string accountToRecover, Hashtable newAuthority,
		    bool broadcast = true)
	    {
		    var @params = new ArrayList {recoveryAccount, accountToRecover, newAuthority, broadcast};
		    return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
	    }
	    
		/// <summary>
		/// This method updates the keys Of an existing account.
		/// </summary>
		/// <param name="accountname">The name Of the account </param>
		/// <param name="jsonMeta">New JSON Metadata to be associated with the account</param>
		/// <param name="owner">New public owner key for the account </param>
		/// <param name="active">New public active key for the account </param>
		/// <param name="posting">New public posting key for the account </param>
		/// <param name="memo">New public memo key for the account</param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string update_account(string accountname, string jsonMeta, string owner, string active, string posting,
			string memo, bool broadcast = true)
		{
			var @params = new ArrayList {accountname, jsonMeta, owner, active, memo, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		
	    
	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="owner"></param>
	    /// <param name="newRecoveryAccount"></param>
	    /// <param name="broadcast">true if you wish to broadcast the transaction.</param>
	    /// <returns></returns>
	    public LockUnlockResponse change_recovery_account(string owner, string newRecoveryAccount, bool broadcast = true)
	    {
		    var @params = new ArrayList {owner, newRecoveryAccount, broadcast};
		    var result= SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		    var contentdata = JsonConvert.DeserializeObject<LockUnlockResponse>(result);
		    return contentdata;
	    }
	    #endregion
    }
}