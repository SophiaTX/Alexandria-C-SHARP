using System;
using Alexandria.net.Messaging.Receiver;

namespace Alexandria.net.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// filter json requests
        /// </summary>
        /// <param name="value">json input</param>
        /// <param name="type">type of operartion</param>
        /// <returns>json object</returns>
        public static string GetJsonString(this string value, Type type)
        {
            if (type == null)
                return value;

            return type == typeof(PrizeFeedQuoteMessage)
                ? value.Replace("{\"Currency\":", "").Replace("\"PrizeFeedQuote\":", "").Replace("SPHTX\"}", "SPHTX\"")
                : value;
        }
    }
}