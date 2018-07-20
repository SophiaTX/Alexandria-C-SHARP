using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receiver
{
    /// <summary>
    /// the price feed quote object
    /// </summary>
    public class PrizeFeedQuote
    {
        /// <summary>
        /// the base price
        /// </summary>
        
        public string @base { get; set; }

        /// <summary>
        /// the quote price
        /// </summary>
       
        public string quote { get; set; }
    }
}