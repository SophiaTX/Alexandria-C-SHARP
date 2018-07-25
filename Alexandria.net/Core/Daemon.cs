using System;
using System.Collections;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.Core
{
	/// <summary>
	/// Daemon implementation
	/// </summary>
	/// <inheritdoc cref="RpcConnection"/>
	public class Daemon : RpcConnection
	{
		private readonly ILogger _logger;

		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="config">the Configuration paramaters for the endpoint and ports</param>
		public Daemon(IConfig config) :
			base(config)
		{
			var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
			_logger = new Logger(LoggingType.Server, assemblyname);
		}

		#endregion

		#region public Methods

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetConfig()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result = SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetDynamicGlobalProperties()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result = SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 	
		/// </summary>
		/// <returns></returns>
		public string GetChainProperties()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result = SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetCurrentMedianHistoryPrice()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result = SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>

		public string GetFeedHistory()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result = SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetWitnessSchedule()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result = SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetHardForkVersion()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result = SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetNextScheduledHardfork()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result = SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="accounts"></param>
		/// <returns></returns>
		public string GetAccounts(ArrayList accounts)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {accounts};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="accounts"></param>
		/// <returns></returns>
		public string LookupAccountNames(ArrayList accounts)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {accounts};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="lowerbound"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		public string LookupAccounts(string lowerbound, uint limit)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {lowerbound, limit};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetAccountCount()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result = SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public string GetOwnerHistory(string account)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {account};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public string GetRecoveryRequest(string account)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {account};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="blockId"></param>
		/// <returns></returns>
		public string GetBlockHeader(long blockId)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {blockId};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="blockId"></param>
		/// <returns></returns>
		public string GetBlock(long blockId)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {blockId};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="witnesses"></param>
		/// <returns></returns>
		public string GetWitnesses(ArrayList witnesses)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {witnesses};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public string GetConversionRequests(string account)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {account};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public string GetWitnessByAccount(string account)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {account};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="from"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		public string GetWitnessesByVote(string from, int limit)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {from, limit};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		// if permlink Is "" then it will return all votes for author
		/// <summary>
		/// 
		/// </summary>
		/// <param name="author"></param>
		/// <param name="permlink"></param>
		/// <returns></returns>
		public string GetActiveVotes(string author, string permlink)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {author, permlink};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="author"></param>
		/// <param name="permlink"></param>
		/// <returns></returns>
		public string GetContent(string author, string permlink)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {author, permlink};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="parentPermlink"></param>
		/// <returns></returns>
		public string GetContentReplies(string parent, string parentPermlink)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {parent, parentPermlink};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
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
		public string GetRepliesByLastUpdate(string startAuthor, string startPermlink, uint limit)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {startAuthor, startPermlink, limit};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
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
		public string GetDiscussionsByAuthorBeforeDate(string author, string startPermlink, DateTime beforeDate,
			uint limit)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {author, startPermlink, beforeDate, limit};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
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
		public string GetAccountHistory(string account, ulong from, uint limit)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {account, from, limit};
				var result = SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		public string GetWitnessCount()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result = SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<string>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		#endregion
	}
}