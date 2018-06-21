﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    /// <para>
    /// Wallet Cryptography Functions
    /// </para>
    public class Cryptography : RpcConnection
    {
        private readonly ILogger _logger;
        #region Constructors

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public Cryptography(IConfig config) : base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(LoggingType.Server, assemblyname);
        }

        #endregion


        /// <summary>
        /// Generates new private/public key pair.
        /// </summary>
        private Tuple<string, byte[]> generateKeyPair()
        {
            try
            {
                var result = SendRequest(MethodBase.GetCurrentMethod().Name);
                return JsonConvert.DeserializeObject<Tuple<string, byte[]>>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
           
        }


        /// <summary>
        /// Generates new private/public key pair from brian key.
        /// </summary>
        /// <param name="brainKey"></param>
        private Tuple<string, byte[]> generateKeyPairFromBrainKey(string brainKey)
        {
            try
            {
                var @params = new ArrayList {brainKey};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return JsonConvert.DeserializeObject<Tuple<string, byte[]>>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }


        /// <summary>
        /// Form a transaction containing a json-formatted operation, sign it with a given private key and send it to
        /// Generates new private/public key pair from brian key.
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="privateKey"></param>
        /// <returns>Returns true is it was properly signes and accepted, false otherwise.</returns>
        public bool signAndSendOperation(string operation, string privateKey)
        {
            try
            {
                var @params = new ArrayList {operation, privateKey};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
           
        }


        /// <summary>
        /// Sing a json-formatted transaction with a given private key and send it to the network.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="privateKey"></param>
        /// <remarks>Returns true is it was properly signes and accepted, false otherwise.</remarks>
        public bool signAndSendTransaction(string transaction, string privateKey)
        {
            try
            {
                var @params = new ArrayList {transaction, privateKey};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }


        /// <summary>
        /// Sign given digest using provided private key.
        /// </summary>
        private char[] signDigest(char[] digest, string privateKey)
        {
            try
            {
                var @params = new ArrayList {digest, privateKey};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return JsonConvert.DeserializeObject<char[]>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }



        /// <summary>
        /// Generate public key part associated to the given private key.
        /// </summary>
        /// <param name="privateKey"></param>
        private byte[] getPublicKey(string privateKey)
        {
            try
            {
                var @params = new ArrayList {privateKey};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return JsonConvert.DeserializeObject<byte[]>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }



        /// <summary>
        /// Decodes base58-encoded string.
        /// </summary>
        /// <param name="encodedData"></param>
        private List<char> fromBase58(string encodedData)
        {
            try
            {
                var @params = new ArrayList {encodedData};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return JsonConvert.DeserializeObject<List<char>>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }



        /// <summary>
        /// Encodes data to base58 string.
        /// </summary>
        /// <param name="data"></param>
        private string toBase58(List<char> data)
        {
            try
            {
                var @params = new ArrayList {data};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return JsonConvert.DeserializeObject<string>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }


        /// <summary>
        /// Verify if the given public key corresponds to the private key used to sign the digest.
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="pubKey"></param>
        /// <param name="signature"></param>
        private bool verifySignature(char[] digest, byte[] pubKey, char[] signature)
        {
            try
            {
                var @params = new ArrayList {digest, pubKey, signature};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        
           
        }


        /// <summary>
        /// Encrypts the document in plaintext using shared secret constructed via sender's private key and receveir's public key.
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        private string encryptDocument(string plaintext, string publicKey, string privateKey)
        {
            try
            {
                var @params = new ArrayList {plaintext, publicKey, privateKey};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return JsonConvert.DeserializeObject<string>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }


        /// <summary>
        /// Decrypts the encrypted data using shared secret constructed via receiver's private key and sender's public key
        /// or receiver's public key and sender's private key.
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        private string decryptDocument(string encryptedText, string publicKey, string privateKey)
        {
            try
            {
                var @params = new ArrayList {encryptedText, publicKey, privateKey};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return JsonConvert.DeserializeObject<string>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Encrypts the data in plain using shared secret constructed via sender's private key and receveir's public key.
        /// </summary>
        /// <param name="plaindata"></param>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        private List<byte> encryptData(List<byte> plaindata, string publicKey, string privateKey)
        {
            try
            {
                var @params = new ArrayList {plaindata, publicKey, privateKey};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return JsonConvert.DeserializeObject<List<byte>>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }


        /// <summary>
        /// Decrypts the encrypted data using shared secret constructed via receiver's private key and sender's public key or receiver's public key and sender's privatekey.
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        private List<byte> decryptData(List<byte> encryptedText, string publicKey, string privateKey)
        {
            try
            {
                var @params = new ArrayList {encryptedText, publicKey, privateKey};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return JsonConvert.DeserializeObject<List<byte>>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }
    }
}