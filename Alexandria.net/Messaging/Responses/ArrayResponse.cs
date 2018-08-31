using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.Messaging.Responses
{
    public class ArrayResponse
    {
        
        public long Id { get; set; }

        public object Result { get; set; }
    }
}