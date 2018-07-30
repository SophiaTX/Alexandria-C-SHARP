using Alexandria.net.Helpers;

namespace Alexandria.net.Enums
{
    /// <summary>
    /// The Account Owner information
    /// </summary>
    public enum AccountOwner
    {
        /// <summary>
        /// the account sender 
        /// </summary>
        [StringValue("sender")]
        Sender = 0,
        /// <summary>
        /// the account receiver
        /// </summary>
        [StringValue("recevier")]
        Receiver
    }
}