using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Enums;
using Alexandria.net.Extensions;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Receiver;
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
                var operations = new List<string>();
                foreach (var doc in senderdata.Documents)
                {
                    var operation = makeCustomJsonOperation(senderdata.Sender, senderdata.Recipients, senderdata.AppId,
                        doc);
                    if (operation != string.Empty)
                        operations.Add(operation);
                }

                if (operations.Count == 0) return false;
                var transaction = makeTransaction(operations);
                if (transaction == string.Empty) return false;
                result = _cryptography.signAndSendTransaction(transaction, senderdata.PrivateKey);
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
                var operations = new List<string>();
                foreach (var doc in senderdata.DocumentChars)
                {
                    var operation = makeCustomBinaryOperation(senderdata.Sender, senderdata.Recipients,
                        senderdata.AppId,
                        doc);
                    if (operation != string.Empty)
                        operations.Add(operation);
                }

                if (operations.Count == 0) return false;

                var transaction = makeTransaction(operations);
                if (transaction == string.Empty) return false;
                result = _cryptography.signAndSendTransaction(transaction, senderdata.PrivateKey);

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
                var operations = new List<string>();
                foreach (var doc in senderdata.Documents)
                {
                    var operation = makeCustomBinaryBase58Operation(senderdata.Sender, senderdata.Recipients,
                        senderdata.AppId, doc);
                    operations.Add(operation);
                }

                if (operations.Count == 0) return false;

                var transaction = makeTransaction(operations);
                if (transaction == string.Empty) return false;
                result = _cryptography.signAndSendTransaction(transaction, senderdata.PrivateKey);
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
        /// <param name="appId">The Id of the application which we are receiving for</param>
        /// <param name="searchType">based on the Search Type Enum</param>
        /// <param name="account">Account Owner - sender or receiver</param>
        /// <param name="start">Start by value - index or ISO time stamp</param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Dictionary<ulong, ReceiverRecipe> Receive(ulong appId, SearchType searchType, AccountOwner account,
            StartBy start,
            uint count)
        {
            Dictionary<ulong, ReceiverRecipe> result;
            try
            {
                result = get_received_documents(appId, searchType.GetStringValue(), account.GetStringValue(),
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
    }
}