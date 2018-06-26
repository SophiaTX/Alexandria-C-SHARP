using System.Collections.Generic;
using System.Net.Mime;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class GetApplicationResponse
    {
        public int id { get; set; }
        public List<ApplicationData> result { get; set; }
    }
}