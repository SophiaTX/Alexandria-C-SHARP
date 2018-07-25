using Alexandria.net.Helpers;

namespace Alexandria.net.Enums
{
    /// <summary>
    /// Types of errors 
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// Debug error message
        /// </summary>
        [StringValue("Debug")]
        Debug,
        /// <summary>
        /// Short error message
        /// </summary>
        [StringValue("Error")]
        Error,
        /// <summary>
        /// Warnings error message
        /// </summary>
        [StringValue("Warning")]
        Warning,
        /// <summary>
        /// Verbose error message
        /// </summary>
        [StringValue("Verbose")]
        Verbose
    }
}