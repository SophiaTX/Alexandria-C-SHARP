using System;
using Alexandria.net.Enums;

namespace Alexandria.net.Settings
{
    /// <summary>
    /// The blockchain configuration for searching
    /// </summary>
    //todo - check whether this can be finally removed 
    public class BlockchainConfig : IBlockchainConfig
    {
        /// <summary>
        /// the ISO Time Stamp for searching 
        /// </summary>
        public DateTime IsoTimeStamp { get; set; }
        /// <summary>
        /// The type of Search to be performed
        /// </summary>
        public SearchType SearchType { get; set; }
        /// <summary>
        /// The account owner for searching
        /// </summary>
        public AccountOwner Account { get; set; }
        /// <summary>
        /// The type to start up
        /// </summary>
        public StartBy Start { get; set; }
        /// <summary>
        /// the index for searching
        /// </summary>
        public uint Index { get; set; }
    }
}