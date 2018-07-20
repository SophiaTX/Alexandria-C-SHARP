using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The response from the Key transaction
    /// </summary>
    public class KeyResponse
    {
        /// <summary>
        /// the public key information 
        /// </summary>
        [JsonProperty("PublicKey")]
        public string PublicKey { get; set; }
        /// <summary>
        /// the private key information
        /// </summary>
        [JsonProperty("PrivateKey")]
        public string PrivateKey { get; set; }   
    }
}