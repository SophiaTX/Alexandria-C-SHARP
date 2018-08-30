using System.Collections;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// Operation Collection for the operations contained in the Transaction Data
    /// </summary>
    public class OperationCollection : IEnumerable
    {
        /// <summary>
        /// The list of operations
        /// </summary>
        public List<Operation> Operations { get; set; }
        
        /// <summary>
        /// Allow enumeration of the list of operations
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var element in Operations)
                yield return element;
        }
    }
}