using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class SendResponseResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ref_block_num")]
        public string RefBlockNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ref_block_prefix")]
        public string RefBlockPrefix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public string Expiration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("operations")]
        public List<List<object>> Operations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extensions")]
        public List<object> Extentions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("signatures")]
        public List<string> Signatures { get; set; }
    }
}