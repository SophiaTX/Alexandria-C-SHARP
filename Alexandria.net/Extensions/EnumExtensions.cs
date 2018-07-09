using System;
using Alexandria.net.Helpers;

namespace Alexandria.net.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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