using System.Collections.Generic;
using Alexandria.net.Messaging.Receive.DTO;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receive
{
    public class RecvMessageCollection
    {
        private readonly List<ReceiveDataResponse> _sophiaRecvMessages = new List<ReceiveDataResponse>();

        public List<ReceiveDataResponse> Deserialise(string jsonstring)
        {
            return JsonConvert.DeserializeAnonymousType(jsonstring, _sophiaRecvMessages);
        }
    }
}