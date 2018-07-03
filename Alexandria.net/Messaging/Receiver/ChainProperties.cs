using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Receiver
{
    /// <summary>
    /// This fee, paid in SOPHIATX, is converted into VESTING SHARES for the new account. Accounts
    /// without vesting shares cannot earn usage rations and therefore are powerless. This minimum
    /// fee requires all accounts to have some kind of commitment to the network that includes the
    /// ability to vote and make transactions
    /// </summary>
    public class ChainProperties
    {

        /// <summary>
        /// 
        /// </summary>
//        public AssetType AccountCreationFee { get; set; } // = asset(SOPHIATX_MIN_ACCOUNT_CREATION_FEE, SOPHIATX_SYMBOL);
//
//        public uint MaximumBlockSize { get; set; }
//        public Tuple<AssetType> PriceFeeds { get; set; }
        public string account_creation_fee { get; set; }
        public int maximum_block_size { get; set; }
        public List<object> price_feeds { get; set; }
    }

   

    
}