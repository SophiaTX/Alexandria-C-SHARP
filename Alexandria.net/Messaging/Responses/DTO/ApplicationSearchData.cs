using System;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class ApplicationSearchData
    {
        public int id { get; set; }
        public int app_id { get; set; }
        public string buyer { get; set; }
        public DateTime created { get; set; }
    }
}