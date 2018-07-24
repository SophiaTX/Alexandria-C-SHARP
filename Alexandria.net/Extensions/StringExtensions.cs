using System;
using Alexandria.net.Messaging.Receiver;

namespace Alexandria.net.Extensions
{
    public static class StringExtensions
    {
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