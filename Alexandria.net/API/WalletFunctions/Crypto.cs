using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    public class Crypto : RpcConnection
    {

        #region Constructors

        /// <summary>
        /// Wallet Constructor
        /// </summary>
        /// <param name="hostname">the rpc endpoint ip address</param>
        /// <param name="port">the rpc endpoint post</param>
        protected Crypto(string hostname = "127.0.0.1", ushort port = 8091) : base(hostname, port)
        {
        }

        #endregion


        /// <summary>
        /// Generates new private/public key pair.
        /// </summary>
        public Tuple<string, byte[]> generateKeyPair()
        {
            var result = SendRequest(MethodBase.GetCurrentMethod().Name);
            return JsonConvert.DeserializeObject<Tuple<string, byte[]>>(result);
        }


        /// <summary>
        /// Generates new private/public key pair from brian key.
        /// </summary>
        /// <param name="brain_key"></param>
        public Tuple<string, byte[]> generateKeyPairFromBrainKey(string brain_key)
        {
            var @params = new ArrayList {brain_key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Tuple<string, byte[]>>(result);
        }


        /// <summary>
        /// Form a transaction containing a json-formatted operation, sign it with a given private key and send it to
        /// Generates new private/public key pair from brian key.
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="private_key"></param>
        /// <returns>Returns true is it was properly signes and accepted, false otherwise.</returns>
        public bool signAndSendOperation(string operation, string private_key)
        {
            var @params = new ArrayList {operation, private_key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }


        /// <summary>
        /// Sing a json-formatted transaction with a given private key and send it to the network.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="private_key"></param>
        /// <remarks>Returns true is it was properly signes and accepted, false otherwise.</remarks>
        public bool signAndSendTransaction(string transaction, string private_key)
        {
            var @params = new ArrayList {transaction, private_key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }


        /// <summary>
        /// Sign given digest using provided private key.
        /// </summary>
        public char[] signDigest(char[] digest, string private_key)
        {
            var @params = new ArrayList {digest, private_key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<char[]>(result);
        }



        /// <summary>
        /// Generate public key part associated to the given private key.
        /// </summary>
        /// <param name="private_key"></param>
        public byte[] getPublicKey(string private_key)
        {
            var @params = new ArrayList {private_key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<byte[]>(result);
        }



        /// <summary>
        /// Decodes base58-encoded string.
        /// </summary>
        /// <param name="encoded_data"></param>
        public List<char> fromBase58(string encoded_data)
        {
            var @params = new ArrayList {encoded_data};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<List<char>>(result);
        }



        /// <summary>
        /// Encodes data to base58 string.
        /// </summary>
        /// <param name="data"></param>
        public string toBase58(List<char> data)
        {
            var @params = new ArrayList {data};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<string>(result);
        }


        /// <summary>
        /// Verify if the given public key corresponds to the private key used to sign the digest.
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="pub_key"></param>
        /// <param name="signature"></param>
        public bool verifySignature(char[] digest, byte[] pub_key, char[] signature)
        {
            var @params = new ArrayList {digest, pub_key, signature};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }


        /// <summary>
        /// Encrypts the document in plaintext using shared secret constructed via sender's private key and receveir's public key.
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="public_key"></param>
        /// <param name="private_key"></param>
        public string encryptDocument(string plaintext, string public_key, string private_key)
        {
            var @params = new ArrayList {plaintext, public_key, private_key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<string>(result);
        }


        /// <summary>
        /// Decrypts the encrypted data using shared secret constructed via receiver's private key and sender's public key
        /// or receiver's public key and sender's private key.
        /// </summary>
        /// <param name="encrypted_text"></param>
        /// <param name="public_key"></param>
        /// <param name="private_key"></param>
        public string decryptDocument(string encrypted_text, string public_key, string private_key)
        {
            var @params = new ArrayList {encrypted_text, public_key, private_key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<string>(result);
        }

        /// <summary>
        /// Encrypts the data in plain using shared secret constructed via sender's private key and receveir's public key.
        /// </summary>
        /// <param name="plaindata"></param>
        /// <param name="public_key"></param>
        /// <param name="private_key"></param>
        public List<byte> encryptData(List<byte> plaindata, string public_key, string private_key)
        {
            var @params = new ArrayList {plaindata, public_key, private_key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<List<byte>>(result);
        }


        /// <summary>
        /// Decrypts the encrypted data using shared secret constructed via receiver's private key and sender's public key or receiver's public key and sender's privatekey.
        /// </summary>
        /// <param name="encrypted_text"></param>
        /// <param name="public_key"></param>
        /// <param name="private_key"></param>
        public List<byte> decryptData(List<byte> encrypted_text, string public_key, string private_key)
        {
            var @params = new ArrayList {encrypted_text, public_key, private_key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<List<byte>>(result);
        }
    }
}