using System;

namespace Alexandria.net.Helpers
{
    /// <summary>
    /// the string attributes
    /// </summary>
    public class StringValueAttribute : Attribute
    {
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// the value sent into the constructor
        /// </summary>
        public string Value { get; }
    }
}