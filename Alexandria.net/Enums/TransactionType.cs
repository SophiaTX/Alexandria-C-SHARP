using Alexandria.net.Helpers;

namespace Alexandria.net.Enums
{
    /// <summary>
    /// the transaction method type you would like use
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// this sends a single document
        /// </summary>
        [StringValue("SignAndSend")]
        SignAndSend,
        /// <summary>
        /// this sends multiple documents
        /// </summary>
        [StringValue("MakeSignAndSend")]
        MakeSignAndSend,
        /// <summary>
        /// this sends multiple document with digest
        /// </summary>
        [StringValue("MakeDigestSignAndSend")]
        MakeDigestSignAndSend
    }
}