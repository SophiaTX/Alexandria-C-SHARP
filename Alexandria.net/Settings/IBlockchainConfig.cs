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
        /// the ISO Time Stamp for searching 
        /// </summary>
        DateTime IsoTimeStamp { get; set; }
        /// <summary>
        /// The type of Search to be performed
        /// </summary>
        SearchType SearchType { get; set; }
        /// <summary>
        /// The account owner for searching
        /// </summary>
        AccountOwner Account { get; set; }
        /// <summary>
        /// The type to start up
        /// </summary>
        StartBy Start { get; set; }
        /// <summary>
        /// the index for searching
        /// </summary>
        uint Index { get; set; }
    }
}