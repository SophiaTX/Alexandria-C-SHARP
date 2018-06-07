using System;
using System.Collections;
using System.Reflection;
using Alexandria.net.API;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.Core
{
	public sealed class Daemon : SphTxApi
	{
		#region Constructors

		public Daemon(string hostname = "127.0.0.1", ushort port = 8090) : base(hostname, port)
		{
		}

		public Daemon(string uri) : base(uri)
		{
		}

		#endregion

		#region public Methods

		public JObject get_config()
		{
			return call_api(MethodBase.GetCurrentMethod().Name);
		}

		public JObject get_dynamic_global_properties()
		{
			return call_api(MethodBase.GetCurrentMethod().Name);
		}

		public JObject get_chain_properties()
		{
			return call_api(MethodBase.GetCurrentMethod().Name);
		}

		public JObject get_current_median_history_price()
		{
			return call_api(MethodBase.GetCurrentMethod().Name);
		}


		public JObject get_feed_history()
		{
			return call_api(MethodBase.GetCurrentMethod().Name);
		}

		public JObject get_witness_schedule()
		{
			return call_api(MethodBase.GetCurrentMethod().Name);
		}

		public JObject get_hardfork_version()
		{
			return call_api(MethodBase.GetCurrentMethod().Name);
		}

		public JObject get_next_scheduled_hardfork()
		{
			return call_api(MethodBase.GetCurrentMethod().Name);
		}

		public JArray get_accounts(ArrayList accounts)
		{
			var arrParams = new ArrayList {accounts};
			return call_api_array(MethodBase.GetCurrentMethod().Name, arrParams);
		}


		public JArray lookup_account_names(ArrayList accounts)
		{
			var arrParams = new ArrayList {accounts};
			return call_api_array(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		public JArray lookup_accounts(string lowerbound, uint limit)
		{
			var arrParams = new ArrayList {lowerbound, limit};
			return call_api_array(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		public JValue get_account_count()
		{
			return call_api_value(MethodBase.GetCurrentMethod().Name);
		}

		public JArray get_owner_history(string account)
		{
			var arrParams = new ArrayList {account};
			return call_api_array(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		public JObject get_recovery_request(string account)
		{
			var arrParams = new ArrayList {account};
			return call_api(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		public JObject get_block_header(long blockId)
		{
			var arrParams = new ArrayList {blockId};
			return call_api(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		public JObject get_block(long blockId)
		{
			var arrParams = new ArrayList {blockId};
			return call_api(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		public JArray get_witnesses(ArrayList witnesses)
		{
			var arrParams = new ArrayList {witnesses};
			return call_api_array(MethodBase.GetCurrentMethod().Name, arrParams);
		}


		public JArray get_conversion_requests(string account)
		{
			var arrParams = new ArrayList {account};
			return call_api_array(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		public JObject get_witness_by_account(string account)
		{
			var arrParams = new ArrayList {account};
			return call_api(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		public JArray get_witnesses_by_vote(string from, int limit)
		{
			var arrParams = new ArrayList {from, limit};
			return call_api_array(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		public JValue get_witness_count()
		{
			return call_api_value(MethodBase.GetCurrentMethod().Name);
		}

		// if permlink Is "" then it will return all votes for author
		public JArray get_active_votes(string author, string permlink)
		{
			var arrParams = new ArrayList {author, permlink};
			return call_api_array(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		public JObject get_content(string author, string permlink)
		{
			var arrParams = new ArrayList {author, permlink};
			return call_api(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		public JArray get_content_replies(string parent, string parentPermlink)
		{
			var arrParams = new ArrayList {parent, parentPermlink};
			return call_api_array(MethodBase.GetCurrentMethod().Name, arrParams);
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
		public JArray get_replies_by_last_update(string startAuthor, string startPermlink, uint limit)
		{
			var arrParams = new ArrayList {startAuthor, startPermlink, limit};
			return call_api_array(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		// This method Is used to fetch all posts/comments by start_author that occur after before_date And start_permlink with up to limit being returned.
		//
		// If start_permlink Is empty then only before_date will be considered. If both are specified the eariler to the two metrics will be used. This
		// should allow easy pagination.
		public JArray get_discussions_by_author_before_date(string author, string startPermlink, DateTime beforeDate,
			uint limit)
		{
			var arrParams = new ArrayList {author, startPermlink, beforeDate, limit};
			return call_api_array(MethodBase.GetCurrentMethod().Name, arrParams);
		}

		// Account operations have sequence numbers from 0 to N where N Is the most recent operation. This method
		// returns operations in the range [from-limit, from]
		//
		// from - the absolute sequence number, -1 means most recent, limit Is the number of operations before from.
		// limit - the maximum number of items that can be queried (0 to 1000], must be less than from
		public JToken get_account_history(string account, ulong from, uint limit)
		{
			var @params = new ArrayList {account, from, limit};
			return call_api_token(MethodBase.GetCurrentMethod().Name, @params);
		}

		#endregion
	}
}