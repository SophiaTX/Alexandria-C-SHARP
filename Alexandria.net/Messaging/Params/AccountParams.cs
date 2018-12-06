using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Params
{
    /// <summary>
    /// The Account Parameters
    /// </summary>
    public class AccountParams : IParams
    {
        /// <summary>
        /// The Account name to search for
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        public object GetDetails(params object[] list)//List<string> parameters)  
        {
            var obj = new AccountParams {AccountName = list[0].ToString()};
            return obj;  
        }
    }
}