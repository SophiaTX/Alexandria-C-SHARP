using System;

namespace Alexandria.net.API.WalletFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public class StringValueAttribute : Attribute
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; }
    }
}