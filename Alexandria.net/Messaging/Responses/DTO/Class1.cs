using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
  
    public class CustomJsonData
    {
        public string fee { get; set; }
        public string sender { get; set; }
        public List<string> recipients { get; set; }
        public int app_id { get; set; }
        public string json { get; set; }
    }

    public class CustomJsonResponse
    {
        public int id { get; set; }
        public List<CustomJsonData> result { get; set; }
    }
}


//{"id":0,"result":["custom_json",{"fee":"0.000000 SPHTX","sender":"test103","recipients":["test101"],"app_id":1,"json":"the quick brown fox jumped over something..."}]}