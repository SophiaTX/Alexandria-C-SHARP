using Alexandria.net.Helpers;

namespace Alexandria.net.Logging
{
    /// <summary>
    /// Type which will be used when writing to logs
    /// </summary>
    public enum LoggingType
    {
        /// <summary>
        /// Writes to a clef file
        /// </summary>
        [StringValue("File")]
        File,
        /// <summary>
        /// Writes to the sophia server
        /// </summary>
        [StringValue("Server")]
        Server
    };
}