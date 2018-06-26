using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class CustomJsonResponse
    {
        public int id { get; set; }
        public List<object> result { get; set; }
    }
}


//{"id":0,"result":["custom_json",{"fee":"0.000000 SPHTX","sender":"test103","recipients":["test101"],"app_id":1,"json":"the quick brown fox jumped over something..."}]}