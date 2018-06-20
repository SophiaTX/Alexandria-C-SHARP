using Alexandria.net.API.WalletFunctions;

namespace Alexandria.net.Enums
{
    /// <summary>
    /// Search Type for receiving data from the Blockchain
    /// </summary>
    public enum SearchType
    {
        /// <summary>
        /// Search by Sender
        /// </summary>
        [StringValue("by_sender")]
        BySender = 0,
        /// <summary>
        /// Search by Recipient
        /// </summary>
        [StringValue("by_recipient")]
        ByRecipient = 1, 
        /// <summary>
        /// Search by Sender DateTime (UTC)
        /// </summary>
        [StringValue("by_sender_datetime")]
        BySenderDatetime = 2, 
        /// <summary>
        /// Search by Receipient DateTime (UTC)
        /// </summary>
        [StringValue("by_recipient_datetime")]
        ByRecipientDatetime = 3
    }

    // Account is then either sender or recevier, and start is either index od ISO time stamp.
}