using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
   
    public class AccountHistoryResponse
    {
        public int id { get; set; }
        public List<List<object>> result { get; set; }
    }
}