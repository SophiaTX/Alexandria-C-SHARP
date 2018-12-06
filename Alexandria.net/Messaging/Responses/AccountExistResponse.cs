using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the account exists reponse object
    /// </summary>
    public class AccountExistsResult
    {
        public bool account_exist { get; set; }
    }

    public class AccountExistResponse
    {
        public string jsonrpc { get; set; }
        public AccountExistsResult result { get; set; }
        public int id { get; set; }
    }
}