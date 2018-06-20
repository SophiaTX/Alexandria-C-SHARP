using System;
using Alexandria.net.API.WalletFunctions;

namespace Alexandria.net.Extensions
{
    public static class EnumExtensions
    {
        public static string GetStringValue(this Enum value)
        {
            string output = null;
            var type = value.GetType();

            var field = type.GetField(value.ToString());
            var attrs = field.GetCustomAttributes(typeof(StringValueAttribute),
                    false) as StringValueAttribute[];
            if (attrs.Length > 0)
                output = attrs[0].Value;

            return output;
        }
    }
}