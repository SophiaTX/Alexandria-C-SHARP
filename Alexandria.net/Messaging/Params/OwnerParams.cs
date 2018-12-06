using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Params
{
    public class OwnerParams : IParams
    {
        /// <summary>
        /// The Account name to search for
        /// </summary>
        [JsonProperty("owner_account")]
        public string OwnerAccount { get; set; }

        public object GetDetails(params object[] list)
        {
            var obj = new OwnerParams {OwnerAccount = list[0].ToString()};
            return obj;  
        }
    }
}