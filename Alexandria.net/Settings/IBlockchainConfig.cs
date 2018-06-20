using System;
using Alexandria.net.Enums;

namespace Alexandria.net.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBlockchainConfig
    {
        /// <summary>
        /// 
        /// </summary>
        DateTime IsoTimeStamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        SearchType SearchType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        AccountOwner Account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        StartBy Start { get; set; }
        /// <summary>
        /// 
        /// </summary>
        uint Index { get; set; }
        
    }
}