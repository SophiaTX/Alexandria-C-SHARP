using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses.DTO;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    /// <para>
    /// Wallet Application Functions
    /// </para>
    public class Application:RpcConnection
    {
        private readonly ILogger _logger;
        #region constructor
        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        /// <param name="wallet"></param>
        public Application(IConfig config, bool wallet = true) : base(config, wallet)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(LoggingType.Server, assemblyname);
        }
        #endregion
        /// <summary>
        ///  This method will create new application object. There is a fee associated with account creation
        ///  that is paid by the creator. The current account creation fee can be found with the
        ///  'info' wallet command.
        /// </summary>
        /// <param name="Author">The account creating the new application</param>
        /// <param name="AppName">The unique name for new application</param>
        /// <param name="URL">The url of the new application</param>
        /// <param name="MetaData">The meta data of new application</param>
        /// <param name="PriceParam">The price parameter that specifies billing for the app (1 or 0)</param>
        public TransactionResponse CreateApplication(string Author, string AppName, string URL, string MetaData, byte PriceParam, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {Author,AppName,URL,MetaData,PriceParam};
                var result= SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata, privateKey);
                return response;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
        }
        /// <summary>
        /// This method will update existing application object.
        /// </summary>
        /// <param name="Author">The author of application</param>
        /// <param name="AppName">The name of app that will be updated</param>
        /// <param name="NewAuthor">The new author</param>
        /// <param name="URL">Updated url</param>
        /// <param name="MetaData">Updated meta data</param>
        /// <param name="PriceParam">Updated price param</param>
        
        public TransactionResponse UpdateApplication(string Author, string AppName, string NewAuthor, string URL, string MetaData,
                                                      int PriceParam, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {Author,AppName,NewAuthor,URL,MetaData,PriceParam};
                var result= SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata, privateKey);
                return response;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
        }
        /// <summary>
        /// This method will delete specified application object.
        /// </summary>
        /// <param name="Author">The author of application that will be deleted</param>
        /// <param name="AppName">The name of app that will be deleted</param>
        
        public TransactionResponse DeleteApplication(string Author, string AppName, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {Author,AppName};
                var result= SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata, privateKey);
                return response;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
        }
        /// <summary>
        /// This method will create application buy object
        /// </summary>
        /// <param name="Buyer">The buyer of application</param>
        /// <param name="AppId">The id of app that buyer will buy</param>
       
        public TransactionResponse BuyApplication(string Buyer, int AppId, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {Buyer, AppId};
                var result= SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata, privateKey);
                return response;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
        }
        /// <summary>
        /// This method will cancel application buy object
        /// </summary>
        /// <param name="AppOwner">The owner of bought application
        ///</param>
        /// <param name="Buyer">The buyer of application</param>
        /// <param name="AppId">The id of bought app</param>
       
        public TransactionResponse CancelApplicationBuying(string AppOwner, string Buyer, int AppId,string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {AppOwner,Buyer,AppId};
                var result= SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata, privateKey);
                return response;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
        }
        /// <summary>
        /// Get all app buyings by app_name or buyer
        /// </summary>
        /// <param name="Name">Application id or buyers name</param>
        /// <param name="SearchType">search_type One of "by_buyer", "by_app_id"</param>
        /// <param name="Count">count Number of items to retrieve</param>
       
        public ApplicationSearchResponse GetApplicationBuyings(string BuyerName, string SearchType, int Count)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {BuyerName,SearchType,Count};
                var result= SendRequest(reqname, @params);
                var response = JsonConvert.DeserializeObject<ApplicationSearchResponse>(result);

                return response;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
        }

        public GetApplicationResponse GetApplications(string ApplicationNames)
        {
            try
            {
                List<string> Names=new List<string>{ApplicationNames};
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {Names};
                var result= SendRequest(reqname, @params);
                var response = JsonConvert.DeserializeObject<GetApplicationResponse>(result);

                return response;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
        }
    }

    #region Public Methods
    
    

    #endregion
}