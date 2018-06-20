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
        SignAndSend,
        /// <summary>
        /// this sends multiple documents
        /// </summary>
        MakeSignAndSend,
        /// <summary>
        /// this sends multiple document with digest
        /// </summary>
        MakeDigestSignAndSend
    }
}