namespace Alexandria.net.Messaging.Responses
{
    public class SAResult
    {
        public SimpleAuthorityData simple_managed_authority { get; set; }
    }

    public class SimpleManagedAuthorityResponse
    {
        public string jsonrpc { get; set; }
        public SAResult result { get; set; }
        public int id { get; set; }
    }
}