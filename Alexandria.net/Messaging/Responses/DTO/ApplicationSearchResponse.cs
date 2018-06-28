using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class ApplicationSearchResponse
    {
        public int id { get; set; }
        public List<ApplicationSearchData> result { get; set; }
    }
    
}