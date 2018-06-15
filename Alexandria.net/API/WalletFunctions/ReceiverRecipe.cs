using System.Collections.Generic;

namespace Alexandria.net.API.WalletFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceiverRecipe
    {
        /// <summary>
        /// 
        /// </summary>
        public ulong AppId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Recipients { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Binary { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Document { get; set; }
    }
}