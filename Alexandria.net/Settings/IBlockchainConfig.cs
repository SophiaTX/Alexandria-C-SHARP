using System;
using Alexandria.net.Enums;

namespace Alexandria.net.Settings
{
    /// <summary>
    /// IBlockchainConfig
    /// </summary>
    public interface IBlockchainConfig
    {
        /// <summary>
        /// IsoTimeStamp
        /// </summary>
        DateTime IsoTimeStamp { get; set; }
        /// <summary>
        /// SearchType
        /// </summary>
        SearchType SearchType { get; set; }
        /// <summary>
        /// Account
        /// </summary>
        AccountOwner Account { get; set; }
        /// <summary>
        /// Start
        /// </summary>
        StartBy Start { get; set; }
        /// <summary>
        /// Index
        /// </summary>
        uint Index { get; set; }
        
    }
}