using System;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.API.WalletFunctions
{
    public partial class Wallet // Messaging
    { 
        /// <summary>
        /// Returns conversion requests by an account
        /// </summary>
        /// <param name="owner">Account name Of the account owning the requests</param>
        /// <returns>All pending conversion requests by account</returns>
        public JArray get_conversion_requests(string owner)
        {
            var @params = new ArrayList {owner};
            return call_api_array(MethodBase.GetCurrentMethod().Name, @params);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="newest"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public JArray get_inbox(string account, DateTime newest, uint limit)
        {
            var @params = new ArrayList {account, newest, limit};
            return call_api_array(MethodBase.GetCurrentMethod().Name, @params);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="newest"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public JArray get_outbox(string account, DateTime newest, uint limit)
        {
            var @params = new ArrayList {account, newest, limit};
            return call_api_array(MethodBase.GetCurrentMethod().Name, @params);
        }
        
        /// <summary>
        /// Post Or update a comment
        /// </summary>
        /// <param name="author">the name Of the account authoring the comment </param>
        /// <param name="permlink">the accountwide unique permlink For the comment </param>
        /// <param name="parentAuthor">can be null If this Is a top level comment</param>
        /// <param name="parentPermlink">becomes category If parent_author Is "" </param>
        /// <param name="title">the title Of the comment </param>
        /// <param name="body">he body Of the comment </param>
        /// <param name="json">the json metadata Of the comment </param>
        /// <param name="broadcast">true if you wish to broadcast the transaction.</param>
        /// <returns></returns>
        public string post_comment(string author, string permlink, string parentAuthor, string parentPermlink,
            string title, string body, string json, bool broadcast = true)
        {
            var @params = new ArrayList {author, permlink, parentAuthor, parentPermlink, title, body, json, broadcast};
            return call_api(MethodBase.GetCurrentMethod().Name, @params);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="broadcast">true if you wish to broadcast the transaction.</param>
        /// <returns></returns>
        public string send_private_message(string from, string to, string subject, string body, bool broadcast = true)
        {
            var @params = new ArrayList {@from, to, subject, body, broadcast};
            return call_api(MethodBase.GetCurrentMethod().Name, @params);
        }

    }
}