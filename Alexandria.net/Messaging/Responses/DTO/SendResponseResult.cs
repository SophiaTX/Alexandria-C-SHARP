using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class SendResponseResult
    {
        [JsonProperty("ref_block_num")]
        public string RefBlockNum { get; set; }

        [JsonProperty("ref_block_prefix")]
        public string RefBlockPrefix { get; set; }

        [JsonProperty("expiration")]
        public string Expiration { get; set; }

        [JsonProperty("operations")]
        public List<List<object>> Operations { get; set; }

        [JsonProperty("extensions")]
        public List<object> Extentions { get; set; }

        [JsonProperty("signatures")]
        public List<string> Signatures { get; set; }
    }
}