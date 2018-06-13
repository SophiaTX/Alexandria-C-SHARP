using System.Collections.Generic;

namespace Alexandria.net.API.WalletFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public class Authority
    {
        public uint weight_threshold { get; set; }
        public Dictionary<string, ushort> account_auths { get; set; }       
        public Dictionary<char[], ushort> key_auths { get; set; }   
    }
}