using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the reponse for received documents
    /// </summary>
    /// 
    public class ReceivedDocumentResponse
    {
        private List<List<Object>> _unstructedoperations;
        private DocumentCollection _operations;
        
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// the received documents response
        /// </summary>
        [JsonProperty("result")]
        public List<List<object>> Result
        {
            get=>_unstructedoperations; 
            set=>SimplifiedData(value);
        }

        /// <summary>
        /// Received documents
        /// </summary>
        public DocumentCollection ReceivedDocumentCollection
        {
            get => _operations;
            set => _operations = value;
        }
        
        private void SimplifiedData(object value)
        {
            var docs = (List<List<object>>) value;
            var doclist=new List<ArrayResponse>();
            
                

                foreach (var pages in docs)
                { var op = new ArrayResponse();
                    op.Id = (long) pages[0];
                    op.Result = JsonConvert.DeserializeObject<ReceiveDocResultData>(pages[1].ToString());
                    doclist.Add(op);
                }
            _operations= new DocumentCollection {Documents = doclist};
            _unstructedoperations = docs;

        }
    }
}