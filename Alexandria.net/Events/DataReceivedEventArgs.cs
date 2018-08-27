using System;
using Alexandria.net.Messaging.Responses;

namespace Alexandria.net.Events
{
    public class DataReceivedEventArgs : EventArgs
    {
        public DataReceivedEventArgs(ReceivedDocumentResponse message)
        {
            Message = message;
        }

        public ReceivedDocumentResponse Message { get; set; }
    }
}