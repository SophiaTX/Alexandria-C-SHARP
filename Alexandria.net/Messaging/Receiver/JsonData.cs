using System.Collections.Generic;
using Alexandria.net.Helpers;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receiver
{
    /// <summary>
    /// The Sender Object
    /// </summary>
    public class JsonData
    {
        #region Member Variables
        private string _jsondoc = "";

        #endregion


        /// <summary>
        /// the sender 
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// the list of receipients
        /// </summary>
        public List<string> Recipients { get; set; }

        /// <summary>
        /// the appid
        /// </summary>
        public uint AppId { get; set; }

        /// <summary>
        /// the document to send in json format
        /// </summary>
        public string JsonDoc{ get; set; }
//        {
//            get => _jsondoc;
//            set => JsonHelper.IsValidJson(value) ? _jsondoc : JsonConvert.SerializeObject(value);
//        }

        /// <summary>
        /// the sender private key
        /// </summary>
        public string PrivateKey { get; set; }
    }
}