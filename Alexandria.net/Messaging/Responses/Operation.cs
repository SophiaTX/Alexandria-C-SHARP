using System;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// Operation response in the Transaction Data
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// The operation name 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// the operation json data body
        /// </summary>
        public JObject Response { get; set; }
    }
}