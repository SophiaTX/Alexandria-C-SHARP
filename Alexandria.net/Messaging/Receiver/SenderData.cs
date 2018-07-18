using System.Collections.Generic;

namespace Alexandria.net.Messaging.Receiver
{
    /// <summary>
    /// Sender data class
    /// </summary>
    public class SenderData
    {
        /// <summary>
        /// Account name of the sender
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// List of recipients account names
        /// </summary>
        public List<string> Recipients { get; set; }
        /// <summary>
        /// New app id
        /// </summary>
        public uint AppId { get; set; }

        /// <summary>
        /// Data to be transmitted
        /// </summary>
        public string Document
        {
            //get;
            set => FormattedDoc = value;
        }
        /// <summary>
        /// Json data 
        /// </summary>
        public string FormattedDoc { get; private set; }
        /// <summary>
        /// Binary data
        /// </summary>
        public string DocumentChars { get; set; }
        /// <summary>
        /// Private key of the sender
        /// </summary>
        public string PrivateKey { get; set; }
    }
}