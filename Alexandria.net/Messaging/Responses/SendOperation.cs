using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses
{
    
        /// <summary>
        /// 
        /// </summary>
        public class SendOperation
        {
            /// <summary>
            /// 
            /// </summary>
            public string Fee { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Sender { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> Recipients { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int AppId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Json { get; set; }
        }
    
}