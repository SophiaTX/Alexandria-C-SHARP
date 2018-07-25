using Alexandria.net.Enums;

namespace Alexandria.net.Logging
{
    /// <summary>
    /// Logger Interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Closes the logger connection
        /// </summary>
        void Close();
        /// <summary>
        /// Writes the data to the log
        /// </summary>
        /// <param name="data">the data to write</param>
        /// <param name="errortype">the severity of the log item</param>
        void Write(string data, ErrorType errortype);
        /// <summary>
        /// Writes an error to the log
        /// </summary>
        /// <param name="data">the data to write</param>
        void WriteError(string data);
        /// <summary>
        /// writes a warning to the log
        /// </summary>
        /// <param name="data">the data to write</param>
        void WriteWarning(string data);
        /// <summary>
        /// writes the information to the log
        /// </summary>
        /// <param name="data">the data to write</param>
        void WriteInfo(string data);
        /// <summary>
        /// writes the test data to the sophia test analysis server
        /// </summary>
        /// <param name="data">the data to write</param>
        void WriteTestData(string data);
        /// <summary>
        /// the build mode to use: Production or Test
        /// </summary>
        BuildMode BuildMode { get; set; }
        
    }
}