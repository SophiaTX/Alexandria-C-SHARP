    using System.Collections.Generic;

namespace Alexandria.net.Messaging.Receiver
{
    /// <summary>
    /// The Sender Object
    /// </summary>
    public class BinaryData
    {
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
        /// the character array to send
        /// </summary>
        public string BinaryDoc { get; set; }
        /// <summary>
        /// the sender private key
        /// </summary>
        public string PrivateKey { get; set; }
    }
}