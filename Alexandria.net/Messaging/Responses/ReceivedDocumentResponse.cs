﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the reponse for received documents
    /// </summary>
    public class ReceivedDocumentResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// the received documents response
        /// </summary>
        [JsonProperty("result")]
        public List<List<object>> Result { get; set; }
//        public List<List<object>> Result
//        {
//            get=>Result; 
//            set=>SimplifiedData(Result);
//        }

//        private void SimplifiedData(List<List<object>> result)
//        {
//            foreach (var r in result)
//            {
////                if (int.TryParse())
////                {
////                    
////                }
//            }
//        }
   }
}