namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class SignedTransactionResponse
    {
        /// <summary>
        /// Response id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Signed Transaction Response 
        /// </summary>
        public SignedTransactionResponseData result { get; set; }
    }
}