using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses
{
   
    public class CreateAuthorityResult
    {
        public SimpleAuthorityData simple_multisig_authority { get; set; }
    }
    public class CreateAuthorityResponse
    {
        public string jsonrpc { get; set; }
        public CreateAuthorityResult result { get; set; }
        public int id { get; set; }
    }
}