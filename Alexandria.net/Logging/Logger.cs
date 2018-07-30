using System;
using Alexandria.net.Enums;
using Alexandria.net.Settings;
using Serilog;
using Serilog.Formatting.Compact;

namespace Alexandria.net.Logging
{
    /// <summary>
    /// The logger object
    /// </summary>
    public class Logger :ILogger
    {
        /// <summary>
        /// the build mode to use: Production or Test
        /// </summary>
        public BuildMode BuildMode { get; set; }

        private readonly IConfig _config;

        /// <summary>
        /// the Logger constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="loggingtype">the type of logging: file or server</param>
        /// <param name="appname">the name of the calling application</param>
        /// <param name="mode">the buildmode: Prod or Testr</param>
        public Logger(IConfig config, LoggingType loggingtype, string appname, BuildMode mode = BuildMode.Prod)
        {
            _config = config;
            switch (loggingtype)
            {
                case LoggingType.File:
                    CreateLoggerCJson(appname);
                    break;
                case LoggingType.Server:
                    CreateLoggerToServer(appname);
                    break;
            }

            BuildMode = mode;
        }


        private void CreateLoggerCJson(string appname)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .Enrich.WithProperty("Application", appname)
                    .WriteTo.File(new CompactJsonFormatter(), $"{appname}.clef")
                    .CreateLogger();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void CreateLoggerToServer(string appname)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .Enrich.WithProperty("Application", appname)
                    .WriteTo.Seq(_config.LoggingServer)
                    .CreateLogger();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Closes the logger connection
        /// </summary>
        public void Close()
        {
            Log.CloseAndFlush();
        }

        /// <summary>
        /// Writes an error to the log
        /// </summary>
        /// <param name="data">the data to write</param>
        public void WriteError(string data)
        {
            Write(data, ErrorType.Error);
        }

        /// <summary>
        /// writes a warning to the log
        /// </summary>
        /// <param name="data">the data to write</param>
        public void WriteWarning(string data)
        {
            Write(data, ErrorType.Warning);
        }

        /// <summary>
        /// writes the information to the log
        /// </summary>
        /// <param name="data">the data to write</param>
        public void WriteInfo(string data)
        {
            Write(data, ErrorType.Debug);
        }

        /// <summary>
        /// writes the test data to the sophia test analysis server
        /// </summary>
        /// <param name="data">the data to write</param>
        public void WriteTestData(string data)
        {
            Write(data, ErrorType.Verbose);
        }

        /// <summary>
        /// Writes the data to the log
        /// </summary>
        /// <param name="data">the data to write</param>
        /// <param name="errortype">the severity of the log item</param>
        public void Write(string data, ErrorType errortype)
        {
            switch (BuildMode)
            {
                case BuildMode.Test:
                    switch (errortype)
                    {
                        case ErrorType.Debug:
                            Log.Debug(data);
                            break;
                        case ErrorType.Error:
                            Log.Error(data);
                            break;
                        case ErrorType.Warning:
                            Log.Warning(data);
                            break;
                        case ErrorType.Verbose:
                            Log.Verbose(data);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(errortype), errortype, null);
                    }
                    break;
                
                case BuildMode.Prod:
                    switch (errortype)
                    {
                        case ErrorType.Debug:
                            Log.Debug(data);
                            break;
                        case ErrorType.Error:
                            Log.Error(data);
                            break;
                        case ErrorType.Warning:
                            Log.Warning(data);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(errortype), errortype, null);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}