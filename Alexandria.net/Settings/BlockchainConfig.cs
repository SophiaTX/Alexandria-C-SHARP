using System;
using Alexandria.net.Enums;

namespace Alexandria.net.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public class BlockchainConfig : IBlockchainConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime IsoTimeStamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SearchType SearchType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AccountOwner Account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public StartBy Start { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint Index { get; set; }
    }
}