using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the response data from the About method call
    /// </summary>
    public class AboutData
    {
        /// <summary>
        /// The version of the blockchain
        /// </summary>
        [JsonProperty("blockchain_version")]
        public string BlockchainVersion { get; set; }
        /// <summary>
        /// the client version number
        /// </summary>
        [JsonProperty("client_version")]
        public string ClientVersion { get; set; }
        /// <summary>
        /// the revision number of the blockchain
        /// </summary>
        [JsonProperty("sophiatx_revision")]
        public string SophiatxRevision { get; set; }
        /// <summary>
        /// the age of the revision
        /// </summary>
        [JsonProperty("sophiatx_revision_age")]
        public string SophiatxRevisionAge { get; set; }
        /// <summary>
        /// the fc cryptography library revision
        /// </summary>
        [JsonProperty("fc_revision")]
        public string FcRevision { get; set; }
        /// <summary>
        /// the age of the new fc cryptography library
        /// </summary>
        [JsonProperty("fc_revision_age")]
        public string FcRevisionAge { get; set; }
        /// <summary>
        /// the compliation date of the code
        /// </summary>
        [JsonProperty("compile_date")]
        public string CompileDate { get; set; }
        /// <summary>
        /// the boost version used by the blockchain
        /// </summary>
        [JsonProperty("boost_version")]
        public string BoostVersion { get; set; }
        /// <summary>
        /// the openssl version used by the blockchain
        /// </summary>
        [JsonProperty("openssl_version")]
        public string OpensslVersion { get; set; }
        /// <summary>
        /// the build version of the blockchain
        /// </summary>
        [JsonProperty("build")]
        public string Build { get; set; }
        /// <summary>
        /// the server blockchain version number
        /// </summary>
        [JsonProperty("server_blockchain_version")]
        public string ServerBlockchainVersion { get; set; }
        /// <summary>
        /// the seophiatx revision
        /// </summary>
        [JsonProperty("server_sophiatx_revision")]
        public string ServerSophiatxRevision { get; set; }
        /// <summary>
        /// the server fc cryptopgraphy revision nunmber
        /// </summary>
        [JsonProperty("server_fc_revision")]
        public string ServerFcRevision { get; set; }
        /// <summary>
        /// the chain identification number
        /// </summary>
        [JsonProperty("chain_id")]
        public string ChainId { get; set; }
    }
}