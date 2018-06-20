using System;
using Alexandria.net.Enums;

namespace Alexandria.net.Settings
{
    public class BlockchainConfig : IBlockchainConfig
    {
        public DateTime IsoTimeStamp { get; set; }
        public SearchType SearchType { get; set; }
        public AccountOwner Account { get; set; }
        public StartBy Start { get; set; }
        public uint Index { get; set; }
    }
}