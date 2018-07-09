using Alexandria.net.Helpers;

namespace Alexandria.net.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum StartBy
    {
        /// <summary>
        /// Search by Sender
        /// </summary>
        [StringValue("index")]
        Index = 0,
        /// <summary>
        /// Search by Recipient
        /// </summary>
        [StringValue("ISO")]
        IsoTimeStamp = 1
    }
}