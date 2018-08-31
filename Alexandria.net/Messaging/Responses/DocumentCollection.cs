using System.Collections;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses
{
    public class DocumentCollection:IEnumerable
    {
        public List<ArrayResponse> Documents { get; set; }
        
        public IEnumerator GetEnumerator()
        {
            foreach (var element in Documents)
                yield return element;
        }
    }
}