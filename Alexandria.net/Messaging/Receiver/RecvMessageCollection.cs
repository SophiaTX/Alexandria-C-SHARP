using System.Collections.Generic;
using Alexandria.net.Messaging.Receiver.DTO;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receiver
{
    /// <summary>
    /// 
    /// </summary>
    public class RecvMessageCollection
    {
        private readonly List<ReceiveDataResponse> _sophiaRecvMessages = new List<ReceiveDataResponse>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonstring"></param>
        /// <returns></returns>
        public List<ReceiveDataResponse> Deserialise(string jsonstring)
        {
            return JsonConvert.DeserializeAnonymousType(jsonstring, _sophiaRecvMessages);
        }
    }
}