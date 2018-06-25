using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class GetOperationsResponse
    {
        public int id { get; set; }
        public List<Operations> result { get; set; }
    }
}