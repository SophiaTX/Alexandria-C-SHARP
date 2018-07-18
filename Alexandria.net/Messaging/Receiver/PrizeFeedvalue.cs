using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receiver
{
    //todo - finalise object description 
    /// <summary>
    /// Prize feed value class
    /// </summary>
    public class PrizeFeedvalue
    {
        /// <summary>
        /// value of the prize feed
        /// </summary>
        [JsonProperty("")]
        public ulong value { get; set; }
        
    }
}