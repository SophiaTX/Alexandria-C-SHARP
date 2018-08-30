using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The Transaction Data body response from the blockchain transaction
    /// </summary>
    public class TransactionData
    {

        private List<List<Object>> _unstructedoperations;
        private OperationCollection _operations;
        
        
        /// <summary>
        /// the block number
        /// </summary>
        [JsonProperty("ref_block_num")]
        public int RefBlockNum { get; set; }
        /// <summary>
        /// the prefix of the block
        /// </summary>
        [JsonProperty("ref_block_prefix")]
        public long RefBlockPrefix { get; set; }
        /// <summary>
        /// the expiration date and time of the transaction
        /// </summary>
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        /// <summary>
        /// the list of the operations asscoiated with the transaction
        /// </summary>
        [JsonProperty("operations")]
        private List<List<object>> UnstructedOperations
        {
            get => _unstructedoperations;
            set => SetOperations(value);
        }
        
        public OperationCollection Operations
        {
            get => _operations;
            set => _operations = value;
        }
        /// <summary>
        /// the extensions associated with the transaction
        /// </summary>
        [JsonProperty("extensions")]
        public List<object> Extensions { get; set; }
        /// <summary>
        /// the list of the signatures assigned to the trabnsaction
        /// </summary>
        [JsonProperty("signatures")]
        public List<string> Signatures { get; set; }
        /// <summary>
        /// the identification number of the transaction
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// the block number the transaction was added to
        /// </summary>
        [JsonProperty("block_num")]
        public int BlockNum { get; set; }
        /// <summary>
        /// The transaction number in the blockchain
        /// </summary>
        [JsonProperty("transaction_num")]
        public int TransactionNum { get; set; }



        private void SetOperations(object value)
        {
            var ops = (List<List<object>>) value;
            var index = 0;
            foreach (var operations in ops)
            {
                var op = new Operation();
                foreach (var operation in operations)
                {
                    if (index == 0)
                        op.Name = operation.ToString();
                    else
                        op.Response = (JObject) operation;
                    index++;
                }
                _operations = new OperationCollection {Operations = new List<Operation> {op}};
                _unstructedoperations = ops;
            }
        }
    }
}