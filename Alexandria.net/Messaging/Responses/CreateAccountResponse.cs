using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the account creation response
    /// </summary>
    public class CreateAccountResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the create account results data
        /// </summary>
        [JsonProperty("result")]
        public List<object> Result { get; set; }
    }
}