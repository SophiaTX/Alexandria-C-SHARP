using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Enums;
using Alexandria.net.Extensions;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.API
{
    /// <inheritdoc />
    /// <para>
    /// WSophia Blockchain Wallet functions
    /// </para>
    public class Application:RpcConnection
    {
        private readonly ILogger _logger;

        #region constructor

        /// <summary>
        /// Application Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="wallet"></param>
        public Application(IConfig config, bool wallet = true) : base(config, wallet)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(config, LoggingType.Server, assemblyname);
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///  This method will create new application object. There is a fee associated with account creation
        ///  that is paid by the creator. The current account creation fee can be found with the
        ///  'info' wallet command.
        /// </summary>
        /// <param name="author">The account creating the new application</param>
        /// <param name="appName">The unique name for new application</param>
        /// <param name="url">The url of the new application</param>
        /// <param name="metaData">The meta data of new application</param>
        /// <param name="priceParam">The price parameter that specifies billing for the app (1 or 0)</param>
        /// <param name="privateKey"></param>
        public TransactionResponse CreateApplication(string author, string appName, string url, string metaData,
            byte priceParam, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {author, appName, url, metaData, priceParam};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata.Result, privateKey);
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }


        /// <summary>
        /// This method will update existing application object.
        /// </summary>
        /// <param name="author">The author of application</param>
        /// <param name="appName">The name of app that will be updated</param>
        /// <param name="newAuthor">The new author</param>
        /// <param name="url">Updated url</param>
        /// <param name="metaData">Updated meta data</param>
        /// <param name="priceParam">Updated price param</param>
        /// <param name="privateKey"></param>
        public TransactionResponse UpdateApplication(string author, string appName, string newAuthor, string url,
            string metaData, byte priceParam, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {author, appName, newAuthor, url, metaData, priceParam};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata.Result, privateKey);
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// This method will delete specified application object.
        /// </summary>
        /// <param name="author">The author of application that will be deleted</param>
        /// <param name="appName">The name of app that will be deleted</param>
        /// <param name="privateKey"></param>
        public TransactionResponse DeleteApplication(string author, string appName, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {author, appName};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata.Result, privateKey);
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// This method will create application buy object
        /// </summary>
        /// <param name="buyer">The buyer of application</param>
        /// <param name="appId">The id of app that buyer will buy</param>
        /// <param name="privateKey"></param>
        public TransactionResponse BuyApplication(string buyer, long appId, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {buyer, appId};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata.Result, privateKey);
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        ///  <summary>
        ///  This method will cancel application buy object
        ///  </summary>
        ///  <param name="appOwner">The owner of bought application
        /// </param>
        ///  <param name="buyer">The buyer of application</param>
        ///  <param name="appId">The id of bought app</param>
        /// <param name="privateKey"></param>
        public TransactionResponse CancelApplicationBuying(string appOwner, string buyer, long appId, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {appOwner, buyer, appId};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata.Result, privateKey);
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Get all app buyings by app_name or buyer
        /// </summary>
        /// <param name="buyerName">the buyers name</param>
        /// <param name="searchType">search_type One of "by_buyer", "by_app_id"</param>
        /// <param name="count">count Number of items to retrieve</param>
        public ApplicationSearchResponse GetApplicationBuyings(string buyerName, SearchType searchType, uint count)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {buyerName, searchType.GetStringValue(), count};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<ApplicationSearchResponse>(result);
 
                return contentdata;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
        }
        /// <summary>
        /// Get list of published applications on the blockchain
        /// </summary>
        /// <param name="applicationNames">list of names of appictions to be searched</param>
        /// <returns>the application response data</returns>
        public GetApplicationResponse GetApplications(List<string> applicationNames)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {applicationNames};
                var result= SendRequest(reqname, @params);
                var response = JsonConvert.DeserializeObject<GetApplicationResponse>(result);

                return response;
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