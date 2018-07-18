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
        /// IsoTimeStamp
        /// </summary>
        public DateTime IsoTimeStamp { get; set; }
        /// <summary>
        /// SearchType
        /// </summary>
        public SearchType SearchType { get; set; }
        /// <summary>
        /// Account
        /// </summary>
        public AccountOwner Account { get; set; }
        /// <summary>
        /// Start
        /// </summary>
        public StartBy Start { get; set; }
        /// <summary>
        /// Index
        /// </summary>
        public uint Index { get; set; }
    }
}