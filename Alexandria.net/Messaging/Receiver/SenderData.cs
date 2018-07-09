using System.Collections.Generic;

namespace Alexandria.net.Messaging.Receiver
{
    /// <summary>
    /// 
    /// </summary>
    public class SenderData
    {
        /// <summary>
        /// 
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Recipients { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint AppId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Document
        {
            set => FormattedDoc = "[\"" + $"{value}" + "\"]";
        }
        public string FormattedDoc { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string DocumentChars { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PrivateKey { get; set; }
    }
}