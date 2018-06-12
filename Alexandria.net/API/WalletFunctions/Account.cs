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
		/// This method will genrate New owner, active, and memo keys For the New account which will be controlable by this wallet.
		/// There Is a fee associated With account creation that Is paid by the creator.
		/// The current account creation fee can be found With the 'info' wallet command.
		/// </summary>
		/// <param name="creator">The account creating the New account </param>
		/// <param name="newAccountName">The name Of the New account </param>
		/// <param name="jsonMeta">JSON Metadata associated With the New account </param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string create_account(string creator, string newAccountName, string jsonMeta, bool broadcast = true)
		{
			var @params = new ArrayList {creator, newAccountName, jsonMeta, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// This method Is used by faucets To create New accounts For other users which must provide their desired keys.
		/// The resulting account may Not be controllable by this wallet. There Is a fee associated With account
		/// creation that Is paid by the creator. The current account creation fee can be found With the 'info' wallet command.
		/// </summary>
		/// <param name="creator">The account creating the New account</param>
		/// <param name="newname">The name Of the New account</param>
		/// <param name="jsonMeta">JSON Metadata associated With the New account owner</param>
		/// <param name="owner">Public owner key Of the New account </param>
		/// <param name="active">Public active key Of the New account</param>
		/// <param name="posting">Public posting key Of the New account</param>
		/// <param name="memo">Public memo key Of the New account</param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string create_account_with_keys(string creator, string newname, string jsonMeta, string owner, string active,
			string posting, string memo, bool broadcast = true)
		{
			var @params = new ArrayList {creator, newname, jsonMeta, owner, active, posting, memo, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}
	    
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
	    public ListAccountsResponse list_accounts(string lowerbound = "", uint limit = 1000)
	    {
		    var @params = new ArrayList {lowerbound, limit};
		    var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		    
		    var contentdata = JsonConvert.DeserializeObject<ListAccountsResponse>(result);
		    return contentdata;
	    }

	    /// <summary>
	    /// Gets the account information For all accounts For which this wallet has aPrivate key
	    /// </summary>
	    /// <returns>the account information</returns>
	    public string list_my_accounts()
	    {
		    return SendRequest(MethodBase.GetCurrentMethod().Name);
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
		/// update_account_auth_key(string account_name, authority_type type, public_key_type key, weight_type weight, bool broadcast)
		/// This method updates the key Of an authority For an exisiting account.
		/// Warning: You can create impossible authorities Using this method. The method will fail If you create an impossible owner authority, but will
		/// allow impossible active And posting authorities.
		/// </summary>
		/// <param name="accountName">The name Of the account whose authority you wish To update</param>
		/// <param name="type">The authority type. e.g. owner, active, Or posting</param>
		/// <param name="authAccount">The Public key To add To the authority</param>
		/// <param name="weight">The weight the key should have In the authority. A weight Of 0 indicates the removal Of the key.</param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string update_account_auth_account(string accountName, string type, string authAccount, ushort weight,
			bool broadcast = true)
		{
			var @params = new ArrayList {accountName, type, authAccount, weight, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="accountName"></param>
		/// <param name="type"></param>
		/// <param name="key"></param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string update_account_auth_key(string accountName, string type, string key, bool broadcast = true)
		{
			var @params = new ArrayList {accountName, type, key, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// This method updates the weight threshold Of an authority For an account. Warning: You can create impossible authorities Using this method As well As
		/// implicitly met authorities. The method will fail If you create an implicitly true authority And if you create an impossible owner authority,
		/// but will allow impossible active And posting authorities.
		/// </summary>
		/// <param name="accountName">The name Of the account whose authority you wish to update </param>
		/// <param name="type">The authority type. e.g. owner, active, Or posting</param>
		/// <param name="threshold">The weight threshold required For the authority To be met</param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string update_account_auth_threshold(string accountName, string type, uint threshold,
			bool broadcast = true)
		{
			var @params = new ArrayList {accountName, type, threshold, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// This method updates the memo key Of an account
		/// </summary>
		/// <param name="accountName">The name Of the account you wish To update </param>
		/// <param name="key">The New memo public key </param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string update_account_memo_key(string accountName, string key, bool broadcast = true)
		{
			var @params = new ArrayList {accountName, key, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}
		
		/// <summary>
		/// This method updates the account JSON metadata 
		/// </summary>
		/// <param name="accountName">The name Of the account you wish To update </param>
		/// <param name="jsonMeta">The New JSON metadata for the account. This overrides existing metadata</param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string update_account_meta(string accountName, string jsonMeta, bool broadcast = true)
		{
			var @params = new ArrayList {accountName, jsonMeta, broadcast};
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