using System;
using Alexandria.net.Helpers;

namespace Alexandria.net.Extensions
{
    /// <summary>
    /// enumerator extensions
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// gets the enum as a string value
        /// </summary>
        /// <param name="value">the name of the enum, value</param>
        /// <returns>the string value of the enum</returns>
        public static string GetStringValue(this Enum value)
        {
            string output = null;
            var type = value.GetType();

            var field = type.GetField(value.ToString());
            if (field.GetCustomAttributes(typeof(StringValueAttribute),
                    false) is StringValueAttribute[] attrs && attrs.Length > 0)
                output = attrs[0].Value;

            return output;
        }
    }
}