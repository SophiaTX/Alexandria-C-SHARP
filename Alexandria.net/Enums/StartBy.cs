using Alexandria.net.Helpers;

namespace Alexandria.net.Enums
{
    /// <summary>
    /// The start by search type
    /// </summary>
    public enum StartBy
    {
        /// <summary>
        /// start by index
        /// </summary>
        [StringValue("index")]
        Index = 0,
        /// <summary>
        /// start by time stamp
        /// </summary>
        [StringValue("ISO")]
        IsoTimeStamp = 1
    }
}