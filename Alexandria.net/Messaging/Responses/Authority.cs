using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class Authority
    {
        /// <summary>
        /// 
        /// </summary>
        public uint WeightThreshold { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, ushort> AccountAuths { get; set; }       
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<char[], ushort> KeyAuths { get; set; }   
    }
}