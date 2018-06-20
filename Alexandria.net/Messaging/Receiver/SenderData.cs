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
        public ulong AppId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Documents { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<List<char>> DocumentChars { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PrivateKey { get; set; }
    }
}