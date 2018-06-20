using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Enums;
using Alexandria.net.Extensions;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses.DTO;
using Alexandria.net.Settings;
using ILogger = Alexandria.net.Logging.ILogger;
using Logger = Alexandria.net.Logging.Logger;

namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Data : Network
    {
        #region member variables

        private readonly ILogger _logger;
        private readonly Cryptography _cryptography;

        private readonly IBlockchainConfig _blockchainConfig;
        //private Timer _timer;
        //private const int TimeoutInMilliseconds = 20000;
        //private readonly string _receiverAddress;
        //private Thread _thread;

        #endregion

        #region ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public Data(IConfig config, IBlockchainConfig blockchainConfig) : base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(LoggingType.Server, assemblyname);
            _cryptography = new Cryptography(config);
            _blockchainConfig = blockchainConfig;
        }

        #endregion

        #region methods - public

        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderdata"></param>
        /// <returns></returns>
        public bool Send(SenderData senderdata)
        {
            bool result;
            try
            {
                var operation = makeCustomJsonOperation(senderdata.Sender, senderdata.Recipients, senderdata.AppId,
                    senderdata.Document);
                if (operation == string.Empty) return false;
                result = SignAndSendData(senderdata, operation);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderdata"></param>
        /// <returns></returns>
        public bool SendBinary(SenderData senderdata)
        {
            bool result;
            try
            {
                var operation = makeCustomBinaryOperation(senderdata.Sender, senderdata.Recipients, senderdata.AppId,
                    senderdata.DocumentChars);
                result = SignAndSendData(senderdata, operation);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderdata"></param>
        /// <returns></returns>
        public bool SendBinaryBase58(SenderData senderdata)
        {
            bool result;
            try
            {
                var operation = makeCustomBinaryBase58Operation(senderdata.Sender, senderdata.Recipients,
                    senderdata.AppId, senderdata.Document);
                if (operation == string.Empty) return false;
                result = SignAndSendData(senderdata, operation);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

            return result;
        }

        /// <summary>
        /// Allowed options for search_type are "by_sender", "by_recipient", "by_sender_datetime", "by_recipient_datetime".
        /// Account is then either sender or recevier, and start is either index od ISO time stamp.
        /// </summary>
        /// <param name="AppId">The Id of the application which we are receiving for</param>
        /// <param name="searchType">based on the Search Type Enum</param>
        /// <param name="account">Account Owner - sender or receiver</param>
        /// <param name="start">Start by value - index or ISO time stamp</param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Dictionary<ulong, ReceiverRecipe> Receive(ulong AppId, SearchType searchType, AccountOwner account,
            StartBy start,
            uint count)
        {
            Dictionary<ulong, ReceiverRecipe> result;
            try
            {
                //todo - define here whether we read from the config file and then send the next number inline so that 
                //todo - we can minimise the number of parameters being parsed
                result = get_received_documents(AppId, searchType.GetStringValue(), account.GetStringValue(),
                    start.GetStringValue(),
                    count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        #endregion

        #region methods - private

        private bool SignAndSendData(SenderData senderdata, string operation)
        {
            bool result;
            string transaction;
            switch (senderdata.TransactionType)
            {
                case TransactionType.SignAndSend:
                    result = _cryptography.signAndSendOperation(operation, senderdata.PrivateKey);
                    break;
                case TransactionType.MakeSignAndSend:
                    transaction = makeTransaction(new List<string> {operation});
                    if (transaction == string.Empty) return false;
                    result = _cryptography.signAndSendTransaction(transaction, senderdata.PrivateKey);
                    break;
                case TransactionType.MakeDigestSignAndSend:
                    transaction = makeTransaction(new List<string> {operation});
                    if (transaction == string.Empty) return false;

                    var digest = getTransactionDigest(transaction);
                    if (digest == null) return false;

                    var signedDigest = _cryptography.signDigest(digest, senderdata.PrivateKey);
                    if (signedDigest == null) return false;

                    var signedtransaction = addSingature(transaction, signedDigest);
                    if (signedtransaction == string.Empty) return false;

                    result = sendSignedTransaction(transaction);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(senderdata.TransactionType),
                        senderdata.TransactionType, null);
            }

            return result;
        }

/*        private static readonly ILog log = LogManager.GetLogger(typeof(Data));

        public void TestLogging(string message, string fullMessage)
        {
            try
            {
                var log4netConfig = new XmlDocument();
                using (var reader = new StreamReader(new FileStream("logging.config", FileMode.Open, FileAccess.Read)))
                {
                    log4netConfig.Load(reader);
                }

                var rep = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                    typeof(log4net.Repository.Hierarchy.Hierarchy));

                XmlConfigurator.Configure(rep, log4netConfig["log4net"]);

                log.Debug(new
                {
                    Message = $"Message: {message} || Full-Message: {fullMessage}",
                    Open = DateTime.UtcNow
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }*/

        #endregion
    }

    
    //Allowed options for search_type are "by_sender", "by_recipient", "by_sender_datetime", "by_recipient_datetime".
    // Account is then either sender or recevier, and start is either index od ISO time stamp.
}