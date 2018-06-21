using System;
using System.Collections;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Settings;

namespace Alexandria.net.Core
{
	/// <summary>
	/// Daemon implementation
	/// </summary>
	/// <inheritdoc cref="RpcConnection"/>
	public class Daemon : RpcConnection
	{
		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="config"></param>
		public Daemon(IConfig config) :
			base(config)
		{
		}

		#endregion

		#region public Methods
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string get_config()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string get_dynamic_global_properties()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name);
		}
		/// <summary>
		/// 	
		/// </summary>
		/// <returns></returns>
		public string get_chain_properties()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string get_current_median_history_price()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>

		public string get_feed_history()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string get_witness_schedule()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string get_hardfork_version()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string get_next_scheduled_hardfork()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="accounts"></param>
		/// <returns></returns>
		public string get_accounts(ArrayList accounts)
		{
			var arrParams = new ArrayList {accounts};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="accounts"></param>
		/// <returns></returns>
		public string lookup_account_names(ArrayList accounts)
		{
			var arrParams = new ArrayList {accounts};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lowerbound"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		public string lookup_accounts(string lowerbound, uint limit)
		{
			var arrParams = new ArrayList {lowerbound, limit};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string get_account_count()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public string get_owner_history(string account)
		{
			var arrParams = new ArrayList {account};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public string get_recovery_request(string account)
		{
			var arrParams = new ArrayList {account};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="blockId"></param>
		/// <returns></returns>
		public string get_block_header(long blockId)
		{
			var arrParams = new ArrayList {blockId};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="blockId"></param>
		/// <returns></returns>
		public string get_block(long blockId)
		{
			var arrParams = new ArrayList {blockId};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="witnesses"></param>
		/// <returns></returns>
		public string get_witnesses(ArrayList witnesses)
		{
			var arrParams = new ArrayList {witnesses};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public string get_conversion_requests(string account)
		{
			var arrParams = new ArrayList {account};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public string get_witness_by_account(string account)
		{
			var arrParams = new ArrayList {account};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="from"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		public string get_witnesses_by_vote(string from, int limit)
		{
			var arrParams = new ArrayList {from, limit};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string get_witness_count()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name);
		}
		
		// if permlink Is "" then it will return all votes for author
		/// <summary>
		/// 
		/// </summary>
		/// <param name="author"></param>
		/// <param name="permlink"></param>
		/// <returns></returns>
		public string get_active_votes(string author, string permlink)
		{
			var arrParams = new ArrayList {author, permlink};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="author"></param>
		/// <param name="permlink"></param>
		/// <returns></returns>
		public string get_content(string author, string permlink)
		{
			var arrParams = new ArrayList {author, permlink};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="parentPermlink"></param>
		/// <returns></returns>
		public string get_content_replies(string parent, string parentPermlink)
		{
			var arrParams = new ArrayList {parent, parentPermlink};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		//  return the active discussions with the highest cumulative pending payouts without respect to category, total
		//  pending payout means the pending payout of all children as well.
		/// <summary>
		/// 
		/// </summary>
		/// <param name="startAuthor"></param>
		/// <param name="startPermlink"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		public string get_replies_by_last_update(string startAuthor, string startPermlink, uint limit)
		{
			var arrParams = new ArrayList {startAuthor, startPermlink, limit};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		// This method Is used to fetch all posts/comments by start_author that occur after before_date And start_permlink with up to limit being returned.
		//
		// If start_permlink Is empty then only before_date will be considered. If both are specified the eariler to the two metrics will be used. This
		// should allow easy pagination.
		/// <summary>
		/// 
		/// </summary>
		/// <param name="author"></param>
		/// <param name="startPermlink"></param>
		/// <param name="beforeDate"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		public string get_discussions_by_author_before_date(string author, string startPermlink, DateTime beforeDate,
			uint limit)
		{
			var arrParams = new ArrayList {author, startPermlink, beforeDate, limit};
			return SendRequest(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		// Account operations have sequence numbers from 0 to N where N Is the most recent operation. This method
		// returns operations in the range [from-limit, from]
		//
		// from - the absolute sequence number, -1 means most recent, limit Is the number of operations before from.
		// limit - the maximum number of items that can be queried (0 to 1000], must be less than from
		/// <summary>
		/// 
		/// </summary>
		/// <param name="account"></param>
		/// <param name="from"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		public string get_account_history(string account, ulong from, uint limit)
		{
			var @params = new ArrayList {account, from, limit};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		#endregion
	}
}