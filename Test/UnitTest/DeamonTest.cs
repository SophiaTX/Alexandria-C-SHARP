/*using System;
 using System.Collections;
 using System.Reflection;
 using Xunit;
 
 namespace UnitTest
 {
 	public class DeamonTest : BaseTest
 	{
 		[Fact]
 		public string GetConfig()
 		{
 			return _client.Daemon.GetConfig();
 		}
 
 		[Fact]
 		public string GetDynamicGlobalProperties()
 		{
 			return _client.Daemon.GetDynamicGlobalProperties();
 		}
 
 
 		[Fact]
 		public string Get_chain_properties()
 		{
 			return _client.Daemon.GetChainProperties();
 		}
 
 
 		[Fact]
 		public string GetCurrentMedianHistoryPrice()
 		{
 			return _client.Daemon.GetCurrentMedianHistoryPrice();
 		}
 
 		[Fact]
 		public string Get_feed_history()
 		{
 			return _client.Daemon.GetFeedHistory();
 		}
 
 		[Fact]
 		public string Get_witness_schedule()
 		{
 			return _client.Daemon.GetWitnessSchedule();
 		}
 
 		[Fact]
 		public string Get_hardfork_version()
 		{
 			return _client.Daemon.GetHardForkVersion();
 		}
 
 		[Fact]
 		public string Get_next_scheduled_hardfork()
 		{
 			return _client.Daemon.GetNextScheduledHardfork();
 		}
 
 		[Fact]
 		public string Get_accounts()
 		{
 			var accounts = new ArrayList();
 			return _client.Daemon.GetAccounts(accounts);
 		}
 
 		[Fact]
 		public string Lookup_account_names()
 		{
 			var accounts = new ArrayList();
 			return _client.Daemon.LookupAccountNames(accounts);
 		}
 
 		[Fact]
 		public string Lookup_accounts()
 		{
 			string lowerbound = "";
 			uint limit = 0;
 			return _client.Daemon.LookupAccounts(lowerbound, limit);
 		}
 
 		[Fact]
 		public string Get_account_count()
 		{
 			return _client.Daemon.GetAccountCount();
 		}
 
 		[Fact]
 		public string get_owner_history()
 		{
 			string account = "";
 			return _client.Daemon.GetOwnerHistory(account);
 		}
 
 		[Fact]
 		public string get_recovery_request()
 		{
 			string account = "";
 			return _client.Daemon.GetRecoveryRequest(account);
 		}
 
 		[Fact]
 		public string get_block_header()
 		{
 			long blockId = 0;
 			return _client.Daemon.GetBlockHeader(blockId);
 		}
 
 		[Fact]
 		public string get_block()
 		{
 			long blockId = 0;
 			return _client.Daemon.GetBlock(blockId);
 		}
 
 		[Fact]
 		public string get_witnesses()
 		{
 			var witnesses = new ArrayList();
 			return _client.Daemon.GetWitnesses(witnesses);
 		}
 
 		[Fact]
 		public string get_conversion_requests()
 		{
 			string account = "";
 			return _client.Daemon.GetConversionRequests(account);
 		}
 
 		[Fact]
 		public string get_witness_by_account()
 		{
 			string account = "";
 			return _client.Daemon.GetWitnessByAccount(account);
 		}
 
 		[Fact]
 		public string get_witnesses_by_vote()
 		{
 			string from = "";
 			int limit = 0;
 			return _client.Daemon.GetWitnessesByVote(from, limit);
 		}
 
 		[Fact]
 		public string get_witness_count()
 		{
 			return _client.Daemon.GetAccountCount();
 		}
 
 		[Fact]
 		public string get_active_votes()
 		{
 			string author = "";
 			string permlink = "";
 			return _client.Daemon.GetActiveVotes(author, permlink);
 		}
 
 		[Fact]
 		public string get_content()
 		{
 			string author = "";
 			string permlink = "";
 			return _client.Daemon.GetContent(author, permlink);
 		}
 
 		[Fact]
 		public string get_content_replies()
 		{
 			string parent = "";
 			string parentPermlink = "";
 			return _client.Daemon.GetContentReplies(parent, parentPermlink);
 		}
 
 		[Fact]
 		public string get_replies_by_last_update()
 		{
 			string startPermlink = "";
 			string startAuthor = "";
 			uint limit = 0;
 			return _client.Daemon.GetRepliesByLastUpdate(startAuthor, startPermlink, limit);
 		}
 
 		[Fact]
 		public string get_discussions_by_author_before_date()
 		{
 			string author = "";
 			string startPermlink = "";
 			DateTime beforeDate = DateTime.UtcNow;
 			uint limit = 0;
 			return _client.Daemon.GetDiscussionsByAuthorBeforeDate(author, startPermlink, beforeDate, limit);
 		}
 
 		[Fact]
 		public string get_account_history()
 		{
 			string account = "";
 			ulong from = 0;
 			uint limit = 0;
 			return _client.Daemon.GetAccountHistory(account, from, limit);
 		}
 
 		[Fact]
 		public string GetWitnessCount()
 		{
 			return _client.Daemon.GetWitnessCount();
 		}
 	}
 }*/