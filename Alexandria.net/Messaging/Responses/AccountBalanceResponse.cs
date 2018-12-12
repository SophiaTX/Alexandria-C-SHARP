namespace Alexandria.net.Messaging.Responses
{
    
    public class AccountBalanceResult
    {
        public string account_balance { get; set; }
    }
  
        public class AccountBalanceResponse
        {
            public string jsonrpc { get; set; }
            public int id { get; set; }
            public AccountBalanceResult result { get; set; }
        }
    
}