using System;

namespace Alexandria.net.API
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageWrapper
    {
        public enum message_type{
            group_operation = 0,
            message = 1
        };

         public message_type type = message_type.group_operation;
         public string message_data;
         public GroupOp  operation_data;
    }
}